using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Zahlensystemrechner
{
    public class BuildRectangle
    {
        public BuildRectangle()
        {

        }

        public void WriteRectangle(int coordX, int coordY, int width, int height)
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

        public void CreateWindowBorder()
        {
            int width = Console.WindowWidth;
            int x = 0, y = 0;
            int x2 = width / 3;
            int height = Console.WindowHeight - 2;

            for (int i = 0; i < 3; i++)
            {
                WriteRectangle(x, y, x2 - 2, height);
                x += x2;
            }
        }
    }
}

