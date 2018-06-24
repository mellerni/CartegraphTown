
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

	SELECT c.Id
        ,c.LastName
        ,c.FirstName      
	FROM dbo.Citizens c
	WHERE c.CreatedDate BETWEEN @startDate AND @endDate
	ORDER BY c.LastName, c.FirstName
END