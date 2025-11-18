CREATE PROCEDURE [dbo].[CreateDoctors]
	@DoctorId NVARCHAR(60), 
    @FirstName NCHAR(50),
	@LastName NVARCHAR(50),
	@PatientName NVARCHAR(50),
	@Specialty NVARCHAR(50)
AS
BEGIN
	INSERT INTO Doctors ([DoctorId], [FirstName], [LastName], [PatientName], [Specialty])
	VALUES (@DoctorId, @FirstName, @LastName, @PatientName, @Specialty)
END