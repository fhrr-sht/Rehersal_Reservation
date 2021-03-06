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
CREATE PROCEDURE [dbo].[InsertUser]
	  @UserType smallint
      ,@UserName nvarchar(50)
      ,@UserMail nvarchar(50)
      ,@UserPhone nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO [dbo].[User] ([UserType], [UserName], [UserMail], [UserPhone], [IsDeleted])
  SELECT  @UserType, @UserName, @UserMail, @UserPhone, 0
END
