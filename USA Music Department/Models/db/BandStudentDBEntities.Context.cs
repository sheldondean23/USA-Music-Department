﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USA_Music_Department.Models.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BandStudentDBEntities : DbContext
    {
        public BandStudentDBEntities()
            : base("name=BandStudentDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<InterestArea> InterestAreas { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<StudentContact> StudentContacts { get; set; }
        public virtual DbSet<InterestAreatoStudent> InterestAreatoStudents { get; set; }
        public virtual DbSet<C_vGetUsers> C_vGetUsers { get; set; }
    
        public virtual int DeleteStudentData(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudentData", idParameter);
        }
    
        public virtual int InsertStudentData(string studentFirstName, string studentLastName, string studentAddress, string studentCity, string studentState, string studentZipCode, string studentPhone, string performanceMedium, string graduationYear, string emailAddress, ObjectParameter outputID)
        {
            var studentFirstNameParameter = studentFirstName != null ?
                new ObjectParameter("StudentFirstName", studentFirstName) :
                new ObjectParameter("StudentFirstName", typeof(string));
    
            var studentLastNameParameter = studentLastName != null ?
                new ObjectParameter("StudentLastName", studentLastName) :
                new ObjectParameter("StudentLastName", typeof(string));
    
            var studentAddressParameter = studentAddress != null ?
                new ObjectParameter("StudentAddress", studentAddress) :
                new ObjectParameter("StudentAddress", typeof(string));
    
            var studentCityParameter = studentCity != null ?
                new ObjectParameter("StudentCity", studentCity) :
                new ObjectParameter("StudentCity", typeof(string));
    
            var studentStateParameter = studentState != null ?
                new ObjectParameter("StudentState", studentState) :
                new ObjectParameter("StudentState", typeof(string));
    
            var studentZipCodeParameter = studentZipCode != null ?
                new ObjectParameter("StudentZipCode", studentZipCode) :
                new ObjectParameter("StudentZipCode", typeof(string));
    
            var studentPhoneParameter = studentPhone != null ?
                new ObjectParameter("StudentPhone", studentPhone) :
                new ObjectParameter("StudentPhone", typeof(string));
    
            var performanceMediumParameter = performanceMedium != null ?
                new ObjectParameter("PerformanceMedium", performanceMedium) :
                new ObjectParameter("PerformanceMedium", typeof(string));
    
            var graduationYearParameter = graduationYear != null ?
                new ObjectParameter("GraduationYear", graduationYear) :
                new ObjectParameter("GraduationYear", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertStudentData", studentFirstNameParameter, studentLastNameParameter, studentAddressParameter, studentCityParameter, studentStateParameter, studentZipCodeParameter, studentPhoneParameter, performanceMediumParameter, graduationYearParameter, emailAddressParameter, outputID);
        }
    
        public virtual int CreateUpdate_InterestAreas(Nullable<int> studentID, Nullable<bool> bMMusicEdVocal, Nullable<bool> bMMusicEdInst, Nullable<bool> bMMusicPerfVocal, Nullable<bool> bMMusicPerfInst, Nullable<bool> bMMusicElecStudiesBusiness, Nullable<bool> bMMusicElecStudiesOutsideFields, Nullable<bool> mMPerfPiano, Nullable<bool> mMPerfVocal, Nullable<bool> mMCollabPiano, Nullable<bool> musicMinor, Nullable<bool> instEnsembles, Nullable<bool> choralEnsembles, Nullable<bool> operaTheater, Nullable<bool> jMB, string other)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var bMMusicEdVocalParameter = bMMusicEdVocal.HasValue ?
                new ObjectParameter("BMMusicEdVocal", bMMusicEdVocal) :
                new ObjectParameter("BMMusicEdVocal", typeof(bool));
    
            var bMMusicEdInstParameter = bMMusicEdInst.HasValue ?
                new ObjectParameter("BMMusicEdInst", bMMusicEdInst) :
                new ObjectParameter("BMMusicEdInst", typeof(bool));
    
            var bMMusicPerfVocalParameter = bMMusicPerfVocal.HasValue ?
                new ObjectParameter("BMMusicPerfVocal", bMMusicPerfVocal) :
                new ObjectParameter("BMMusicPerfVocal", typeof(bool));
    
            var bMMusicPerfInstParameter = bMMusicPerfInst.HasValue ?
                new ObjectParameter("BMMusicPerfInst", bMMusicPerfInst) :
                new ObjectParameter("BMMusicPerfInst", typeof(bool));
    
            var bMMusicElecStudiesBusinessParameter = bMMusicElecStudiesBusiness.HasValue ?
                new ObjectParameter("BMMusicElecStudiesBusiness", bMMusicElecStudiesBusiness) :
                new ObjectParameter("BMMusicElecStudiesBusiness", typeof(bool));
    
            var bMMusicElecStudiesOutsideFieldsParameter = bMMusicElecStudiesOutsideFields.HasValue ?
                new ObjectParameter("BMMusicElecStudiesOutsideFields", bMMusicElecStudiesOutsideFields) :
                new ObjectParameter("BMMusicElecStudiesOutsideFields", typeof(bool));
    
            var mMPerfPianoParameter = mMPerfPiano.HasValue ?
                new ObjectParameter("MMPerfPiano", mMPerfPiano) :
                new ObjectParameter("MMPerfPiano", typeof(bool));
    
            var mMPerfVocalParameter = mMPerfVocal.HasValue ?
                new ObjectParameter("MMPerfVocal", mMPerfVocal) :
                new ObjectParameter("MMPerfVocal", typeof(bool));
    
            var mMCollabPianoParameter = mMCollabPiano.HasValue ?
                new ObjectParameter("MMCollabPiano", mMCollabPiano) :
                new ObjectParameter("MMCollabPiano", typeof(bool));
    
            var musicMinorParameter = musicMinor.HasValue ?
                new ObjectParameter("MusicMinor", musicMinor) :
                new ObjectParameter("MusicMinor", typeof(bool));
    
            var instEnsemblesParameter = instEnsembles.HasValue ?
                new ObjectParameter("InstEnsembles", instEnsembles) :
                new ObjectParameter("InstEnsembles", typeof(bool));
    
            var choralEnsemblesParameter = choralEnsembles.HasValue ?
                new ObjectParameter("ChoralEnsembles", choralEnsembles) :
                new ObjectParameter("ChoralEnsembles", typeof(bool));
    
            var operaTheaterParameter = operaTheater.HasValue ?
                new ObjectParameter("OperaTheater", operaTheater) :
                new ObjectParameter("OperaTheater", typeof(bool));
    
            var jMBParameter = jMB.HasValue ?
                new ObjectParameter("JMB", jMB) :
                new ObjectParameter("JMB", typeof(bool));
    
            var otherParameter = other != null ?
                new ObjectParameter("Other", other) :
                new ObjectParameter("Other", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUpdate_InterestAreas", studentIDParameter, bMMusicEdVocalParameter, bMMusicEdInstParameter, bMMusicPerfVocalParameter, bMMusicPerfInstParameter, bMMusicElecStudiesBusinessParameter, bMMusicElecStudiesOutsideFieldsParameter, mMPerfPianoParameter, mMPerfVocalParameter, mMCollabPianoParameter, musicMinorParameter, instEnsemblesParameter, choralEnsemblesParameter, operaTheaterParameter, jMBParameter, otherParameter);
        }
    
        public virtual ObjectResult<GetStudentDetails_Result> GetStudentDetails(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("Studentid", studentid) :
                new ObjectParameter("Studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentDetails_Result>("GetStudentDetails", studentidParameter);
        }
    
        public virtual ObjectResult<string> TableColumnNames(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("TableColumnNames", tableNameParameter);
        }
    
        public virtual int GetUserRoles(string userid)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("Userid", userid) :
                new ObjectParameter("Userid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetUserRoles", useridParameter);
        }
    
        public virtual int CreateBlankUserRecord(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateBlankUserRecord", userNameParameter);
        }
    
        public virtual int UpdateUserRecord(Nullable<int> userId, string userName, string userFirstName, string userLastName, Nullable<bool> active)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userFirstNameParameter = userFirstName != null ?
                new ObjectParameter("UserFirstName", userFirstName) :
                new ObjectParameter("UserFirstName", typeof(string));
    
            var userLastNameParameter = userLastName != null ?
                new ObjectParameter("UserLastName", userLastName) :
                new ObjectParameter("UserLastName", typeof(string));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUserRecord", userIdParameter, userNameParameter, userFirstNameParameter, userLastNameParameter, activeParameter);
        }
    
        public virtual int InsertContactRecord(Nullable<int> studentid, Nullable<int> contactedBy, Nullable<System.DateTime> contactedDate, string contactedMedium)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("Studentid", studentid) :
                new ObjectParameter("Studentid", typeof(int));
    
            var contactedByParameter = contactedBy.HasValue ?
                new ObjectParameter("ContactedBy", contactedBy) :
                new ObjectParameter("ContactedBy", typeof(int));
    
            var contactedDateParameter = contactedDate.HasValue ?
                new ObjectParameter("ContactedDate", contactedDate) :
                new ObjectParameter("ContactedDate", typeof(System.DateTime));
    
            var contactedMediumParameter = contactedMedium != null ?
                new ObjectParameter("ContactedMedium", contactedMedium) :
                new ObjectParameter("ContactedMedium", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertContactRecord", studentidParameter, contactedByParameter, contactedDateParameter, contactedMediumParameter);
        }
    }
}
