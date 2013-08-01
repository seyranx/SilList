﻿CREATE TABLE [app].[JobCategories] (
    [jobCategoriesId]   UNIQUEIDENTIFIER NOT NULL,
    [jobId]             UNIQUEIDENTIFIER NULL,
    [created]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT              NULL,
    [modifiedBy]        INT              NULL,
    [isActive]          BIT              NULL,
    [jobCategoryTypeId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([jobCategoriesId] ASC)
);





