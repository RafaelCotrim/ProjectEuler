using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public interface ISolution<T>
    {
        public T Solve();
    }
}
