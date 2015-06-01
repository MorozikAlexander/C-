using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    public class ConcordanceWordUnit : WordUnit
    {
        public int NumberOfEntries;
        public int[] OnPages;

        public ConcordanceWordUnit(string word) : base(word)
        {
            NumberOfEntries = 0;
            OnPages = null;
        }
    }
}
