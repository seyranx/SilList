CREATE TABLE [dbo].[JobType] (
    [jobTypeId]   INT            NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [description] NVARCHAR (MAX) NULL,
    [created]     DATETIME       DEFAULT (getdate()) NULL,
    [modified]    DATETIME       DEFAULT (getdate()) NULL,
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            NULL,
    PRIMARY KEY CLUSTERED ([jobTypeId] ASC)
);

