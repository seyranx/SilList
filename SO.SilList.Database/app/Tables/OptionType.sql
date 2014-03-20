CREATE TABLE [app].[OptionType] (
    [optionTypeId] INT            NOT NULL,
    [groupName]    NVARCHAR (100) NOT NULL,
    [name]         NVARCHAR (100) NULL,
    [value]        NVARCHAR (100) NULL,
    [description]  NVARCHAR (MAX) NULL,
    [createdBy]    INT            NULL,
    [modifiedBy]   INT            NULL,
    [modified]     DATETIME       NOT NULL,
    [created]      DATETIME       NOT NULL,
    [isActive]     BIT            NOT NULL,
    CONSTRAINT [PK__optionTypeId] PRIMARY KEY CLUSTERED ([optionTypeId] ASC)
);

