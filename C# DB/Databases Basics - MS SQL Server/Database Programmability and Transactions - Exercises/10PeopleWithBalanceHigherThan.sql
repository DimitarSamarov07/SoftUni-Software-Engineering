CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@moneyAmount DECIMAL(20,5))
AS
BEGIN
    SELECT FirstName, LastName
    FROM Accounts
             JOIN AccountHolders AH ON Accounts.AccountHolderId = AH.Id
    GROUP BY FirstName, LastName
    HAVING SUM(Balance) > @moneyAmount
    ORDER BY FirstName, LastName
END