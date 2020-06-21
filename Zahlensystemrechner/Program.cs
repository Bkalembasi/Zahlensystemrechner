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
        bool allSolutions = false;

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
                String originInput = term;

                //Wenn nicht das Kürzel zum ändern der Ausgabemenge eingegeben wurde, berechne den Term
                if(ChangeSolutionNumber(term))
                {
                    //Falls kein ANS eingegeben wurde oder ANS eingegeben wurde, nachdem ein Ergebnis gespeichert wurde.
                    if(AnsFunction(ref term))
                    {
                        CalcInput calc = new CalcInput(term);
                        BasicCalc startCalc = new BasicCalc();
                        Number solNumber = new Number();

                        String output;
                        if (calc.GetError())
                        {
                            output = CreateErrorString(calc);
                        }
                        else
                        {
                            String[] dezArray = calc.GetCalcArray();
                            long solution = startCalc.GetSolution(dezArray);

                            solNumber.SetDecNumber(solution);
                            output = Convert.ToString(solution);
                        }
                        solField.SaveAndClearInput(output, calc.GetError());
                        solField.WriteInfoText("Eingabe: " + originInput, false);
                        solField.WriteInfoText(String.Join("", calc.GetCalcArray()) + "=", false);
                        solField.WriteInfoText(output, false);

                        if (this.allSolutions)
                        {
                            solNumber.ToOtherSystems();
                            WriteAllSolutions(solNumber);
                        }
                    }
                    //Falls ANS eingegeben wurde, obwohl noch keine erfolgreiche Berechnung durchgeführt wurde.
                    else
                    {
                        solField.SaveAndClearInput("", true);
                        solField.WriteInfoText("ANS nicht möglich, da kein Ergebnis gespeichert wurde.", false);
                    }
                }
                //Wenn das Kürzel zum Ändern des Ausgabesystems eingegeben wurde   
                else
                {
                    solField.SaveAndClearInput("", false);
                    String output;
                    if(this.allSolutions)
                    {
                        output = "Ausgabe zu allen Zahlensystemen geändert.";
                    }
                    else
                    {
                        output = "Ausgabe zu nur dezimal geändert.";
                    }
                    solField.WriteInfoText(output, false);
                }    
            }
        }
      
        private String CreateErrorString(CalcInput calc) {
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
  
        private bool ChangeSolutionNumber (String term)
        {
            if(term == "A")
            {
                this.allSolutions = !this.allSolutions;
                return false;
            }
            return true;
        }

        private void WriteAllSolutions(Number solNumber)
        {
            solField.WriteInfoText("Binär: " + solNumber.GetBinaryNumber(), false);
            solField.WriteInfoText("Oktal: " + solNumber.GetOctaNumber(), false);
            solField.WriteInfoText("Hexadezimal : " + solNumber.GetHexDecNumber(), false);
        }

        private bool AnsFunction(ref String term)
        {
            term = term.ToUpper();
            if (term.Contains("ANS"))
            {
                LinkedList<string> lastEntry = solField.SaveInput;
                
                if (lastEntry.Count > 0)
                {
                    var entry = lastEntry.Last;
                    term = term.Replace("ANS", entry.Value);
                    return true;
                } else
                {
                    return false;
                }
            }
            return true;
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
