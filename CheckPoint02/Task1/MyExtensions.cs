using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    static class MyExtensions
    {
        public static void PrintSentences(this IEnumerable<SentenceUnit> Sentences, bool ifPrintWords)
        {
            if ((Sentences != null) && (Sentences.Count<SentenceUnit>() > 0))
            {                
                foreach (SentenceUnit item in Sentences)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[{0}]:{1}", item.MyWords.Count, item.Sentence);
                    if (ifPrintWords) item.PrintWords();
                    Console.WriteLine();
                }
            }
        }

        public static void PrintWords(this SentenceUnit Sentence)
        {
            if ((Sentence != null) && (Sentence.MyWords.Count > 0))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Words: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (WordUnit item in Sentence.MyWords)
                {
                    Console.Write(item.text + ' ');                    
                }
            }
        }
    }
}
