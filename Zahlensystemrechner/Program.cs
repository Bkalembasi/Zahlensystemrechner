using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;

namespace Zahlensystemrechner
{
    class Programm
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        bool windowChanged = true;

        protected Infobox inf = new RightInfoBox();
        protected InputField inputField = new InputField();
        protected LeftInfoBox solField = new LeftInfoBox();

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
                term = term.ToUpper();
                AnsFunction(ref term);

                CalcInput calc = new CalcInput(term);
                BasicCalc startCalc = new BasicCalc();
              
                String output = "";
                if(calc.GetError()) {
                    output = createErrorString(calc);
                }
                else {
                    String[] dezArray = calc.GetCalcArray();
                    long solution = startCalc.GetSolution(dezArray);

                    Number solNumber = new Number();
                    solNumber.SetDecNumber(solution);
                    output = System.Convert.ToString(solution);
                }
                solField.SaveAndClearInput(output, calc.GetError());
                solField.WriteInfoText(output);     
                //TODO Ausgabe 
                //Ausgabe am besten durch die Variable output. Andernfalls Rückgabewert der createErrorString Methode bearbeiten etc
            }
        }
      
        private String createErrorString(CalcInput calc) {
            String errorString = "";
            int errorPosition = calc.GetErrorPosition();
            String errorInput = calc.GetOriginArray()[errorPosition];
            errorString += "Fehler bei der Eingabe: " + errorInput + " ";
            errorString += "Vollständiger Term: ";
            foreach(string str in calc.GetOriginArray()) {
              errorString += str + " ";
            }
            return errorString;
        }
  
        private void AnsFunction(ref String term)
        {
            if (term.Contains("ANS"))
            {
                LinkedList<string> lastEntry = solField.SaveInput;
                
                if (lastEntry.Count > 0)
                {
                    var entry = lastEntry.Last;
                    term = term.Replace("ANS", entry.Value);
                } else
                {
                    //Schrei rum weil Fehler
                }
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
