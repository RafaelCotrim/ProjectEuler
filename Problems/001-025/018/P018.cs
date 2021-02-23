using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    //By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

    //3
    //7 4
    //2 4 6
    //8 5 9 3

    //That is, 3 + 7 + 4 + 9 = 23.
    //Find the maximum total from top to bottom of the triangle below:

    //              75
    //             95 64
    //            17 47 82
    //           18 35 87 10
    //          20 04 82 47 65
    //         19 01 23 75 03 34
    //        88 02 77 73 07 63 67
    //       99 65 04 28 06 16 70 92
    //      41 41 26 56 83 40 80 70 33
    //     41 48 72 33 47 32 37 16 94 29
    //    53 71 44 65 25 43 91 52 97 51 14
    //   70 11 33 28 77 73 17 78 39 68 17 57
    //  91 71 52 38 17 14 91 43 58 50 27 29 48
    // 63 66 04 68 89 53 67 30 73 16 69 87 40 31
    //04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
    public class P018: ISolution<int>
    {
        

        public int Solve()
        {
            var lines = new List<string>();
            using (var f = new StreamReader(@".\\001-025\\018\\triangle.txt"))
            {
                string l;
                while ((l = f.ReadLine()) != null)
                {
                    lines.Add(l);
                }
            }

            var numbers = new int[lines.Count, lines.Count];

            // Sum array is 1 bigger to avoid out of range exceptions
            var sum = new int[lines.Count + 1, lines.Count + 1];

            // Fill numbers array as a bottom triangular matrix
            for (int i = 0; i < lines.Count; i++)
            {
                var ns = lines[i].Trim().Split(" ").Select(x => Int32.Parse(x)).ToArray();
                for (int j = 0; j < ns.Length; j++)
                {
                    numbers[i, j] = ns[j];
                }
            }

            // For each position in the sum array, get the maximun between
            // the position directly below and the next one.
            // Sum the max of the two with the value of the current postition
            for (int i = sum.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < sum.GetLength(1) - 2; j++)
                {
                    var max = 0;
                    if(sum[i + 1, j] > sum[i + 1, j + 1])
                    {
                        max = sum[i + 1, j];
                    } 
                    else
                    {
                        max = sum[i + 1, j + 1];
                    }
                    sum[i, j] = max + numbers[i, j];
                }
            }

            return sum[0, 0];
        }
    }
}
