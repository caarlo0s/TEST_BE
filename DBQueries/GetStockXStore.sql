SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('GetStockXStore', 'P') IS NOT NULL
	DROP PROC GetStockXStore
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE GetStockXStore
@codigo varchar(50),
@id_articulo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT         Tienda.sucursal, Stock_Tienda.stock
FROM            Stock_Tienda INNER JOIN
                         Articulos ON Stock_Tienda.id_articulo_r = Articulos.id_articulo INNER JOIN
                         Tienda ON Stock_Tienda.id_tienda_r = Tienda.id_tienda
WHERE        (Articulos.codigo = @codigo) AND (Articulos.id_articulo =@id_articulo)
END

--GRANT EXECUTE ON GetStock TO sa;
--GO