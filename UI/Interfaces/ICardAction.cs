using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Model;

namespace BlackJack
{
    interface ICardAction
    {

        Cards GetNewCard(int ID);
        
    }
}
