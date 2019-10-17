CREATE TABLE Planes
(
    Id    INT PRIMARY KEY IDENTITY,
    Name  NVARCHAR(30) NOT NULL,
    Seats INT          NOT NULL,
    Range INT          NOT NULL
)

CREATE TABLE Flights
(
    Id            INT PRIMARY KEY IDENTITY,
    DepartureTime DATETIME,
    ArrivalTime   DATETIME,
    Origin        NVARCHAR(50) NOT NULL,
    Destination   NVARCHAR(50) NOT NULL,
    PlaneId       INT          NOT NULL FOREIGN KEY REFERENCES Planes (Id)
)

CREATE TABLE Passengers
(
    Id         INT PRIMARY KEY IDENTITY,
    FirstName  NVARCHAR(30) NOT NULL,
    LastName   NVARCHAR(30) NOT NULL,
    Age        INT          NOT NULL,
    Address    NVARCHAR(30) NOT NULL,
    PassportId CHAR(11)     NOT NULL
)

CREATE TABLE LuggageTypes
(
    Id   INT PRIMARY KEY IDENTITY,
    Type NVARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages
(
    Id            INT PRIMARY KEY IDENTITY,
    LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes (Id),
    PassengerId   INT NOT NULL FOREIGN KEY REFERENCES Passengers (Id)
)

CREATE TABLE Tickets
(
    Id          INT PRIMARY KEY IDENTITY,
    PassengerId INT            NOT NULL FOREIGN KEY REFERENCES Passengers (Id),
    FlightId    INT            NOT NULL FOREIGN KEY REFERENCES Flights (Id),
    LuggageId   INT            NOT NULL FOREIGN KEY REFERENCES Luggages (Id),
    Price       DECIMAL(18, 2) NOT NULL
)