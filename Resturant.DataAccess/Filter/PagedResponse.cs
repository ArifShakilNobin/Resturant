using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataAccess.Filter
{
    public class PagedResponse
    {
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        //public Uri FirstPage { get; set; }
        //public Uri LastPage { get; set; }
        //public int TotalPages { get; set; }
        //public int TotalRecords { get; set; }
        //public Uri NextPage { get; set; }
        //public Uri PreviousPage { get; set; }

        //public PagedResponse(T data, int pageNumber, int pageSize)
        //{
        //    this.PageNumber = pageNumber;
        //    this.PageSize = pageSize;
        //    this.Data = data;
        //    this.Message = null;
        //    this.Succeeded = true;
        //    this.Errors = null;
        //}
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
    }
}
