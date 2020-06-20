using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zahlensystemrechner
{
    class InputField : Infobox
    {
        public InputField()
        {
            Init();
        }

        public override void Init()
        {
            this.width = Console.WindowWidth / 3 - 3;
            this.coordX = Console.WindowWidth / 3 + 2;
            this.coordY = 2;
            this.height = Convert.ToInt32(Console.WindowHeight * 0.1);

            SetCursorPosition();
        }

        public String ReadInput()
        {
            SetCursorPosition();
            while(true)
            {
                String input = Console.ReadKey().KeyChar.ToString();

                if (input.Equals("\r") || input.Equals("="))
                {
                    break;
                }

                if (input.Equals("\b"))
                {
                    if (saveInput.Count == width - 2)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + input);

                    saveInput.RemoveLast();
                } else
                {
                    if (saveInput.Count < width-2)
                    {
                        saveInput.AddLast(input);
                    } else
                    {
                        Console.Write("\b");
                        saveInput.RemoveLast();
                        saveInput.AddLast(input);
                    }
                }
            }
            ClearBox();
            String output = String.Join("", saveInput.ToArray());
            saveInput.Clear();
            return output;
        }
    }
}
