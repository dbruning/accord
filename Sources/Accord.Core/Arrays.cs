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

    /// <summary>
    /// Support class providing implementations from the System.Array class that are not
    /// available in PCL.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal static class Array_
    {
        #region METHODS

        /// <summary>
        /// Sorts a pair of Array objects (one contains the keys and the other contains the corresponding items) 
        /// based on the keys in the first Array using the IComparable&lt;T&gt; generic interface implementation of each key.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of the key array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based Array that contains the keys to sort.</param>
        /// <param name="items">The one-dimensional, zero-based Array that contains the items that correspond to the keys in keys, 
        /// or null to sort only keys.</param>
        /// <remarks>Implementation relies on the LINQ OrderBy method, which uses stable sort. Original .NET implementation of
        /// Array.Sort uses an unstable sort algorithm.</remarks>
        internal static void Sort<TKey, TValue>(TKey[] keys, TValue[] items)
        {
            Sort(keys, items, Comparer<TKey>.Default);
        }

        /// <summary>
        /// Sorts a pair of Array objects (one contains the keys and the other contains the corresponding items) 
        /// based on the keys in the first Array using the specified IComparer&lt;T&gt; generic interface.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of the key array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based Array that contains the keys to sort.</param>
        /// <param name="items">The one-dimensional, zero-based Array that contains the items that correspond to the keys in keys, 
        /// or null to sort only keys.</param>
        /// <param name="comparer">The IComparer&lt;T&gt; generic interface implementation to use when comparing elements, 
        /// or null to use the IComparable&lt;T&gt; generic interface implementation of each element.</param>
        /// <remarks>Implementation relies on the LINQ OrderBy method, which uses stable sort. Original .NET implementation of
        /// Array.Sort uses an unstable sort algorithm.</remarks>
        internal static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer)
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

        /// <summary>
        /// Sorts a range of elements in a pair of Array objects (one contains the keys and the other contains the corresponding items)
        /// based on the keys in the first Array using the specified IComparer&lt;T&gt; generic interface.
        /// </summary>
        /// <typeparam name="TKey">The type of the elements of the key array.</typeparam>
        /// <typeparam name="TValue">The type of the elements of the items array.</typeparam>
        /// <param name="keys">The one-dimensional, zero-based Array that contains the keys to sort.</param>
        /// <param name="items">The one-dimensional, zero-based Array that contains the items that correspond to the keys in keys, 
        /// or null to sort only keys.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <param name="comparer">The IComparer&lt;T&gt; generic interface implementation to use when comparing elements, 
        /// or null to use the IComparable&lt;T&gt; generic interface implementation of each element.</param>
        /// <remarks>Implementation relies on the LINQ OrderBy method, which uses stable sort. Original .NET implementation of
        /// Array.Sort uses an unstable sort algorithm.</remarks>
        internal static void Sort<TKey, TValue>(
            TKey[] keys,
            TValue[] items,
            int index,
            int length,
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

        /// <summary>
        /// Converts an array of one type to an array of another type.
        /// </summary>
        /// <typeparam name="TInput">The type of the elements of the source array.</typeparam>
        /// <typeparam name="TOutput">The type of the elements of the target array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based Array to convert to a target type.</param>
        /// <param name="converter">A Converter&lt;TInput, TOutput&gt; that converts each element from one type to another type.</param>
        /// <returns>An array of the target type containing the converted elements from the source array.</returns>
        internal static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            var newArray = new TOutput[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                newArray[i] = converter(array[i]);
            }
            return newArray;
        }

        #endregion
    }
}