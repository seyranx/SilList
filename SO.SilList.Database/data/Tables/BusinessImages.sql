CREATE TABLE [data].[BusinessImages] (
    [imageId]    UNIQUEIDENTIFIER NOT NULL,
    [businessId] UNIQUEIDENTIFIER NULL,
    [created]    DATETIME         CONSTRAINT [DF__BusinessI__creat__5812160E] DEFAULT (getdate()) NULL,
    [modified]   DATETIME         CONSTRAINT [DF__BusinessI__modif__59063A47] DEFAULT (getdate()) NULL,
    [craetedBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              NULL,
    CONSTRAINT [FK_BusinessImages_Image] FOREIGN KEY ([imageId]) REFERENCES [data].[Image] ([imageId]) ON DELETE CASCADE ON UPDATE CASCADE
);

