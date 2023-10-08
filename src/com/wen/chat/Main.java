package com.wen.chat;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

import static java.awt.Color.pink;

class MyFrame {
    public void myframe() {
        JFrame frame = new JFrame();
        JPanel panel = new JPanel();

        panel.setBounds(30, 30, 590, 410);
        panel.setBackground(Color.green);

        /*输入框*/
        JTextArea textSend = new JTextArea(2, 10);
        textSend.setBounds(90, 260, 50, 50);
        textSend.setFont(new Font("微软雅黑", Font.ITALIC, 20));
        textSend.setBackground(pink);


        //布局置空,设置绝对定位
        frame.setLayout(null);
        //panel添加到窗体里面
        frame.add(panel);
        panel.add(textSend);
        frame.setBounds(100, 100, 650, 500);
        //设置窗口不可变
        frame.setResizable(false);
        //设置窗口可见
        frame.setVisible(true);
        //设置背景颜色
        frame.getContentPane().setBackground(Color.MAGENTA);
        //关闭窗体
//        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.addWindowListener(new WindowAdapter() {

            @Override
            public void windowLostFocus(WindowEvent e) {
                System.out.println("失去焦点");
            }

            @Override
            public void windowClosing(WindowEvent e) {
                System.out.println("Closing");
                System.exit(0);//退出程序

            }

            @Override
            public void windowClosed(WindowEvent e) {
                System.out.println("Closed");
            }

            @Override
            public void windowDeactivated(WindowEvent e) {
                System.out.println("windowDeactivated");
            }
        });

        panel.setVisible(true);

        //添加键盘监听事件
        panel.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent e) {
                System.out.println("敲击了键盘");
            }

            @Override
            public void keyTyped(KeyEvent e) {
                System.out.println("按下按键");
            }

            @Override
            public void keyReleased(KeyEvent e) {
                System.out.println("释放按键");
            }
        });

        panel.setFocusable(true);//设置获取焦点

    }

    public static void main(String[] args) {
        new MyFrame().myframe();
    }
}

