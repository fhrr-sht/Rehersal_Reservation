USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRehersal]    Script Date: 25.10.2020 22:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCity] 
@CityID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 DELETE FROM [dbo].[City] WHERE [CityID] = @CityID
END
