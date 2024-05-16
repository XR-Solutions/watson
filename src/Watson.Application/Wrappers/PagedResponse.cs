using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public PagedResponse(T data, int pageNumber, int pageSize, int totalItems)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            TotalItems = totalItems;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get { return ((TotalItems - 1) / PageSize) + 1; } }
    }
}
