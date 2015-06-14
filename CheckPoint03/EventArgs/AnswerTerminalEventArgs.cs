using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class AnswerTerminalEventArgs : EventArgs
    {
        public DateTime AnswerCallTime;
        public string ResultOperationMessage;

        public AnswerTerminalEventArgs(DateTime answer_call_time)
        {            
            AnswerCallTime = answer_call_time;

        }
    }
}
