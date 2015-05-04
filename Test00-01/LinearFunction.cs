using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_01
{
    public class LinearFunction
    {
        private double a = 0.0;
        private double b = 0.0;

        public double ValueA
        {
            get { return a; }
            set { a = value; }
        }

        public double ValueB
        {
            get { return b; }
            set { b = value; }
        }

        public double y(double x)
        {
            return a * x + b;
        }
    }
}
