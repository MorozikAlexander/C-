using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CheckPoint02
{
    public class Task1
    {
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
                    Console.WriteLine("[{0}]:{1}", sentences[i].Length, sentences[i]);
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

                while ((text.Contains("  ")) && (text.Length > 0))
                {
                    text = text.Replace("  ", " ");
                    
                }

                if (text[0] == ' ')
                    text = text.Remove(0, 1);




                Console.WriteLine("PREPARE*TEXT**********************TEXT*AFTER:");
                Console.WriteLine("{0}:{1}", text, text.Length);
                Console.WriteLine("************************************");




                
            }

        }



    }
}
