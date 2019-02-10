using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class PcPlayer
    {
        const int WIN_Points = 21;
        readonly int Hidden_Points;

        public PcPlayer()
        {
            fillDeck();
            Hidden_Points = HiddenPointSuggestion();
        }

        private int HiddenPointSuggestion()
        {
            int points=0;
            foreach (var card in _deck)
            {
                points += card.CardValue;
            }

            return points / _deck.Count();
        }

        public bool Think(List<Cards> _History)
        {

            
            bool CardNeeded = false;
            int point = GetPoints(_Hand);

            if (point ==0)
            {
                CardNeeded = true;                
                return CardNeeded;
            }
                      
            DeleteCards(_History);

            if (GetСhance(point)>=30.0)
            {
                CardNeeded = true;
            }
            
            return CardNeeded;
        }

        double GetСhance(int points)
        {            
            int count = 0;

            int Point_Needed = WIN_Points - points-Hidden_Points;

            if (Point_Needed<=0)
            {
                return 0;
            }

            foreach (var card in _deck)
            {
                if (card.CardValue<= Point_Needed)
                {
                    count++;
                }
            }
            
            return (count/ _deck.Count)*100;
        }

        int GetPoints(List<Cards> _PCHand)
        {
            int points = 0;

            foreach (var card in _PCHand)
            {
                points += card.CardValue;
            }
            return points;
        }

        void DeleteCards(List<Cards> _History)
        {
            foreach (var item in _History)
            {
                for (int i = 0; i < _deck.Count; i++)
                {
                    if (_deck[i].CardID == item.CardID)
                    {
                        _deck.Remove(_deck[i]);
                    }
                }

            }
        }

        void fillDeck()
        {
            _deck = connection.GetDeck();
        }

        public void getFirstCard(Cards c)
        {
            _hiddenCard = c;
        }

        public void putinHand(Cards c)
        {
            _Hand.Add(c);
        }

        public int getHandPoints
        {
            get
            {
                int points = 0;

                points += _hiddenCard.CardValue;

                foreach (var item in _Hand)
                {
                    points += item.CardValue;
                }

                return points;
            }
        }


        IDeck connection = new Connection();
        // private  List<Cards> LEFtCards = new List<Cards>();
        private List<Cards> _deck = new List<Cards>();

        private Cards _hiddenCard = new Cards();

        private List<Cards> _Hand = new List<Cards>();
    }
}

