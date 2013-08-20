CREATE TABLE [app].[BusinessCategoryType] (
    [businessCategoryTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]                   NVARCHAR (200) NOT NULL,
    [description]            NVARCHAR (MAX) NULL,
    [createdBy]              INT            NULL,
    [modifiedBy]             INT            NULL,
    [modified]               DATETIME       CONSTRAINT [DF_Business_modified] DEFAULT (getdate()) NOT NULL,
    [created]                DATETIME       CONSTRAINT [DF_Business_created] DEFAULT (getdate()) NOT NULL,
    [isActive]               BIT            CONSTRAINT [DF_Business_isActive] DEFAULT ((1)) NOT NULL,
    [siteId]                 INT            NULL,
    CONSTRAINT [PK__Business__773E9039E7BFA967] PRIMARY KEY CLUSTERED ([businessCategoryTypeId] ASC),
    CONSTRAINT [FK_BusinessCategoryType_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);






