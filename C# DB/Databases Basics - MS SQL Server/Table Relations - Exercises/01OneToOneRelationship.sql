CREATE TABLE Passports
(
    PassportID     INT PRIMARY KEY,
    PassportNumber NVARCHAR(10)
)
CREATE TABLE Persons
(
    PersonID   INT PRIMARY KEY IDENTITY,
    FirstName  NVARCHAR(30),
    Salary     DECIMAL(8, 2),
    PassportID INT FOREIGN KEY REFERENCES Passports (PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
       (102, 'K65LO4R7'),
       (103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102),
       ('Tom', 56100.00, 103),
       ('Yana', 60200.00, 101)