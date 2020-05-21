using System;
using System.Collections.Generic;

namespace Exercises._04_Collections
{
    public static class Fibonacci
    {
        public static IEnumerable<int> GetFirst(int n)
        {
            var x1 = 0;
            var x2 = 1;
            yield return x1;
            yield return x2;
            for (var i = 2; i < n; i++)
            {
                var result = x1 + x2;
                x1 = x2;
                x2 = result;
                yield return result;
            }
        }
    }
}