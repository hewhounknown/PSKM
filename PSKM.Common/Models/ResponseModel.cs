using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSKM.Common.Models;

public class ResponseModel<T>
{
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseModel<T> Success(T data, string message = "Operation successful")
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel<T> Fail(string message = "Operation failed!!")
        {
                return new ResponseModel<T>
                {
                        IsSuccess = false,
                        Message = message,
                };
        }
}
