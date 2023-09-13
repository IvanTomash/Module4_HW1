using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class ReqresUserRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Avatar { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Email: {Email} | FirstName: {FirstName} | LastName: {LastName} | Avatar: {Avatar}";
        }
    }
}
