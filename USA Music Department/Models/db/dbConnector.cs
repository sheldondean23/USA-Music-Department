using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace USA_Music_Department.Models.db
{
    public class dbConnector
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BandStudentDBEntities"].ConnectionString);
        public int rowsAffected;
    }
}