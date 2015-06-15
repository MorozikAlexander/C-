using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class TerminalUnit
    {        
        private event EventHandler<CallTerminalEventArgs> OnCall;
        private event EventHandler<RegisterTermianlEventArgs> OnRegisterTerminal;
        private event EventHandler<AnswerTerminalEventArgs> OnAnswer;
        private event EventHandler<EndCallTerminalEventArgs> OnEndCall;

        public int AbonentNumber;
        public ContractUnit Contract;
        public PortUnit LinkOnATSPort;

        public TerminalUnit(out string message, int number, ContractUnit contract, ATSUnit ats)
        {
            AbonentNumber = number;
            Contract = contract;            
            OnRegisterTerminal += ats.SomeTerminalRegister;
            if (RegisterPortOnATS(out message))
            {
                OnCall += ats.SomeTerminalCall;
                OnAnswer += ats.SomeTerminalAnswer;
                OnEndCall += ats.SomeTerminalEndCall;
            }
        }

        public void Call(out string result, int call_number, DateTime start_call_time)
        {
            if (call_number == AbonentNumber)
                result = "Звонок самому себе!";
            else if (OnCall != null)
            {
                if (LinkOnATSPort.PortStatus == PortStatusEnum.ON)
                {
                    CallTerminalEventArgs eventargs = new CallTerminalEventArgs(call_number, start_call_time);
                    OnCall(this, eventargs);
                    result = eventargs.ResultOperationMessage;
                }
                else result = "Терминал не готов звонить!";
            }
            else result = "Терминал не зарегистрирован!";
        }

        public void Answer(out string result, DateTime answer_call_time)
        {
            if ((LinkOnATSPort != null) && (OnAnswer != null))
            {
                if (LinkOnATSPort.PortStatus == PortStatusEnum.WAIT_FOR_ANSWER)
                {
                    AnswerTerminalEventArgs eventargs = new AnswerTerminalEventArgs(answer_call_time);
                    OnAnswer(this, eventargs);
                    result = eventargs.ResultOperationMessage;
                }
                else result = "Никто не звонит что бы отвечать!";
            }
            else result = "Терминал не зарегистрирован!";
        }

        public void EndCall(out string result, DateTime end_call_time)
        {
            if ((LinkOnATSPort != null) && (OnEndCall != null))
            {
                if (LinkOnATSPort.PortStatus == PortStatusEnum.BUSY)
                {
                    EndCallTerminalEventArgs eventargs = new EndCallTerminalEventArgs(end_call_time);
                    OnEndCall(this, eventargs);
                    result = eventargs.ResultOperationMessage;
                }
                else result = "Абонент не разговаривает - некого отключать!";
            }
            else result = "Терминал не зарегистрирован!";
        }

        public void On()
        {
            if (LinkOnATSPort != null)
                if (LinkOnATSPort.PortStatus == PortStatusEnum.OFF)
                    LinkOnATSPort.PortStatus = PortStatusEnum.ON;
        }

        public void Off()
        {
            if (LinkOnATSPort != null)
                if (LinkOnATSPort.PortStatus == PortStatusEnum.ON)
                    LinkOnATSPort.PortStatus = PortStatusEnum.OFF;
        }

        private bool RegisterPortOnATS(out string result)
        {            
            if (OnRegisterTerminal != null)
            {
                RegisterTermianlEventArgs eventargs = new RegisterTermianlEventArgs();
                OnRegisterTerminal(this, eventargs);
                if (eventargs.ResultPort != null)
                {
                    LinkOnATSPort = eventargs.ResultPort;
                    result = eventargs.ResultOperationMessage;
                    return true;
                }
                else
                {
                    LinkOnATSPort = null;
                    result = eventargs.ResultOperationMessage;
                    return false;
                }
            }
            else
            {
                LinkOnATSPort = null;
                result = "Терминал не привязан к АТС!";
                return false;
            }
        }
    }
}
