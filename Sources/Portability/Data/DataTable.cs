//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

using System.Globalization;

namespace System.Data
{
    public class DataTable
    {
        #region PROPERTIES

        public DataColumnCollection Columns { get; private set; }

        public DataRowCollection Rows { get; private set; }

        public CultureInfo Locale { get; set; }

        #endregion
    }
}