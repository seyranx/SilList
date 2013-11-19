CREATE TABLE [data].[Rental] (
    [rentalId]          UNIQUEIDENTIFIER NOT NULL,
    [title]             NVARCHAR (50)    NULL,
    [description]       NVARCHAR (MAX)   NULL,
    [propertyTypeId]    INT              NULL,
    [siteId]            INT              NULL,
    [bedrooms]          INT              NULL,
    [bathrooms]         INT              NULL,
    [price]             DECIMAL (18)     NULL,
    [leaseTermTypeId]   INT              NULL,
    [size]              INT              NULL,
    [lotSize]           INT              NULL,
    [acceptsSection8]   BIT              NULL,
    [rentTypeId]        INT              NULL,
    [memberId]          INT              NULL,
    [address]           NVARCHAR (MAX)   NULL,
    [cityTypeId]        INT              NULL,
    [stateTypeId]       INT              NULL,
    [countryTypeId]     INT              NULL,
    [zip]               INT              NULL,
    [phone]             NVARCHAR (50)    NULL,
    [fax]               NVARCHAR (50)    NULL,
    [startDate]         DATE             NOT NULL,
    [endDate]           DATE             NOT NULL,
    [entryStatusTypeId] INT              CONSTRAINT [DF__Rental__isApprov__634EBE90] DEFAULT ((1)) NOT NULL,
    [modifiedBy]        INT              NULL,
    [modified]          DATETIME         CONSTRAINT [DF_Rental_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT              NULL,
    [created]           DATETIME         CONSTRAINT [DF_Rental_created] DEFAULT (getdate()) NOT NULL,
    [isActive]          BIT              CONSTRAINT [DF_Rental_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Rental__0164732E8D8BC5AB] PRIMARY KEY CLUSTERED ([rentalId] ASC),
    CONSTRAINT [FK_Rental_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_EntryStatusType] FOREIGN KEY ([entryStatusTypeId]) REFERENCES [app].[EntryStatusType] ([entryStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_LeaseTermType] FOREIGN KEY ([leaseTermTypeId]) REFERENCES [app].[LeaseTermType] ([leaseTermTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_Member] FOREIGN KEY ([memberId]) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_PropertyType] FOREIGN KEY ([propertyTypeId]) REFERENCES [app].[PropertyType] ([propertyTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_RentType] FOREIGN KEY ([rentTypeId]) REFERENCES [app].[RentType] ([rentTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Rental_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);























