CREATE PROC usp_FindByExtension(@fileType NVARCHAR(30))
AS
BEGIN
    SELECT Id, Name, CONCAT(Size, 'KB') AS [Size]
    FROM Files
    WHERE Name LIKE '%' + @fileType + '%'
    ORDER BY Id, Name, Size DESC
END