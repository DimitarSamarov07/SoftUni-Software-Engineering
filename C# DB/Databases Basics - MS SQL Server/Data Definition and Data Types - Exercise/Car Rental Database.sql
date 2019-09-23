-- Remove the next line if you are submitting to Judge
-- CREATE DATABASE CarRental

CREATE TABLE Categories
(
    Id           INT PRIMARY KEY IDENTITY,
    CategoryName VARCHAR(50) NOT NULL,
    DailyRate    DECIMAL(5, 2),
    WeeklyRate   DECIMAL(5, 2),
    MonthlyRate  DECIMAL(5, 2),
    WeekendRate  DECIMAL(5, 2)
)

CREATE TABLE Cars
(
    Id           INT PRIMARY KEY IDENTITY,
    PlateNumber  NVARCHAR(30),
    Manufacturer NVARCHAR(30) NOT NULL,
    Model        VARCHAR(40)  NOT NULL,
    CarYear      INT          NULL,
    CategoryId   INT          NOT NULL FOREIGN KEY REFERENCES Categories (Id),
    Doors        SMALLINT     NOT NULL,
    Picture      VARBINARY(MAX),
    Condition    VARCHAR(15)  NOT NULL,
    Available    NVARCHAR(5)  NOT NULL
)

CREATE TABLE Employees
(
    Id        INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    LastName  VARCHAR(30) NOT NULL,
    Title     VARCHAR(30) NOT NULL,
    Notes     NVARCHAR(MAX)
)

CREATE TABLE Customers
(
    Id                  INT PRIMARY KEY IDENTITY,
    DriverLicenceNumber VARCHAR(30)   NOT NULL,
    FullName            VARCHAR(80)   NOT NULL,
    Address             NVARCHAR(100) NOT NULL,
    City                NVARCHAR(30)  NOT NULL,
    ZIPCode             INT           NOT NULL,
    Notes               NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
    Id               INT PRIMARY KEY IDENTITY,
    EmployeeId       INT           NOT NULL FOREIGN KEY REFERENCES Employees (Id),
    CustomerId       INT           NOT NULL FOREIGN KEY REFERENCES Customers (Id),
    CarId            INT           NOT NULL FOREIGN KEY REFERENCES Cars (Id),
    TankLevel        DECIMAL(6, 2) NOT NULL,
    KilometrageStart INT           NOT NULL,
    KilometrageEnd   INT           NOT NULL,
    TotalKilometrage INT           NOT NULL,
    StartDate        DATE          NOT NULL,
    EndDate          DATE          NOT NULL,
    TotalDays        SMALLINT      NOT NULL,
    RateApplied      BIT,
    TaxRate          DECIMAL(4, 2) NOT NULL,
    OrderStatus      VARCHAR(20)   NOT NULL,
    Notes            NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Town Cars', 8, 9, 7, 4),
       ('Sport Cars', NULL, NULL, NULL, NULL),
       ('Cheap Cars', 4, 5, 6, 5)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES ('1111111', 'BMW', 'X4', 2017, 1, 2, 12222, 'Good', 'Yes'),
       ('11a223df', 'Volkswagen', 'Golf MK3', 1991, 3, 4, NULL, 'Not Bad', 'No'),
       ('RV 111 222 DS', 'Tesla', 'S', 2019, 2, 4, 29929, 'Perfect', 'Yes')

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Pesho', 'Petkov', 'The Smartest man', 'Will receive raise'),
       ('Stamo', 'Petkov', 'Nz', 'Does not remember his name... :('),
       ('Gosho', 'Leniviq', 'Lazy', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES ('122NERAoo9', 'Ivan Kostadinov Petkov', '42, Bancika street', 'London', 22132, 'He is still alive'),
       ('121FJFJkkk00', 'Gosho Borisov Petkov', '41, Musaka street', 'Sofia', 2312, NULL),
       ('123NULTkkks123', 'Boris Ivanov Samarov', '40, Pesho street', 'Paris', 22134, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
                         StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1, 1, 1, 50.1, 20000, 30000, 10000, '2018-02-15', '2019-12-13', 800, 2, 21.2, 'In Progress', 'Some notes'),
       (2, 2, 2, 40.3, 0, 10000, 10000, '2016-09-23', '2017-09-23', 365, 1, 32.4, 'Completed', NULL),
       (3, 3, 3, 20.3, 45345, 45800, 455, '2019-09-22', '2019-09-23', 1, 2, 34, 'Completed', NULL)