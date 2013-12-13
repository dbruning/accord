//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

namespace Accord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Arrays
    {
        #region METHODS

        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items)
        {
            Sort(keys, items, Comparer<TKey>.Default);
        }

        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer)
        {
            var ordered =
                keys.Zip(items, (k, v) => new KeyValuePair<TKey, TValue>(k, v))
                    .OrderBy(kv => kv.Key, comparer)
                    .ToArray();
            Array.Copy(ordered.Select(kv => kv.Key).ToArray(), keys, ordered.Length);
            Array.Copy(ordered.Select(kv => kv.Value).ToArray(), items, ordered.Length);
        }

        #endregion
    }
}