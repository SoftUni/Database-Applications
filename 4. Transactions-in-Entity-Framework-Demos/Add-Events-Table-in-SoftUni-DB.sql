USE SoftUni
GO

IF OBJECT_ID('Events') IS NULL
BEGIN
	CREATE TABLE Events(
		Id int IDENTITY NOT NULL,
		Name nvarchar(100) NOT NULL,
		Date datetime NOT NULL,
		AddressID int NULL,
	  CONSTRAINT PK_Events PRIMARY KEY CLUSTERED(Id),
	  CONSTRAINT UK_Events_Name_DateTime UNIQUE(Name, Date)
	)
	ALTER TABLE Events ADD CONSTRAINT FK_Events_Addresses
	FOREIGN KEY(AddressID) REFERENCES Addresses(AddressID)
END
