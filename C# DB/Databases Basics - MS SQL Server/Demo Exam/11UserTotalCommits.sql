CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
    RETURNS INT
AS
BEGIN
    DECLARE @result INT
    Select
    TOP 1
    @result = SUM(CASE WHEN Username = @username THEN 1 ELSE 0 END)
    FROM Commits
             JOIN Users U on Commits.ContributorId = U.Id;
    RETURN @result
END
