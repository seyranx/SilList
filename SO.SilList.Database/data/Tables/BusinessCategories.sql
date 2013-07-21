CREATE TABLE [data].[BusinessCategories] (
    [businessId]             UNIQUEIDENTIFIER NOT NULL,
    [businessCategoryTypeId] INT              NOT NULL,
    [created]                DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]               DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]              INT              NULL,
    [modifiedBy]             INT              NULL,
    [isActive]               BIT              NULL,
    CONSTRAINT [PK_BusinessCategories] PRIMARY KEY CLUSTERED ([businessId] ASC),
    CONSTRAINT [FK_BusinessCategories_BusinessCategoryType] FOREIGN KEY ([businessCategoryTypeId]) REFERENCES [app].[BusinessCategoryType] ([businessCategoryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);






