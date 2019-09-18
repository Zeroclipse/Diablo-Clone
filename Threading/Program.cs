using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static Object obj = new object();

        static void Main(string[] args)
        {
            #region OldMain
            //while (true)
            //{
            //    //Console.WriteLine("Main thread starting");
            //    //Thread t = new Thread(new ThreadStart(ThreadTest.DoStuff));
            //    //t.Start();

            //    ////    Thread.Sleep(0);

            //    ////    for (int i = 0; i < 5; i++)
            //    ////    {
            //    ////        Console.WriteLine("This is the main thread! + " + i);
            //    ////        Thread.Sleep(0);
            //    ////    }

            //    //ThreadTest.counter = 0;
            //    //for (int i = 0; i < 50; i++)
            //    //{
            //    //    ThreadTest.counter += 1;
            //    //    Console.WriteLine("Main thread: counter is " + ThreadTest.counter);
            //    //    Thread.Sleep(1);
            //    //}
            //    //Console.WriteLine("Waiting for the other thread");
            //    //t.Join();
            //    //Console.WriteLine("All threads done.");
            //}
            #endregion
            Console.WriteLine("Main thread start");
            Thread t = new Thread(ShowThreadInfo);
            t.Start();

            t = new Thread(ShowThreadInfo);
            t.IsBackground = true;
            t.Start();

            t = new Thread(ShowThreadInfo);
            t.Start();

            Thread.Sleep(50);
            ShowThreadInfo();

            //Console.WriteLine("Waiting for other thread");
            //t.Join();
            Console.WriteLine("All Done");
        }

        static void ShowThreadInfo()
        {
            Thread currentThread = Thread.CurrentThread;
            lock (obj)
            {
                Console.WriteLine("Thread ID: {0}", currentThread.ManagedThreadId);
                Console.WriteLine("Background: {0}", currentThread.IsBackground);
                Console.WriteLine("Is Threadpool: {0}", currentThread.IsThreadPoolThread);
                Console.WriteLine("Priority: {0}", currentThread.Priority);
                Console.WriteLine("Culture Name: {0}", currentThread.CurrentCulture.Name);
                Console.WriteLine("Done");
            }
        }
    }

    public class ThreadTest
    {
        public static int counter;
        /// <summary>
        /// This is a tool tip
        /// </summary>
        /// <param name="data">How many times to say hi</param>
        public static void DoStuff(Object data)
        {
            #region OldDostuff
            //    for(int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("Hello from the other thread + " + i);
            //        Thread.Sleep(0);
            //    }
            //while (true)
            //{
            //    if (ThreadTest.counter >= 25)
            //    {
            //        break;
            //    }
            //    ThreadTest.counter += 1;
            //    Console.WriteLine("Other thread: counter is " + ThreadTest.counter);
            //}
            #endregion
            int counter = (int)data;

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Hello There Carter #" + (i+1));
            }
        }
    }
}
