SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('AddUpdateStore', 'P') IS NOT NULL
	DROP PROC AddUpdateStore
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 25/02/2023
-- Description:	Add Update Store
-- =============================================
CREATE PROCEDURE AddUpdateStore
	-- Add the parameters for the stored procedure here
	@id int,
	@sucursal varchar(50),
	@direccion  varchar(100)

AS
BEGIN
	SET NOCOUNT ON;

	 IF(@id = 0)
        BEGIN
	
				INSERT INTO Tienda
				(sucursal,  direccion) 
				VALUES  (@sucursal, @direccion)
		END	
	 ELSE	  
		BEGIN

			UPDATE Tienda
				SET   sucursal=@sucursal, 				
				direccion=@direccion
				WHERE  id_tienda = @id
		END
END

--GRANT EXECUTE ON AddUpdateStore TO sa;
--GO