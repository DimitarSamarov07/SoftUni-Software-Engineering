-- Remove the next live if you are submitting to Judge
CREATE DATABASE Movies

CREATE TABLE Directors
(
    Id           INT PRIMARY KEY IDENTITY,
    DirectorName NVARCHAR(60) NOT NULL,
    Notes        NVARCHAR(1000)
)

CREATE TABLE Genres
(
    Id        INT PRIMARY KEY IDENTITY,
    GenreName NVARCHAR(30) NOT NULL,
    Notes     NVARCHAR(1000)
)

CREATE TABLE Categories
(
    Id           INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(30) NOT NULL,
    Notes        NVARCHAR(1000)
)

CREATE TABLE Movies
(
    Id            INT PRIMARY KEY IDENTITY,
    Title         NVARCHAR(100) NOT NULL,
    DirectorId    INT           NOT NULL FOREIGN KEY REFERENCES Directors (Id),
    CopyrightYear INT           NOT NULL,
    Length        TIME          NOT NULL,
    GenreId       INT           NOT NULL FOREIGN KEY REFERENCES Genres (Id),
    CategoryId    INT           NOT NULL FOREIGN KEY REFERENCES Categories (Id),
    Rating        DECIMAL(5, 2),
    Notes         NVARCHAR(1000)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES ('Pesho', 'The smartest one'),
       ('Gergin', NULL),
       ('Gokata', 'The creator of God of Wars(Musaka Edition)'),
       ('Mariq', NULL),
       ('Stamo', 'Well... he is Stamo and he forgets...everything')

INSERT INTO Genres(GenreName, Notes)
VALUES ('Comedy', 'Blah blah..'),
       ('Action', NULL),
       ('Anime', 'Stupid animation :D'),
       ('Fantasy', NULL),
       ('History', 'DUUUUUMB')

INSERT INTO Categories(CategoryName, Notes)
VALUES ('Dumb things', 'Just dumb things...'),
       ('Best Of All Time', 'GOD LIVES HERE'),
       ('Oscars', NULL),
       ('Most disliked', NULL),
       ('Most expensive', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES ('Titanik',1,2000,'02:30:15',5,2,9.3,'Something'),
       ('The Matrix', 2,1999,'02:45:11',4,3,8.69,NULL),
       ('God of Wars(Musaka edition)',3,2014,'01:34:03',1,1,NULL,NULL),
       ('The China Gang Guy',5,2018,'00:30:59',3,4,6.76,'The China Gang Guy Dies'),
       ('Indiana Jones',4,2,'01:55:00',2,5,8.4,'It is not the most expensive,but I have to use all the keys soo...')