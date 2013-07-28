CREATE TABLE [data].[RentalImages] (
    [rentalImageId] UNIQUEIDENTIFIER NOT NULL,
    [rentalId]      UNIQUEIDENTIFIER NULL,
    [created]       DATETIME         CONSTRAINT [DF__RentalIma__creat__2DE6D218] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME         CONSTRAINT [DF__RentalIma__modif__2EDAF651] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT              NULL,
    [modifiedBy]    INT              NULL,
    [isActive]      BIT              NULL,
    [imageId]       UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK__RentalIm__1C1874E4DC08ABDD] PRIMARY KEY CLUSTERED ([rentalImageId] ASC),
    CONSTRAINT [FK_RentalImages_Image1] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_RentalImages_Rental1] FOREIGN KEY ([rentalId]) REFERENCES [data].[Rental] ([rentalId]) ON DELETE CASCADE ON UPDATE CASCADE
);








