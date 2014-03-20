CREATE TABLE [data].[Property] (
    [propertyId]            UNIQUEIDENTIFIER NOT NULL,
    [title]                 NVARCHAR (50)    NOT NULL,
    [description]           NVARCHAR (MAX)   NULL,
    [propertyTypeId]        INT              NULL,
    [propertyListingTypeId] INT              NULL,
    [roomCount]             INT              NULL,
    [bathroomCount]         INT              NULL,
    [price]                 DECIMAL (18)     NULL,
    [size]                  INT              NULL,
    [lotSize]               INT              NULL,
    [hasSection8]           INT              NULL,
    [isPetAllowed]          INT              NULL,
    [address]               NVARCHAR (MAX)   NULL,
    [cityTypeId]            INT              NULL,
    [stateTypeId]           INT              NULL,
    [countryTypeId]         INT              NULL,
    [zip]                   INT              NULL,
    [startDate]             DATE             NOT NULL,
    [endDate]               DATE             NOT NULL,
    [listingStatusTypeId]   INT              CONSTRAINT [DF__tmp_ms_xx__entry__386F4D83] DEFAULT ((1)) NULL,
    [modifiedBy]            INT              NULL,
    [modified]              DATETIME         CONSTRAINT [DF_Property_modified] DEFAULT (getdate()) NOT NULL,
    [createdBy]             INT              NULL,
    [created]               DATETIME         CONSTRAINT [DF_Property_created] DEFAULT (getdate()) NOT NULL,
    [isActive]              BIT              CONSTRAINT [DF_Property_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__0164732E4C94D603] PRIMARY KEY CLUSTERED ([propertyId] ASC),
    CONSTRAINT [FK_Property_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Property_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Property_ListingStatusType] FOREIGN KEY ([listingStatusTypeId]) REFERENCES [app].[ListingStatusType] ([listingStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Property_PropertyListingType] FOREIGN KEY ([propertyListingTypeId]) REFERENCES [app].[PropertyListingType] ([propertyListingTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Property_PropertyType] FOREIGN KEY ([propertyTypeId]) REFERENCES [app].[PropertyType] ([propertyTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Property_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);





