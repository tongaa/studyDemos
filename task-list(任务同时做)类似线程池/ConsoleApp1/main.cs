using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//C# Task 的用法
//其实Task跟线程池ThreadPool的功能类似，不过写起来更为简单，直观。代码更简洁了，使用Task来进行操作。
//可以跟线程一样可以轻松的对执行的方法进行控制。
//顺便提一下，配合CancellationTokenSource类更为可以轻松的对Task操作的代码进行中途终止运行，会在后面的章节中讲述。
namespace ConsoleApp1
{
    class Program2
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Factory.StartNew(() => {
                Thread.Sleep(1000);
                Console.WriteLine("1秒执行结束");
            }));
            taskList.Add(Task.Factory.StartNew(() => {
                Thread.Sleep(800);
                Console.WriteLine("o.8秒执行结束");
            }));
            Console.WriteLine("执行中");
            TaskFactory taskFactory = new TaskFactory();
            taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), tArray =>
            { Thread.Sleep(5000);
              Console.WriteLine("等待这些完成后执行"); }));


            Console.ReadLine();
            //
            Console.WriteLine("执行完成");
            Console.Read();
        }
    }
}
