using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_17_Huy_32_Phat
{
    public class Giaipt_17_32
    {
        private float a, b, c;
        public Giaipt_17_32(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

        }
        public static String giaiB1(float a, float b)
        {
            if (a == 0)
            {
                if (b == 0)
                    return "PTB1 Vô số nghiệm";
                else
                    return "PTB1 Vô nghiệm";
            }
            else
            {
                return "" + (-b / a);
            }
        }
        public static String giaiB2(float a, float b, float c)
        {
            if (a == 0)
            {
                return giaiB1(b, c);
            }
            else
            {
                float d = (b * b) - (4 * a * c);
                if (d < 0)
                {
                    return "PTB2 Vô nghiệm";
                }
                else if (d == 0)
                {
                    return "x1=x2=" + (-b / (2 * a));
                }
                else
                {
                    float x1 = ((float)(-b + Math.Sqrt(d))) / (2 * a);
                    float x2 = ((float)(-b - Math.Sqrt(d))) / (2 * a);
                    return "x1=" + x1 + "  " + "x2=" + x2;
                }
            }
        }
    }
}
