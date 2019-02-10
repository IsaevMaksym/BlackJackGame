using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abstract;

namespace BL
{
    class Player
    {
        public Player(string nick)
        {
            player.NickName = nick;
            _PlayerHand = new List<Cards>(8);
            player.PlayerID = Ipl.GetPlayerId(nick);
        }

        public int ID
        {
            get
            {
                return player.PlayerID;
            }
        }

        public void PutCard(Cards c)
        {
            _PlayerHand.Add(c);
        }

        public bool CheckPlayerHand()
        {
            bool _handNotFull = true;

            if (CountPoints >= 21)
            {
                _handNotFull = false;
            }
            return _handNotFull;
        }
        private bool IsBlackJack
        {
            get
            {
                bool OK = false;
                
                if ((_PlayerHand.Count==2) &&_PlayerHand[0].CardValue == 11 && _PlayerHand[1].CardValue == 11)
                {
                    OK = true;
                }
                return OK;
            }
        }
        public int CountPoints
        {
            get
            {
                int _hand = 0;
                if (IsBlackJack)
                {
                    _hand = 21;
                }
                else
                {
                    foreach (var card in _PlayerHand)
                    {
                        _hand += card.CardValue;
                    }
                }               

                return _hand;
            }
        }

        private List<Cards> _PlayerHand;

        IPlayer Ipl = new Validator();
        PLAYERS player = new PLAYERS();
    }
}
