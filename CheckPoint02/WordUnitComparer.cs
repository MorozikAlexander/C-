using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    class WordUnitComparer : IComparer<WordUnit>
    {
        public int Compare(WordUnit x, WordUnit y)
        {
            return String.Compare(x.text, y.text);
        }
    }
}
