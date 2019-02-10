using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public interface IAutentification
    {
        bool CheckPlayerNick(string nick);

        bool checkPlayerNickPass(string nick, string pass);

        void CreatePlayer(string nick, string pass);

        
    }
}
