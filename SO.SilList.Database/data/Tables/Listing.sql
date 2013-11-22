CREATE TABLE [data].[Listing] (
    [listingId]     UNIQUEIDENTIFIER CONSTRAINT [DF__Listing__listing__61316BF4] DEFAULT (newid()) NOT NULL,
    [title]         NVARCHAR (50)    NULL,
    [description]   NVARCHAR (MAX)   NULL,
    [siteId]        INT              NULL,
    [listingTypeId] INT              NULL,
    [price]         DECIMAL (18)     NULL,
    [address]       NVARCHAR (MAX)   NULL,
    [cityTypeId]    INT              NULL,
    [stateTypeId]   INT              NULL,
    [countryTypeId] INT              NULL,
    [zip]           INT              NULL,
    [phone]         NVARCHAR (50)    NULL,
    [fax]           NVARCHAR (50)    NULL,
    [startDate]     DATE             NOT NULL,
    [endDate]       DATE             NOT NULL,
    [entryStatusTypeId]    INT              CONSTRAINT [DF__Listing__isAppro__7F80E8EA] DEFAULT ((1)) NULL,
    [createdBy ]    INT              NULL,
    [modifiedBy]    INT              NULL,
    [created]       DATETIME         CONSTRAINT [DF__Listing__created__589C25F3] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME         CONSTRAINT [DF__Listing__modifie__59904A2C] DEFAULT (getdate()) NOT NULL,
    [isActive]      BIT              CONSTRAINT [DF__Listing__isActiv__5A846E65] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Listing__5A0F3D990749C430] PRIMARY KEY CLUSTERED ([listingId] ASC),
    CONSTRAINT [FK_Listing_CityType] FOREIGN KEY ([cityTypeId]) REFERENCES [app].[CityType] ([cityTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Listing_CountryType] FOREIGN KEY ([countryTypeId]) REFERENCES [app].[CountryType] ([countryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Listing_ListingType] FOREIGN KEY ([listingTypeId]) REFERENCES [app].[ListingType] ([listingTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Listing_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Listing_StateType] FOREIGN KEY ([stateTypeId]) REFERENCES [app].[StateType] ([stateTypeId]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_Listing_EntryStatusType] FOREIGN KEY ([entryStatusTypeId]) REFERENCES [app].[EntryStatusType] ([entryStatusTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);














