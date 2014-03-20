CREATE TABLE [data].[ListingCategoryLookup] (
    [listingCategoryLookupId] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [listingCategoryTypeId]   INT              NULL,
    [listingId]               UNIQUEIDENTIFIER NULL,
    [createdBy ]              INT              NULL,
    [modifiedBy]              INT              NULL,
    [created]                 DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]                DATETIME         DEFAULT (getdate()) NOT NULL,
    [isActive]                BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([listingCategoryLookupId] ASC),
    CONSTRAINT [FK_ListingCategories_Listing] FOREIGN KEY ([listingId]) REFERENCES [data].[Listing] ([listingId]),
    CONSTRAINT [FK_ListingCategories_ListingCategoryType] FOREIGN KEY ([listingCategoryTypeId]) REFERENCES [app].[ListingCategoryType] ([listingCategoryTypeId])
);

