using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncVar
{
    class Program
    {
        static void Main(string[] args)
        {
            Data d1 = new Data();
            //Worker w1 = new Worker() { data = d1 };
            //Worker w2 = new Worker() { data = d1 };

            Worker.statData = d1;

            /*w1.doWork();
            w2.doWork();
            Console.WriteLine(d1.x);*/

            //Thread t1 = new Thread(w1.doWork);
            //Thread t2 = new Thread(w2.doWork);

            Thread t1 = new Thread(Worker.doWork2);
            Thread t2 = new Thread(Worker.doWork2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(d1.x);
        }
    }
}
