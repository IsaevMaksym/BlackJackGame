using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    public class Player
    {
        IO io = new IO();

        #region Fields
        private string _name;       //Имя игрока
        private int _value;         //Колличество "очков" в руке игрока
        private int _winCount;      //Счётчик выигранных партий
        private int _gamesCount;    //Счётчик сыгранных партий        
        
        #endregion

        #region Incapsulation
        public int value
            {
                get { return _value; }
                set { _value = value; }
            }

        public string name
            {
                get { return _name; }
                set { _name = value; }
            }

        public int winCount
        {
            get { return _winCount; }
            set { _winCount = value; }
        }

        public int gamesCount
        {
            get { return _gamesCount; }
            set { _gamesCount = value; }
        }

        #endregion
        
        #region Functions

        public List<Card> GiveStartCards(CardSet deck)
        {
            List<Card> playerHand = new List<Card>();
            playerHand.Add(deck.GetCard());
            playerHand.Add(deck.GetCard());
            return playerHand;
        }                           //выдаёт стартовую "руку"

        public virtual void GetTheCard(ref List<Card> playerHand, CardSet deck){}


        public int GetPoints(List<Card> playerHand)
        {
            int points = 0;

            foreach (Card c in playerHand)
            {
                if ((int)c.valueOfCard > 10 && (int)c.valueOfCard != 14)
                {
                    points += 10;
                }
                else if ((int)c.valueOfCard==14)
                {
                    points += 11;
                }
                else
                {
                    points +=(int) c.valueOfCard;
                }
                
            }

            return points;
        }                               //Возвращает колличество очков с карт в руке

        public void ShowTheCard(List<Card> playerHand, Player pl, int compMove=0)
        {
            int move=0;
            
            foreach (Card c in playerHand)
            {
                io.DrawTheCard(c, move,compMove);
                move += 10;
                io.ShowTheValue(pl);
            }

        }             //Отображение карты и вызов метода отрисовки.

        #endregion
    }
}
