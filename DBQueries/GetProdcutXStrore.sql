SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('GetProdcutXStrore', 'P') IS NOT NULL
	DROP PROC GetProdcutXStrore
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE GetProdcutXStrore

@id_tienda int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT        Articulos.id_articulo, Articulos.codigo, Articulos.descripcion, Articulos.precio, Articulos.imagen
FROM            Articulos INNER JOIN
                         Stock_Tienda ON Articulos.id_articulo = Stock_Tienda.id_articulo_r INNER JOIN
                         Tienda ON Stock_Tienda.id_tienda_r = Tienda.id_tienda
WHERE        (Stock_Tienda.stock > 0) AND (Stock_Tienda.id_tienda_r = @id_tienda)
END

--GRANT EXECUTE ON GetStock TO sa;
--GO