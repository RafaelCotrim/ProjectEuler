using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{


    //Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    //For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

    //What is the total of all the name scores in the file?

    public class P022 : ISolution<int>
    {
        public int Solve()
        {
            IEnumerable<string> names;
            using (var f = new StreamReader(@".\\001-025\\022\\names.txt"))
            {
                names = f.ReadToEnd().Replace("\"", "").Split(",").OrderBy(x => x);
            }
            var scores = names.Select(x => StrValue(x)).ToArray();
            int final = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                final += scores[i] * (i + 1);
            }
            return final;
        }

        public int StrValue(string str)
        {
            var sum = 0;
            foreach (var c in str.ToLower())
            {
                sum += c - 'a' + 1;
            }
            return sum;
        }
    }
}
