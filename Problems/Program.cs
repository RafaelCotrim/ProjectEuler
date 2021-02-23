using Guaraci.Core.Numeric.Sequences;
using ProjectEuler.Utils.Numbers;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxLength = 0;
            var maxDenominator = 0;

            for (int i = 99999; i > maxLength; i -= 2)
            {
                if (i % 5 == 0)
                    continue;

                var decimalExpansio = GetCyclicDecimal(i);

                if(decimalExpansio.Length > maxLength)
                {
                    maxLength = decimalExpansio.Length;
                    maxDenominator = i;
                }

                Console.WriteLine($"{i} =>  {decimalExpansio.Length}");
            }
        }

        public static int NextDigit(int numerator, int denominator, out int remainder)
        {
            if (denominator > numerator)
                numerator *= 10;

            remainder = (numerator % denominator);

            return numerator / denominator;
        }
        
        public static string GetCyclicDecimal(int denominator)
        {
            var str = "";
            var numerator = 1;
            var magnitude = denominator.ToString().Length;

            for (int i = 0; i < denominator * 2; i++)
            {
                str += NextDigit(numerator, denominator, out numerator);

                if (i < magnitude) // Prevents the detection of the leading zeros as repeated when dividing by big numbers
                    continue;

                if (str.Length % 2 == 0)
                {
                    var half = str.Length / 2;
                    if (str.Substring(0, half) == str.Substring(half))
                    {
                        str = str.Substring(0, half);
                        break;
                    }
                }
            }
            return str;
        }
    }
}
