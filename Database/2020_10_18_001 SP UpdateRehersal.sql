USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRehersal]    Script Date: 18.10.2020 21:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRehersal] 
@RehersalSpaseID int,
@RehersalSpaseName nvarchar(50),
@CityID int,
@Adress nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[RehersalSpase]
 SET [RehersalSpaseName] = @RehersalSpaseName,
     [CityID] = @CityID,
     [Adress] = @Adress
  WHERE [RehersalSpaseID] = @RehersalSpaseID
END
