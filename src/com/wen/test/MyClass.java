package com.wen.test;

public class MyClass {

    public static void main(String[] args) {

        Init init = new Init();
        System.out.println(init.str);


    }

    public void info(){

        MyInter myInter = new MyInter() {
            @Override
            public void test1() {
                System.out.println("new");
            }

            @Override
            public void test2() {
                System.out.println("new");
            }
        };
        myInter.test1();

        new MyInter() {
            @Override
            public void test1() {
                System.out.println("test1");
            }

            @Override
            public void test2() {
                System.out.println("test2");
            }
        };
        System.out.println("info");
    }
}



class inferImpl implements MyInter{

    @Override
    public void test1() {
        System.out.println("class test1");
    }

    @Override
    public void test2() {
        System.out.println("class test2");
    }
}
