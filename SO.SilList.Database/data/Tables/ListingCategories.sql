CREATE TABLE [data].[ListingCategories] (
    [listingCategoryId]     UNIQUEIDENTIFIER NOT NULL,
    [listingCategoryTypeId] INT              NULL,
    [listingId]             UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([listingCategoryId] ASC)
);




