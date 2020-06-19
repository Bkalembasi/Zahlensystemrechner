﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zahlensystemrechner
{
    class RightInfoBox : Infobox
    {
        public RightInfoBox ()
        {
            Init();
        }

        public override void Init()
        {
            this.width = Console.WindowWidth / 3 - 3;
            this.coordX = Console.WindowWidth / 3 * 2 + 1;
            this.coordY = 1;
        }
    }
}
