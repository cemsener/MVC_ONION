using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes
{
    public class SuccessDataResult<T> : DataResult<T> where T : class
    {
        public SuccessDataResult() : base(default, true) { }
        public SuccessDataResult(string message) : base(default, true, message) { }
        public SuccessDataResult(T data, string message) : base(data, true, message) { }
        
        //default ile data arasındaki fark: defatult ile baştaki T baz alınıyor, data olunca parametre olarak giden data baz alınıyor

    }
}
