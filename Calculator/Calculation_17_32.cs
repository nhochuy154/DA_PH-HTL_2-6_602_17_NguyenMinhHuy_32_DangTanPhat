using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit_17_Huy_32_Phat
{
    public class Calculation_17_32
    {
        private int a, b;
        public Calculation_17_32(int a, int b)
        {
            this.a = a;
            this.b = b;
            
        }
        public int Execute(String CalSymbol)
        {
            int result = 0;
            switch (CalSymbol)
            {
                case "+":
                    result = this.a + this.b;
                    break;
                case "-":
                    result = this.a - this.b;
                    break;
                case "*":
                    result = this.a * this.b;
                    break;
                case "/":
                    result = this.a / this.b;
                    break;
            }
            return result;
        }
        


    }
}
