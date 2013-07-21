CREATE TABLE [data].[BusinessRatings] (
    [ratingId]   UNIQUEIDENTIFIER NOT NULL,
    [businessId] UNIQUEIDENTIFIER NULL,
    [created]    DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              DEFAULT ((1)) NULL,
    CONSTRAINT [FK_BusinessRatings_Rating] FOREIGN KEY ([ratingId]) REFERENCES [data].[Rating] ([ratingId]) ON DELETE CASCADE ON UPDATE CASCADE
);




