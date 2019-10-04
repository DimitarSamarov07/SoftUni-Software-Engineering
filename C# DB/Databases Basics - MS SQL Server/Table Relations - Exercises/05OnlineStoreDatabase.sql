CREATE TABLE ItemTypes
(
    ItemTypeID INT PRIMARY KEY NOT NULL,
    Name       VARCHAR(50)
)

CREATE TABLE Items
(
    ItemID     INT PRIMARY KEY NOT NULL,
    ItemTypeID INT             NOT NULL FOREIGN KEY REFERENCES ItemTypes (ItemTypeID)
)

CREATE TABLE Cities
(
    CityID INT PRIMARY KEY NOT NULL,
    Name   VARCHAR(50)     NOT NULL
)
CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY NOT NULL,
    Name       VARCHAR(50)     NOT NULL,
    Birthday   DATE,
    CityID     INT             NOT NULL FOREIGN KEY REFERENCES Cities (CityID)
)

CREATE TABLE Orders
(
    OrderID    INT PRIMARY KEY NOT NULL,
    CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID)
)
CREATE TABLE OrderItems
(
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders (OrderID),
    ItemID  INT NOT NULL FOREIGN KEY REFERENCES Items (ItemID)
)
ALTER TABLE OrderItems
    ADD CONSTRAINT PK_OrderItems
        PRIMARY KEY (OrderID, ItemID)
