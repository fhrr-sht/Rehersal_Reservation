USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetRoom]    Script Date: 12.11.2020 18:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetRoom] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalRoomID], [RehersalRoomName], [RehersalRoomSize], [RehersalSpaseID]
  FROM [dbo].[Room]
END
