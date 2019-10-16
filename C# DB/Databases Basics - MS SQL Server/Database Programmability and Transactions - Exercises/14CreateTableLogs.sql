CREATE TABLE Logs
(
    LogId     INT PRIMARY KEY IDENTITY,
    AccountId INT   NOT NULL FOREIGN KEY REFERENCES Accounts (Id),
    OldSum    MONEY NOT NULL,
    NewSum    MONEY NOT NULL
)
CREATE TRIGGER tr_sumUpdate
    ON Accounts
    FOR UPDATE
    AS
BEGIN
    INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT D.Id,
           D.Balance,
           I.Balance
    FROM Deleted AS D
             INNER JOIN Inserted AS I ON I.Id = D.Id
END