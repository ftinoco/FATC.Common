namespace FATC.Common
{ 
    public class QueryStringParameters
    {
        const int maxPageSize = 50;
        
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
         

        public string SortField { get; set; }

        public SortOrder CurrentSortOrder { get; set; }

        public string CurrentSortField { get; set; }

        public bool Sortable { get { return string.IsNullOrWhiteSpace(SortField); } }

        public string FilterText { get; set; }
    }
}
