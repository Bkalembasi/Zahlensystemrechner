using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Zahlensystemrechner
{
    class Rahmen
    {
        int breite = Console.WindowWidth;
        int hoehe = Console.WindowHeight;
        bool geaendert = true;

        private void ZeichneRahmen()
        {
            while (true)
            { 
                if (geaendert)
                {

                    Console.Clear();
                    geaendert = false;
                    Console.WriteLine(this.breite);
                    Console.WriteLine(this.hoehe);
                    this.breite = Console.WindowWidth;
                    this.hoehe = Console.WindowHeight;
                }
                if (!(breite==Console.WindowWidth) && !(hoehe==Console.WindowHeight))
                {
                    geaendert = true;

                }
            }
        }

        public static void Main(string[] args)
        {
            Rahmen rahmen = new Rahmen();
            Thread t = new Thread(new ThreadStart(rahmen.ZeichneRahmen));
            t.Start();
        }
    }
}
