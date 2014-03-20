CREATE TABLE [data].[BusinessCategoryLookup] (
    [businessCategoryLookupId] UNIQUEIDENTIFIER CONSTRAINT [DF_BusinessCategories_businessCategoryId] DEFAULT (newid()) NOT NULL,
    [businessId]               UNIQUEIDENTIFIER NULL,
    [businessCategoryTypeId]   INT              NULL,
    [created]                  DATETIME         CONSTRAINT [DF__BusinessC__creat__5070F446] DEFAULT (getdate()) NOT NULL,
    [modified]                 DATETIME         CONSTRAINT [DF__BusinessC__modif__5165187F] DEFAULT (getdate()) NOT NULL,
    [createdBy]                INT              NULL,
    [modifiedBy]               INT              NULL,
    [isActive]                 BIT              CONSTRAINT [DF_BusinessCategories_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BusinessCategories_1] PRIMARY KEY CLUSTERED ([businessCategoryLookupId] ASC),
    CONSTRAINT [FK_BusinessCategories_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessCategories_BusinessCategoryType] FOREIGN KEY ([businessCategoryTypeId]) REFERENCES [app].[BusinessCategoryType] ([businessCategoryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);

