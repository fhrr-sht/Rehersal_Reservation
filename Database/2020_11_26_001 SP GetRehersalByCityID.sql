USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRehersalByID]    Script Date: 26.11.2020 20:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRehersalByCityID] 
@CityID  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalSpaseID]
      ,[RehersalSpaseName]
      ,[CityID]
      ,[Adress]
  FROM [dbo].[RehersalSpase] WHERE CityID = @CityID
END
