CREATE TABLE [data].[ListingImages] (
    [listingImageId] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [imageId]        UNIQUEIDENTIFIER NULL,
    [listingId]      UNIQUEIDENTIFIER NULL,
    [createdBy ]     INT              NULL,
    [modifiedBy]     INT              NULL,
    [created]        DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]       DATETIME         DEFAULT (getdate()) NOT NULL,
    [isActive]       BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([listingImageId] ASC),
    CONSTRAINT [FK_ListingImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]),
    CONSTRAINT [FK_ListingImages_Listing] FOREIGN KEY ([listingId]) REFERENCES [data].[Listing] ([listingId])
);






