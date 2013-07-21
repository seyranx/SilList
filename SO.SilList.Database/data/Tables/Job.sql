CREATE TABLE [data].[Job] (
    [Id]               INT              NOT NULL,
    [jobId]            UNIQUEIDENTIFIER NULL,
    [listingDetailId]  UNIQUEIDENTIFIER NULL,
    [siteId]           INT              NULL,
    [title]            NVARCHAR (50)    NULL,
    [description]      NVARCHAR (50)    NULL,
    [jobTypeId]        INT              NULL,
    [city]             NVARCHAR (10)    NULL,
    [state]            NVARCHAR (10)    NULL,
    [isTravelRequired] BIT              NULL,
    [isTelecomute]     BIT              NULL,
    [jobCompanyId]     UNIQUEIDENTIFIER NULL,
    [created]          DATE             NULL,
    [modified]         DATETIME         NULL,
    [createdBy]        INT              NULL,
    [modifiedBy]       INT              NULL,
    [isActive]         BIT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Job_JobCompany] FOREIGN KEY ([jobCompanyId]) REFERENCES [data].[JobCompany] ([jobCompanyId]),
    CONSTRAINT [FK_Job_JobType] FOREIGN KEY ([jobTypeId]) REFERENCES [app].[JobType] ([jobTypeId])
);



