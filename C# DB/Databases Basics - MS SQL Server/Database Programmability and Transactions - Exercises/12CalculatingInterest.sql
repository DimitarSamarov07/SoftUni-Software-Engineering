CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
BEGIN
    SELECT A.Id,
           FirstName,
           LastName,
           Balance,
           dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5) AS [Balance in 5 years]
    FROM Accounts A
             JOIN AccountHolders AH ON A.AccountHolderId = AH.Id
    WHERE A.Id = @accountId
END
    EXEC usp_CalculateFutureValueForAccount 1, 0.1