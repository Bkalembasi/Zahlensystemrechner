using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zahlensystemrechner;

namespace Zahlensystemrechner
{
    abstract class Infobox
    {
        protected int width;
        protected int coordX;
        protected int coordY;
        protected int height;
        protected LinkedList<string> saveInput = new LinkedList<string>();

        public LinkedList<string> SaveInput { get => saveInput; set => saveInput = value; }

        public Infobox()
        {
        }

        public abstract void Init();

        public void InfoTextContent()
        {
            WriteInfoText("Zahlensystem-Rechner", false);
            WriteInfoText("Infos:", false);
            WriteInfoText("Im linken Drittel werden die Ergebnisse angezeigt", false);
            WriteInfoText("Im mittleren Drittel können Terme zum Berechnen eingegeben werden", false);
            WriteInfoText("Der Rechner beherrscht die Grundrechenarten + - / * ", false);
            WriteInfoText("", false);
            WriteInfoText("Der Rechner beachtet Klammern und Punkt-vor-Strich", false);
            WriteInfoText("", false);
            WriteInfoText("Das Ergebnis wird mit Betätigen der Return- oder =-Taste berechnet und ausgegeben", false);
            WriteInfoText("", false);
            WriteInfoText("Zahlen der verschiedenen Zahlensysteme müssen mit dem zugehörigen Präfix gekennzeichnet werden:", false);
            WriteInfoText("Oktal: O_", false);
            WriteInfoText("Binär: B_", false);
            WriteInfoText("Hexadezimal: H_", false);
            WriteInfoText("Dezimal: ohne Präfix", false);
        }

        public void ClearBox()
        {
            Init();
            SetCursorPosition();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    Console.Write(" ");
                }
                this.coordY++;
                SetCursorPosition();
            }
            Init();
        }

        public void PrintSavedInput()
        {
            Init();
            SetCursorPosition();
            String savedInput = String.Join("", saveInput.ToArray());
            int removeCharCount = WriteInfoText(savedInput, true);
            LeonStinkt(removeCharCount);
        }

        private void LeonStinkt(int removeCharCount)
        {
            for(int i = 0; i < removeCharCount; i++)
            {
                this.saveInput.RemoveLast();
            }
        }

        public void SetCursorPosition()
        {
            Console.SetCursorPosition(this.coordX, this.coordY);
        }

        public int WriteInfoText(string s, bool remRest)
        {
            bool hasWritten = false;
            int cutStringLength = 0;
            if (this.coordX > Console.WindowWidth || this.coordY > Console.WindowHeight)
            {
                return 0;
            }

            if (remRest)
            {
                if (s.Length >= width)
                {
                    String output = s.Substring(0, width - 1);
                    cutStringLength = s.Length - output.Length;
                    Console.Write(output);
                } else
                {
                    Console.Write(s);
                }
                return cutStringLength;
            } 
            int wordlength = 0;
            string[] words = s.Split(' ');

            Console.SetCursorPosition(this.coordX, this.coordY);

            for (int i = 0; i < words.Length; i++)
            {
                //+1 für Leerzeichen
                wordlength = wordlength + words[i].Length + 1;
                if (wordlength > width)
                {
                    wordlength = words[i].Length;
                    Console.SetCursorPosition(this.coordX, ++this.coordY);
                }
                Console.Write(words[i] + " ");
                hasWritten = true;
            }

            if (hasWritten)
            {
                this.coordY++;
            }
            return 0;
        }
    }
}
