CREATE TABLE [data].[BusinessServices] (
    [serviceTypeId] INT              NOT NULL,
    [businessId]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [created]       DATETIME         DEFAULT (getdate()) NULL,
    [modified]      DATETIME         DEFAULT (getdate()) NULL,
    [createdBy]     INT              NULL,
    [modifiedBy]    INT              NULL,
    [isActive]      BIT              NULL,
    PRIMARY KEY CLUSTERED ([serviceTypeId] ASC)
);




