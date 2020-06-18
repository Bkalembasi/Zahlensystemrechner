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
                    Console.Clear();
                    geaendert = false;
                    this.breite = Console.WindowWidth;
                    this.hoehe = Console.WindowHeight;

                    rec.createWindowBorder();
                    rec.writeInfoText();
                    calc.WriteCalculator();
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
                //TODO 
                Number solNumber = new Number();
                solNumber.SetDecNumber(solution);
                String newSolution = solNumber.getAllSystems();

                Console.WriteLine(newSolution);
            }
        }


        public static void Main(string[] args)
        {
            Programm calculator = new Programm();

            Thread ui = new Thread(new ThreadStart(calculator.WriteUI));
            ui.Start();
            Thread calc = new Thread(new ThreadStart(calculator.StartCalc));
            calc.Start();
        }
    }
}
