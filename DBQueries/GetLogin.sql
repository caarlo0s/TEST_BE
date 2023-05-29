SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('GetLogin', 'P') IS NOT NULL
	DROP PROC GetLogin
GO
-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE GetLogin
	@email  varchar(50),
	@password  varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
	@keyPassword varchar(50),
	@date datetime,
	@iuser int
    SET @keyPassword =  (SELECT value FROM Settings WHERE code='keyPassword')
	SET @iuser=(SELECT id_user FROM Users WHERE email= @email 
				AND convert(varchar(100), DECRYPTBYPASSPHRASE(@keyPassword,password)) = @password
				AND status = 1)
	IF (@iuser!=0)
	BEGIN 
	

		SELECT id_user, fullname, email, status 
			FROM Users
			WHERE email = @email
			AND convert(varchar(100), DECRYPTBYPASSPHRASE(@keyPassword,password)) = @password
			AND status = 1
				
	END
END
go


