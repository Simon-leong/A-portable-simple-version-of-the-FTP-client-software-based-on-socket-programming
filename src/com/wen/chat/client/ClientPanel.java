package com.wen.chat.client;

import com.wen.chat.util.ClientBase;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.net.Socket;

import static java.awt.Color.*;

public class ClientPanel extends JPanel {

    private ClientBase clientBase = null;

    public ClientPanel() {

    }

    public void panel() {

        setBounds(30, 30, 590, 410);

//        setBackground(LIGHT_GRAY);
        setFocusable(true);//设置获取焦点
        setLayout(null);//布局自定义

        /*lab_ip*/
        JLabel lab_ip = new JLabel("IP:");
        lab_ip.setBounds(10, 10, 50, 30);
        lab_ip.setFont(new Font("宋体", Font.BOLD, 20));//字体样式
        lab_ip.setForeground(BLUE);//标签字体前景色
        /*ip框*/
        JTextField ip = new JTextField(20);
        ip.setBounds(60, 10, 180, 30);
        ip.setFont(new Font("微软雅黑", Font.BOLD, 20));
        /*端口*/
        JLabel lab_port = new JLabel("端口:");
        lab_port.setBounds(240, 10, 80, 30);
        lab_port.setFont(new Font("宋体", Font.BOLD, 20));//字体样式
        lab_port.setForeground(BLUE);//标签字体前景色
        /*端口框*/
        JTextField port = new JTextField(10);
        port.setBounds(320, 10, 100, 30);
        port.setFont(new Font("微软雅黑", Font.BOLD, 20));
        /*连接按钮*/
        JButton connection = new JButton("连接");
        connection.setBounds(450, 10, 100, 30);
        connection.setBackground(green);
        /*状态标签*/
        JLabel flag = new JLabel("");
        flag.setBounds(230, 30, 100, 35);
        /*接收框*/
        TextArea textRec = new TextArea("");
        textRec.setBounds(90, 70, 400, 180);
        textRec.setFont(new Font("微软雅黑", Font.PLAIN, 20));
        /*输入框*/
        TextArea textSend = new TextArea(1, 10);
        textSend.setColumns(20);
        textSend.setBounds(90, 260, 400, 70);
        textSend.setFont(new Font("微软雅黑", Font.ITALIC, 20));
        textSend.setBackground(pink);
        /*重输按钮*/
        JButton btn_cl = new JButton("清空");
        btn_cl.setBounds(40, 350, 100, 40);
        btn_cl.setBackground(pink);
        /*发送按钮*/
        JButton btn_en = new JButton("发送");
        btn_en.setBounds(440, 350, 100, 40);
        btn_en.setBackground(pink);
        /*在线人数lab*/
        JLabel jLabel = new JLabel("在线人数:");
        jLabel.setBounds(0, 70, 90, 35);
        jLabel.setFont(new Font("微软雅黑", Font.PLAIN, 20));
        /*人数*/
        JLabel online = new JLabel("");
        online.setBounds(30, 120, 100, 18);
        online.setFont(new Font("微软雅黑", Font.PLAIN, 18));
        online.setText("");

        add(lab_ip);
        add(ip);
        add(lab_port);
        add(port);
        add(connection);
        add(flag);
        add(textRec);
        add(textSend);
        add(btn_cl);
        add(btn_en);
//        add(jLabel);
//        add(online);

        //连接事件监听
        connection.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    clientBase = new ClientBase(ip.getText(), Integer.parseInt(port.getText()));
                } catch (IOException ioException) {
                    flag.setText("未连接");
                    flag.setForeground(red);
                }
                Socket socket = clientBase.getSocket();
                if (flag.getText().equals("已连接") && clientBase != null) {

                } else if (socket != null){
                    try {
                        flag.setText("已连接");
                        flag.setForeground(green);
                        //接收线程
                        new Thread(new Runnable() {
                            private boolean f = true;//线程标志位

                            @Override
                            public void run() {
                                //接收消息
                                while (f) {
                                    try {
                                        String text = clientBase.receiveTest();
                                        //判断转回的消息是不是自己的
                                        String temp = text.substring(0, 3);//截取前三位字符，注意不包括3  [0,3)
                                        //是否以len开始
                                        if (text.startsWith("len")) {
                                            textRec.setForeground(blue);
                                            //追加收到内容
                                            textRec.append(text.substring(3));//截取第三个到末尾的字符串

                                        } else {
                                            textRec.setForeground(black);
                                            textRec.append(text);
                                        }
                                    } catch (IOException ioException) {
                                        flag.setText("连接重置");
                                        flag.setForeground(red);
                                        f = false;
                                        ioException.printStackTrace();
                                        clientBase.closeable(clientBase.getIn());
                                    }
                                }
                            }
                        }).start();
                    } catch (Exception exception) {
                        exception.printStackTrace();
                        flag.setText("未连接");
                        flag.setForeground(red);
                        System.out.println("catch..");
                    }
                }
            }
        });

        //发送事件监听
        btn_en.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                flagTrue(flag, textSend);
            }
        });

        //回车监听
     /*   textSend.addKeyListener(new KeyAdapter() {
            @Override
            public void keyTyped(KeyEvent e) {
                if (e.getKeyChar() == KeyEvent.VK_ENTER) {
                    if (textSend.getText().hashCode() != 413 && textSend.getText().length() != 0) {
                        flagTrue(flag, textSend);
                    }
                }
            }
        });*/

        //重输事件
        btn_cl.addActionListener(e -> {
            textRec.setText("");
            textSend.setText("");
        });


    }

    private void flagTrue(JLabel flag, TextArea textSend) {
        if (flag.getText().equals("已连接")) {
            try {
                clientBase.sendTest(textSend.getText());
            } catch (IOException ioException) {
                ioException.printStackTrace();
                //关闭资源
                clientBase.closeable(clientBase.getOut());
            }
            textSend.setText("");
        } else {
            flag.setText("未连接");
            flag.setForeground(red);
        }
    }

}

