CREATE PROCEDURE [dbo].[DeleteDoctor]
	@DoctorId NVARCHAR(60) 
AS
BEGIN
	SELECT * FROM dbo.Doctors WHERE DoctorId = @DoctorId;
END