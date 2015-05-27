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
        public List<SentenceUnit> MyWords = new List<SentenceUnit>();


        public SentenceUnit(string text1, SentenceKind kind)
        {
            text = text1;
            sentenseKind = kind;
            MyWords = null;

        }

        public void Extract_Words()
        {

        }

    }
}
