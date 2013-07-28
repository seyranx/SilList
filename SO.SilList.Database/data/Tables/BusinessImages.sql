CREATE TABLE [data].[BusinessImages] (
    [imageId]    UNIQUEIDENTIFIER NOT NULL,
    [businessId] UNIQUEIDENTIFIER NULL,
    [created]    DATETIME         DEFAULT (getdate()) NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NULL,
    [craetedBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              NULL,
    PRIMARY KEY CLUSTERED ([imageId] ASC)
);





