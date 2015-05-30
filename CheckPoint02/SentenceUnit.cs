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

        public string Sentence
        {
            get
            {
                switch (sentenseKind)
                {
                    case SentenceKind.declarative:
                        return text + '.';
                        break;
                    case SentenceKind.question:
                        return text + '?';
                        break;
                    case SentenceKind.exclamatory:
                        return text + '!';
                        break;
                    case SentenceKind.unknown:
                        return text + '.';
                        break;
                    default:
                        return text + '.';
                        break;
                }
            }
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
