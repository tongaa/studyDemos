using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
 /*
    ///工作原理

当主程序启动时,创建了一个Counter类的对象。该类定义了一个可以递增和递减的简单的计数器。然后我们启动了三个线程
这三个线程共享同一个counter实例,在一个周期中进行一次递增和一次递减。这将导致不确定的结果。如果运行程序多次,
则会打印出多个不同的计数器值。结果可能是0,但大多数情况下则不是0.

这是因为Counter类并不是线程安全的。当多个线程同时访问counter对象时,第一个线程得到的counter值10并增加为11,
然后第二个线程得到的值是11并增加为12,第一个线程得到counter值12,但是递减操作发生前,第二个线程得到的counter值也是12,
然后 , 第一个线程将12递减为11并保存回counter中,同时第二个线程进行了同样的操作。
结果,我们进行了两次递增操作但是只有一次递减操作,这显然不对。这种情形被称为竞争条件, (race condition),
竞争条件是多线程环境中非常常见的导致错误的原因。

为了确保不会发生以上情形,必须保证当有线程操作counter对象时,所有其他线程必须等待直到当前线程完成操作。
我们可以使用lock关键字来实现这种行为。如果锁定了一个对象,需要访问该对象的所有其他线程则会处于阻塞状态,
并等待直到该对象解除锁定。这,可能会导致严重的性能问题,在第2章中将会进一步学习该知识点。

使用Monitor类锁定资源 */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Incorrect counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}", c.Count);
            Console.WriteLine("--------------------------");

            Console.WriteLine("Correct counter");

            var c1 = new CounterWithLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Total count: {0}", c1.Count);

            Console.ReadKey();

        }
        //CounterBase c     父类变量 引用 子类的实例（对象）。###称为向上转型
        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }

        class Counter : CounterBase
        {
            public int Count { get; private set; }

            public override void Increment()
            {
                Count++;
            }

            public override void Decrement()
            {
                Count--;
            }
        }

        class CounterWithLock : CounterBase
        {
            private readonly object _syncRoot = new Object(); //这是一把锁

            public int Count { get; private set; }

            public override void Increment()
            {
                lock (_syncRoot) //线程进来就上锁   线程走了就打开锁
                {
                    Count++;
                }
            }

            public override void Decrement()
            {
                lock (_syncRoot)
                {
                    Count--;
                }
            }
        }

        abstract class CounterBase
        {
            public abstract void Increment();

            public abstract void Decrement();
        }
    }























    //////////////////////////////////////////
}


