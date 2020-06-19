using System;
using System.Collections.Generic;
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
        }
    }
}
