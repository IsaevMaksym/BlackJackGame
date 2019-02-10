using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FinalExam_Part2
{
    public class Comp : Player
    {
        private string _name = "Жулик";

        public void Play(Comp AI ,List<Card> compHand, List<Card> playerHand, CardSet deck, User player)
        {
            compHand = AI.GiveStartCards(deck);

            AIPlay(AI, compHand, playerHand, deck, player);

        }          //Получение ПК стартовой руки

        private void AIPlay(Comp AI, List<Card> compHand, List<Card> playerHand, CardSet deck, User player)
        {
            AI.value = AI.GetPoints(compHand);

            Console.SetCursorPosition(1, 14);
            Console.WriteLine("{0} получает карты:", _name);
            AI.ShowTheCard(compHand, player,13);

            Console.SetCursorPosition(1, 23);
            Console.WriteLine("{0} думает...", _name);
            System.Threading.Thread.Sleep(2000);


            if (AIThinking(AI, compHand, playerHand, player))
            {
                compHand.Add(deck.GetCard());
                AI.AIPlay(AI, compHand, playerHand, deck, player);
            }
            else
            {
                AI.value = AI.GetPoints(compHand);

                Console.SetCursorPosition(1, 14);
                Console.WriteLine("{0} получает карты:", _name);
                AI.ShowTheCard(compHand,player, 13);

                Console.SetCursorPosition(1, 23);
                Console.WriteLine("{0} больше не хочет брать!", _name);
            }
            
        }       //Реализация мышления ПК

        private static bool AIThinking(Comp AI,List<Card> compHand, List<Card> playerHand,User player) 
        {
            bool ok = false;

            if ((AI.value < player.value) && (player.value<=21))
            {
                ok = true;
            }
            
            return ok;

        }           //Функция определяющая нужна ли ПК ещё карта

    }
}
