using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
     public struct IOBlackJack
    {
         public static int Greatings()                                                                //Greating part of the game.
         {
             Console.Write("Enter please your name:");
             string name = "Player";
             name = Console.ReadLine();
             Console.Write("Hi {0},choose the number of opponents: ", name);
             int numberOFPlayers = 1;
             numberOFPlayers = GetNumber();
             return numberOFPlayers;
         }

         public static int GetNumber()                                                                  //Receive number from console.
         {
             int num;
             string s;
             do
             {
                 s = Console.ReadLine();
             } while (!int.TryParse(s, out num));
             return num;
         }

         public static void PlayerGetCard() 
         { 
             Console.Write("");
 
         }
    }
    
}
