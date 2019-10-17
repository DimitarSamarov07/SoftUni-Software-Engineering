CREATE TABLE Students
(
    Id         INT PRIMARY KEY IDENTITY,
    FirstName  NVARCHAR(30) NOT NULL,
    MiddleName NVARCHAR(25),
    LastName   NVARCHAR(30) NOT NULL,
    Age        INT CHECK (Age BETWEEN 5 AND 100),
    Address    NVARCHAR(50),
    Phone      NCHAR(10)
)

CREATE TABLE Subjects
(
    Id      INT PRIMARY KEY IDENTITY,
    Name    NVARCHAR(20)            NOT NULL,
    Lessons INT CHECK (Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects
(
    Id        INT PRIMARY KEY IDENTITY,
    StudentId INT           NOT NULL FOREIGN KEY REFERENCES Students (Id),
    SubjectId INT           NOT NULL FOREIGN KEY REFERENCES Subjects (Id),
    Grade     DECIMAL(3, 2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
    Id        INT PRIMARY KEY IDENTITY,
    Date      DATETIME,
    SubjectId INT NOT NULL REFERENCES Subjects (Id)
)

CREATE TABLE StudentsExams
(
    StudentId INT           NOT NULL REFERENCES Students (Id),
    ExamId    INT           NOT NULL FOREIGN KEY REFERENCES Exams (Id),
    Grade     DECIMAL(3, 2) NOT NULL CHECK (Grade BETWEEN 2 AND 6),
    CONSTRAINT CK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
    Id        INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(20) NOT NULL,
    LastName  NVARCHAR(20) NOT NULL,
    Address   NVARCHAR(20),
    Phone     NCHAR(10),
    SubjectId INT          NOT NULL FOREIGN KEY REFERENCES Subjects (Id)
)

CREATE TABLE StudentsTeachers
(
    StudentId INT NOT NULL FOREIGN KEY REFERENCES Students (Id),
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers (Id),
    CONSTRAINT CK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)