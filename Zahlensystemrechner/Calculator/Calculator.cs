using System;
using System.Collections.Generic;
using System.Text;
using Zahlensystemrechner;

namespace Zahlensystemrechner
{
    class Calculator
    {
        public Calculator()
        {

        }
        public void WriteCalculator()
        {
            WriteInputField();
            WriteNumberFields();
        }

        private void WriteInputField()
        {
            int coordX = Console.WindowWidth / 3 + 1;
            int coordY = 1;
            int height = Convert.ToInt32(Console.WindowHeight * 0.1);
            int width = Convert.ToInt32(Console.WindowWidth / 3 * 0.9);

            BuildRectangle rec = new BuildRectangle();
            rec.writeRectangle(coordX, coordY, width, height);
        }

        private void WriteNumberFields()
        {
            int coordX = Console.WindowWidth / 3 + 2;
            int coordY = Convert.ToInt32(Console.WindowHeight * 0.1 + 3);
            int width = Convert.ToInt32(((Console.WindowWidth-10) / 3)* 0.2);
            int height = Convert.ToInt32((width * 0.25));

            for (int i = 0; i < 3; i++)
            {
                int tempCoordX = coordX;
                for (int j = 0; j < 4; j++)
                {
                    
                    BuildRectangle rec = new BuildRectangle();
                    Console.Write(height);
                    rec.writeRectangle(tempCoordX, coordY, width, height);
                    tempCoordX += width + 2;
                }
                coordY += height + 2;
                tempCoordX = coordX;
            }
        }

    }
}
