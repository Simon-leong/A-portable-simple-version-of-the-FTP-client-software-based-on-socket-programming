package com.wen.chat.util;

import java.io.Closeable;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;

public class ClientBase {
    private String ip;
    private int port;

    Socket socket = null;
    OutputStream outputStream = null;
    InputStream inputStream = null;
    String string = null;

    public ClientBase(String ip, int port) throws IOException {
//        socket = new Socket(ip, port);
//        socket.setSoTimeout(5000);
        //设置超时时间5秒
        socket = new Socket();
        socket.connect(new InetSocketAddress(ip, port), 5000);
    }

    /**
     * 发送方法
     */
    public void sendTest(String msg) throws IOException {
        //获取 字节输出流
        if (msg.length() != 0) {
            outputStream = socket.getOutputStream();
            outputStream.write(msg.getBytes("UTF-8"));
        }
    }

    /**
     * 接收方法
     *
     * @return 接收内容
     */
    public String receiveTest() throws IOException {
        //获取服务器回应消息
        inputStream = socket.getInputStream();
        byte[] bytes = new byte[1024];
        int len = inputStream.read(bytes);
        try {
            string = new String(bytes, 0, len, "UTF-8");
        } catch (IOException e) {
            System.out.println("error");
        }
        return string;
    }

    /*接收在线人数*/
    public String onLine() {
        String str = "";
        InputStream inputStream = null;
        try {
            inputStream = socket.getInputStream();
            byte[] bytes = new byte[1024];
            int len = inputStream.read(bytes);
            str = new String(bytes, 0, len);
        } catch (IOException e) {
            e.printStackTrace();
            try {
                inputStream.close();
            } catch (IOException ioException) {
                ioException.printStackTrace();
            }
        }
        return str;
    }

    //可变参数关闭流
    public void closeable(Closeable... args) {
        try {
            if (outputStream != null) {
                outputStream.close();
            }
            if (inputStream != null) {
                inputStream.close();
            }
            if (socket != null) {
                socket.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public String getIp() {
        return ip;
    }

    public int getPort() {
        return port;
    }

    public Socket getSocket() {
        return socket;
    }

    public OutputStream getOut() {
        return outputStream;
    }

    public InputStream getIn() {
        return inputStream;
    }

    public String getString() {
        return string;
    }
}
