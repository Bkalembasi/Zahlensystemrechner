using System;
using System.Collections.Generic;
using System.Text;
using Zahlensystemrechner;

namespace Zahlensystemrechner
{
    class Calculator
    {
        protected int width;
        protected int height;
        protected BuildRectangle outputWindow = new BuildRectangle();
        protected BuildRectangle buttons = new BuildRectangle();


        public Calculator()
        {
            this.Width = 120;
            this.Height = 30;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public void WriteCalculator(int width,int height)
        {
            WriteInputField(width, height);
            WriteNumberFields(width,height);
        }

        private void WriteInputField(int width,int height)
        {
            int coordX = width / 3 + 1;
            int coordY = 1;
            this.height = Convert.ToInt32(height * 0.1);
            this.width = Convert.ToInt32(width / 3 - 4);
            this.outputWindow.WriteRectangle(coordX, coordY, this.width, this.height);
        }

        private void WriteNumberFields(int width,int height)
        {
            int coordX = width / 3 + 2;
            int coordY = Convert.ToInt32(height * 0.1 + 3);
            this.width = Convert.ToInt32(((width-10) / 3)* 0.2);
            this.height = Convert.ToInt32((this.width * 0.25));
            List<string> numbers = new List<string>() {"Ans","(",")",":","7","8","9","x","4","5","6","-","1","2","3","+","0",".","+/-","="};
            int numbercounter = 0;
            int tempCoordX = 0;

            for (int i = 0; i < 5; i++)
            {
                tempCoordX = coordX;
                for (int j = 0; j < 4; j++)
                {
                    buttons.WriteRectangle(tempCoordX, coordY, this.width, this.height);
                    Console.SetCursorPosition(++tempCoordX, ++coordY);
                    Console.Write(numbers[numbercounter]);
                                   
                    tempCoordX += this.width + 2;
                    numbercounter++;
                    --tempCoordX;
                    --coordY;
                }
                coordY += this.height + 2;
            }
        }
    }
}
