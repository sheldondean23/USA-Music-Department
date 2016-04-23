using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using USA_Music_Department.Models.Forms.Interest_Form;

namespace USA_Music_Department.Models.db
{
    public class StudentManipulation
    {
        public static void Insert(StudentToAdd student)
        {

            BandStudentDBEntities db = new BandStudentDBEntities();
            System.Data.Entity.Core.Objects.ObjectParameter OutputID = new System.Data.Entity.Core.Objects.ObjectParameter("OutputID", typeof(int?));
            int StudentIdFromDB = db.InsertStudentData(student.StudentFirstName, student.StudentLastName, student.StudentAddress, student.StudentCity, student.StudentState, student.StudentZipCode, student.StudentPhone, student.PerformanceMedium, student.GraduationYear, student.EmailAddress, OutputID);
            StudentIdFromDB = Convert.ToInt32(OutputID.Value);
            db.SaveChanges();
            db.CreateUpdate_InterestAreas(StudentIdFromDB, student.InterestAreas.BM_Music_Education_Vocal, student.InterestAreas.BM_Music_Education_Instrumental,
                                          student.InterestAreas.BM_Music_Performance_Vocal, student.InterestAreas.BM_Music_Performance_Instrumental,
                                          student.InterestAreas.BM_Music_Elective_Studies_Business, student.InterestAreas.BM_Music_Elective_Studies_Outside_Fields,
                                          student.InterestAreas.MM_Performance_Piano, student.InterestAreas.MM_Performance_Vocal, student.InterestAreas.MM_Collaborative_Piano,
                                          student.InterestAreas.Music_Minor, student.InterestAreas.Instrumental_Ensembles, student.InterestAreas.Choral_Ensembles,
                                          student.InterestAreas.Opera_Theatre, student.InterestAreas.Jaguar_Marching_Band, student.InterestAreas.Other, student.InterestAreas.MM_Concentration_in_Music_Education);
            db.SaveChanges();
        }

        public static StudentToAdd Details(int? ID)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            StudentToAdd student = new StudentToAdd
            {
                InterestAreas = new InterestAreas()
            };
            SqlConnection dbconnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@StudentId", ID);
            SqlDataReader reader;

            cmd.CommandText = "GetStudentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = dbconnection;

            dbconnection.Open();

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                student.StudentFirstName = reader.GetString(0);
                student.StudentLastName = reader.GetString(1);
                student.StudentAddress = reader.GetString(2);
                student.StudentCity = reader.GetString(3);
                student.StudentState = reader.GetString(4);
                student.StudentZipCode = reader.GetString(5);
                student.StudentPhone = reader.GetString(6);
                student.PerformanceMedium = reader.GetString(7);
                student.GraduationYear = reader.GetString(8);
                try {
                    student.EmailAddress = reader.GetString(9);
                }
                catch { 
                }
                student.InterestAreas.BM_Music_Education_Vocal = reader.GetBoolean(10);
                student.InterestAreas.BM_Music_Education_Instrumental = reader.GetBoolean(11);
                student.InterestAreas.BM_Music_Performance_Vocal = reader.GetBoolean(12);
                student.InterestAreas.BM_Music_Performance_Instrumental = reader.GetBoolean(13);
                student.InterestAreas.BM_Music_Elective_Studies_Business = reader.GetBoolean(14);
                student.InterestAreas.BM_Music_Elective_Studies_Outside_Fields = reader.GetBoolean(15);
                student.InterestAreas.MM_Performance_Piano = reader.GetBoolean(16);
                student.InterestAreas.MM_Performance_Vocal = reader.GetBoolean(17);
                student.InterestAreas.MM_Collaborative_Piano = reader.GetBoolean(18);
                student.InterestAreas.Music_Minor = reader.GetBoolean(19);
                student.InterestAreas.Instrumental_Ensembles = reader.GetBoolean(20);
                student.InterestAreas.Choral_Ensembles = reader.GetBoolean(21);
                student.InterestAreas.Opera_Theatre = reader.GetBoolean(22);
                student.InterestAreas.Jaguar_Marching_Band = reader.GetBoolean(23);
                student.InterestAreas.MM_Concentration_in_Music_Education = reader.GetBoolean(25);
                student.InterestAreas.Other = reader.GetString(26);
            }

            dbconnection.Dispose();
            dbconnection.Close();
            return student;
        }

        public static List<string> GetColumns(string tableName)
        {
            BandStudentDBEntities db = new BandStudentDBEntities();
            return db.TableColumnNames(tableName).ToList();
        }

    }
}