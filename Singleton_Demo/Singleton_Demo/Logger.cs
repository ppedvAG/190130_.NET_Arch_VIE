using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Logger
    {
        private Logger()
        {
            instanceCounter++;
        }

        private static object syncObject = new object();
        private static int instanceCounter;
        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null) // Performance, damit wir nicht IMMER in ein Lock() hineingeraten
                    lock (syncObject)
                    {
                        if (instance == null) // Es kann sein, dass ein Thread vor dem Lock() stoppt -> 2 Instanzen
                        {
                            Thread.Sleep(10);
                            instance = new Logger();
                        }
                    }
                return instance;
            }
        }


        public void Log(string message)
        {
            Console.WriteLine($"{instanceCounter}[{DateTime.Now.ToLongTimeString()}]: {message}");
        }
    }
}
