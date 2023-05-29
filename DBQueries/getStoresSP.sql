SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('GetStores', 'P') IS NOT NULL
	DROP PROC GetStores
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE GetStores

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select id_tienda, sucursal, direccion from Tienda
END

--GRANT EXECUTE ON GetStores TO sa;
--GO