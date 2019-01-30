using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_Demo
{
    class Demo
    {
        private int wert;
        private object syncObject = new object();
        public void MachWas()
        {
            while(true)
            {
                lock (syncObject)
                {
                    wert++;
                    if (wert > 100)
                        break;
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {wert}");
                }

                // Alternative:
                // Interlocked.Increment(ref wert);
            }
        }
    }
}
