using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Application.Parameters
{
    public class RequestParameter
    {
        public RequestParameter() { }

        public RequestParameter(int page, int pageSize)
        {
            Page = page < 1 ? 1 : page;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
