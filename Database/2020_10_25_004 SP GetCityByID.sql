USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRehersalByID]    Script Date: 25.10.2020 22:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCityByID] 
@CityID  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [CityID],[CityName]
  FROM [dbo].[City] WHERE CityID = @CityID
END
