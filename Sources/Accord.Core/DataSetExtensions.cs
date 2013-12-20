// Accord Core Library
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

namespace Accord
{

    using System;
    using System.Data;
    using System.Linq;

    /// <summary>
    ///   Static class for DataSet-related extension methods.
    /// </summary>
    /// 
    public static class DataSetExtensions
    {

        /// <summary>
        ///   Creates and adds multiple <see cref="System.Data.DataColumn"/>
        ///   objects with the given names at once.
        /// </summary>
        /// 
        /// <param name="collection">The <see cref="System.Data.DataColumnCollection"/>
        /// to add in.</param>
        /// <param name="columnNames">The names of the <see cref="System.Data.DataColumn"/> to
        /// be created and added.</param>
        /// 
        /// <example>
        ///   <code>
        ///   DataTable table = new DataTable();
        ///   
        ///   // Add multiple columns at once:
        ///   table.Columns.Add("columnName1", "columnName2");
        ///   </code>
        /// </example>
        /// 
        [CLSCompliant(false)]
        public static void Add(this DataColumnCollection collection, params string[] columnNames)
        {
            for (int i = 0; i < columnNames.Length; i++)
                collection.Add(columnNames[i], typeof(object));
        }

        [CLSCompliant(false)]
        public static DataRow[] GetRows(this DataTable table, string columnName, object columnValue)
        {
            return table.Rows.Cast<DataRow>().Where(row => row[columnName].Equals(columnValue)).ToArray();
        }

        [CLSCompliant(false)]
        public static object GetMin(this DataTable table, string columnName)
        {
            return table.Rows.Cast<DataRow>().Select(row => row[columnName]).Min();
        }

        [CLSCompliant(false)]
        public static object GetMax(this DataTable table, string columnName)
        {
            return table.Rows.Cast<DataRow>().Select(row => row[columnName]).Max();
        }

        [CLSCompliant(false)]
        public static double GetAverage(this DataTable table, string columnName)
        {
            return table.Rows.Cast<DataRow>().Select(row => Convert.ToDouble(row[columnName])).Average();
        }

        [CLSCompliant(false)]
        public static double GetStdev(this DataTable table, string columnName)
        {
            var n = table.Rows.Count;
            if (n <= 1) return 0.0;

            var k = table.Rows.Cast<DataRow>().Select(row => Math.Pow(Convert.ToDouble(row[columnName]), 2.0)).Sum();
            var s = table.Rows.Cast<DataRow>().Select(row => Convert.ToDouble(row[columnName])).Sum();
            return Math.Sqrt((k - s * s / n) / (n - 1.0));
        }
    }
}
