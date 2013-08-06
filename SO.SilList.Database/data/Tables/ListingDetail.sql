CREATE TABLE [data].[ListingDetail]
(
	[listingDetailId] UNIQUEIDENTIFIER NOT NULL  DEFAULT newid(), 
    [startDate] DATE NOT NULL DEFAULT getdate(), 
    [endDate] DATE NOT NULL DEFAULT getdate(), 
    [isApproved] BIT NULL DEFAULT 0,
	[created] DATETIME NOT NULL DEFAULT getdate(), 
    [modified] DATETIME NOT NULL DEFAULT getdate(), 
    [createdBy] INT NULL, 
    [modifiedBy] INT NULL, 
    [isActive] BIT NOT NULL DEFAULT ((1)), 
    CONSTRAINT [PK_ListingDetail] PRIMARY KEY ([listingDetailId])
)
