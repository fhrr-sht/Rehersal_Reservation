USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[InsertCity]    Script Date: 11.11.2020 21:59:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertRoom]
@RehersalRoomName nvarchar(50),
@RehersalRoomSize int,
@RehersalSpaseID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO [dbo].[Room] ([RehersalRoomName],[RehersalRoomSize],[RehersalSpaseID])
  SELECT @RehersalRoomName, @RehersalRoomSize, @RehersalSpaseID
END
