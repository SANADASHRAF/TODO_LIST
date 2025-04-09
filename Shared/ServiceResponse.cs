using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


        public ServiceResponse(bool success, string message, T data = default)
        {
            Success = success;
            Message = message;
            Data = data ?? new object();
        }

        public ServiceResponse(bool success, T data)
        {
            Success = success;
            Data = data;
        }
    }
}
