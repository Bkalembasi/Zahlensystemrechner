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
        bool windowChanged = true;

        Infobox inf = new RightInfoBox();
        InputField inputField = new InputField();
        LeftInfoBox solField = new LeftInfoBox();

        private void WriteUI()
        {
            while (true)
            {
                CheckAndResetWindowSize();
                if (windowChanged)
                {
                    ResizeWindow();
                }
                if (!(width == Console.WindowWidth) || !(height == Console.WindowHeight))
                {
                    windowChanged = true;
                }
            }
        }


        private void ResizeWindow()
        {
            BuildRectangle rec = new BuildRectangle();
            Calculator calc = new Calculator();
            Console.Title = "Zahlensystemrechner by BurnUp GmbH ©";
           
            Console.Clear();
            windowChanged = false;
            this.width = Console.WindowWidth;
            this.height = Console.WindowHeight;

            //WindowBorder + Rechner erzeugen
            rec.CreateWindowBorder(width,height);
            calc.WriteCalculator(width,height);
            Console.SetCursorPosition(0, 0);

            //Felder und Koordinaten neu Initialisieren
            inf.Init();
            inputField.Init();
            solField.Init();

            solField.PrintSavedInput();
            inputField.PrintSavedInput();
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
                String term = inputField.ReadInput();
                CalcInput calc = new CalcInput(term);
                BasicCalc startCalc = new BasicCalc();

                String[] dezArray = calc.GetCalcArray();
                long solution = startCalc.GetSolution(dezArray);

                Number solNumber = new Number();
                solNumber.SetDecNumber(solution);
                solField.WriteInfoText(System.Convert.ToString(solution));
                solField.SaveAndClearInput(Convert.ToString(solution));
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
