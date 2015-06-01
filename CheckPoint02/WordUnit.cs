using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint02
{
    public class WordUnit : TextBaseUnit
    {
        public WordUnit(string word)
        {
            Text = word;
        }

        public int Length
        {
            get  { return Text.Length; }
        }
    }
}
