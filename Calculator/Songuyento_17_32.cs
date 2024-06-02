using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_17_Huy_32_Phat
{
    public class Songuyento_17_32
    {
        private int a;
        public Songuyento_17_32(int a)
        {
            this.a = a;

        }
        public static String Songuyento_17_Huy_32_Phat(int a)
        {
            if (a < 0)
            {
                return "Vui lòng nhập số lớn hơn 0";
            }
            else if (a == 0 || a ==1)
            {
                return "Đây không phải số nguyên tố";
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(a); i++)
                {
                    if (a % i == 0)
                    {
                        return "Đây không phải số nguyên tố";
                    }
                }
            }
            return "Đây là số nguyên tố";
        }
    }
}
