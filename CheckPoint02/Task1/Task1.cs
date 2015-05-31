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

        public string ReplaceSentenceWordsBySubStr(SentenceUnit Sentence, int WordLength, string SubStr)
        {
            if ((Sentence != null) && (Sentence.MyWords.Count >= 1))
            {
                string text = Sentence.Sentence;
                foreach (WordUnit Word in Sentence.MyWords)
                    if (Word.Length == WordLength)             
                            text = text.Replace(Word.text, SubStr);
                return text;
            }
            else return "";
        }        

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
                string TextResult;
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
                        TextResult = text.DeleteAllWordsStartConsonant(MySentences, selector).PrepareText();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(TextResult);                        
                    }
                } while (selector >= 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Задание 1-4: В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова:");
                Console.WriteLine("Количество предложений:{0}.", MySentences.Count);
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < MySentences.Count; i++)
                    Console.WriteLine("[{0}]:{1}", i+1, MySentences[i].Sentence);
                int SentenseIndex, WordLength;
                string SubStr;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите номер предложения:");
                SentenseIndex = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите длину заменяемых слов:");
                WordLength = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите заменяющую подстроку:");
                SubStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Изначальное предложение №{0}:{1}", SentenseIndex, MySentences[SentenseIndex - 1].Sentence);
                TextResult = ReplaceSentenceWordsBySubStr(MySentences[SentenseIndex - 1], WordLength, SubStr);
                Console.WriteLine("Результат:{0}", TextResult);                                
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
