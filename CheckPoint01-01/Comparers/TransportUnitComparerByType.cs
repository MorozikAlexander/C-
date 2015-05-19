using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class TransportUnitComparerByType : IComparer<TransportUnit>
    {
        public int Compare(TransportUnit x, TransportUnit y)
        {
            return String.Compare(x.UnitKind.ToString(), y.UnitKind.ToString());
        }
    }
}
