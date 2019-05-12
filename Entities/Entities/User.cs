using Entities.Enums;
using System.Collections.Generic;

namespace Entities.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }

        public string Token { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
