CREATE TABLE [data].[BusinessCategories] (
    [businessCategoryId]     UNIQUEIDENTIFIER NOT NULL,
    [businessId]             UNIQUEIDENTIFIER NULL,
    [businessCategoryTypeId] INT              NULL,
    [created]                DATETIME         CONSTRAINT [DF__BusinessC__creat__59FA5E80] DEFAULT (getdate()) NOT NULL,
    [modified]               DATETIME         CONSTRAINT [DF__BusinessC__modif__5AEE82B9] DEFAULT (getdate()) NOT NULL,
    [createdBy]              INT              NULL,
    [modifiedBy]             INT              NULL,
    [isActive]               BIT              NULL,
    CONSTRAINT [PK_BusinessCategories] PRIMARY KEY CLUSTERED ([businessCategoryId] ASC),
    CONSTRAINT [FK_BusinessCategories_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessCategories_BusinessCategoryType] FOREIGN KEY ([businessCategoryTypeId]) REFERENCES [app].[BusinessCategoryType] ([businessCategoryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);
















