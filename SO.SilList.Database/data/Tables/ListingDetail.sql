CREATE TABLE [data].[ListingDetail]
(
	[listingDetailId] UNIQUEIDENTIFIER NOT NULL  DEFAULT newid(), 
    [startDate] DATE NULL DEFAULT getdate(), 
    [endDate] DATE NULL DEFAULT getdate(), 
    [isApproved] BIT NULL DEFAULT 0,
	CONSTRAINT [PK_ListingDetail] PRIMARY KEY ([listingDetailId])
)
