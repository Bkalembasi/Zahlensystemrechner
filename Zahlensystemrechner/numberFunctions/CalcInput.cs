using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zahlensystemrechner
{
    public class CalcInput
    {
        //Eine Kopie des Eingabearrays, in dem alle Zahlen ins Dezimalsystem umgewandelt werden
        private string[] calcArray;
        //Hat die Eingabe einen Fehler? (zB eine Binärzahl mit einer 3)
        private Boolean error = false;
        //Position des Eingabefehlers (Falls einer vorhanden ist)
        private int errorPosition = 0;
        //Liste, die alle generierten Zahlenobjekte enthält
        private List<Number> numberList;

        public CalcInput(string input)
        {
            numberList = new List<Number>();
            calcArray = SplitInput(input.ToUpper().Replace(":", "/"));
            ReplaceCalcArray();
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
        private void ReplaceCalcArray()
        {
            for (int i = 0; i < calcArray.Length; i++)
            {
                Number number = new Number(calcArray[i]);
                number.SetIndex(i);
                //Falls das Zahlenobjekt nicht erstellt werden konnte, brich ab und merke dir die Stelle des Fehlers
                if (number.GetErrror())
                {
                    error = true;
                    errorPosition = i;
                    break;
                }
                else
                {
                    if(!number.GetIsOperator())
                    { 
                        numberList.Add(number);
                        calcArray[i] = number.GetDecNumber();
                    }
                }

            }
        }
    }
}
