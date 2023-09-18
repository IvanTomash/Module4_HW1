using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class ReqresResourceRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | Year: {Year} | Color: {Color} | PantoneValue: {PantoneValue}";
        }
    }
}
