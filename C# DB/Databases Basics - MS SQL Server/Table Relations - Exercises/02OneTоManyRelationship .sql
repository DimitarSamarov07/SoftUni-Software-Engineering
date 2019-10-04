CREATE TABLE Models
(
    ModelID        INT NOT NULL ,
    Name           NVARCHAR(30) NOT NULL,
    ManufacturerID INT          NOT NULL
)
CREATE TABLE Manufacturers
(
    ManufacturerID INT NOT NULL PRIMARY KEY IDENTITY,
    Name           NVARCHAR(30) NOT NULL,
    EstablishedOn  DATE         NOT NULL
)

ALTER TABLE Models
    ADD CONSTRAINT PK_Models
        PRIMARY KEY (ModelID)

ALTER TABLE Models
ADD CONSTRAINT FK_Models_ManufacturerID
FOREIGN KEY(ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)