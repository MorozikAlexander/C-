using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CheckPoint02
{
    public enum SentenceKind { declarative, question, exclamatory, unknown };

    public class Task1
    {
        List<SentenceUnit> MySentences = new List<SentenceUnit>();
        public string text;        
        public string sentence_separators = "([.!?]) ";
        
        
        public void SortSentencesByWordsCount()
        {
            if (MySentences.Count > 0)
            {
                IEnumerable<SentenceUnit> Result = from c in MySentences orderby c.MyWords.Count select c;
                Result.PrintSentences(true);





            }

            
        }

        public Task1(string input_text)
        {
            if (input_text.Length > 0)
            {
                text = input_text;
                PrepareText();
                Extract_Sentences();
                //Extract_Words();
                SortSentencesByWordsCount();
            }
        }


        
        public void Extract_Sentences()
        {
            string[] sentences = Regex.Split(text, sentence_separators);
            if (sentences.Length > 0)
                for (int i = 0; i < sentences.Length; i++)
                {
                    if (sentences[i].Length > 2)
                        if (sentences[i][sentences[i].Length - 1] == ' ')
                            sentences[i] = sentences[i].Remove(sentences[i].Length - 1, 1);
                    Console.WriteLine("[{2}:{0}]:{1}", sentences[i].Length, sentences[i],i);
                }

            Console.WriteLine(sentences.Length);

            if (sentences.Length>2)
            {
                int i = 0;
                while ((i + 1) <= (sentences.Length - 1))
                {
                    if (sentences[i].Length > 0)
                    {
                        switch (sentences[i+1][0])
                            {
                                case '.' :
                                    
                                    MySentences.Add (new SentenceUnit(sentences[i], SentenceKind.declarative));
                                    break;
                                    
                                case '!' :
                                    
                                    MySentences.Add (new SentenceUnit(sentences[i], SentenceKind.exclamatory));
                                    break;
                                    
                                case '?' :
                                    
                                    MySentences.Add (new SentenceUnit(sentences[i], SentenceKind.question));
                                    break;
                                    
                                default:
                                    
                                    MySentences.Add (new SentenceUnit(sentences[i], SentenceKind.unknown));
                                    break;
                                    
                            }                        
                    }
                    i += 2;                    
                }                
            }

            if (MySentences.Count > 0)
                foreach (SentenceUnit item in MySentences)
                {
                    Console.Write("[{0}]:{1}", item.text.Length, item.text);
                    switch (item.sentenseKind)  
                    {
                        case SentenceKind.declarative:
                            Console.WriteLine('.');
                            break;
                        case SentenceKind.question:
                            Console.WriteLine('?');
                            break;
                        case SentenceKind.exclamatory:
                            Console.WriteLine('!');
                            break;
                        case SentenceKind.unknown:
                            Console.WriteLine('#');
                            break;
                        default:
                            break;
                    }
                }

        }
         
         
        

        public void PrepareText()
        {
            if (text.Length > 0)
            {
                text = text.Replace("-\r\n", "");
                text = text.Replace("\r\n", " ");
                text = text.Replace('\t', ' ');
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
            }
        }
    }
}
