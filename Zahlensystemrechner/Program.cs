﻿using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Zahlensystemrechner
{
    class Programm
    {
        int breite = Console.WindowWidth;
        int hoehe = Console.WindowHeight;
        bool geaendert = true;

        private void WriteUI()
        {
            BuildRectangle rec = new BuildRectangle();
            Calculator calc = new Calculator();

            while (true)
            { 
                if (geaendert)
                {
                    Infobox inf = new Infobox(Console.WindowWidth / 3 - 3, Console.WindowWidth / 3 * 2 + 1, 1);
                    Console.Clear();
                    geaendert = false;
                    this.breite = Console.WindowWidth;
                    this.hoehe = Console.WindowHeight;

                    rec.CreateWindowBorder();
                    calc.WriteCalculator();
                    inf.InfoTextContent();
                }

                if (!(breite==Console.WindowWidth) || !(hoehe==Console.WindowHeight))
                {
                    geaendert = true;
                }
            }
        }

        public static void Main()
        {
            Programm calculator = new Programm();

            Thread ui = new Thread(new ThreadStart(calculator.WriteUI));
            ui.Start();

            String term = Convert.ToString(Console.ReadLine());          
        }
    }
}
