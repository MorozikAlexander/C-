using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckPoint02
{
    public class ConcordanceUnit
    {
        private List<ConcordanceWordUnit> _concordance = new List<ConcordanceWordUnit>();
        private static string _word_separators = " [-,:;.!?()] [-,:;.!?()] |[-,:;.!?()] [-,:;.!?()] | [-,:;.!?()] |[-,:;.!?()] | [-,:;.!?()]|[-,:;!?()]| ";

        public ConcordanceUnit(string InputFilePath, string OutputFilePath, int StringsOnPage)
        {
            string line;
            int counter_line = 1;
            int current_page = 1;
            System.IO.StreamReader source_file = new System.IO.StreamReader(InputFilePath);
            string[] words;
            int finded, index;
            System.Console.WriteLine("Пошел процесс....Ждите!");
            while ((line = source_file.ReadLine()) != null)
            {
                line = line.PrepareTextForConcordance();
                if (line != "")
                {                    
                    words = Regex.Split(line, _word_separators);
                    if (words.Length > 0)
                        foreach (string item in words)
                            if (item != "")
                                    if (_concordance.Count > 0)
                                    {
                                        finded = -1;
                                        index = 0;
                                        while ((finded == -1) && (index <= _concordance.Count - 1))
                                            if (_concordance[index].Text == item)
                                                finded = index;
                                            else
                                                index++;
                                        if (finded == -1)
                                            _concordance.Add(new ConcordanceWordUnit(item, current_page));
                                        else
                                        {
                                            _concordance[index].NumberOfEntries++;
                                            if (!_concordance[index].OnPages.Contains(current_page))
                                                _concordance[index].OnPages.Add(current_page);
                                        }
                                    }
                                    else _concordance.Add(new ConcordanceWordUnit(item, current_page));                                                    
                    if ((counter_line % StringsOnPage) == 0)                       
                        current_page++;
                    counter_line++;                    
                }                
            }
            source_file.Close();
            _concordance.Sort(new ConcordanceComparer());
            using (System.IO.StreamWriter result_file = new System.IO.StreamWriter(OutputFilePath))
            {
                string general_char = ((_concordance[0].Text[0]).ToString()).ToUpper();
                result_file.WriteLine("{0}:", general_char);
                foreach (ConcordanceWordUnit item in _concordance)
                {
                    if (general_char != ((item.Text[0]).ToString()).ToUpper())
                    {
                        general_char = ((item.Text[0]).ToString()).ToUpper();
                        result_file.WriteLine("{0}:", general_char);
                    }
                    result_file.Write("{0,20} {1,1}:",item.Text, item.NumberOfEntries);
                    foreach (int Page in item.OnPages)
                        result_file.Write("{0},", Page);
                    result_file.WriteLine();
                }
            }
            Console.WriteLine("Обработано {0} строк, {1} страниц.", counter_line, current_page);
        }
    }
}
