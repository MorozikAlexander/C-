using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CheckPoint02
{
    public enum SentenceKind { declarative, question, exclamatory, unknown };// . ? !

    public class Task1
    {
        List<SentenceUnit> MySentences = new List<SentenceUnit>();
        public string text;
        //string sentence_separators = "([.] .)|([!] .)|([?] .)";
        string sentence_separators = "([.!?]) ";
        //string[] sentences;

        public Task1(string input_text)
        {
            if (input_text.Length > 0)
            {
                text = input_text;
                PrepareText();
                Extract_Sentences();
            }
        }

        public void Extract_Sentences()
        {
            string[] sentences = Regex.Split(text, sentence_separators);
            if (sentences.Length > 0)
                for (int i = 0; i < sentences.Length; i++)
                {                    
                    Console.WriteLine("[{2}:{0}]:{1}", sentences[i].Length, sentences[i],i);
                }

            Console.WriteLine(sentences.Length);                    
        }

        public void PrepareText()
        {
            if (text.Length > 0)
            {
                Console.WriteLine("PREPARE*TEXT**********************TEXT*BEFORE:");
                Console.WriteLine("{0}:{1}", text, text.Length);
                Console.WriteLine("************************************");
                

                text = text.Replace("\r\n", " ");
                text = text.Replace('\t', ' ');
                //text = string.Concat(text, ' ');

                while ((text.Contains("  ")) && (text.Length > 0))
                {
                    text = text.Replace("  ", " ");
                    
                }

                while ((text.Contains("..")) && (text.Length > 0))
                {
                    text = text.Replace("..", ".");

                }

                while ((text.Contains("!!")) && (text.Length > 0))
                {
                    text = text.Replace("!!", "!");

                }

                while ((text.Contains("??")) && (text.Length > 0))
                {
                    text = text.Replace("??", "?");

                }

                while ((text[0] == ' ') || (text[0] == '!') || (text[0] == '.') || (text[0] == ',') || (text[0] == '?'))
                    text = text.Remove(0, 1);

                while (text[text.Length - 1] == ' ')
                    text = text.Remove(text.Length - 1, 1);

                if ((text[text.Length - 1] == '.') || (text[text.Length - 1] == '!') || (text[text.Length - 1] == '?'))
                    text = string.Concat(text, ' ');
                else
                    text = string.Concat(text, ". ");





                Console.WriteLine("PREPARE*TEXT**********************TEXT*AFTER:");
                Console.WriteLine("{0}:{1}", text, text.Length);
                Console.WriteLine("************************************");




                
            }

        }



    }
}
