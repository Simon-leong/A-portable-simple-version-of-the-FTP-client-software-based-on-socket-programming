package com.wen.chat.util;

import java.io.IOException;

public class sendMain {
    public static void main(String[] args) {
        try {
            ClientBase clientBase = new ClientBase("127.0.0.1",8848);
            clientBase.sendTest("hello world");
            System.out.println(clientBase.receiveTest());
        } catch (IOException e) {
            e.printStackTrace();
        }


    }
}
