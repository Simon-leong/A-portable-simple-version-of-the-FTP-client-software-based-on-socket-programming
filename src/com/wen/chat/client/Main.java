package com.wen.chat.client;

public class Main {
    public static void main(String[] args) {
        try {
            ClientFrame clientFrame = new ClientFrame();
            clientFrame.frame();
        } catch (Exception e) {
            System.out.println("min异常");
        }
    }

}
