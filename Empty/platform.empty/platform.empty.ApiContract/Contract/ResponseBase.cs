using platform.empty.ApiContract.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ApiContract.Contract
{
    public class ResponseBase<T> : ResponseBaseMessage
    {
        public T Data { get; set; }
    }
}
