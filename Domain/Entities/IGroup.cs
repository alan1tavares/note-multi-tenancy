using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IGroup
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
