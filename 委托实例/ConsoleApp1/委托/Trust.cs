using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void MyDelegate(string s); //创建委托实例
    class Trust
    {
        static void TestMetthod1( string str)
        {
            Console.WriteLine("这是方法1：{0}",str);
        }
        static void TestMetthod2(string str)
        {
            Console.WriteLine("这是方法2：{0}", str);
        }
        static void TestMetthod3(string str)
        {
            Console.WriteLine("这是方法3：{0}", str);
        }

        //将方法作为参数传递 委托可以让方法作为参数传递给其它方法。
        static void Test(MyDelegate d)
        {
            if (d != null)
            {
                d("5");
                Console.WriteLine("123");
            }

        }
           


        static void Main(string[] args)
        {
            MyDelegate D1, D2; //定义委托变量
            MyDelegate D4; //定义委托变量
            MyDelegate D5; //定义委托变量

            D1 = TestMetthod1; //关联方法
                               //  D1("111"); //调用委托实例

            //一个委托实例关联三个方法
            D4 = TestMetthod1;
            D4 += TestMetthod2;
            D4 += TestMetthod3;
          //  D4("4"); //三个方法均调用一次
           // 移除一个委托实例中的方法 使用“-”
            D4 -= TestMetthod2;
           // D4("4"); //2个方法均调用一次 去掉 TestMetthod2
            D5 = TestMetthod1;
            Test(D5);



        }
    }
}
