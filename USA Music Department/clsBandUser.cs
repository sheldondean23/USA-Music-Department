using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace USA_Music_Department
{
    public class clsBandUser
    {
        //User Data Fields
        private string UserName;
        private string PasswordHash;
        private string UserFirstName;
        private string UserLastName;
        private bool IsAdmin;
        private bool Active;

        //Constructors

        //Default Constructor
        public clsBandUser() { }
        public clsBandUser(string _UserName, string _Password, string _UserFirstName, string _UserLastName, bool _IsAdmin, bool _Active)
        {
            UserName = _UserName;
            PasswordHash = clsPassword.CreateHash(_Password);
            UserFirstName = _UserFirstName;
            UserLastName = _UserLastName;
            IsAdmin = _IsAdmin;
            Active = _Active;
        }

        public string usrUserName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public string usrFirstName
        {
            get { return UserFirstName; }
            set { UserFirstName = value; }
        }

        public string usrLastName
        {
            get { return UserLastName; }
            set { UserLastName = value; }
        }

        public bool usrIsAdmin
        {
            get { return IsAdmin; }
            set { IsAdmin = value; }
        }

        public bool usrActive
        {
            get { return Active; }
            set { Active = value; }
        }

    }
}