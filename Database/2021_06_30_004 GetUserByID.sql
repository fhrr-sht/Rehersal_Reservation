USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[InsertCity]    Script Date: 30.06.2021 14:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserByID]
	 @UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [UserID], [UserType], [UserName], [UserMail], [UserPhone], [IsDeleted]
  FROM [dbo].[User] WHERE UserID = @UserID AND IsDeleted=0 
END
