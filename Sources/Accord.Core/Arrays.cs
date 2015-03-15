// Accord.Core Library
// The Portable Accord.NET Framework
// https://github.com/cureos/accord
//
// Copyright © Anders Gustafsson, 2013-2014
// anders at cureos dot com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
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
            if (items != null)
            {
                var ordered =
                    keys.Zip(items, (k, v) => new KeyValuePair<TKey, TValue>(k, v))
                        .OrderBy(kv => kv.Key, comparer)
                        .ToArray();
                lock (keys)
                {
                    Array.Copy(ordered.Select(kv => kv.Key).ToArray(), keys, ordered.Length);
                    Array.Copy(ordered.Select(kv => kv.Value).ToArray(), items, ordered.Length);
                }
            }
            else
            {
                Array.Sort(keys);
            }
        }

        public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length,
            IComparer<TKey> comparer)
        {
            if (items != null)
            {
                var ordered =
                    keys.Skip(index)
                        .Take(length)
                        .Zip(items.Skip(index).Take(length), (k, v) => new KeyValuePair<TKey, TValue>(k, v))
                        .OrderBy(kv => kv.Key, comparer)
                        .ToList();
                lock (keys)
                {
                    Array.Copy(ordered.Select(kv => kv.Key).ToArray(), 0, keys, index, length);
                    Array.Copy(ordered.Select(kv => kv.Value).ToArray(), 0, items, index, length);
                }
            }
            else
            {
                Array.Sort(keys, index, length, comparer);
            }
        }

        #endregion
    }
}