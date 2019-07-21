using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncMethods
{
    class Data
    {
        private int state = 1;
        public int count = 0;

        public void sayHello() {
            //Thread.Sleep(10);
            Console.Write("Hello");
            //Thread.Sleep(10);
            state = 2;
        }

        public void sayWorld()
        {
            //Thread.Sleep(10);
            Console.Write(" World");
            //Thread.Sleep(10);
            state = 3;
        }

        public void sayDot()
        {
            //Thread.Sleep(10);
            Console.WriteLine(".");
            //Thread.Sleep(10);
            state = 1;
        }

        public int getState() {
            return state;
        }
    }
}
