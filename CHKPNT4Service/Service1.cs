using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CheckPoint04;

namespace CHKPNT4Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DataCollectorUnit DC = new DataCollectorUnit(@"D:\Data");
        }

        protected override void OnStop()
        {
        }
    }
}
