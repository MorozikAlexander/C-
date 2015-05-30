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
        private string _text;
        public List<WordUnit> MyWords = new List<WordUnit>();
        public static string word_separators = " [-,:;] [-,:;] |[-,:;] [-,:;] | [-,:;] |[-,:;] |[-,:;] |[-,:;]| ";

        public string text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                Extract_Words();
            }
        }

        public void Extract_Words()
        {
            MyWords.Clear();
            if (_text.Length > 0)
            {
                string[] words = Regex.Split(_text, word_separators);
                if (words.Length > 0)
                    for (int i = 0; i < words.Length; i++)                        
                        MyWords.Add(new WordUnit(words[i]));                    
            }                
        }


        public int Length
        {
            get { return _text.Length; }
        }

        public string Sentence
        {
            get
            {
                switch (sentenseKind)
                {
                    case SentenceKind.declarative:
                        return _text + '.';
                        break;
                    case SentenceKind.question:
                        return _text + '?';
                        break;
                    case SentenceKind.exclamatory:
                        return _text + '!';
                        break;
                    case SentenceKind.unknown:
                        return _text + '.';
                        break;
                    default:
                        return _text + '.';
                        break;
                }
            }
        }

        public SentenceUnit(string text1, SentenceKind kind)
        {
            text = text1;
            sentenseKind = kind;
        }
    }
}
