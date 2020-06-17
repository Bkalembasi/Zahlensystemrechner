using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zahlensystemrechner
{
    public class CalcInput
    {
        //Array der Eingabe
        private string[] inputArray;
        //Eine Kopie des Eingabearrays, in dem alle Zahlen ins Dezimalsystem umgewandelt werden
        private string[] calcArray;
        //Hat die Eingabe einen Fehler? (zB eine Binärzahl mit einer 3)
        private Boolean error = false;
        //Position des Eingabefehlers (Falls einer vorhanden ist)
        private int errorPosition = 0;
        private List<Number> numberList;

        public CalcInput(string input)
        {
            inputArray = SplitInput(input.ToUpper().Replace(":", "/"));
            calcArray = CreateCalcArray();
        }

        //Gebe das Dezimalarray für die Berechnung zurück
        public string[] GetCalcArray()
        {
            return calcArray;
        }

        //Gebe Error zurück
        public Boolean GetError()
        {
            return error;
        }

        //Gebe die Position des Eingabefehlers zurück
        public int GetErrorPosition()
        {
            return errorPosition;
        }

        //Spalte den eingegebenen Term bei jedem neuen Operator/jeder neuen Zahl auf
        //und speichere dieses in einem Array
        private string[] SplitInput(string input)
        {
            Regex regex = new Regex("(?<=[-+*/)(^])|(?=[-+*/)(^])");
            Regex filter = new Regex("[^0-9-+*/^HOB_)(.]");
            input = filter.Replace(input, "");
            String[] result = regex.Split(input);

            return result;
        }

        //Erstelle eine Kopie des Eingabearrays, in dem alle Zahlen ins Dezimalsystem umgewandelt sind
        private string[] CreateCalcArray()
        {
            string[] decArray = new string[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                Number number = new Number(inputArray[i]);
                if (!number.GetErrror())
                {
                    if (number.GetIsOperator())
                    {
                        decArray[i] = inputArray[i];
                    }
                    else
                    {
                        numberList.Add(number);
                        decArray[i] = number.GetDecNumber();
                    }
                }
                else
                {
                    error = true;
                    errorPosition = i;
                    break;
                }

            }
            return decArray;
        }
    }
}
