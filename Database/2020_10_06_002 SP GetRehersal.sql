USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRehersal]    Script Date: 06.10.2020 20:30:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRehersal] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalSpaseID]
      ,[RehersalSpaseName]
      ,[CityID]
      ,[Adress]
  FROM [dbo].[RehersalSpase]
END
GO
