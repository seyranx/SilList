CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [siteID] INT NULL, 
    [firstName] NVARCHAR(50) NULL, 
    [lastName] NVARCHAR(50) NULL, 
    [address] NVARCHAR(50) NULL, 
    [city] NVARCHAR(50) NULL, 
    [state] NVARCHAR(50) NULL, 
    [zip] NVARCHAR(50) NULL, 
    [email] NVARCHAR(50) NULL, 
    [username] NVARCHAR(50) NULL, 
    [password] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(50) NULL, 
    [isEmailConfirmed] BIT NULL, 
    [ipAddress] NVARCHAR(50) NULL, 
    [lastLogin] DATETIME NULL, 
    [isEmailSubscribed] BIT NULL
)
