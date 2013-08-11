CREATE TABLE [data].[Listing] (
    [listingId]       UNIQUEIDENTIFIER CONSTRAINT [DF__Listing__listing__61316BF4] DEFAULT (newid()) NOT NULL,
    [listingDetailId] UNIQUEIDENTIFIER NULL,
    [title]           NVARCHAR (50)    NULL,
    [description]     NVARCHAR (50)    NULL,
    [siteId]          INT              NULL,
    [listingTypeId]   INT              NULL,
    [createdBy ]      INT              NULL,
    [modifiedBy]      INT              NULL,
    [created]         DATETIME         CONSTRAINT [DF__Listing__created__589C25F3] DEFAULT (getdate()) NOT NULL,
    [modified]        DATETIME         CONSTRAINT [DF__Listing__modifie__59904A2C] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF__Listing__isActiv__5A846E65] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Listing__5A0F3D990749C430] PRIMARY KEY CLUSTERED ([listingId] ASC),
    CONSTRAINT [FK_Listing_ListingDetail] FOREIGN KEY ([listingDetailId]) REFERENCES [data].[ListingDetail] ([listingDetailId]),
    CONSTRAINT [FK_Listing_ListingType] FOREIGN KEY ([listingTypeId]) REFERENCES [app].[ListingType] ([listingTypeId]),
    CONSTRAINT [FK_Listing_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId])
);








