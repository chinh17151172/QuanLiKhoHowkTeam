CREATE DATABASE QuanLiKho
GO

USE QuanLiKho
GO

CREATE TABLE Unit
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName NVARCHAR(MAX)
)
GO

CREATE TABLE Supplier
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName NVARCHAR(MAX),
	Address nvarchar(MAX),
	Phone NVARCHAR(20),
	Email NVARCHAR(200),
	MoreInfo NVARCHAR(Max),
	ContractDate DateTime
)
GO

CREATE TABLE Customer
(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(200),
	MoreInfo nvarchar(max),
	ContractDate DateTime
)
GO

CREATE TABLE Objects
(
	Id nvarchar(128) primary key,
	DisplayName nvarchar(max),
	IdUnit int not null,
	IdSuplier int not null,
	QRCode nvarchar(max),
	BarCode nvarchar(max)

	FOREIGN KEY(IdUnit) REFERENCES dbo.Unit(Id),
	FOREIGN KEY(IdSuplier) REFERENCES dbo.Supplier(Id),
)
GO

CREATE TABLE UserRole
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName NVARCHAR(max)
)
GO


CREATE TABLE Users
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	DisplayName NVARCHAR(max),
	UserName NVARCHAR(100),
	Password NVARCHAR(max),
	IdRole INT NOT NULL

	FOREIGN KEY(IdRole) REFERENCES dbo.UserRole(Id)
)
GO

CREATE TABLE Input
(
	Id NVARCHAR(128) PRIMARY KEY,
	DateInput DATETIME
)
GO

CREATE TABLE InputInfo
(
	Id NVARCHAR(128) PRIMARY KEY,
	IdObject NVARCHAR(128) NOT NULL,
	IdInput NVARCHAR(128) NOT NULL,
	Count INT,
	InputPrice FLOAT DEFAULT 0,
	OutputPrice FLOAT DEFAULT 0,
	Status NVARCHAR(MAX)

	FOREIGN KEY(IdObject) REFERENCES dbo.Objects(Id),
	FOREIGN KEY(IdInput) REFERENCES dbo.Input(Id)
)
GO

CREATE TABLE Output
(
	Id NVARCHAR(128) PRIMARY KEY,
	DateOutput DATETIME
)
GO

CREATE TABLE OutputInfo
(
	Id NVARCHAR(128) PRIMARY KEY,
	IdObject NVARCHAR(128) NOT NULL,
	IdOutputInfo NVARCHAR(128) NOT NULL,
	IdCustomer INT NOT NULL,
	Count INT,
	Status NVARCHAR(MAX)

	FOREIGN KEY(IdObject) REFERENCES dbo.Objects(Id),
	FOREIGN KEY(Id) REFERENCES dbo.Output(Id),
	FOREIGN KEY(IdCustomer) REFERENCES dbo.Customer(Id)
)
GO







