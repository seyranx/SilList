CREATE TABLE [app].[JobCategoryType] (
    [jobCategoryTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (50)  NULL,
    [description]       NVARCHAR (MAX) NULL,
    [created]           DATETIME       CONSTRAINT [DF__JobCatego__creat__2EDAF651] DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME       CONSTRAINT [DF__JobCatego__modif__2FCF1A8A] DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT            NULL,
    [modifiedBy]        INT            NULL,
    [isActive]          BIT            NULL,
    CONSTRAINT [PK__JobCateg__6772F0834BCD2F39] PRIMARY KEY CLUSTERED ([jobCategoryTypeId] ASC)
);






