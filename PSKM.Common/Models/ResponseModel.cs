using PSKM.Common.Enums;

namespace PSKM.Common.Models;

public class ResponseModel<T>
{
        public bool IsSuccess { get; set; }
        public EnumResponseCode StatusCode { get; set; }
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

        public static ResponseModel<T> Success(T data, EnumResponseCode code, string message = "Operation successful")
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                StatusCode = code,
                Message = message,
                Data = data
            };
        }

        public static ResponseModel<T> Success(EnumResponseCode code, string message = "Operation successful")
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                StatusCode = code,
                Message = message,
            };
        }

        public static ResponseModel<T> Fail(EnumResponseCode code,string message = "Operation failed!!")
        {
                return new ResponseModel<T>
                {
                        IsSuccess = false,
                        StatusCode = code,
                        Message = message,
                };
        }
}
