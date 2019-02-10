
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerABstract
{
    public interface IDeck
    {

        List<Cards> GetDeck(int size = 1);
    }
}
