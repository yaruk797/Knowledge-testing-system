using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UserProfile : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
