using System;
using System.Collections.Generic;
using System.Text;

namespace Zahlensystemrechner
{
    class LeftInfoBox : Infobox
    {
        public LeftInfoBox ()
        {
            this.width = Console.WindowWidth / 3 - 3;
        }

        public override void Init()
        {
            this.width = Console.WindowWidth / 3 - 3;
            this.coordX = 1;
            this.coordY = 1;
        }
    }
}

