CREATE TABLE [data].[Listing] (
    [listingId]       UNIQUEIDENTIFIER NOT NULL,
    [listingDetailId] UNIQUEIDENTIFIER NULL,
    [title]           NVARCHAR (50)    NULL,
    [description]     NVARCHAR (50)    NULL,
    [siteId]          INT              NULL,
    [listingTypeId]   INT              NULL,
    PRIMARY KEY CLUSTERED ([listingId] ASC)
);






