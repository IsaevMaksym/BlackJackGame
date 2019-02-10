using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public struct Card                //Inizialization of the card;
    {
        public int valueOFCard;
        public int cardNum;
        public string suit;    // !!! enum
        public string nameOfCard;   // !!! enum

        public static int GetValue(Card c)
        {
            int retVal = 0;

            //...

            return retVal;
        }
    }


}
