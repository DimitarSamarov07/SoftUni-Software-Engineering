CREATE PROC usp_GetTownsStartingWith @Param NVARCHAR(200)
AS
BEGIN
    SELECT Name
    FROM Towns
    WHERE LEFT(Name, LEN(@Param)) = @Param
END
