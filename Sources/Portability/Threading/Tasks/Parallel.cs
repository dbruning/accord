//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

namespace System.Threading.Tasks
{
    public static class Parallel
    {
        public static void For(int fromInclusive, int toExclusive, Action<int> body)
        {
            for (var i = fromInclusive; i < toExclusive; ++i) body(i);
        }
    }
}