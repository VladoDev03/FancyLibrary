CREATE DATABASE FancyLibrary;

USE FancyLibrary;

CREATE TABLE Countries (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE Authors (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	Birthday DATE,
	Nickname VARCHAR(50) --UNIQUE,
	CountryId INT FOREIGN KEY REFERENCES Countries(id)
);

CREATE TABLE Contacts (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Email VARCHAR(50) --UNIQUE,
	Phone VARCHAR(50) --UNIQUE
);

CREATE TABLE LogData (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	LastTimeLoggedIn DATETIME NOT NULL,
	IsOnline BIT NOT NULL,
	RegisterDate DATE NOT NULL,
	TimesLoggedIn INT NOT NULL,
);

CREATE TABLE Books (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Title VARCHAR(50) NOT NULL UNIQUE,
	Genre VARCHAR(50) NOT NULL,
	[Year] INT,
	Pages INT,
	AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(id),
	InspiredById INT FOREIGN KEY REFERENCES Books(id)
);

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(50) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	Birthday DATE NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(id) --UNIQUE,
	LogDataId INT NOT NULL UNIQUE FOREIGN KEY REFERENCES LogData(id),
	CountryId INT FOREIGN KEY REFERENCES Countries(id)
);

CREATE TABLE UsersBooks (
	UserId INT UNIQUE FOREIGN KEY REFERENCES Users(id),
	BookId INT UNIQUE FOREIGN KEY REFERENCES Books(id),
	PRIMARY KEY (UserId, BookId)
);