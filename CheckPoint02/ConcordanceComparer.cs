using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    public class ConcordanceComparer : IComparer<ConcordanceWordUnit>
    {
        public int Compare(ConcordanceWordUnit x, ConcordanceWordUnit y)
        {
            return String.Compare(x.Text, y.Text);
        }
    }
}
