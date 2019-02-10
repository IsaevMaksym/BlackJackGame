using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract;

namespace BL
{
    
    public class GameEngine
    {
        public GameEngine(string PlayerNick)
        {
            cardAction = new Validator();

            WinnerID = 0000;
            _History = new List<Cards>();
            IsCardFirst = true;
            player= new Player(PlayerNick);
        }

        public byte[] GetPlayerCard()
        {
            _card = dealer.GetCard();

            player.PutCard(_card);

            GameLog += "P" + _card.CardID.ToString();
            _History.Add(_card);

            return _card.Image;
        }

        public bool CheckPlayerHand()
        {
            return player.CheckPlayerHand();
        }

        public byte[] PCGetCard()
        {
            _card = dealer.GetCard();

            if (IsCardFirst)
            {
                IsCardFirst = false;

                PC.getFirstCard(_card);
                _HiddenCard = _card;
            }
            else
            {
                _History.Add(_card);
                PC.putinHand(_card);
            }

            GameLog += "A" + _card.CardID.ToString();
            return _card.Image;
        }

        public bool PCThink()
        {
            return PC.Think(_History);
        }

        public byte[] GetFirstCard()
        {
            return _HiddenCard.Image;
        }

        public int GetWiiner()
        {
            int playerWon = 2;            

            if ((player.CountPoints<=21)&&(PC.getHandPoints < player.CountPoints)       ||
                ((player.CountPoints > 21) && (PC.getHandPoints >= player.CountPoints))   )
            {
                 playerWon = 0;
                WinnerID = player.ID;
            }
            if ((player.CountPoints <= 21)&& (PC.getHandPoints == player.CountPoints))
            {
                WinnerID = player.ID;
                playerWon = 1;
            }

            SaveGame();
            return playerWon;
        }

        private void SaveGame()
        {
            Igame = new Validator();

            Igame.SaveGame(player.ID, WinnerID, GameLog);

            Igame.UpdatePlayerStatistic(player.ID, WinnerID);
        }
        
        PcPlayer PC = new PcPlayer();

        string GameLog;
        int WinnerID;
        bool IsCardFirst;
        Player player;
        ICardAction cardAction = new Validator();
        Dealer dealer = new Dealer();
        IGame Igame; 
        private List<Cards> _History;
        private Cards _card;
        private Cards _HiddenCard;
    }
}


