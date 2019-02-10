﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Model;

namespace BlackJack
{
    interface IGamelogic

    {
        void StartNewGame();

        byte[] GetCard();

        //bool PCNeedCard();

        //bool PlayerNeedCard();

        //byte[] GetPCCard();

        //byte[] GetHiddenCard();

        //int GetWinner();
    }
}
