using System;
using System.Collections.Generic;

namespace Tridi.Data.Entities
{
    public partial class User
    {
        public User()
        {
            MessageFroms = new HashSet<Message>();
            MessageTos = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Message> MessageFroms { get; set; }
        public virtual ICollection<Message> MessageTos { get; set; }
    }
}
