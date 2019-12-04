using System;

namespace FATC.Common.WebUseful
{
    /// <summary>
    /// Deprecated object use <see cref="PagedList&lt;T&gt;"/> instead
    /// </summary>
    [Obsolete()]
    public class PaginationResult
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int? TotalRecords { get; set; }

        public int? TotalPages => TotalRecords.HasValue ? (int)Math.Ceiling(TotalRecords.Value / (double)PageSize) : (int?)null;
    }
}
