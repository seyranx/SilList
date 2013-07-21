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
    [modifiedBy]      INT              NULL,
    [modified]        DATETIME         CONSTRAINT [DF_Rental_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [created]         DATETIME         CONSTRAINT [DF_Rental_created] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF_Rental_isActive] DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([rentalId] ASC)
);

