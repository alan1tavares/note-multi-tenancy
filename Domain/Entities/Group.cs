using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<User> Users { get; } = new();
    }
}
