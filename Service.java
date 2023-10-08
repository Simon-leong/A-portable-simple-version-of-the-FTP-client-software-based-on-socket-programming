package com.wen.net.server;

import java.io.Closeable;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.util.List;

public class Service implements Runnable {

    Socket socket = null;
    InputStream inputStream = null;
    OutputStream outputStream = null;

    private boolean flag = true;

    public Service(Socket socket) {
        this.socket = socket;
    }

    public Service() {
    }

    @Override
    public void run() {

        while (flag) {
            try {
                //  1. 接受客户端消息
                String msg = this.receiveTest(socket);
                System.out.println("[-- " + msg + " --]");
                //转发其他客户端
                sendOther(socket, msg);

            } catch (Exception e) {
                e.printStackTrace();
                flag = false;
                ServerTest.list.remove(socket);
                System.out.println("当前客户端数" + ServerTest.list.size());
                //发送在线客户端数
                this.onLine();
            }
        }
    }

    //接收消息
    public String receiveTest(Socket socket) throws IOException {
        inputStream = socket.getInputStream();
        byte[] bytes = new byte[1024];
        int len = inputStream.read(bytes);
        return new String(bytes, 0, len);
    }

    //转发其他客户端方法
    public void sendOther(Socket socket, String msg) throws IOException {
        for (Socket client : ServerTest.list) {
            if (client == socket) {

                //2.是自己返回带标记的消息
                outputStream = socket.getOutputStream();
                InetAddress localAddress = socket.getLocalAddress();
                //是自己的返回消息类型
                outputStream.write(("len" + msg + "：[" + localAddress.toString().substring(1) + "]\r\n\n").getBytes());

                //客户端是自己不转发
                continue;
            }
            //输出对应客户端socket
            outputStream = client.getOutputStream();
            SocketAddress socketAddress = client.getLocalSocketAddress();
            //分割字符串，从第一个开始
            outputStream.write(("[" + socketAddress.toString().substring(1) + "]：" + msg+"\r\n\n").getBytes());
            System.out.println("已转发=>" + msg);

        }

    }

    //统计在线人数
    public void onLine() {
        int num = ServerTest.list.size();

        List<Socket> sockets = ServerTest.list;
        for (Socket client : sockets) {
            try {
                outputStream = client.getOutputStream();
                outputStream.write(("\n        【当前在线人数：" + num + "】\n").getBytes());
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
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
}
