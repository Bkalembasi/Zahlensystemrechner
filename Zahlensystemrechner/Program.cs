using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
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
            string term;
            BuildRectangle rec = new BuildRectangle();
            rec.createWindowBorder();
            rec.writeInfoText();

            Calculator calc = new Calculator();
            calc.WriteCalculator();

            //Infotext();

            term = Convert.ToString(Console.ReadLine());
            
          
        }

        public static void Infotext()
        {
            Console.SetCursorPosition(1,1);
            Console.WriteLine("Zahlensystem-Rechner");
            Console.SetCursorPosition(1,2);
            Console.WriteLine("Infos:");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Der Rechner beherrscht die Grundrechenarten + - / *");
            Console.WriteLine("");
            Console.SetCursorPosition(1, 5);
            Console.WriteLine("Der Rechner beachtet Klammern und Punkt-vor-Strich");
            Console.WriteLine("");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("Das Ergebnis wird mit Betätigen der Return- oder =-Taste berechnet und ausgegeben");
            Console.WriteLine("");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("Zahlen der verschiedenen Zahlensysteme müssen mit dem zugehörigen Präfix gekennzeichnet werden:");
            Console.SetCursorPosition(1, 10);
            Console.WriteLine("Oktar: O_");
            Console.SetCursorPosition(1, 11);
            Console.WriteLine("Binär: B_");
            Console.SetCursorPosition(1, 12);
            Console.WriteLine("Hexadezimal: H_");
            Console.SetCursorPosition(1, 13);
            Console.WriteLine("Dezimal: ohne Präfix");
            Console.WriteLine("");
            Console.SetCursorPosition(1, 15);
            Console.WriteLine("Eingabe der Rechnung:");
            Rahmen rahmen = new Rahmen();
            Thread t = new Thread(new ThreadStart(rahmen.ZeichneRahmen));
            t.Start();
        }
    }
}
