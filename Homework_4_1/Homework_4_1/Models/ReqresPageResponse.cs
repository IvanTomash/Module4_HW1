using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class ReqresPageResponse<T>
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public List<T> Data { get; set; }

        public override string ToString()
        {
            return $"Page: {Page} | PerPage: {PerPage} | Total: {Total} | TotalPages: {TotalPages}";
        }
    }
}
