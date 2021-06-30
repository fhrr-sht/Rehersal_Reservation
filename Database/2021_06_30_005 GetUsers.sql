USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 30.06.2021 14:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [UserID], [UserType], [UserName], [UserMail], [UserPhone], [IsDeleted]
  FROM [dbo].[User] WHERE IsDeleted=0 
END
