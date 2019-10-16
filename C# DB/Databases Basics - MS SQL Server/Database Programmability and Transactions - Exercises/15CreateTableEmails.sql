CREATE TABLE NotificationEmails
(
    Id        INT PRIMARY KEY IDENTITY,
    Recipient INT           NOT NULL FOREIGN KEY REFERENCES Accounts (Id),
    Subject   NVARCHAR(50)  NOT NULL,
    Body      NVARCHAR(200) NOT NULL
)

CREATE TRIGGER tr_LogCreated
    ON Logs
    FOR INSERT
    AS
BEGIN
    INSERT INTO NotificationEmails(Recipient, Subject, Body)
    SELECT AccountId,
           CONCAT('Balance change for account: ', AccountId),
           CONCAT('On ', GETDATE(), ' your balance was changed from ', OldSum, NewSum)
    FROM Inserted
END
