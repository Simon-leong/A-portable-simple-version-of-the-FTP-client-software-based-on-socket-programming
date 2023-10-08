package com.wen.chat.client;


import javax.swing.*;

public class ClientFrame {
    public  void frame() {
        JFrame frame = new JFrame();
        frame.setTitle("JavaChat@Len");
        ClientPanel panel = new ClientPanel();
        panel.panel();
        //panel添加到窗体里面
        frame.add(panel);

        //布局置空,设置绝对定位
        frame.setLayout(null);

        frame.setBounds(100, 100, 650, 500);
        //设置窗口不可变
        frame.setResizable(false);
        //设置窗口可见
        frame.setVisible(true);
        //设置背景颜色
//        frame.getContentPane().setBackground(Color.MAGENTA);
        //关闭窗体
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

    }
}
