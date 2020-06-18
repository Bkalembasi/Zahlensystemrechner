using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Zahlensystemrechner
{
    public class BuildRectangle
    {
        public BuildRectangle()
        {

        }

        public void writeRectangle(int coordX, int coordY, int width, int height)
        {
            string space = "";

            Console.SetCursorPosition(coordX, coordY);

            Console.Write("╔");
            //TOP
            for (int i = 0; i < width; i++)
            {
                space += " ";
                Console.Write("═");
            }

            Console.Write("╗" + "\n");
            coordY += 1;
            Console.SetCursorPosition(coordX, coordY);

            //LEFT & RIGHT?
            for (int i = 0; i < height; i++)
            {
                Console.Write("║" + space + "║" + "\n");
                coordY += 1;
                Console.SetCursorPosition(coordX, coordY);
            }

            Console.Write("╚");

            //BOTTOM
            for (int i = 0; i < width; i++)
            {
                Console.Write("═");
            }

            Console.Write("╝" + "\n");
        }

        public void createWindowBorder()
        {
            int width = Console.WindowWidth;
            int x = 0, y = 0, y2 = 0;
            int x2 = width / 3;
            int height = Console.WindowHeight - 2;

            for (int i = 0; i < 3; i++)
            {
                writeRectangle(x, y, x2 - 2, height);
                x += x2;
            }
        }

        public void writeInfoText()
        {
            int width = Console.WindowWidth;
            int coordX = width/3*2+1, coordY = 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.WriteLine("Zahlensystem-Rechner");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Infos:");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Der Rechner beherrscht die Grundrechenarten + - / *");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Der Rechner beachtet Klammern und Punkt-vor-Strich");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Das Ergebnis wird mit Betätigen der Return- oder =-Taste berechnet und ausgegeben");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Zahlen der verschiedenen Zahlensysteme müssen mit dem zugehörigen Präfix gekennzeichnet werden:");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Oktar: O_");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Binär: B_");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Hexadezimal: H_");
            Console.SetCursorPosition(coordX, coordY++);
            Console.WriteLine("Dezimal: ohne Präfix");
        }

    }
}

