using System;
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
            this.coordX = 1;
            this.coordY = 1;
        }

        public void SaveAndClearInput(String input)
        {
            this.saveInput.Clear();
            ClearBox();
            this.saveInput.AddLast(input);
        }
    }
}

