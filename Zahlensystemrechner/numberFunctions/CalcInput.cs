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
        //Das Array des eigentlichen Terms
        private string[] originArray;
        //Hat die Eingabe einen Fehler? (zB eine Binärzahl mit einer 3)
        private Boolean error = false;
        //Position des Eingabefehlers (Falls einer vorhanden ist)
        private int errorPosition = 0;
        //Liste, die alle generierten Zahlenobjekte enthält
        private List<Number> numberList;

        //Initialisiere die numberList, damit dort etwas gespeichert werden kann
        //Ersetze alle klein geschriebenen Buchstaben durch die Großen und ersetze ":" durch "/"
        //Splitte den String bei Zahlen und Operatoren und wandle alle Zahlen ins Dezimalsystem um
        public CalcInput(string input)
        { 
            numberList = new List<Number>();
            calcArray = SplitInput(input.ToUpper().Replace(":", "/"));
            originArray = calcArray;
            ReplaceCalcArray();
            if(calcArray[0] == "")
            {
                this.error = true;
            }
        }

        //Gebe das Dezimalarray für die Berechnung zurück
        public string[] GetCalcArray()
        {
            return calcArray;
        }

        //Gebe das Array der ursprünglichen Eingabe zurück
        public string[] GetOriginArray()
        {
            return originArray;
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

        //Ersetze die nicht Dezimalzahlen durch Zahlen des Dezimalsystem, die den gleichen Wert haben
        //Speichere die Zahlenobjekte in der numberList
        private void ReplaceCalcArray()
        {
            int operatorCounter = 0;
            int numberCounter = 0;
            int clampCounter = 0;
            for (int i = 0; i < calcArray.Length; i++)
            {
                //Generiere für jeden String ein Zahlenobjekt
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
                    //Falls das erstellte Zahlenobejekt kein Operator ist, speichere es in der numberList
                    //und tausche im Array die Zahl durch ihr Äquivalent im Dezimalsystem aus
                    if(!number.GetIsOperator())
                    {
                        numberCounter++;
                        operatorCounter = 0;
                        if (numberCounter < 2)
                        {
                            numberList.Add(number);
                            calcArray[i] = number.GetDecNumber();
                        }
                        else
                        {
                            this.error = true;
                            this.errorPosition = i;
                        }
                    }
                    else
                    {
                        if( calcArray[i] != "(" && calcArray[i] != ")")
                        {
                            numberCounter = 0;
                            operatorCounter++;

                            if(operatorCounter < 2 )
                            {
                                this.error = true;
                                this.errorPosition = i;
                            }
                        }
                        else
                        {
                            if( calcArray[i] == "(" )
                            {
                                clampCounter++;
                            }
                            else
                            {
                                clampCounter--;
                            }
                        }
                    }
                }

            }
            if(clampCounter != 0)
            {
                this.error = true;
                this.errorPosition = calcArray.Length - 1;
            }
        }
    }
}
