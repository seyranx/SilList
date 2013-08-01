CREATE TABLE [app].[JobType] (
    [jobTypeId]   INT            NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [description] NVARCHAR (MAX) NULL,
    [created]     DATETIME       CONSTRAINT [DF__JobType__created__4316F928] DEFAULT (getdate()) NULL,
    [modified]    DATETIME       CONSTRAINT [DF__JobType__modifie__440B1D61] DEFAULT (getdate()) NULL,
    [createdBy]   INT            NOT NULL,
    [modifiedBy]  INT            NOT NULL,
    [isActive]    BIT            NULL,
    CONSTRAINT [PK__JobType__2C2C30BE4621E091] PRIMARY KEY CLUSTERED ([jobTypeId] ASC)
);


