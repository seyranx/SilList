CREATE TABLE [data].[Rental] (
    [rentalId]        UNIQUEIDENTIFIER NOT NULL,
    [propertyTypeId]  INT              NULL,
    [siteId]          INT              NULL,
    [bedrooms]        INT              NULL,
    [bathrooms]       INT              NULL,
    [rent]            FLOAT (53)       NULL,
    [leaseTermTypeId] INT              NULL,
    [size]            INT              NULL,
    [lotSize]         INT              NULL,
    [acceptsSection8] BIT              NULL,
    [rentTypeId]      INT              NULL,
    [startDate]		  DATE             NOT NULL,
    [endDate]         DATE             NOT NULL,
    [isApproved]      BIT              NOT NULL DEFAULT (0),
    [modifiedBy]      INT              NULL,
    [modified]        DATETIME         CONSTRAINT [DF_Rental_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [created]         DATETIME         CONSTRAINT [DF_Rental_created] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF_Rental_isActive] DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([rentalId] ASC),
    CONSTRAINT [FK_Rental_LeaseTermType] FOREIGN KEY ([leaseTermTypeId]) REFERENCES [app].[LeaseTermType] ([leaseTermTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_Member] FOREIGN KEY ([rentTypeId]) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_PropertyType1] FOREIGN KEY ([propertyTypeId]) REFERENCES [app].[PropertyType] ([propertyTypeId]),
    CONSTRAINT [FK_Rental_RentType1] FOREIGN KEY ([rentTypeId]) REFERENCES [app].[RentType] ([rentTypeId]),
    CONSTRAINT [FK_Rental_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);













