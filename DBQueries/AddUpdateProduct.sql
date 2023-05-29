SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('AddUpdateProduct', 'P') IS NOT NULL
	DROP PROC AddUpdateProduct
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 25/02/2023
-- Description:	Add Update Product
-- =============================================
CREATE PROCEDURE AddUpdateProduct
	-- Add the parameters for the stored procedure here
	@id_articulo int,
	@codigo varchar(50),
	@descripcion  varchar(100),
	@precio decimal(6,2),
	@imagen varchar(max)

AS
BEGIN
	SET NOCOUNT ON;
	declare 

	@id int
    
	set @id=(SELECT COUNT(*) as Existe FROM Articulos WHERE id_articulo=@id_articulo)

	 IF(@id = 0)
        BEGIN
			INSERT INTO Articulos
			(codigo,descripcion,imagen,precio) 
			VALUES  (@codigo,@descripcion,@imagen,@precio) 
					
				
		END	
	 ELSE	  
		BEGIN
		UPDATE Articulos
		SET  codigo=@codigo,descripcion=@descripcion,imagen=@imagen,precio=@precio
		WHERE  id_articulo = @id_articulo
		
			
		END
END

--GRANT EXECUTE ON AddUpdateStore TO sa;
--GO