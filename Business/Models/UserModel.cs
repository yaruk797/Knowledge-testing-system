﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<int> TestIds { get; set; }
    }
}
