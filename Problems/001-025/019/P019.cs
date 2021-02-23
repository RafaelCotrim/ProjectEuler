using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{


    //You are given the following information, but you may prefer to do some research for yourself.

    //1 Jan 1900 was a Monday.
    //Thirty days has September,
    //April, June and November.
    //All the rest have thirty-one,
    //Saving February alone,
    //Which has twenty-eight, rain or shine.
    //And on leap years, twenty-nine.

    //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

    //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

    public class P019 : ISolution<int>
    {
        private static int[] _monthKeys = new int[] { 1, 4, 4, 0, 2, 5, 0, 3, 6, 1, 4, 6 };
        private static int[] _yearKeys = new int[] { 6, 4, 2, 0 };
        public int Solve()
        {
            var count = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    var d = new DateTime(year, month, 1);
                    if(new DateTime(year, month, 1).DayOfWeek == DayOfWeek.Sunday)
                        count++;
                }
            }
            return count;
        }

        public bool IsLeepYear(int year)
        {
            if (year % 4 != 0)
                return false;
            if (year % 100 != 0)
                return true;
            if (year % 400 == 0)
                return true;
            return false;
        }

        public int WeekDay(int year, int month, int day)
        {
            var k = (year % 100);
            k /= 4;
            k += day;
            k += _monthKeys[month];

            if (IsLeepYear(year))
                k -= 1;

            k += _yearKeys[(year / 100) % 4];
            k += year % 100;
            return k % 7;
        }
    }
}
