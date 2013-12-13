// Accord Machine Learning Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2013
// cesarsouza at gmail.com
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

namespace Accord.MachineLearning
{
    using System;

    /// <summary>
    ///   k-Modes algorithm.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   The k-Modes algorithm is a variant of the k-Means which instead of 
    ///   locating means attempts to locate the modes of a set of points. As
    ///   the algorithm does not require explicit numeric manipulation of the
    ///   input points (such as addition and division to compute the means),
    ///   the algorithm can be used with arbitrary (generic) data structures.</para>
    /// <para>
    ///   This is the specialized, non-generic version of the K-Models algorithm
    ///   that is set to work on <see cref="T:System.Int32"/> arrays.</para>
    /// </remarks>
    /// 
    /// <seealso cref="KModes{T}"/>
    /// 
    [Serializable]
    public class KModes : KModes<int[]>
    {

        /// <summary>
        ///   Initializes a new instance of K-Modes algorithm
        /// </summary>
        /// 
        /// <param name="k">The number of clusters to divide input data.</param>    
        /// 
        public KModes(int k) : base(k, Accord.Math.Distance.Manhattan) { }
    }
}