USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCity]    Script Date: 11.11.2020 22:03:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRoom] 
@RehersalRoomID int,
@RehersalRoomName nvarchar(50),
@RehersalSpaseID int,
@RehersalRoomSize int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[Room]
 SET  [RehersalRoomName] = @RehersalRoomName,
[RehersalSpaseID] = @RehersalSpaseID,
[RehersalRoomSize] = @RehersalRoomSize    
  WHERE [RehersalRoomID] = @RehersalRoomID
END
