using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //工作原理
    //当主程序启动时, 首先创建了ManualResetEventSlim类的一个实例。然后启动了三个线程,等待事件信号通知它们继续执行。
    // ManualResetEvnetSlim的整个工作方式有点像人群通过大门。而AutoResetEvent事件像一个旋转门,一次只允许一人通过。
    // ManualResetEventSlim是ManualResetEvent的混合版本,一直保持大门敞开直到手动调用Reset方法。当调用mainEvent.Set时,
    // 相当于打开了大门从而允许准备好的线程接收信号并继续工作。然而线程3还处于睡眠 "状态,没有赶上时间。
    // 当调用mainEvent.Reset相当于关闭了大门。最后一个线程已经准备好执行,但是不得不等待下一个信号,
    // 即要等待好几秒钟。
    class Program
    {

    
        
            static void Main(string[] args)
            {
                var t1 = new Thread(() => TravelThroughGates("Thread 1", 5));
                var t2 = new Thread(() => TravelThroughGates("Thread 2", 6));
                var t3 = new Thread(() => TravelThroughGates("Thread 3", 12));
                t1.Start();
                t2.Start();
                t3.Start();
                Thread.Sleep(TimeSpan.FromSeconds(6));
                Console.WriteLine("The gates are now open!"); //一次只允许一个人通过！
                _mainEvent.Set();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _mainEvent.Reset();
                Console.WriteLine("The gates have been closed!");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.WriteLine("The gates are now open for the second time!");
                _mainEvent.Set();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("The gates have been closed!");
                _mainEvent.Reset();

                Console.ReadKey();
            }

            static void TravelThroughGates(string threadName, int seconds)
            {
                Console.WriteLine("{0} falls to sleep", threadName);
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
                Console.WriteLine("{0} waits for the gates to open!", threadName);
                _mainEvent.Wait();
                Console.WriteLine("{0} enters the gates!", threadName);
            }

            static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);
        



















        //////////////////////////////////////////
    }
}


