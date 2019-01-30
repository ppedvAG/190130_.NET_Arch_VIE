using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Thread - Allgemein
            //Thread t1 = new Thread(Punkterl);
            //Thread t2 = new Thread(Stricherl);

            //t1.Start();
            //t2.Start();

            // Warten
            //t1.Join();
            //t2.Join();

            //Thread.Sleep(3000);
            //t1.Abort();
            //t2.Abort();
            //t1.Join();
            //t2.Join(); 
            #endregion

            Demo d1 = new Demo();
            Thread t1 = new Thread(d1.MachWas);
            Thread t2 = new Thread(d1.MachWas);

            t1.Start();
            t2.Start();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Stricherl()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.Write('-');
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread 'Stricherl' wurde abgebrochen");
            }
        }

        private static void Punkterl()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                Console.Write('.');
            }
        }
    }
}
