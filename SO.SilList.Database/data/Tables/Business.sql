CREATE TABLE [data].[Business] (
    [businessId]      UNIQUEIDENTIFIER CONSTRAINT [DF_Business_businessId] DEFAULT (newid()) NOT NULL,
    [siteId]          INT              NULL,
    [listingDetailId] UNIQUEIDENTIFIER NULL,
    [name]            NVARCHAR (250)   NULL,
    [address]         NVARCHAR (250)   NULL,
    [city]            NVARCHAR (250)   NULL,
    [state]           NVARCHAR (50)    NULL,
    [zip]             INT              NULL,
    [startDate]		  DATE             NOT NULL,
    [endDate]         DATE             NOT NULL,
    [isApproved]      BIT              NOT NULL DEFAULT (0),
    [createdBy]       INT              NULL,
    [modifiedBy]      INT              NULL,
    [modified]        DATETIME         CONSTRAINT [DF_Business_modified] DEFAULT (getdate()) NOT NULL,
    [created]         DATETIME         CONSTRAINT [DF_Business_created] DEFAULT (getdate()) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF_Business_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED ([businessId] ASC),
    CONSTRAINT [FK_Business_ListingDetail] FOREIGN KEY ([listingDetailId]) REFERENCES [data].[ListingDetail] ([listingDetailId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Business_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);











