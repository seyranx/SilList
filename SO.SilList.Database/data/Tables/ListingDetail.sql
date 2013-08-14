CREATE TABLE [data].[ListingDetail] (
    [listingDetailId] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [startDate]       DATE             DEFAULT (getdate()) NOT NULL,
    [endDate]         DATE             DEFAULT (getdate()) NOT NULL,
    [isApproved]      BIT              DEFAULT ((0)) NULL,
    [created]         DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]        DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]       INT              NULL,
    [modifiedBy]      INT              NULL,
    [isActive]        BIT              NOT NULL DEFAULT ((1)),
    CONSTRAINT [PK_ListingDetail] PRIMARY KEY CLUSTERED ([listingDetailId] ASC)
);


