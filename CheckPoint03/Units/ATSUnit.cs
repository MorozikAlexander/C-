using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class ATSUnit
    {
        public List<PortUnit> ATS_Ports = new List<PortUnit>();
        public List<BillingRecordUnit> Billing = new List<BillingRecordUnit>();

        public PortUnit AddPort(TerminalUnit terminal)
        {
            PortUnit creatingport = new PortUnit(terminal);
            ATS_Ports.Add(creatingport);
            return creatingport;
        }

        public void SomeTerminalRegister(object sender, RegisterTermianlEventArgs eventargs)
        {
            if (sender is TerminalUnit)
            {
                if (ATS_Ports.Count > 0)
                {
                    PortUnit checkport;
                    checkport = ATS_Ports.Find(x => x.Terminal.AbonentNumber == (sender as TerminalUnit).AbonentNumber);
                    if (checkport != null)
                    {
                        eventargs.ResultOperationMessage = Convert.ToString(checkport.Terminal.AbonentNumber) + " номер уже существует, терминал не зарегистрирован!";
                        eventargs.ResultPort = null;
                    }
                    else
                    {
                        eventargs.ResultPort = AddPort(sender as TerminalUnit);
                        eventargs.ResultOperationMessage = "Терминал с номером " + Convert.ToString(eventargs.ResultPort.Terminal.AbonentNumber) + " успешно зарегистрирован!";
                    }
                }
                else
                {
                    eventargs.ResultPort = AddPort(sender as TerminalUnit);
                    eventargs.ResultOperationMessage = "Терминал с номером " + Convert.ToString(eventargs.ResultPort.Terminal.AbonentNumber) + " успешно зарегистрирован!";
                }
            }
        }

        public void SomeTerminalEndCall(object sender, EndCallTerminalEventArgs eventargs)
        {
            if (sender is TerminalUnit)
                if ((sender as TerminalUnit).LinkOnATSPort.PortStatus == PortStatusEnum.BUSY)
                {
                    (sender as TerminalUnit).LinkOnATSPort.BillingRecord.EndCall = eventargs.EndCallTime;
                    Billing.Add((sender as TerminalUnit).LinkOnATSPort.BillingRecord);
                    (sender as TerminalUnit).LinkOnATSPort.BillingRecord.Terminal.LinkOnATSPort.PortStatus = PortStatusEnum.ON;
                    (sender as TerminalUnit).LinkOnATSPort.BillingRecord.toTerminal.LinkOnATSPort.PortStatus = PortStatusEnum.ON;
                    eventargs.ResultOperationMessage = "Звонок окончен!";
                }
                else eventargs.ResultOperationMessage = "Терминал не звонит!";
        }

        public void SomeTerminalAnswer(object sender, AnswerTerminalEventArgs eventargs)
        {
            if (sender is TerminalUnit)
                if ((sender as TerminalUnit).LinkOnATSPort.whoCall != null)
                {
                    if ((sender as TerminalUnit).LinkOnATSPort.PortStatus == PortStatusEnum.WAIT_FOR_ANSWER)
                    {
                        (sender as TerminalUnit).LinkOnATSPort.BillingRecord = new BillingRecordUnit(eventargs.AnswerCallTime);
                        (sender as TerminalUnit).LinkOnATSPort.PortStatus = PortStatusEnum.BUSY;
                        (sender as TerminalUnit).LinkOnATSPort.whoCall.LinkOnATSPort.PortStatus = PortStatusEnum.BUSY;
                        (sender as TerminalUnit).LinkOnATSPort.BillingRecord.Terminal = (sender as TerminalUnit).LinkOnATSPort.whoCall;
                        (sender as TerminalUnit).LinkOnATSPort.BillingRecord.toTerminal = sender as TerminalUnit;
                        (sender as TerminalUnit).LinkOnATSPort.whoCall.LinkOnATSPort.BillingRecord = (sender as TerminalUnit).LinkOnATSPort.BillingRecord;
                        eventargs.ResultOperationMessage = "Начался разговор!";
                    }
                    else eventargs.ResultOperationMessage = "Никто не звонит!";
                }
                else eventargs.ResultOperationMessage = "Непонятно кто и как звонит!";                    
        }

        public void SomeTerminalCall(object sender, CallTerminalEventArgs eventargs)
        {
            if (sender is TerminalUnit)
            {
                Console.WriteLine("Терминал с номером:{0} хочет позвонить по номеру:{1}", (sender as TerminalUnit).AbonentNumber, eventargs.CallNumber);
                eventargs.ResultOperationMessage = "Все нормально!";                
                if (ATS_Ports.Count > 0)
                {
                    PortUnit searchport = ATS_Ports.Find(x => x.Terminal.AbonentNumber == eventargs.CallNumber);
                    if (searchport != null)
                    {                        
                        switch (searchport.PortStatus)
                        {
                            case PortStatusEnum.ON:
                                (sender as TerminalUnit).LinkOnATSPort.PortStatus = PortStatusEnum.CALL;
                                searchport.PortStatus = PortStatusEnum.WAIT_FOR_ANSWER;
                                searchport.whoCall = (sender as TerminalUnit);
                                eventargs.ResultOperationMessage = "Абонент дозванивается!";
                                break;
                            case PortStatusEnum.OFF:
                                eventargs.ResultOperationMessage = "Абонент недоступен! Позвоните позже!";
                                break;
                            case PortStatusEnum.WAIT_FOR_ANSWER:
                            case PortStatusEnum.BUSY:
                                eventargs.ResultOperationMessage = "Абонент занят!";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого номера не существует!");
                    }
                }
                else eventargs.ResultOperationMessage = "Нету зарегистрированных терминалов на АТС!";
            }
        }
    }
}
