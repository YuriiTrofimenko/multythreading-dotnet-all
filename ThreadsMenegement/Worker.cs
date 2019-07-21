using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsMenegement
{
    class Worker
    {
        public static bool isAlive = true;
        public static bool isSuspended = false;
        public static void doWork ()
        {
            for (int i = 0; i < 300; i++)
            {
                if (isAlive)
                {
                    while (isSuspended)
                    {
                        Thread.CurrentThread.Suspend();
                    }
                    Console.Write($"{i}: ");
                    Console.Write("Hello");
                    Console.Write(" World");
                    Console.WriteLine("!");
                }
                else {
                    Thread.CurrentThread.Abort();
                }
            }
        }

        public static void resume(Thread _childThread) {
            isSuspended = false;
            _childThread.Resume();
        }
    }
}
