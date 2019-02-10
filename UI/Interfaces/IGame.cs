using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IGame
    {
       void SaveGame(int playerID, int winner, string log);

        void UpdatePlayerStatistic(int playerID, int WinnerID);
    }
}
