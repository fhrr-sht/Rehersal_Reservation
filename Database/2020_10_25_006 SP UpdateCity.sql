USE [Rehersal]
GO
/****** Object:  StoredProcedure [dbo].[UpdateRehersal]    Script Date: 25.10.2020 22:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCity] 
@CityID int,
@CityName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].[City]
 SET  [CityName] = @CityName
    
  WHERE [CityID] = @CityID
END
