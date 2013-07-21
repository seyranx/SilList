CREATE TABLE [data].[BusinessCategories] (
    [businessId]             UNIQUEIDENTIFIER NOT NULL,
    [businessCategoryTypeId] INT              NOT NULL,
    CONSTRAINT [PK_BusinessCategories] PRIMARY KEY CLUSTERED ([businessId] ASC),
    CONSTRAINT [FK_BusinessCategories_BusinessCategoryType] FOREIGN KEY ([businessCategoryTypeId]) REFERENCES [app].[BusinessCategoryType] ([businessCategoryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);


