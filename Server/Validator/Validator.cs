using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Server
{
    public class Validator : IAutentification, ICardAction, IGame, IPlayer
    {

        #region IAutentification

        public bool CheckPlayerNick(string nick)
        {
            return cn.CheckPlayer(nick);
        }

        public bool checkPlayerNickPass(string nick, string pass)
        {
            bool isOk = false;

            if (!(String.IsNullOrWhiteSpace(nick)) && !(String.IsNullOrWhiteSpace(pass)))
            {
                isOk = cn.CheckPlayerPass(nick, pass);
            }

            return isOk;

        }

        void IAutentification.CreatePlayer(string nick, string pass)
        {

            cn.CreatePlayer(nick, pass);

        }

        #endregion

        #region ICardAction
        
         Cards ICardAction.GetNewCard(int ID)
        {
            if (ID == 0 || ID > 52)
            {
                return null;
            }
            else
            {
                return cn.GetCardPicture(ID);
            }


        }

        #endregion


        #region Igame
        void IGame.SaveGame(int playerID, int winner, string log)
        {
            cn.SaveGame(playerID, winner, log);
        }

        void IGame.UpdatePlayerStatistic(int playerID, int WinnerID)
        {
            cn.UpdatePlayer(playerID, WinnerID);


        }

        public int GetPlayerId(string Nick)
        {
            return cn.GetPLayerID(Nick);
        }
        #endregion


        //public void startNewGame(int playerID)
        //{
        //    cn.startNewGame(playerID);
        //}
        Connection cn = new Connection();
    }
}
