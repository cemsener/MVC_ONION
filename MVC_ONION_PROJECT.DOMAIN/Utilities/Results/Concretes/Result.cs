using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public Result()
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        public Result(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
            //this.Message = string.Empty;
        }

        public Result(bool ısSuccess, string message) : this(ısSuccess)
        {
            Message = message;
        }
    }
}
