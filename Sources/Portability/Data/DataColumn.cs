namespace System.Data
{
    public class DataColumn
    {
        #region FIELDS

        private string _caption;
        
        #endregion

        #region PROPERTIES

        public DataTable Table { get; private set; }

        public string ColumnName { get; set; }

        public string Caption
        {
            get { return _caption ?? ColumnName; }
            set { _caption = value; }
        }

        #endregion
    }
}