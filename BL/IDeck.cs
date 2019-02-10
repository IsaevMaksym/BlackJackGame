
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IDeck
    {
        bool IsDBCardsetExist();

        void PushDbCardSet();

        List<Cards> GetDeck(int size = 1);
    }
}
