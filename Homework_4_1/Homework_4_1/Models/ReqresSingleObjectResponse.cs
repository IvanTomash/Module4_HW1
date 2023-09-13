using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class ReqresSingleObjectResponse<T>
    {
        public T Data { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
