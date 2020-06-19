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
        private void StartCalc()
        {
            while (true)
            {
                String term = Convert.ToString(Console.ReadLine());
                CalcInput calc = new CalcInput(term);
                BasicCalc startCalc = new BasicCalc();

                String[] dezArray = calc.GetCalcArray();
                long solution = startCalc.GetSolution(dezArray);
                
                Number solNumber = new Number();
                solNumber.SetDecNumber(solution);
                Console.Write(solution);
                //TODO Ausgabe
            }
        }

        public static void Main()

        {
            Programm calculator = new Programm();

            Thread ui = new Thread(new ThreadStart(calculator.WriteUI));
            ui.Start();
            Thread calc = new Thread(new ThreadStart(calculator.StartCalc));
            calc.Start();
        }
    }
}
