using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace Zahlensystemrechner
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
