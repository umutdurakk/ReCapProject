using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result.Concrete
{
    public class DataResult<T> : IResult, IDataResult<T>
    {
        public DataResult(T data , bool success,string message):this(data , success)
        {
            Message = message;
            Data = data;
        }
        public DataResult(T data, bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }

        public T Data { get; }
    }
}
