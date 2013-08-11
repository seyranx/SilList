CREATE TABLE [data].[ListingImages] (
    [listingImagesId] UNIQUEIDENTIFIER NOT NULL,
    [imageId]         UNIQUEIDENTIFIER NULL,
    [listingId]       UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([listingImagesId] ASC)
);




