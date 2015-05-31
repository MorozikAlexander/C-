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
        

        public Task1(string input_text)
        {
            if (input_text.Length > 0)
            {                
                text = input_text;
                text = text.PrepareText();
                Extract_Sentences();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Задание 1-1: Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них:");
                MySentences.SortSentencesByWordsCount().PrintSentences(false);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Задание 1-2: Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины:");
                Console.WriteLine("Все вопросительные предложения:");
                MySentences.SelectQuestionSentences().PrintSentences(true);
                int selector;                
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;                    
                    selector = 1;
                    try
                    {
                        Console.Write("Какая длина слов вас интересует(< 1 -выход, >= 1 - выполнение):");
                        selector = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {                        
                        Console.WriteLine("!Ошибка:{0}:вводите целые числа!", e.Message);                        
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    if (selector >= 1)
                    {
                        Console.Write("Результат:");
                        MySentences.SelectQuestionSentences().SelectWordsByLengthInSentences(selector).PrintWordsInList();
                        Console.WriteLine();
                    }                    
                } while (selector >= 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Задание 1-3: Из текста удалить все слова заданной длины, начинающиеся на согласную букву:");
                Console.WriteLine("Весь текст:");
                MySentences.PrintSentences(false);
                Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    selector = 1;
                    try
                    {
                        Console.Write("Какая длина слов вас интересует(< 1 -выход, >= 1 - выполнение):");
                        selector = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("!Ошибка:{0}:вводите целые числа!", e.Message);
                    }
                    
                    if (selector >= 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Результат:");
                        string RR = text.DeleteAllWordsStartConsonant(MySentences, selector).PrepareText();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(RR);
                        
                    }
                } while (selector >= 1);

                                
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
                }            
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
        }        


    }
}
