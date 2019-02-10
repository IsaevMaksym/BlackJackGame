using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    public class BL
    {
        ConsoleKey key;
        IO Io = new IO();

        #region ==========Main Game==========
        public void Run(User Gamer, Comp AI)
        {
            Io.ChangeBackgroungColor(ConsoleColor.Black);
            Gamer.name = Io.GameStart();
            do
            {
                key = Io.Menu(Gamer.name);

                ChooseTheWay(key, Gamer);
            } while (key != ConsoleKey.Escape);
        }
        
        public void ChooseTheWay(ConsoleKey key, User Gamer)
        {
            switch (key)
            {

                case ConsoleKey.D1:
                    Io.Rules();
                    Console.ResetColor();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine(" ");
                    PlayTheGame(Gamer);
                    break;
                case ConsoleKey.D3:
                    Io.Statistic(Gamer);
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }

        public void PlayTheGame(User Player)
        {
            Console.Clear();

            List<Card> playerHand = new List<Card>();
            List<Card> compHand = new List<Card>();

            CardSet deck = new CardSet();

            deck.FillTheDeck();

            #region ==========Выдача стартовых карт==============

            playerHand = Player.GiveStartCards(deck);         //Даёт игроку первые 2 карты.
            Player.value = Player.GetPoints(playerHand);

            Console.SetCursorPosition(0,0);
            Console.WriteLine("Вот твои Карты:");

            Player.ShowTheCard(playerHand, Player);
            CheckValue(Player);

            #endregion

            #region ==========Получение следующей карты==========
            
            GetCards(Player, playerHand, deck);

            for (int i =2; i < 30; i++)
			{
			  Console.SetCursorPosition(i, 10);
              Console.WriteLine(" ");
			}

            Console.SetCursorPosition(0, 12);
            Console.WriteLine(" ");
            


            #endregion

            #region ==========Игра Компа==================

            Comp AI = new Comp();            
            
            AI.Play(AI,compHand, playerHand, deck,Player);

            WhoWon(Player, AI);

            Console.ReadKey();

            #endregion



        }
        #endregion

        #region ==========Additional Functions==========
        private void GetCards(User Player, List<Card> playerHand, CardSet deck)
        {
            bool oK = true;
            
            do
            {
                key = WantACard();
                if ((key == ConsoleKey.Y)&&(Player.value<21))
                {
                    playerHand.Add(deck.GetCard());                    
                    Player.value = Player.GetPoints(playerHand);
                    CheckValue(Player);
                    Player.ShowTheCard(playerHand,Player);
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Вот твои Карты:");

                    Player.ShowTheCard(playerHand,Player);

                    oK = false;
                }
            } while (oK);
         }                       

        private bool CheckValue(User Player)
        {            

            bool oK = false;

            if (Player.value > 21)
            {
                Console.SetCursorPosition(2, 11);
                Io.ChangeBackgroungColor(ConsoleColor.DarkGray);
                Io.ChangeForegroundColor(ConsoleColor.Red);
                Console.WriteLine(" ТЫ перебрал! Нажми Y ");

                Io.ChangeBackgroungColor(ConsoleColor.Black);
                Io.ChangeForegroundColor(ConsoleColor.Gray);                
                oK = false;
            }
            return oK;
        }


        private ConsoleKey WantACard()
        {
            Console.SetCursorPosition(2, 10);         

            Console.Write("Желаете ещё карту(y/n)? ");
            do
            {
                Console.SetCursorPosition(25, 10);
                Console.Write(' ');
                Console.SetCursorPosition(25, 10);

                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Y && key != ConsoleKey.N);

            return key;
        }

        public void WhoWon(User player, Comp AI)
        {
                                                 //если True то победил игрок, Если False, То победил Жулик
            if ((player.value > AI.value) && (player.value <= 21) || (AI.value>21))
            {
                player.winCount++;
                player.gamesCount++;
                Io.Winner(1);
            }
            else if ((player.value == AI.value) && (player.value <= 21))
            {
                player.gamesCount++;
                Io.Winner(2);
            }
            else
            {
                player.gamesCount++;
                Io.Winner(3);
            }


        }
        #endregion
    }
}