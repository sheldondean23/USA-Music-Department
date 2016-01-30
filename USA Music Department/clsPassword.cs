using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using USA_Music_Department.Models.db;

namespace USA_Music_Department
{
    static class clsPassword
    {
        public static string CreateHash(string _Password)
        {
            string savedpasswordhash;
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(_Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashbytes = new byte[36];
            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);
            savedpasswordhash = Convert.ToBase64String(hashbytes);
            return savedpasswordhash;
        }
    }
}