using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab33.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        private ushort value;
        private string romanVal;

        private string calcRomanValue(ushort n)
        {
            char[] symb = new char[] { 'M', 'D', 'C', 'L', 'X', 'V' };
            char[] symb2 = new char[] { 'C', 'X', 'I' };
            string res = "";
            for (int i = 0; i < n / 1000; ++i) res += 'M';
            int t = n % 1000;
            for (int i = 100, k = 0; i > 0; i /= 10, ++k)
            {
                int x = t / i;
                if (x == 9) res = res + symb2[k] + symb[k * 2];
                else if (x >= 5)
                {
                    res += symb[1 + k * 2];
                    for (int j = 0; j < x - 5; ++j) res += symb2[k];
                }
                else
                {
                    if (x == 4) res = res + symb2[k] + symb[1 + k * 2];
                    else
                    {
                        for (int j = 0; j < x; ++j) res += symb2[k];
                    }
                }
                t = t % i;
            }
            return res;
        }

        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (!(n > 0)) throw new RomanNumberException();
            value = n;
            romanVal = calcRomanValue(n);
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value + n2.value));
        }

        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n1.value <= n2.value) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value - n2.value));
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value * n2.value));
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n2.value == 0 || ((ushort)(n1.value / n2.value)) == 0) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value / n2.value));
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return romanVal;
        }

        public object Clone()
        {
            return new RomanNumber(value);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            RomanNumber another = obj as RomanNumber;

            if (another == null) throw new ArgumentException("Object is not a RomanNumber.");

            return value.CompareTo(another.value);
        }
    }

}