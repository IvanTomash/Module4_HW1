using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1.Models
{
    internal sealed class UserCreatedResponse
    {
        public string Name { get; set; }

        public string Job { get; set; }

        public int? Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Name {Name} | Job: {Job} | Id {Id} | CreatedAt: {CreatedAt}";
        }
    }
}
