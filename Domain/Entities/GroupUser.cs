﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupUser
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public Group Group { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
