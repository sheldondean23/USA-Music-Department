using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USA_Music_Department.Models.Users
{
    public class UserInformation
    {
        public string Userid { get; set; }
        public bool RoleCanView { get; set; }
        public bool RoleCanEdit { get; set; }
        public bool RoleAdmin { get; set; }
        public string Username { get; set; }
    }
}