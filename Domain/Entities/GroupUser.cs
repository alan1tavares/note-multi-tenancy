using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class GroupUser
    {
        public Guid Id { get; set; }
        public required Group Group { get; set; }
        public required User User { get; set; }
    }
}
