USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCity]    Script Date: 30.06.2021 14:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser] 
@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 UPDATE  [dbo].[User] 
 SET  [IsDeleted] = 1
 WHERE [UserID] = @UserID
END
