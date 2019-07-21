using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*new Thread(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("Hello");
                }
            }).Start();
            new Thread(() => {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("World");
                }
            }).Start();*/
            //Thread.Sleep(1);

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("Hello");
                }
            });
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine("World");
                }
            });

            t1.IsBackground = true;
            t2.IsBackground = true;

            t1.Start();
            t2.Start();

            t1.Join(10000);
            t2.Join(10000);

            Console.WriteLine("The End");
        }
    }
}
