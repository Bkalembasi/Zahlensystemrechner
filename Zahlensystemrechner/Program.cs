using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Zahlensystemrechner
{
    class Programm
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        bool geaendert = true;

        private void WriteUI()
        {
            BuildRectangle rec = new BuildRectangle();
            Calculator calc = new Calculator();

            while (true)
            {
                CheckAndResetWindowSize();
                if (geaendert)
                {
                    Thread.Sleep(300);
                    Infobox inf = new Infobox(Console.WindowWidth / 3 - 3, Console.WindowWidth / 3 * 2 + 1, 1);
                    Console.Title = "Zahlensystemrechner by BurnUp GmbH ©";
                    Console.Clear();
                    geaendert = false;
                    this.width = Console.WindowWidth;
                    this.height = Console.WindowHeight;

                    rec.CreateWindowBorder(width,height);
                    calc.WriteCalculator(width,height);
                    inf.InfoTextContent();
                }
                if (!(width == Console.WindowWidth) || !(height == Console.WindowHeight))
                {

                    geaendert = true;
                }
            }
        }

        private void CheckAndResetWindowSize()
        {
            if (Console.WindowHeight < 30 || Console.WindowWidth < 120)
            {
                Console.SetWindowSize(120, 30);
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
