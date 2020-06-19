using System;
using System.Collections.Generic;
using System.Text;
using Zahlensystemrechner;

namespace Zahlensystemrechner
{
    class Infobox
    {
        int width;
        int coordX;
        int coordY;
        private int[] coords = new int[3];

        public Infobox(int width, int coordX, int coordY)
        {
            this.width = width;
            this.coordX = coordX;
            this.coordY = coordY;
        }

        public void InfoTextContent()
        {
            WriteInfoText("Zahlensystem-Rechner");
            WriteInfoText("Infos:");
            WriteInfoText("Im linken Drittel werden die Ergebnisse angezeigt");
            WriteInfoText("Im mittleren Drittel können Terme zum Berechnen eingegeben werden");
            WriteInfoText("Der Rechner beherrscht die Grundrechenarten + - / *");
            WriteInfoText("");
            WriteInfoText("Der Rechner beachtet Klammern und Punkt-vor-Strich");
            WriteInfoText("");
            WriteInfoText("Das Ergebnis wird mit Betätigen der Return- oder =-Taste berechnet und ausgegeben");
            WriteInfoText("");
            WriteInfoText("Zahlen der verschiedenen Zahlensysteme müssen mit dem zugehörigen Präfix gekennzeichnet werden:");
            WriteInfoText("Oktal: O_");
            WriteInfoText("Binär: B_");
            WriteInfoText("Hexadezimal: H_");
            WriteInfoText("Dezimal: ohne Präfix");
        }

        public void WriteInfoText(string s)
        {
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
            }
            coordY++;
        }
    }
}
