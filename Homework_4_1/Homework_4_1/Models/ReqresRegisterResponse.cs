using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class ReqresRegisterResponse
    {
        public int? Id { get; set; }

        public string Token { get; set; }

        public string Error { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Token: {Token} | Error: {Error}";
        }
    }
}
