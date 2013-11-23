CREATE TABLE [data].[PropertyImages] (
    [rentalImageId] UNIQUEIDENTIFIER NOT NULL,
    [imageId]       UNIQUEIDENTIFIER NULL,
    [propertyId]    UNIQUEIDENTIFIER NULL,
    [created]       DATETIME         CONSTRAINT [DF__RentalIma__creat__6FE99F9F] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME         CONSTRAINT [DF__RentalIma__modif__70DDC3D8] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT              NULL,
    [modifiedBy]    INT              NULL,
    [isActive]      BIT              CONSTRAINT [DF_RentalImages_isActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__RentalIm__336E9B55254858FA] PRIMARY KEY CLUSTERED ([rentalImageId] ASC),
    CONSTRAINT [FK_RentalImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_RentalImages_Rental] FOREIGN KEY ([propertyId]) REFERENCES [data].[Property] ([propertyId]) ON DELETE CASCADE ON UPDATE CASCADE
);

