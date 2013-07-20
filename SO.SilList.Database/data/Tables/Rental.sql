CREATE TABLE [data].[Rental] (
    [rentalId]        UNIQUEIDENTIFIER NOT NULL,
    [propertyTypeId]  INT              NULL,
    [listingDetailId] UNIQUEIDENTIFIER NULL,
    [siteId]          INT              NULL,
    [bedrooms]        INT              NULL,
    [bathrooms]       INT              NULL,
    [rent]            FLOAT (53)       NULL,
    [leaseTermTypeId] INT              NULL,
    [size]            INT              NULL,
    [lotSize]         INT              NULL,
    [acceptsSection8] BIT              NULL,
    [rentTypeId]      INT              NULL,
    PRIMARY KEY CLUSTERED ([rentalId] ASC)
);



