
-- =============================================
-- Author:		Nicolas Meller
-- Create date: 6/20/2018
-- Description:	Basic example of stored proc
-- =============================================
CREATE PROCEDURE [dbo].[Example] 
    @startDate DATETIME
	,@endDate DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.Id
	FROM dbo.Users u
	WHERE u.CreatedDate BETWEEN @startDate AND @endDate
	ORDER BY u.LastName, u.FirstName
END