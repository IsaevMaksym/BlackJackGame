using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    public class User : Player
    {
        IO io = new IO();
        public override void GetTheCard(ref List<Card> playerHand, CardSet deck)
        {
            if (playerHand.Count >= 8)                          
            {
                io.ChangeForegroundColor(ConsoleColor.Red);
                Console.WriteLine("Ваша рука полная");
            }
            else
            {
                 playerHand.Add(deck.GetCard());   
            }          

        }


      
    }
}
