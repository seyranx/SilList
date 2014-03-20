CREATE TABLE [data].[JobCategoryLookup] (
    [jobCategoryLookupId] UNIQUEIDENTIFIER NOT NULL,
    [jobId]               UNIQUEIDENTIFIER NULL,
    [created]             DATETIME         CONSTRAINT [DF__JobCatego__creat__662B2B3B] DEFAULT (getdate()) NOT NULL,
    [modified]            DATETIME         CONSTRAINT [DF__JobCatego__modif__671F4F74] DEFAULT (getdate()) NOT NULL,
    [createdBy]           INT              NULL,
    [modifiedBy]          INT              NULL,
    [isActive]            BIT              DEFAULT ((1)) NOT NULL,
    [jobCategoryTypeId]   INT              NULL,
    CONSTRAINT [PK__JobCateg__2AC8374378794D6D] PRIMARY KEY CLUSTERED ([jobCategoryLookupId] ASC),
    CONSTRAINT [FK_JobCategories_Job] FOREIGN KEY ([jobId]) REFERENCES [data].[Job] ([jobId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_JobCategories_JobCategoryType] FOREIGN KEY ([jobCategoryTypeId]) REFERENCES [app].[JobCategoryType] ([jobCategoryTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);

