using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsMenegement
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            /*Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 300; i++)
                {
                    Console.Write("Hello");
                    Console.Write(" World");
                    Console.WriteLine("!");
                }
            });
            t1.Start();
            Thread.Sleep(1);
            t1.Abort();*/

            //2
            Thread t1 = new Thread(Worker.doWork);
            t1.Start();
            Thread.Sleep(1);
            //Worker.isAlive = false;
            Worker.isSuspended = true;
            Thread.Sleep(2000);
            Worker.resume(t1);
        }
    }
}
