CREATE TABLE [data].[RentalImages] (
    [rentalImageId] UNIQUEIDENTIFIER NOT NULL,
    [rentalId]      UNIQUEIDENTIFIER NOT NULL,
    [created]       DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT              NULL,
    [modifiedBy]    INT              NULL,
    [isActive]      BIT              NULL,
    [imageId]       UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([rentalImageId] ASC),
    CONSTRAINT [FK_RentalImages_Image1] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_RentalImages_Rental1] FOREIGN KEY ([rentalId]) REFERENCES [data].[Rental] ([rentalId]) ON DELETE CASCADE ON UPDATE CASCADE
);






