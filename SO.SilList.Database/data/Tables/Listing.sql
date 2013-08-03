CREATE TABLE [data].[Listing]
(
	[listingId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [listingDetailId] UNIQUEIDENTIFIER NULL, 
    [title] NVARCHAR(50) NULL, 
    [description] NVARCHAR(50) NULL, 
    [siteId] INT NULL, 
    [listingTypeId] INT NULL,
    [createdBy ] INT NULL, 
    [modifiedBy] INT NULL, 
    [created] DATETIME NOT NULL DEFAULT (getdate()), 
    [modified] DATETIME NOT NULL DEFAULT (getdate()), 
    [isActive] BIT NOT NULL DEFAULT ((1))
)
