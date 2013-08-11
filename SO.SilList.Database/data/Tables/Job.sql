CREATE TABLE [data].[Job] (
    [jobId]            UNIQUEIDENTIFIER NOT NULL,
    [listingDetailId]  UNIQUEIDENTIFIER NOT NULL,
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
    PRIMARY KEY CLUSTERED ([jobId] ASC),
    CONSTRAINT [FK_Job_JobType1] FOREIGN KEY ([jobTypeId]) REFERENCES [app].[JobType] ([jobTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);







