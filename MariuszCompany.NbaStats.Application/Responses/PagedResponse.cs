using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Result = data;
            Success = true;
            ErrorMessages = null;
        }
    }
}
