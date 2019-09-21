CREATE TABLE Users(
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) NOT NULL ,
    Password VARCHAR(26) NOT NULL ,
    ProfilePicture VARBINARY(MAX),
    CHECK(DATALENGTH(ProfilePicture) <= 900000),
    LastLoginTime DATETIME,
    IsDeleted VARCHAR(5),
    CHECK(IsDeleted = 'true' OR IsDeleted = 'false')
)

INSERT Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Gosho','NZPass',9000, '2019-03-04 16:13:14','true'),
('Ganco','NoPassButPass',2000, NULL,'false'),
('Genka','CannotPass134',3000, '2007-03-04 17:13:14','true'),
('Ivan','NoPassNoClass',4567, '1980-03-04 16:13:14','true'),
('Lena','BlueIsRed',6534, '2019-09-21 19:13:14','false')