CREATE TABLE [app].[JobCategoryType] (
    [jobCategoryTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (50)  NULL,
    [description]       NVARCHAR (MAX) NULL,
    [created]           DATETIME       CONSTRAINT [DF__JobCatego__creat__45F365D3] DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME       CONSTRAINT [DF__JobCatego__modif__46E78A0C] DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT            NULL,
    [modifiedBy]        INT            NULL,
    [isActive]          BIT            NULL,
    CONSTRAINT [PK__JobCateg__6772F083DA3A2360] PRIMARY KEY CLUSTERED ([jobCategoryTypeId] ASC)
);










