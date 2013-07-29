CREATE TABLE [app].[JobCategories] (
    [jobCategoryTypeId] INT              NOT NULL,
    [jobId]             UNIQUEIDENTIFIER NULL,
    [created]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT              NULL,
    [modifiedBy]        INT              NULL,
    [isActive]          BIT              NULL,
    PRIMARY KEY CLUSTERED ([jobCategoryTypeId] ASC),
    CONSTRAINT [FK_JobCategories_Job] FOREIGN KEY ([jobId]) REFERENCES [data].[Job] ([jobId]) ON DELETE CASCADE ON UPDATE CASCADE
);




