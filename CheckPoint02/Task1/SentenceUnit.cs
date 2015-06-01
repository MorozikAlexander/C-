using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckPoint02
{
    public class SentenceUnit
    {        
        private string _text;
        private static string _word_separators = " [-,:;] [-,:;] |[-,:;] [-,:;] | [-,:;] |[-,:;] |[-,:;] |[-,:;]| ";
        public List<WordUnit> Words = new List<WordUnit>();
        public SentenceKind SentenseKind;        

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
            Words.Clear();
            if (_text.Length > 0)
            {
                string[] words = Regex.Split(_text, _word_separators);
                if (words.Length > 0)
                    for (int i = 0; i < words.Length; i++)                        
                        Words.Add(new WordUnit(words[i]));                    
            }                
        }

        public int Length
        {
            get { return _text.Length + 1; }
        }

        public string Sentence
        {
            get
            {
                switch (SentenseKind)
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
            SentenseKind = kind;
        }
    }
}
