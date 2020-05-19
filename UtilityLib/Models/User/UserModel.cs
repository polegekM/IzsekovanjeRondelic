using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityLib.Models.User
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}