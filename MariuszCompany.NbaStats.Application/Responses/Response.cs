using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Responses
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Success = true;
            Result = data;
        }
        public Response(List<string> errorMessages)
        {
            Success = false;
            ErrorMessages = errorMessages;
        }
        public bool Success { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public T Result { get; set; }
    }
}
