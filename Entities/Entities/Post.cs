using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
