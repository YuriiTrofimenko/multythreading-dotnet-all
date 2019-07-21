using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncMethods
{
    class Program
    {
        const int LOOP_MAX = 5;
        static void Main(string[] args)
        {
            Data d1 = new Data();
            Worker w1 = new Worker() { id = 1, data = d1 };
            Worker w2 = new Worker() { id = 2, data = d1 };
            Worker w3 = new Worker() { id = 3, data = d1 };

            /*Thread t1 = new Thread(w2.doWork);
            Thread t2 = new Thread(w1.doWork);
            Thread t3 = new Thread(w3.doWork);*/

            Thread t1 = new Thread(new ParameterizedThreadStart(w2.doWork2));
            Thread t2 = new Thread(w1.doWork2);
            Thread t3 = new Thread(w3.doWork2);

            /*t3.Start();
            t2.Start();
            t1.Start();*/

            t3.Start(LOOP_MAX);
            t2.Start(LOOP_MAX);
            t1.Start(LOOP_MAX);

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"count = {d1.count}");
        }
    }
}
