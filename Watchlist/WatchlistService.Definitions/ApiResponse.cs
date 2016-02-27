using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.Definitions
{
    public enum MethodResponseCode
    {
        Success = 0,
        DatabaseError = 1,
        ExternalServiceError = 2,
        InternalServiceError = 3
    }
    public class ApiResponse<T>
    {
        public MethodResultContainer<T> ResponseContainer { get; set; }

        public ApiResponse()
        {
            this.ResponseContainer = new MethodResultContainer<T>();
        }
    }
    public class MethodResultContainer<T>
    {
        public T ResponseObject { get; set; }
        public MethodResponseCode ResponseCode { get; set; }
        public string ErrorMessage { get; set; }

        public MethodResultContainer()
        {
            this.ResponseCode = MethodResponseCode.Success;
            this.ErrorMessage = "Success";
        }
    }
}
