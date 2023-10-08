using System;
using System.IO;
// 添加命令空间
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        private const int ftpport = 21;
        private string ftpUristring = null;
        private NetworkCredential networkCredential;
        private string currentDir = "/";
        public Form1()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses("");
            tbxServerIp.Text = ips[4].ToString();
            tbxServerIp.SelectAll();
            lstbxFtpResources.Enabled = false;
            lstbxFtpState.Enabled = false;
            btnUpload.Enabled = false;
            btndownload.Enabled = false;
            btnDelete.Enabled = false;
        }

        #region 键盘按下事件

        private void tbxServerIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 输入用户名回车后，焦点直接转到密码文本框
            if (e.KeyChar == (char)13)
            {
                tbxUsername.Focus();
            }
        }

        private void tbxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 输入用户名回车后，焦点直接转到密码文本框
            if (e.KeyChar == (char)13)
            {
                tbxPassword.Focus();
            }
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 输入密码回车后直接可以登录
            if (e.KeyChar == (char)13)
            {
                btnlogin.Focus();
            }
        }
        #endregion

        // 匿名复选框Click事件
        private void chkbxAnonymous_Click(object sender, EventArgs e)
        {
            // 实名方式登录
            // 此时需要输入用户名和密码
            if (chkbxAnonymous.Checked == false)
            {
                tbxUsername.Enabled = true;
                tbxUsername.Text = "user1";
                tbxPassword.Enabled = true;
                tbxPassword.Text = "";
                tbxUsername.Focus();
            }
            // 匿名方式
            else
            {
                tbxUsername.Text = "anonymous";
                tbxUsername.Enabled = false;
                tbxPassword.Text = "";
                tbxPassword.Enabled = false;
            }
        }


        #region 与服务器的交互
        
        // 创建FTP连接
        private FtpWebRequest CreateFtpWebRequest(string uri, string requestMethod)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
            request.Credentials = networkCredential;
            request.KeepAlive = true;
            request.UseBinary = true;
            request.Method = requestMethod;
            return request;
        }

        // 获取服务器返回的响应体
        private FtpWebResponse GetFtpResponse(FtpWebRequest request)
        {
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)request.GetResponse();
                lstbxFtpState.Items.Add("验证完毕，服务器回应信息：[" + response.WelcomeMessage + "]");
                lstbxFtpState.Items.Add("正在连接：[ " + response.BannerMessage + "]");
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                return response;
            }
            catch(WebException ex)
            {
                lstbxFtpState.Items.Add("发送错误。返回信息为：" + ex.Status);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                return null;
            }
        }
        #endregion 

        #region 登录模块的实现
        // 登录服务器事件
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (tbxServerIp.Text == string.Empty)
            {
                MessageBox.Show("请先填写服务器IP地址", "提示");
                return;
            }

            ftpUristring = "ftp://" + tbxServerIp.Text;
            networkCredential = new NetworkCredential(tbxUsername.Text, tbxPassword.Text);
            if (ShowFtpFileAndDirectory() == true)
            {
                btnlogin.Enabled = false;
                lstbxFtpResources.Enabled = true;
                lstbxFtpState.Enabled = true;
                tbxServerIp.Enabled = false;
                if (chkbxAnonymous.Checked == false)
                {
                    tbxUsername.Enabled = false;
                    tbxPassword.Enabled = false;
                    chkbxAnonymous.Enabled = false;
                }
                else
                {
                    chkbxAnonymous.Enabled = false;
                }

                tbxloginmessage.Text = "登录成功!";
                btnUpload.Enabled = true;
                btndownload.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                lstbxFtpState.Enabled = true;
                tbxloginmessage.Text = "登陆失败";
            }
        }

        // 显示资源列表
        private bool ShowFtpFileAndDirectory()
        {
            lstbxFtpResources.Items.Clear();
            string uri = string.Empty;
            if (currentDir == "/")
            {
                uri = ftpUristring;
            }
            else
            {
                uri = ftpUristring + currentDir;
            }

            string[] urifield = uri.Split(' ');
            uri = urifield[0];
            FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.ListDirectoryDetails);
            
            // 获得服务器返回的响应信息
            FtpWebResponse response = GetFtpResponse(request);
            if (response == null)
            {
                return false;
            }
            lstbxFtpState.Items.Add("连接成功，服务器返回的是："+response.StatusCode+" "+response.StatusDescription);

            // 读取网络流数据
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream,Encoding.Default);
            lstbxFtpState.Items.Add("获取响应流....");
            string s = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            response.Close();
            lstbxFtpState.Items.Add("传输完成");
            
            // 处理并显示文件目录列表
            string[] ftpdir = s.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            lstbxFtpResources.Items.Add("↑返回上层目录");
            int length = 0;
            for (int i = 0; i < ftpdir.Length; i++)
            {
                if (ftpdir[i].EndsWith("."))
                {
                    length = ftpdir[i].Length - 2;
                    break;
                }
            }

            for (int i = 0; i < ftpdir.Length; i++)
            {
                s = ftpdir[i];
                int index = s.LastIndexOf('\t');
                if (index == -1)
                {
                    if (length < s.Length)
                    {
                        index = length;
                    }
                    else
                    {
                        continue;
                    }
                }

                string name = s.Substring(index + 1);
                if (name == "." || name == "..")
                {
                    continue;
                }

                // 判断是否为目录，在名称前加"目录"来表示
                if (s[0] == 'd' || (s.ToLower()).Contains("<dir>"))
                {
                    string[] namefield = name.Split(' ');
                    int namefieldlength = namefield.Length;
                    string dirname;                   
                    dirname = namefield[namefieldlength - 1];

                    // 对齐
                    dirname = dirname.PadRight(34,' ');
                    name = dirname;
                    // 显示目录
                    lstbxFtpResources.Items.Add("[目录]" + name);
                }
            }

            for (int i = 0; i < ftpdir.Length; i++)
            {
                s = ftpdir[i];
                int index = s.LastIndexOf('\t');
                if (index == -1)
                {
                    if (length < s.Length)
                    {
                        index = length;
                    }
                    else
                    {
                        continue;
                    }
                }

                string name = s.Substring(index + 1);
                if (name == "." || name == "..")
                {
                    continue;
                }

                // 判断是否为文件
                if (!(s[0] == 'd' || (s.ToLower()).Contains("<dir>")))
                {
                    string[] namefield = name.Split(' ');
                    int namefieldlength = namefield.Length;
                    string filename;
                 
                    filename = namefield[namefieldlength - 1];
                   
                    // 对齐
                    filename = filename.PadRight(34, ' ');           
                    name = filename;

                    // 显示文件
                    lstbxFtpResources.Items.Add(name);
                }
            }

            return true;
        }


        #region 对文件的操作模块实现
        // 上传文件到服务器事件
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // 选择要上传的文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = openFileDialog.FileNames.ToString();
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FileInfo fileinfo = new FileInfo(openFileDialog.FileName);
            try
            {
                string uri = GetUriString(fileinfo.Name);
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.UploadFile);
                request.ContentLength = fileinfo.Length;
                int buflength = 8196;
                byte[] buffer = new byte[buflength];
                FileStream filestream = fileinfo.OpenRead();
                Stream responseStream = request.GetRequestStream();
                lstbxFtpState.Items.Add("打开上传流，文件上传中...");
                int contenlength = filestream.Read(buffer, 0, buflength);
                while (contenlength != 0)
                {
                    responseStream.Write(buffer, 0, contenlength);
                    contenlength = filestream.Read(buffer, 0, buflength);
                }

                responseStream.Close();
                filestream.Close();
                FtpWebResponse response = GetFtpResponse(request);
                if (response == null)
                {
                    lstbxFtpState.Items.Add("服务器未响应...");
                    lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                    return;
                }

                lstbxFtpState.Items.Add("上传完毕，服务器返回：" + response.StatusCode + " " + response.StatusDescription);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                MessageBox.Show("上传成功！");

                // 上传成功后，立即刷新服务器目录列表
                ShowFtpFileAndDirectory();
            }
            catch (WebException ex)
            {
                lstbxFtpState.Items.Add("上传发生错误，返回信息为：" + ex.Status);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                MessageBox.Show(ex.Message, "上传失败");
            }
        }


        private string GetUriString(string filename)
        {
            string uri = string.Empty;
            if (currentDir.EndsWith("/"))
            {
                uri = ftpUristring + currentDir + filename;
            }
            else
            {
                uri = ftpUristring + currentDir + "/" + filename;
            }

            return uri;
        }

        // 从服务器上下载文件到本地事件
        private void btndownload_Click(object sender, EventArgs e)
        {
            string fileName = GetSelectedFile();
            if (fileName.Length == 0)
            {
                MessageBox.Show("请选择要下载的文件！","提示");
                return;
            }

            // 选择保存文件的位置
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "所有文件(*.*)|(*.*)";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = saveFileDialog.FileName;
            try
            {
                string uri = GetUriString(fileName);
                FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.DownloadFile);
                FtpWebResponse response = GetFtpResponse(request);
                if (response == null)
                {
                    lstbxFtpState.Items.Add("服务器未响应...");
                    lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                    return;
                }

                Stream responseStream = response.GetResponseStream();
                FileStream filestream = File.Create(filePath);
                int buflength = 8196;
                byte[] buffer = new byte[buflength];
                int bytesRead =1;
                lstbxFtpState.Items.Add("打开下载通道，文件下载中...");
                while (bytesRead != 0)
                {
                    bytesRead = responseStream.Read(buffer, 0, buflength);
                    filestream.Write(buffer, 0, bytesRead);
                }

                responseStream.Close();
                filestream.Close();
                lstbxFtpState.Items.Add("下载完毕，服务器返回：" + response.StatusCode + " " + response.StatusDescription);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                MessageBox.Show("下载完成！");
            }
            catch (WebException ex)
            {
                lstbxFtpState.Items.Add("发生错误，返回状态为：" + ex.Status);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                MessageBox.Show(ex.Message, "下载失败");
            }
        }

        // 获得选择的文件
        // 如果选择的是目录或者是返回上层目录，则返回null
        private string GetSelectedFile()
        {
            string filename = string.Empty;
            if (!(lstbxFtpResources.SelectedIndex == -1 || lstbxFtpResources.SelectedItem.ToString().Substring(0, 4) == "[目录]"))
            {
                string[] namefield = lstbxFtpResources.SelectedItem.ToString().Split(' ');
                filename = namefield[0];
            }
            return filename;

        }
        // 删除服务器文件事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string filename = GetSelectedFile();
            if (filename.Length == 0)
            {
                MessageBox.Show("请选择要删除的文件！", "提示");
                return;
            }

            try
            {
                string uri = GetUriString(filename);
                if (MessageBox.Show("确定要删除文件 " + filename + " 吗?", "确认文件删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FtpWebRequest request = CreateFtpWebRequest(uri, WebRequestMethods.Ftp.DeleteFile);
                    FtpWebResponse response = GetFtpResponse(request);
                    if (response == null)
                    {
                        lstbxFtpState.Items.Add("服务器未响应...");
                        lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                        return;
                    }

                    lstbxFtpState.Items.Add("文件删除成功，服务器返回：" + response.StatusCode + " " + response.StatusDescription);
                    ShowFtpFileAndDirectory();
                }
                else
                {
                    return;
                }
            }
            catch (WebException ex)
            {

                lstbxFtpState.Items.Add("发生错误，返回状态为：" + ex.Status);
                lstbxFtpState.TopIndex = lstbxFtpState.Items.Count - 1;
                MessageBox.Show(ex.Message, "删除失败");
            }
        }
        #endregion

        // 变更目录操作
        private void lstbxFtpResources_DoubleClick(object sender, EventArgs e)
        {
            // 点击返回上层目录
            if (lstbxFtpResources.SelectedIndex == 0)
            {
                if (currentDir == "/")
                {
                    MessageBox.Show("当前目录已经是顶层目录", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int index = currentDir.LastIndexOf("/");
                if (index == 0)
                {
                    currentDir = "/";
                }
                else
                {
                    currentDir = currentDir.Substring(0, index);
                }

                // 每次更改目录后立即刷新资源列表
                ShowFtpFileAndDirectory();
            }
            else
            {
                if (lstbxFtpResources.SelectedIndex > 0 && lstbxFtpResources.SelectedItem.ToString().Contains("[目录]"))
                {
                    if (currentDir == "/")
                    {
                        currentDir = "/" + lstbxFtpResources.SelectedItem.ToString().Substring(4);

                    }
                    else
                    {
                        currentDir = currentDir + "/" + lstbxFtpResources.SelectedItem.ToString().Substring(4);
                    }

                    string[] currentDirfield = currentDir.Split(' ');
                    currentDir = currentDirfield[0];
                    // 每次更改目录后立即刷新资源列表
                    ShowFtpFileAndDirectory();
                }
            }
        }

        private void tbxloginmessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxServerIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
#endregion