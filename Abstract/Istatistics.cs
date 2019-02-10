using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface Istatistics
    {
        int playerStats( string PLayerName, out double winrate);

    }
}
