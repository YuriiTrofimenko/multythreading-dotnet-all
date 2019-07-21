using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncMethods
{
    class Worker
    {
        public Data data;
        public int id;
        public volatile int loopMax = 10;

        public void doWork() {
            for (int i = 0; i < loopMax; i++)
            {
                /*if (data.getState() == id)
                {
                    if (id == 1)
                    {
                        data.sayHello();
                    }
                    else
                    {
                        data.sayWorld();
                    }
                }*/
                //Локируем объект data от всех остальных потоков
                //при выполнении ниже приведенных строк кода
                Monitor.Enter(data);
                //Если состояние разделяемого объекта не совпадает с нашим ид
                while (data.getState() != id)
                {
                    //Thread.Sleep(10);
                    //уступаем очередь другим
                    Monitor.Wait(data);
                }
                //иначе
                //Console.Write($" - {i} - ");
                //проверяем свой ид
                //и выполняем соотв-й метод на объекте
                if (id == 1)
                {
                    data.sayHello();
                }
                else if (id == 2)
                {
                    data.sayWorld();
                }
                else {
                    data.sayDot();
                }
                int localCount = data.count;
                localCount++;
                data.count = localCount;
                //Monitor.Pulse(data);
                //Выполнив работу на объекте,
                //уведомляем все потоки выполнения, что они
                //могут снова пробовать работать с объектом
                Monitor.PulseAll(data);
                //Снимаем лок
                Monitor.Exit(data);
            }
        }

        public void doWork2(object _loopMax)
        {
            for (int i = 0; i < (int)_loopMax; i++)
            {
                /*if (data.getState() == id)
                {
                    if (id == 1)
                    {
                        data.sayHello();
                    }
                    else
                    {
                        data.sayWorld();
                    }
                }*/
                //Локируем объект data от всех остальных потоков
                //при выполнении ниже приведенных строк кода
                Monitor.Enter(data);
                //Если состояние разделяемого объекта не совпадает с нашим ид
                while (data.getState() != id)
                {
                    //Thread.Sleep(10);
                    //уступаем очередь другим
                    Monitor.Wait(data);
                }
                //иначе
                //Console.Write($" - {i} - ");
                //проверяем свой ид
                //и выполняем соотв-й метод на объекте
                if (id == 1)
                {
                    data.sayHello();
                }
                else if (id == 2)
                {
                    data.sayWorld();
                }
                else
                {
                    data.sayDot();
                }
                int localCount = data.count;
                localCount++;
                data.count = localCount;
                //Monitor.Pulse(data);
                //Выполнив работу на объекте,
                //уведомляем все потоки выполнения, что они
                //могут снова пробовать работать с объектом
                Monitor.PulseAll(data);
                //Снимаем лок
                Monitor.Exit(data);
            }
        }
    }
}
