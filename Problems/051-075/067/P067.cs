using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    //By starting at the top of the triangle below and moving to adjacent numbers on the row below, 
    //the maximum total from top to bottom is 23.

    //3
    //7 4
    //2 4 6
    //8 5 9 3

    //That is, 3 + 7 + 4 + 9 = 23.

    //Find the maximum total from top to bottom in triangle.txt, 
    //a 15K text file containing a triangle with one-hundred rows.
    public class P067 : ISolution<int>
    {
        public int Solve()
        {
            var lines = new List<string>();
            using (var f = new StreamReader(@".\\051-075\\067\\triangle.txt"))
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
                    if (sum[i + 1, j] > sum[i + 1, j + 1])
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
