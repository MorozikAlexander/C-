using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01
{
    public class TransportUnitComparerByID : IComparer<TransportUnit>
    {
        public int Compare(TransportUnit x, TransportUnit y)
        {
            if (x != null && y != null)
            {
                if (x.ID > y.ID)
                {
                    return 1;
                }
                else
                {
                    return (x.ID == y.ID) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
