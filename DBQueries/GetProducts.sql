SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('GetProducts', 'P') IS NOT NULL
	DROP PROC GetProducts
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE GetProducts

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select id_articulo,codigo,descripcion,precio,imagen from Articulos
END

--GRANT EXECUTE ON GetProducts TO sa;
--GO