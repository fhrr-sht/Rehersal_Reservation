USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetCityByID]    Script Date: 11.11.2020 21:56:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoomByID] 
@RehersalRoomID  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalRoomID],[RehersalRoomName],[RehersalRoomSize],[RehersalSpaseID]
  FROM [dbo].[Room] WHERE RehersalRoomID = @RehersalRoomID
END
