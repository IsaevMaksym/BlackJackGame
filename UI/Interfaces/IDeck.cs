using BlackJack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IDeck
    {

        List<Cards> GetDeck(int size = 1);
    }
}
