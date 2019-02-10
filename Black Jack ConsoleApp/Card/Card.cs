using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    abstract public class Card
    {
        public abstract CardValue valueOfCard { get; set; }
        public CardSuit suitOfCard { get; set; }

        

       
    }
}
