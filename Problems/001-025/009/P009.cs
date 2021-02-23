using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    // Problem:
    //A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    //a2 + b2 = c2
    //For example, 32 + 42 = 9 + 16 = 25 = 52.
    //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    //Find the product abc.

    // Link:
    // https://projecteuler.net/problem=9
    public class P009: ISolution<int>
    {
        public int Solve()
        {
            var trip = FindTriplet(1000);
            return trip.a * trip.b * trip.c * (int)Math.Pow(trip.factor, 3);
        }

        private (int a, int b, int c, double factor) FindTriplet(int sum)
        {
            for (int v = 1; v < sum; v++)
            {
                for (int u = v + 1; u < sum; u++)
                {
                    // a + b + c = 2 * (u^2) + 2 * u * v
                    // 
                    if (sum % SumOfTriplet(u, v) == 0)
                    {
                        var factor = sum / SumOfTriplet(u, v);
                        var trip = GenerateTriplet(u, v);
                        //var partial = trip.a + trip.b + trip.c;
                        //if (partial * factor != sum)
                        //    continue;
                        return (trip.a, trip.b, trip.c, factor);
                    }
                }
            }
            return (0, 0, 0, 0);
        }

        private (int a, int b, int c) GenerateTriplet(int u, int v)
        {
            return (u * u - v * v, 2 * u * v, u * u + v * v);
        }

        private int SumOfTriplet(int u, int v)
        {
            return 2 * u * (u + v);
        }
    }
}
