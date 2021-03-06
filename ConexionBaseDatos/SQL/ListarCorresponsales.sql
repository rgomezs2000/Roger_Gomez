USE [cmmoneycash]
GO
/****** Object:  StoredProcedure [dbo].[ListarCorresponsales]    Script Date: 11 mar. 2018 23:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[ListarCorresponsales] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		COR_CORRESPONSAL_ID,
		COR_NOMBRE,
		COUNT(O.OFI_CORRESPONSAL_ID) AS COR_NRO_OFI 
	FROM
		CORRESPONSALES AS C 
	INNER JOIN
		OFICINAS AS O 
	ON
		O.OFI_CORRESPONSAL_ID = C.COR_CORRESPONSAL_ID 
	GROUP BY
		COR_CORRESPONSAL_ID, COR_NOMBRE
	ORDER BY
		COR_NOMBRE;

	SET NOCOUNT OFF;

END
