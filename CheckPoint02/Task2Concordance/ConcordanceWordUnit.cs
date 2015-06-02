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
        public List<int> OnPages = new List<int>();

        public ConcordanceWordUnit(string word, int page) : base(word)
        {
            NumberOfEntries = 1;
            OnPages.Add(page);
            

        }
    }
}
