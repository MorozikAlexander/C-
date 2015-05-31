using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    static class MyExtensions
    {
        public static string PrepareText(this string text)
        {
            if (text.Length > 0)
            {
                text = text.Replace("-\r\n", "");
                text = text.Replace("\r\n", " ");
                text = text.Replace('\t', ' ');
                while (text.Contains(" ,")) text = text.Replace(" ,", ",");
                while (text.Contains("  ")) text = text.Replace("  ", " ");
                while (text.Contains("..")) text = text.Replace("..", ".");
                while (text.Contains("!!")) text = text.Replace("!!", "!");
                while (text.Contains("??")) text = text.Replace("??", "?");
                while (text[text.Length - 1] == ' ') text = text.Remove(text.Length - 1, 1);
                while ((text[0] == ' ') || (text[0] == '!') || (text[0] == '.') || (text[0] == ',') || (text[0] == '?'))
                    text = text.Remove(0, 1);
                if ((text[text.Length - 1] == '.') || (text[text.Length - 1] == '!') || (text[text.Length - 1] == '?'))
                    text = string.Concat(text, ' ');
                else
                    text = string.Concat(text, ". ");
                return text;
            }
            else return "";
        }

        public static string DeleteAllWordsStartConsonant(this string text, List<SentenceUnit> Sentences, int WordLength)
        {
            if ((text.Length > 1) && (Sentences.Count >= 1))
            {
                string consonant_letters = "QqWwRrTtPpSsDdFfGgHhKkLlZzXxCcVvBbNnMmЦцКкГгШшЩщЗзХхФфВвПпРрЛлДдЖжЧчСсМмТтБб";
                foreach (SentenceUnit Sentence in Sentences)                
                    if (Sentence.MyWords.Count >= 1)
                        foreach (WordUnit Word in Sentence.MyWords)
                            if (Word.Length == WordLength)
                                if ((consonant_letters.IndexOf(Word.text[0]) != -1) && (text.Contains(Word.text)))
                                    text = text.Replace(Word.text, "");                
                return text;
            }
            else return "";
        }

        public static List<WordUnit> SelectWordsByLengthInSentences(this List<SentenceUnit> Sentences, int WordLength)
        {
            if (Sentences.Count > 0)
            {
                List<WordUnit> Result = new List<WordUnit>();
                foreach (SentenceUnit item in Sentences)                
                    Result.AddRange(from c in item.MyWords where c.Length == WordLength select c);
                Result = (Result.GroupBy(w => w.text).Select(x => x.First())).ToList<WordUnit>();
                return Result;                
            }                
            else
                return null;
        }

        public static List<SentenceUnit> SelectQuestionSentences(this List<SentenceUnit> Sentences)
        {
            if (Sentences.Count > 0)
                return (from c in Sentences where c.sentenseKind == SentenceKind.question select c).ToList<SentenceUnit>();
            else
                return null;
        }

        public static List<SentenceUnit> SortSentencesByWordsCount(this List<SentenceUnit> Sentences)
        {
            if (Sentences.Count > 0)
                return (from c in Sentences orderby c.MyWords.Count select c).ToList<SentenceUnit>();
            else
                return null;
        }

        public static void PrintSentences(this IEnumerable<SentenceUnit> Sentences, bool ifPrintWords)
        {
            if ((Sentences != null) && (Sentences.Count<SentenceUnit>() > 0))
            {                
                foreach (SentenceUnit item in Sentences)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[{0}]:", item.MyWords.Count);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} ", item.Sentence);
                    if (ifPrintWords) item.PrintWordsInSentence();
                    Console.WriteLine();
                }
            }
        }

        public static void PrintWordsInSentence(this SentenceUnit Sentence)
        {
            if ((Sentence != null) && (Sentence.MyWords.Count > 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Words:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (WordUnit item in Sentence.MyWords)
                {
                    Console.Write('|' + item.text);                    
                }
                Console.Write('|');
            }
        }

        public static void PrintWordsInList(this List<WordUnit> Words)
        {
            if ((Words != null) && (Words.Count > 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Words:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (WordUnit item in Words)
                {
                    Console.Write('|' + item.text);
                }
                Console.Write('|');
            }
        }
    }
}
