CREATE TABLE [app].[JobType] (
    [jobTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [description] NVARCHAR (MAX) NULL,
    [created]     DATETIME       CONSTRAINT [DF__JobType__created__403A8C7D] DEFAULT (getdate()) NULL,
    [modified]    DATETIME       CONSTRAINT [DF__JobType__modifie__412EB0B6] DEFAULT (getdate()) NULL,
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            NULL,
    CONSTRAINT [PK__JobType__2C2C30BEFD0CA05A] PRIMARY KEY CLUSTERED ([jobTypeId] ASC)
);


