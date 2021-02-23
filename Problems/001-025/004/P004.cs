using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    // A palindromic number reads the same both ways.The largest palindrome made from the product of two 
    // 2-digit numbers is 9009 = 91 × 99.
    // Find the largest palindrome made from the product of two 3-digit numbers.
    // Link:
    // https://projecteuler.net/problem=4

    public class P004 : ISolution<long>
    {
        public long Solve()
        {
            return BruteSearch(100, 999);
        }

        public static bool IsPalindrome(long n)
        {
            var str = n.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }
            return true;
        }

        public static long BruteSearch(long min, long max)
        {
            long maxPal = 0;

            for (long i = max; i >= min; i--)
            {
                for (long j = i; j >= min; j--)
                {
                    if (IsPalindrome(i * j) && i * j > maxPal)
                        maxPal = i * j;
                }
            }
            return maxPal;
        }
    }
}
