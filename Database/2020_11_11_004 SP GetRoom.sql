USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetCity]    Script Date: 11.11.2020 21:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoom] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [RehersalRoomID], [RehersalRoomName], [RehersalRoomSize]
  FROM [dbo].[Room]
END
