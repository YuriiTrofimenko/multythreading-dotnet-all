using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncVar
{
    class Worker
    {
        public Data data;
        public static Data statData;
        public static object syncObj = new object();
        public void doWork()
        {
            for (int i = 0; i < 100000; i++)
            {
                /*int x = data.x;
                //Thread.Sleep(1);
                x++;
                //Thread.Sleep(1);
                data.x = x;*/

                /*Monitor.Enter(data);
                int x = data.x;
                x++;
                data.x = x;
                Monitor.Exit(data);*/

                lock(data)
                {
                    int x = data.x;
                    x++;
                    data.x = x;
                }
            }
        }

        public static void doWork2()
        {
            for (int i = 0; i < 100000; i++)
            {
                /*int x = data.x;
                //Thread.Sleep(1);
                x++;
                //Thread.Sleep(1);
                data.x = x;*/

                /*Monitor.Enter(data);
                int x = data.x;
                x++;
                data.x = x;
                Monitor.Exit(data);*/

                lock (syncObj)
                {
                    int x = statData.x;
                    x++;
                    statData.x = x;
                }
            }
        }
    }
}
