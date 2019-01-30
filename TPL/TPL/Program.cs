using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Starten von einem Task
            //Task t1 = new Task(MachEtwas);
            //t1.Start();

            //// 4.0
            //Task t2 = Task.Factory.StartNew(MachEtwas); // Startet sofort
            //// 4.5
            //Task t3 = Task.Run(new Action(MachEtwas)); // Startet sofort

            ////Anonyme Methode:
            //Task t4 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("lalala");
            //}); 
            #endregion

            #region Task mit einem Ergebnis
            //Task<string> t1 = Task.Run(() =>
            //{
            //   Thread.Sleep(3000);
            //   return DateTime.Now.ToLongTimeString();
            //});

            //Thread.Sleep(5000);
            //string aktuelleUhrzeit = t1.Result; // Wartet, sofern das Ergebnis noch nicht da sein sollte !
            //Console.WriteLine(aktuelleUhrzeit); 
            #endregion

            #region Warten auf Tasks
            //Task t1 = Task.Run(() =>
            //{
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Eins");
            //});
            //Task t2 = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Zwei");
            //});
            //Task t3 = Task.Run(() =>
            //{
            //    Thread.Sleep(8000);
            //    Console.WriteLine("Drei");
            //});

            ////t2.Wait(); 
            ////Task.WaitAll(t1, t2, t3);
            //Task.WaitAny(t1, t2, t3); 
            #endregion

            #region Task abbrechen
            //CancellationTokenSource cts = new CancellationTokenSource();
            //var t = cts.Token;

            //Task t1 = Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(100);
            //        Console.Write("#");
            //        if (t.IsCancellationRequested)
            //            break;
            //    }
            //});

            //Thread.Sleep(5000);
            //cts.Cancel(); 
            #endregion

            #region Exceptions behandeln
            //Task t1 = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    throw new DivideByZeroException();
            //});
            //Task t2 = Task.Factory.StartNew(() => throw new FormatException());
            //Task t3 = new Task(() => throw new StackOverflowException());
            //t3.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write('#');
            //    Thread.Sleep(100);
            //}

            //try
            //{
            //    Task.WaitAll(t1, t2, t3); // Man bekommt die Exception NUR, wenn man auf den Task wartet, das Resultat abruft (.Result) oder selber schaut (.IsFaulted - Property)
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //} 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void MachEtwas()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Ich habe etwas gemacht ...");
        }
    }
}
