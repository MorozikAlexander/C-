using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint02
{
    public class WordUnit : Unit
    {
        public WordUnit(string word)
        {
            text = word;
        }

        public int Length
        {
            get  { return text.Length; }
        }
    }
}
