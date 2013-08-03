CREATE TABLE [app].[ListingType] (
    [listingTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (50) NULL,
    [description]   NVARCHAR (50) NULL,
    [createdBy ]    INT           NULL,
    [modifiedBy]    INT           NULL,
    [created]       DATETIME      CONSTRAINT [DF__ListingTy__creat__55BFB948] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME      CONSTRAINT [DF__ListingTy__modif__56B3DD81] DEFAULT (getdate()) NOT NULL,
    [isActive]      BIT           CONSTRAINT [DF__ListingTy__isAct__57A801BA] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__98F4AA90E9C00D70] PRIMARY KEY CLUSTERED ([listingTypeId] ASC)
);


