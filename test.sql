select * from Students 
inner join StudentContacts on StudentContacts.StudentId = Students.StudentID 
where StudentContacts.ContactedDate >= Convert(datetime, '2010-04-01' ) and StudentContacts.ContactedDate <= Convert(datetime, '2010-04-01' )