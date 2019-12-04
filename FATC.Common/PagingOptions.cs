using System;

namespace FATC.Common
{
    /// <summary>
    /// Deprecated object use <see cref="QueryStringParameters"/> instead
    /// </summary>
    [Obsolete()]
    public class PagingOptions
    {
        private const int maxPageSize = 100;

        public bool IncludeCount { get; set; } = false;

        public int? PageNumber { get; set; }

        private int _pageSize = 50;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value < maxPageSize) ? value : maxPageSize;
            }
        }

        public string SortField { get; set; }

        public string CurrentSortOrder { get; set; }

        public string CurrentSortField { get; set; } 
    }
}
