CREATE TABLE [data].[RentalImages] (
    [imageId]    UNIQUEIDENTIFIER NOT NULL,
    [rentalId]   UNIQUEIDENTIFIER NOT NULL,
    [created]    DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              NULL,
    PRIMARY KEY CLUSTERED ([imageId] ASC)
);








