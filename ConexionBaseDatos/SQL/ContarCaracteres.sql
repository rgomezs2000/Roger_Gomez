USE [cmmoneycash]
GO
/****** Object:  StoredProcedure [dbo].[ContarCaracteres]    Script Date: 11 mar. 2018 23:57:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ContarCaracteres]
	-- Add the parameters for the stored procedure here
	@COR_CORRESPONSAL_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1
		C.COR_CORRESPONSAL_ID,
		C.COR_NOMBRE,
		O.OFI_NOMBRE
	FROM
		Corresponsales AS C 
	INNER JOIN
		OFICINAS AS O 
	ON
		C.COR_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID 
	WHERE
		LEN(OFI_NOMBRE) = (SELECT
							MAX(LEN(OFI_NOMBRE))
						   FROM
							OFICINAS
						   WHERE
							OFICINAS.OFI_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID )
		AND C.COR_CORRESPONSAL_ID =  @COR_CORRESPONSAL_ID;

	SET NOCOUNT OFF;

END
