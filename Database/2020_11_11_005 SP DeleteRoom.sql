USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRehersal]    Script Date: 11.11.2020 21:49:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRoom] 
@RehersalRoomID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 DELETE FROM [dbo].[Room] WHERE [RehersalRoomID] = @RehersalRoomID
END
