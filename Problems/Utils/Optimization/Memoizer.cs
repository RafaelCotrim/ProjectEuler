using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Utils.Optimization
{
    public class Memoizer
    {
        public static Func<A,R> Memoize<A,R>(Func<A,R> func)
        {
            var cache = new Dictionary<A, R>();
            return (A a) =>
            {
                if (cache.TryGetValue(a, out R value))
                    return value;

                value = func(a);
                cache.Add(a, value);

                return (value);
            };
        }
    }
}
