SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('AddUpdProductStock', 'P') IS NOT NULL
	DROP PROC AddUpdProductStock
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 25/02/2023
-- Description:	Add Update Product
-- =============================================
CREATE PROCEDURE AddUpdProductStock
	-- Add the parameters for the stored procedure here
	@id int,
	@id_articulo varchar(50),
	@id_tienda  varchar(100),
	@stock decimal(6,2)
AS
BEGIN
	SET NOCOUNT ON;
	declare 
	@existe int
	set @existe= (SELECT COUNT(*) as exis FROM Stock_Tienda WHERE id_articulo_r=@id_articulo AND id_tienda_r=@id_tienda)
	 IF(@existe = 0)
        BEGIN
			INSERT INTO Stock_Tienda
			(id_articulo_r,id_tienda_r,stock) 
			VALUES  (@id_articulo,@id_tienda,@stock) 
					
				
		END	
	 ELSE	  
		BEGIN
		UPDATE Stock_Tienda
		SET id_articulo_r=@id_articulo,id_tienda_r=@id_tienda,stock=@stock
		WHERE   id_articulo_r=@id_articulo AND id_tienda_r=@id_tienda
		
			
		END
END

--GRANT EXECUTE ON AddProductStock TO sa;
--GO