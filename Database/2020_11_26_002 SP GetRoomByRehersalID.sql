USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRoomByID]    Script Date: 26.11.2020 20:43:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoomByRehersalID] 
@RehersalSpaceID  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalRoomID],[RehersalRoomName],[RehersalRoomSize],[RehersalSpaseID]
  FROM [dbo].[Room] WHERE RehersalSpaseID = @RehersalSpaceID
END
