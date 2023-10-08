package com.wen.net.server;


import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class ServerTest {

    //客户端集合
    protected static List<Socket> list = new ArrayList<>();

    public static void main(String[] args) {
        Service service = null;
        try {
            int i = 0;
            ServerSocket serverSocket = new ServerSocket(8848);
            while (true) {
                //一直接受客户端请求,多客户端连接
                Socket socket = serverSocket.accept();
                list.add(socket);

                //服务线程
                service = new Service(socket);

                //开启线程
                new Thread(service).start();

                service.onLine();
                System.out.println("socket=" + socket);
                System.out.println("主线程循环" + i++ + "次");
                System.out.println("客户端在线数：" + list.size());
            }


        } catch (IOException e) {
            e.printStackTrace();
            service.onLine();//出异常再次调用通知人数方法
        }
    }
}
