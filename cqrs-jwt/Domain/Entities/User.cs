using Domain.Common;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
    }
}
