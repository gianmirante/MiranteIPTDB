CREATE PROCEDURE [dbo].[UpdateDoctor]
	@DoctorId NVARCHAR(60), 
    @FirstName NCHAR(50),
	@LastName NVARCHAR(50),
	@PatientName NVARCHAR(50),
	@Specialty NVARCHAR(50)
AS
BEGIN
     Update dbo.Doctors
	 SET DoctorId = @DoctorId,
         FirstName = @FirstName,
	     LastName = @LastName,
		 PatientName = @PatientName,
	     Specialty = @Specialty
     WHERE DoctorId = @DoctorId;
END