﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
            
        }

        public SuccessResult(string message) : base(true, message)
        {
            
        }
    }
}
