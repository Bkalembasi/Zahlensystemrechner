﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zahlensystemrechner
{
    class LeftInfoBox : Infobox
    {
        public LeftInfoBox ()
        {
            Init();
        }

        public override void Init()
        {
            this.width = Console.WindowWidth / 3 - 3;
            this.height = Convert.ToInt32(Console.WindowHeight * 0.9) - 2;
            this.coordX = 1;
            this.coordY = 1;
        }

        public void SaveAndClearInput(String input, bool error)
        {
            if (!error)
            {
                this.saveInput.Clear();
                this.saveInput.AddLast(input);
            }
            ClearBox();
        }
    }
}

