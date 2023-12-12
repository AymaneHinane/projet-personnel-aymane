using System;
using Project.Shared.Request;

namespace Project.Shared.RequestFeatures
{
	public class InvoiceParameters: RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 15;
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


        public string? category { get; set; }
        public string? numero { get; set; }
        public DateTime? date { get; set; }

    }
}

