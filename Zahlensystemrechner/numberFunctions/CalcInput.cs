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
            //Dient zu Splitten des Strings bei den Zeichen -, +. *, /, ), ( oder ^
            Regex regex = new Regex("(?<=[-+*/)(^])|(?=[-+*/)(^])");
            //Dient zum löschen aller Zeichen, die nicht 0,1,2,3,4,5,6,7,8,9,-,+,*,/,),(,^,A,B,C,D,E,F,G,H,O oder _ sind
            Regex filter = new Regex("[^0-9-+*/^ABCDEFHO_)(.]");
            //Lösche die Zeichen, die nicht im Filter vorhanden sind
            input = filter.Replace(input, "");
            //Splitte den String bei den im Regex gespeicherten Zeichen
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
                //Falls das Zahlenobjekt nicht erstellt werden konnte, brich ab, setze error = true und merke dir die Stelle des Fehlers
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
