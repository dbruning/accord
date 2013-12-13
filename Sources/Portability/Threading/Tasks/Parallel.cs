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

        public static void For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, Action<int> body)
        {
            for (var i = fromInclusive; i < toExclusive; ++i) body(i);
        }

        public static void For<TLocal>(int fromInclusive, int toExclusive, Func<TLocal> localInit,
            Func<int, object, TLocal, TLocal> body, Action<TLocal> localFinally)
        {
            for (var i = fromInclusive; i < toExclusive; ++i)
                localFinally(body(i, null, localInit()));
        }
    }
}