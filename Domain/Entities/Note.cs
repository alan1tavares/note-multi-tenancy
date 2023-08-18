using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Note
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public required User User { get; set; }
        public required Group Group { get; set; }
    }
}
