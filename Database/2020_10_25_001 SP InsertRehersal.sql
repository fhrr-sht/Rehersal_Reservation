USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRehersal]    Script Date: 25.10.2020 21:56:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertRehersal]
@RehersalSpaseName nvarchar(50),
@CityID int,
@Adress nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO [dbo].[RehersalSpase] ([RehersalSpaseName], [CityID],[Adress])
  SELECT @RehersalSpaseName, @CityID, @Adress  
END
