using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract;
using BL;

namespace Controller
{
  
    public class GameCOntroller : IGamelogic
    {
        public GameCOntroller(string nick)
        {
            PlayerNick = nick;
        }

        public GameCOntroller()
        {
        }
                
        public void StartNewGame()
        {
            gameEngine = new GameEngine(PlayerNick);

        }
               
        byte[] IGamelogic.GetHiddenCard()
        {
            System.Threading.Thread.Sleep(1000);
           return gameEngine.GetFirstCard();


        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                returnImage = Image.FromStream(ms);

            }

            return returnImage;
        }

        public int GetWinner()
        {
            return gameEngine.GetWiiner();
        }

        byte[] IGamelogic.GetCard()
        {
           
               return gameEngine.GetPlayerCard();
           
        }

        public bool PCNeedCard()
        {
            System.Threading.Thread.Sleep(1000);
            return gameEngine.PCThink();
        }

        public bool PlayerNeedCard()
        {
            bool IsOk = true;

            if (!gameEngine.CheckPlayerHand())
            {
                IsOk = false;
            }

            return IsOk;
        }

        byte[] IGamelogic.GetPCCard()
        {

            return gameEngine.PCGetCard();

        }

        string PlayerNick;


        GameEngine gameEngine;       
    }
}
