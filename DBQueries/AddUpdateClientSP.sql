SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('AddUpdateClient', 'P') IS NOT NULL
	DROP PROC AddUpdateClient
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE AddUpdateClient
	-- Add the parameters for the stored procedure here
	@id int,
	@nombre varchar(50),
	@apellidos  varchar(50), 
	@direccion  varchar(100)

AS
BEGIN
	SET NOCOUNT ON;

	 IF(@id = 0)
        BEGIN
	
				INSERT INTO Clientes
				(nombre, apellidos, direccion) 
				VALUES  (@nombre,@apellidos, @direccion)
		END	
	 ELSE	  
		BEGIN

			UPDATE Clientes
				SET   nombre=@nombre, 
				apellidos=@apellidos, 
				direccion=@direccion
				WHERE  id_cliente = @id
		END
END

--GRANT EXECUTE ON AddUpdateClient TO sa;
--GO