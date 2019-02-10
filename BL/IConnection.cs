using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IConnection
    {
        bool CheckPlayer(string nick);

        bool CheckPlayerPass(string nick, string pass);

        Cards GetCardPicture(int id);

        void SaveGame(int playerID, int winner, string log);

        void CreatePlayer(string nick, string pass);

        int GetPLayerID(string NIck);

        void UpdatePlayer(int playerID, int WinnerID);

        int getStatistic(string NIck, out double winrate);

    }

}
