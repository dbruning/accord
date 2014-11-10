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

using System;
using System.Data;
using System.Linq;

namespace Accord
{
    public static class DataTableExtensions
    {
        [CLSCompliant(false)]
        public static DataRow[] GetRows<T>(this DataTable table, string columnName, T columnValue)
        {
            return
                table.Rows.Cast<DataRow>()
                    .Where(row => columnValue.Equals(Convert.ChangeType(row[columnName], typeof(T))))
                    .ToArray();
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

            var k = table.Rows.Cast<DataRow>().Select(row => System.Math.Pow(Convert.ToDouble(row[columnName]), 2.0)).Sum();
            var s = table.Rows.Cast<DataRow>().Select(row => Convert.ToDouble(row[columnName])).Sum();
            return System.Math.Sqrt((k - s * s / n) / (n - 1.0));
        }
    }
}