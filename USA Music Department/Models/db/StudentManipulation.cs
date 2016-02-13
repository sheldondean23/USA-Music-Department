using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using USA_Music_Department.Models.Forms.Interest_Form;

namespace USA_Music_Department.Models.db
{
    public class StudentManipulation : dbConnector
    {
        public void Insert(StudentToAdd student)
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
                                          student.InterestAreas.Opera_Theatre, student.InterestAreas.Jaguar_Marching_Band, student.InterestAreas.Other);
            db.SaveChanges();

            //connection.Open();
            //SqlCommand comm = new SqlCommand("InsertStudentData", connection);
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = student.StudentFirstName;
            //comm.Parameters.Add(new SqlParameter("@StudentLastName", SqlDbType.VarChar)).Value = student.StudentLastName;
            //comm.Parameters.Add(new SqlParameter("@StudentAddress", SqlDbType.VarChar)).Value = student.StudentAddress;
            //comm.Parameters.Add(new SqlParameter("@StudentCity", SqlDbType.VarChar)).Value = student.StudentCity;
            //comm.Parameters.Add(new SqlParameter("@StudentState", SqlDbType.VarChar)).Value = student.StudentState;
            //comm.Parameters.Add(new SqlParameter("@StudentZipCode", SqlDbType.Int)).Value = student.StudentZipCode;
            //comm.Parameters.Add(new SqlParameter("@StudentPhone", SqlDbType.VarChar)).Value = student.StudentPhone;
            //comm.Parameters.Add(new SqlParameter("@PerformanceMedium", SqlDbType.VarChar)).Value = student.PerformanceMedium;
            //comm.Parameters.Add(new SqlParameter("@GraduationYear", SqlDbType.Int)).Value = student.GraduationYear;
            //comm.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.VarChar)).Value = student.EmailAddress;
            //comm.Parameters.Add("@OutputID", SqlDbType.Int).Direction = ParameterDirection.Output;
            //rowsAffected = comm.ExecuteNonQuery();
            //int newID = Convert.ToInt32(comm.Parameters["@NewId"].Value);
            //connection.Close();

            //var interestAreas = InterestAreaFormat(student);

            //connection.Open();
            //for (int i =0; i <= interestAreas.Count(); i++)
            //{
            //    switch (interestAreas[i])
            //    {
            //        case "BM Music Education - Vocal":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@InterestArea", SqlDbType.VarChar)).Value = "BM Music Education -Vocal";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "BM Music Education - Instrumental":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "BM Music Education - Instrumental";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "BM Music Performance - Vocal":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "BM Music Performance - Vocal";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "BM Music Performance - Instrumental":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "BM Music Performance - Instrumental";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "BM Music Elective Studies -Business":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "BM Music Elective Studies -Business";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "BM Music Elective Studies -Outside Fields":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "BM Music Elective Studies -Outside Fields";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "MM Performance - Piano":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "MM Performance - Piano";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "MM Performance -Vocal":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "MM Performance -Vocal";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "MM Collaborative Piano":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "MM Collaborative Piano";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "Music Minor":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "Music Minor";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "Instrumental Ensembles":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "Instrumental Ensembles";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "Choral Ensembles":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "Choral Ensembles";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "Opera Theatre":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "Opera Theatre";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        case "Jaguar Marching Band":
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = "Jaguar Marching Band";
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //        default:
            //            comm = new SqlCommand("InsertStudentInterestAreas", connection);
            //            comm.CommandType = CommandType.StoredProcedure;
            //            comm.Parameters.Add(new SqlParameter("@StudentFirstName", SqlDbType.VarChar)).Value = interestAreas[i];
            //            comm.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar)).Value = newID;
            //            rowsAffected = comm.ExecuteNonQuery();
            //            break;
            //    }
            //}
            //connection.Close();
        }
        private string[] InterestAreaFormat(StudentToAdd student)
        {
            string[] selectedInterestAreas = new string[0];

            foreach (var property in student.InterestAreas.GetType().GetProperties())
            {
                if (!property.GetValue(student.InterestAreas).Equals(false))
                {
                    Array.Resize(ref selectedInterestAreas, selectedInterestAreas.Count() + 1);
                    var count = selectedInterestAreas.Count();
                    selectedInterestAreas[count] = property.Name;
                }
            }
            Array.Resize(ref selectedInterestAreas, selectedInterestAreas.Count());
            return selectedInterestAreas;
        }
    }
}