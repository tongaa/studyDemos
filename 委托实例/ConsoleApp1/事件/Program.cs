using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();

        cat.catEvent += Mouse;//订阅猫事件
        cat.catEvent += Person;//订阅人事件

        cat.Cry("猫：喵~");//猫叫的动作，触发事件

        Console.ReadKey();
    }

    private static void Person(object sender, EventArgs e)
    {
        Console.WriteLine("人：大半夜的不睡觉，叫唤个啥呢？~");
    }

    private static void Mouse(object sender, EventArgs e)
    {
        Console.WriteLine("老鼠：快跑~");
    }
}

public class Cat
{
    public event EventHandler<EventArgs> catEvent;

    public void Cry(string msg)
    {
        Console.WriteLine(msg);

        catEvent(this, new EventArgs()); //开始执行订阅的事件 先老鼠后人
    }
}