using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEvents
{
    class Program
    {
        // Delegate-Type
        public delegate void MeinDelegat(); // signatur ist: void()
        static void Main(string[] args)
        {
            #region Delegate - Variante "Alt"

            //// MeinDelegat del = new MeinDelegat(MachWas);
            //MeinDelegat del = MachWas;
            //del += MachWas2;
            //del += MachWasMitInt;
            ////del.Invoke();   // Aufruf
            //del();          // ebenfalls Aufruf 
            #endregion

            #region Action<T> und Func<T>
            //// Action<T> -> void
            //Action parameterlos = MachWas;
            //parameterlos += MachWas2;
            //parameterlos();

            //Action<int> intInput = MachWasMitInt;
            //intInput(3);

            //// Func<T> -> alles mit Rückgabe

            //Func<int, int, int> rechnung = Add;
            //rechnung += Sub;

            //int erg = rechnung(12, 5);
            //Console.WriteLine(erg); 
            #endregion

            // Im UI (z.B. WinForms, WPF, UWP, Xamarin etc) => Delegat für die Oberfläche
            // EventHandler eh = Button1_Click;
            // EventHandler<MeineArgumente> ehm = Button2_Click;

            Button b = new Button();
            b.ButtonClick_Event += MeinButtonClick;
            b.ButtonClick_Event += Logger;

            b.Click();

            //b.ButtonClick_Event = null;       // absolut verboten

            b.Click();
            b.Click();

            b.ButtonClick_Event -= Logger;

            b.Click();
            b.Click();
            b.Click();
            b.Click();

            //b.ButtonClick_Event?.Invoke(null, null);  // Verboten

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: Button wurde geklickt");
        }

        private static void MeinButtonClick(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        private static void Button2_Click(object sender, MeineArgumente e)
        {
            throw new NotImplementedException();
        }

        private static void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //private static bool NurUngeradeZahlen x => x % 2 == 1;
        //{
        //    return x % 2 == 1;
        //}

        public static void MachWas()
        {
            Console.WriteLine("Machwas");
        }
        public static void MachWas2()
        {
            Console.WriteLine("Machwas2");
        }
        public static void MachWasMitInt(int zahl)
        {
            Console.WriteLine($"Machwas mit {zahl}");
        }

        public static int Add(int z1, int z2) => z1 + z2;
        public static int Sub(int z1, int z2) => z1 - z2;

    }
}
