CREATE TABLE [data].[Member]
(
	[memberId] INT NOT NULL PRIMARY KEY, 
    [siteId] INT NOT NULL, 
    [firstName] NVARCHAR(50) NOT NULL, 
    [lastName] NVARCHAR(50) NOT NULL, 
    [address] NVARCHAR(50) NOT NULL, 
    [city] NVARCHAR(50) NOT NULL, 
    [state] NVARCHAR(50) NOT NULL, 
    [zip] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL, 
    [isEmailConfirmed] BIT NOT NULL, 
    [ipAddress] NVARCHAR(50) NOT NULL, 
    [lastLogin] DATE NOT NULL, 
    [isEmailSubscribed] BIT NOT NULL
)
