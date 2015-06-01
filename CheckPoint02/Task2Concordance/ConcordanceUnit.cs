using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint02
{
    public class ConcordanceUnit
    {
        private List<ConcordanceWordUnit> _words = new List<ConcordanceWordUnit>();
        public ConcordanceUnit(string InputFilePath, string OutputFilePath)
        {
            string line;
            int counter = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(InputFilePath);
            while ((line = file.ReadLine()) != null)
            {
                line = line.PrepareText();
                if (line != "")
                {
                    System.Console.WriteLine(line);
                    counter++;                    
                }
                    
                
            }
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
        }
    }
}
