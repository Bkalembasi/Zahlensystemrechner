using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Zahlensystemrechner
{
    public class BuildRectangle
    {
        int width;
        int height;

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public BuildRectangle()
        {
            this.width = 120;
            this.height = 30;
        }

        public void WriteRectangle(int coordX, int coordY, int width, int height)
        {
            if (coordX > Console.WindowWidth || coordY > Console.WindowHeight)
            {
                return;
            }
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

        public void CreateWindowBorder(int width, int height)
        {
            this.width = width;
            int x = 0, y = 0;
            int x2 = this.width / 3;
            this.height = height - 2;

            for (int i = 0; i < 3; i++)
            {
                WriteRectangle(x, y, x2 - 2, this.height);
                x += x2;
            }
        }
    }
}

