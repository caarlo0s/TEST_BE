SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('DeleteStore', 'P') IS NOT NULL
	DROP PROC DeleteStore
GO

-- =============================================
-- Author:		Carlos Vazquez
-- Create date: 18/02/2023
-- Description:	StorePRocedure for Insert,Update and Delete Users
-- =============================================
CREATE PROCEDURE DeleteStore
	@id  varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
delete from Tienda where id_tienda=@id
END

--GRANT EXECUTE ON getOrders TO sa;
--GO