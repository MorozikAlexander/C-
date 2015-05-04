using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test00_04_Logistic
{
    public class Man : Unit, ICargo
    {        
        public string LastName { get; set; }
        public int CurrentLoad { get; set; }
        public String Name {
            get { return LastName + ' ' + base.Name; }
            set { base.Name = value; }
            }
    }
}
