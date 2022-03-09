using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab33.Models
{
    public class RomanNumberExtend : RomanNumber
    {

        static private ushort getNumber(string str)
        {
            if(str == null) throw new ArgumentNullException();
            ushort res = 0;

            char[] symb = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            char[] symb2 = new char[] { 'C', 'X', 'I' };

            int index = 6;
            for (int i=str.Length-1; i>=0; --i) {
                char t = str[i];
                if(t=='I')
                {
                    if (index < 6) res -= 1;
                    else res += 1;
                }
                if (t == 'X')
                {
                    if (index < 4) res -= 10;
                    else res += 10;
                    index = 4;
                }
                if (t == 'C')
                {
                    if (index < 2) res -= 100;
                    else res += 100;
                    index = 2;
                }
                if (t == 'V') { res += 5; index = 5; }
                if (t == 'L') { res += 50; index = 3; }
                if (t == 'D') { res += 500; index = 1; }
                if (t == 'M') { res += 1000; index = 0; }
            }

            return res;
        }
        public RomanNumberExtend(ushort n) : base(n) { }
        public RomanNumberExtend(string str) : base(getNumber(str))
        {
        }
    }
}
