CREATE TABLE [app].[ListingCategoryType] (
    [listingCategoryTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [name]                  NVARCHAR (50) NULL,
    [description]           NVARCHAR (50) NULL,
    [createdBy ]            INT           NULL,
    [modifiedBy]            INT           NULL,
    [created]               DATETIME      CONSTRAINT [DF__ListingCa__creat__52E34C9D] DEFAULT (getdate()) NOT NULL,
    [modified]              DATETIME      CONSTRAINT [DF__ListingCa__modif__53D770D6] DEFAULT (getdate()) NOT NULL,
    [isActive]              BIT           CONSTRAINT [DF__ListingCa__isAct__54CB950F] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__76345007D51067BA] PRIMARY KEY CLUSTERED ([listingCategoryTypeId] ASC)
);


