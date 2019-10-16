CREATE PROCEDURE usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(18, 4))
AS
    BEGIN TRANSACTION
    IF (@moneyAmount < 0)
        BEGIN
            RAISERROR ('Invalid money amount!!',16,1)
        END
UPDATE Accounts
SET Balance+=@moneyAmount
WHERE Id = @accountId
    COMMIT
