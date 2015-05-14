using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    class TransportUnitComparerByName : IComparer<TransportUnit>
    {
        public int Compare(TransportUnit x, TransportUnit y)
        {            
            return String.Compare(x.Name, y.Name);
        }
    }
}
