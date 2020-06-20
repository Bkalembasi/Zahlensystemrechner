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

        Infobox inf = new RightInfoBox();
        InputField inputField = new InputField();
        LeftInfoBox solField = new LeftInfoBox();

        private void WriteUI()
        {
            

            while (true)
            { 
                if (geaendert)
                {
                    ResizeWindow();
                }
                if (!(breite==Console.WindowWidth) || !(hoehe==Console.WindowHeight))
                {
                    geaendert = true;
                }
            }
        }

        private void ResizeWindow()
        {
            BuildRectangle rec = new BuildRectangle();
            Calculator calc = new Calculator();

            Console.Clear();
            geaendert = false;
            this.breite = Console.WindowWidth;
            this.hoehe = Console.WindowHeight;

            //WindowBorder + Rechner erzeugen
            rec.CreateWindowBorder();
            calc.WriteCalculator();
            Console.SetCursorPosition(0, 0);

            //Felder und Koordinaten neu Initialisieren
            inf.Init();
            inputField.Init();
            solField.Init();

            solField.PrintSavedInput();
            inputField.PrintSavedInput();
        }

        private void StartCalc()
        {
            while (true)
            {
                String term = inputField.ReadInput();
                CalcInput calc = new CalcInput(term);
                BasicCalc startCalc = new BasicCalc();

                String[] dezArray = calc.GetCalcArray();
                long solution = startCalc.GetSolution(dezArray);
                
                Number solNumber = new Number();
                solNumber.SetDecNumber(solution);
                solField.WriteInfoText(System.Convert.ToString(solution));
                solField.SaveAndClearInput(Convert.ToString(solution));

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
