CREATE TABLE People
(
    Id        INT PRIMARY KEY IDENTITY,
    Name      VARCHAR(200) NOT NULL,
    Picture   varbinary(MAX),
    CHECK (DATALENGTH(Picture) <= 2097152),
    Height    DECIMAL(10, 2),
    Weight    DECIMAL(10, 2),
    Gender    CHAR(1)      NOT NULL,
    CHECK (Gender = 'm' OR Gender = 'f'),
    Birthdate DATE         NOT NULL,
    Biography VARCHAR(MAX)
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Ivan',NULL,NULL,NULL,'m','2007-01-21',NULL),
('Mqriq',NULL,NULL,NULL,'f','2003-09-29',NULL),
('Pena',1222,1.70,50.1,'f','2008-03-01','No idea :D'),
('Tosho',3444,1.85,80.3,'m','1990-05-24','Still alive somewhere in the universe!'),
('Gergin',2000,1.89,83.3,'m','1950-05-24','Too old to write ;D')



