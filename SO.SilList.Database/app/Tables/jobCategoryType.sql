CREATE TABLE [app].[JobCategoryType] (
    [jobCategoryTypeId] INT            NOT NULL,
    [name]              NVARCHAR (50)  NULL,
    [description]       NVARCHAR (MAX) NULL,
    [created]           DATETIME       DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT            NULL,
    [modifiedBy]        INT            NULL,
    [isActive]          BIT            NULL,
    PRIMARY KEY CLUSTERED ([jobCategoryTypeId] ASC)
);


