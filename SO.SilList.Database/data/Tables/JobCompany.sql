CREATE TABLE [data].[JobCompany]
(
	[jobCompanyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NULL, 
    [address] NVARCHAR(50) NULL, 
    [city] NVARCHAR(50) NULL, 
    [state] NVARCHAR(50) NULL, 
    [zip] INT NULL, 
    [website] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(50) NULL, 
    [siteId] NCHAR(10) NULL, 
    [created] DATETIME NULL DEFAULT getdate(), 
    [modified] DATETIME NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NULL
)
