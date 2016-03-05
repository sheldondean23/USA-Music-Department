using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using USA_Music_Department.Models.Users;
using USA_Music_Department.Controllers;
using Microsoft.AspNet.Identity.Owin;
using USA_Music_Department.Models.db;

namespace USA_Music_Department.Models.Users
{
    public class UserManipulation
    {
        public static UserInformation Details(string ID)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            UserInformation user = new UserInformation();
            SqlConnection dbconnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Userid", ID);
            SqlDataReader reader;

            cmd.CommandText = "GetUserRoles";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = dbconnection;

            dbconnection.Open();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user.RoleCanView = reader.GetBoolean(0);
                user.RoleCanEdit = reader.GetBoolean(1);
                user.RoleAdmin = reader.GetBoolean(2);
            }

            dbconnection.Dispose();
            dbconnection.Close();
            return user;
        }

        public static User GetUserInfo(string username)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            User user = new User();
            SqlConnection dbconnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserName", username);
            SqlDataReader reader;

            cmd.CommandText = "GetUserDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = dbconnection;

            dbconnection.Open();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user.UserID = reader.GetInt32(0);
                user.UserFirstName = reader.GetString(1);
                user.UserLastName = reader.GetString(2);
                user.Active = reader.GetBoolean(3);
            }

            dbconnection.Dispose();
            dbconnection.Close();
            return user;
        }

        public static UserInformation UpdateRoles(string ID, bool RoleCanView, bool RoleCanEdit, bool RoleAdmin)
        {
            UserInformation user = new UserInformation();
            bool canview = false;
            bool canedit = false;
            bool admin = false;
            if(RoleAdmin == true)
            {
                canview = true;
                canedit = true;
                admin = true;
            }
            else 
            if(RoleCanEdit == true && RoleAdmin == false) 
            {
                canedit = true;
                canview = true;
            }
            else
            if(RoleCanView == true && RoleCanEdit == false && RoleAdmin == false)
            {
                canview = true;
            }
            user.Userid = ID;
            user.RoleAdmin = admin;
            user.RoleCanView = canview;
            user.RoleCanEdit = canedit;
            return user;
        }
    }
}