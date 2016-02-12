using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USA_Music_Department.Models.Forms.Interest_Form;
using USA_Music_Department.Models.db;

namespace USA_Music_Department.Models.db
{
    public class StudentManipulation : dbConnector
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
                                          student.InterestAreas.Opera_Theatre, student.InterestAreas.Jaguar_Marching_Band, student.InterestAreas.Other);
            db.SaveChanges();
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}