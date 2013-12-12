//
// Portability Class Library
//
// Copyright © Cureos AB, 2013
// info at cureos dot com
//

using System.Collections.Generic;

namespace System.Data
{
    public class DataColumnCollection : List<DataColumn>
    {
        #region INDEXERS

        public DataColumn this[string columnName]
        {
            get { return null; }
        }

        #endregion

        #region METHODS

        public void Add(string columnName, Type type)
        {
        }

        #endregion
    }
}