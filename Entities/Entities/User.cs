using Entities.Enums;

namespace Entities.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }
    }
}
