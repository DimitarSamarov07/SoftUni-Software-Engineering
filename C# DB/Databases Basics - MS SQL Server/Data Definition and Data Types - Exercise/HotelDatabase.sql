--Remove the next line if you are submitting to Judge
-- CREATE DATABASE Hotel

CREATE TABLE Employees
(
    Id        INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(20) NOT NULL,
    LastName  VARCHAR(30) NOT NULL,
    Title     VARCHAR(50) NOT NULL,
    Notes     NVARCHAR(MAX)
)

CREATE TABLE Customers
(
    AccountNumber   INT PRIMARY KEY IDENTITY NOT NULL,
    FirstName       VARCHAR(30)              NOT NULL,
    LastName        VARCHAR(30)              NOT NULL,
    PhoneNumber     VARCHAR(15)              NOT NULL,
    EmergencyName   VARCHAR(40)              NOT NULL,
    EmergencyNumber VARCHAR(15)              NOT NULL,
    Notes           VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
    RoomStatus VARCHAR(20) PRIMARY KEY NOT NULL,
    Notes      VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
    RoomType VARCHAR(30) PRIMARY KEY NOT NULL,
    Notes    VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
    BedType VARCHAR(20) PRIMARY KEY NOT NULL,
    Notes   VARCHAR(MAX)
)

CREATE TABLE Rooms
(
    RoomNumber INT           NOT NULL PRIMARY KEY,
    RoomType   VARCHAR(30)   NOT NULL FOREIGN KEY REFERENCES RoomTypes (RoomType),
    BedType    VARCHAR(20)   NOT NULL FOREIGN KEY REFERENCES BedTypes (BedType),
    Rate       DECIMAL(4, 2) NOT NULL,
    RoomStatus VARCHAR(20)   NOT NULL FOREIGN KEY REFERENCES RoomStatus (RoomStatus),
    Notes      NVARCHAR(MAX)
)

CREATE TABLE Payments
(
    Id                INT PRIMARY KEY IDENTITY,
    EmployeeId        INT            NOT NULL FOREIGN KEY REFERENCES Employees (Id),
    PaymentDate       DATE           NOT NULL,
    AccountNumber     INT            NOT NULL FOREIGN KEY REFERENCES Customers (AccountNumber),
    FirstDateOccupied DATE           NOT NULL,
    LastDateOccupied  DATE           NOT NULL,
    TotalDays         INT            NOT NULL,
    AmountCharged     DECIMAL(10, 2) NOT NULL,
    TaxRate           DECIMAL(4, 2)  NOT NULL,
    TaxAmount         DECIMAL(6, 2)  NOT NULL,
    PaymentTotal      DECIMAL(10, 2) NOT NULL,
    Notes             NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
    Id            INT PRIMARY KEY IDENTITY,
    EmployeeId    INT  NOT NULL FOREIGN KEY REFERENCES Employees (Id),
    DateOccupied  DATE NOT NULL,
    AccountNumber INT  NOT NULL FOREIGN KEY REFERENCES Customers (AccountNumber),
    RoomNumber    INT  NOT NULL FOREIGN KEY REFERENCES Rooms (RoomNumber),
    RateApplied   DECIMAL(4, 2),
    PhoneCharge   DECIMAL(5, 2),
    Notes         NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Gosho', 'Petkov', 'Receptionist', 'Should receive a raise soon!'),
       ('Pesho', 'Dimitrov', 'Manager', NULL),
       ('Pena', 'Georgieva', 'Cleaner', 'She is very lazy :( ')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('Gosho', 'Peshov', '+359 887992243', 'GENKA', '+359 886231153', 'Nz'),
       ('Goso', 'Plshov', '+359 845992243', 'Lenka', '+359 886212153', NULL),
       ('Jane ', 'Lame', '+359 810992243', 'Gergin', '+359 346231153', 'Nzzz')

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES ('Taken', 'Sth'),
       ('Free', NULL),
       ('Under maintenance', 'DO NOT ENTER!!')

INSERT INTO RoomTypes(RoomType, Notes)
VALUES ('For One Person', 'Sth'),
       ('Studio', '2-4 persons'),
       ('Balcony', '2 persons')

INSERT BedTypes(BedType, Notes)
VALUES ('Single', 'Nz'),
       ('Double', NULL),
       ('Sofa', NULL)

INSERT Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES (100, 'For One Person', 'Single', 5.6, 'Taken', 'Sth'),
       (200, 'Studio', 'Double', 7.5, 'Free', NULL),
       (300, 'Balcony', 'Sofa', 9.8, 'Under maintenance', NULL)

INSERT Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged,
                TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (1, '2019-02-02', 1, '2019-02-01', '2019-02-02', 1, 120.12, 4, 20, 140.12, NULL),
       (2, '2018-02-02', 2, '2018-01-02', '2018-02-02', 30, 134.12, 20, 40, 160, 'STH'),
       (3, '2017-02-02', 3, '2017-01-02', '2017-02-02', 30, 123.34, 20, 40.12, 180, NULL)

INSERT Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1, '2019-02-02', 1, 100, 6.7, 30.10, 'NZ'),
       (2, '2019-02-03', 2, 200, 4.3, 0, NULL),
       (3, '2019-02-04', 3, 300, 9.8, 50, NULL)