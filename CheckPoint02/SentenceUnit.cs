using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckPoint02
{
    public class SentenceUnit
    {
        public SentenceKind sentenseKind;
        public string text;
        public List<WordUnit> MyWords = new List<WordUnit>();

        public int Length
        {
            get { return text.Length; }
        }


        public SentenceUnit(string text1, SentenceKind kind)
        {
            text = text1;
            sentenseKind = kind;
        }

        public void Extract_Words()
        {

        }

    }
}
