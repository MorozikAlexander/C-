using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_03
{
    class Triangle
    {
        private int[] sides = new int[3] {0, 0, 0};
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        private enum TriangleType {Rect, Obtus, Acute, Unknown};
        private TriangleType mytriangletype;        

        public Triangle()
        {
            mytriangletype = TriangleType.Unknown;
            A = 0;
            B = 0;
            C = 0;            
        }

        public void CheckTriangleType()
        {
            mytriangletype = GetTriangleType(A, B, C);
        }

        private bool isValidTriangle(int x, int y, int z)
        {
            if ((x<=0)||(y<=0)||(z<=0))
            {
                return false;
            } 
            else
            {
                sides[0] = x;
                sides[1] = y;
                sides[2] = z;
                int m = 0;
                for (int i = 2; i > 0; i--)
                {
                    if (sides[i] > sides[i - 1])
                    {
                        m = sides[i];
                        sides[i] = sides[i-1];
                        sides[i - 1] = m;
                    }                    
                }
                if (sides[0] < (sides[1] + sides[2]))
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
        }

        private TriangleType GetTriangleType(int xx, int yy, int zz)
        {
            if (isValidTriangle(xx, yy, zz) == true)
            {
                if (sides[0] * sides[0] == sides[1] * sides[1] + sides[1] * sides[1])
                {
                    return TriangleType.Rect;
                }
                else if (sides[0] * sides[0] > sides[1] * sides[1] + sides[1] * sides[1])
                {
                    return TriangleType.Obtus;
                }
                else if (sides[0] * sides[0] < sides[1] * sides[1] + sides[1] * sides[1])
                {
                    return TriangleType.Acute;
                }
                else
                {
                    return TriangleType.Unknown;
                }
            }
            else
            {
                return TriangleType.Unknown;
            }
        }

        public string PrintTriangleType()
        {
            switch (mytriangletype)
            {
                case TriangleType.Rect:
                    return "Прямоугольный";
                    break;
                case TriangleType.Obtus:
                    return "Тупоугольный";
                    break;
                case TriangleType.Acute:
                    return "Остроугольный";
                    break;
                case TriangleType.Unknown:
                    return "Неопределенный";
                    break;            
                default:
                    return "";
                    break;
            }
        }

    }
}
