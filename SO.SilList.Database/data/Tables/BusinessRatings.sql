CREATE TABLE [data].[BusinessRatings] (
    [businessRatingId] UNIQUEIDENTIFIER NOT NULL,
    [ratingId]         UNIQUEIDENTIFIER NULL,
    [businessId]       UNIQUEIDENTIFIER NULL,
    [created]          DATETIME         CONSTRAINT [DF__BusinessR__creat__4D94879B] DEFAULT (getdate()) NOT NULL,
    [modified]         DATETIME         CONSTRAINT [DF__BusinessR__modif__4E88ABD4] DEFAULT (getdate()) NOT NULL,
    [createdBy]        INT              NULL,
    [modifiedBy]       INT              NULL,
    [isActive]         BIT              CONSTRAINT [DF__BusinessR__isAct__4F7CD00D] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_BusinessRatings] PRIMARY KEY CLUSTERED ([businessRatingId] ASC),
    CONSTRAINT [FK_BusinessRatings_Business] FOREIGN KEY ([businessId]) REFERENCES [data].[Business] ([businessId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BusinessRatings_Rating] FOREIGN KEY ([ratingId]) REFERENCES [data].[Rating] ([ratingId]) ON DELETE CASCADE ON UPDATE CASCADE
);








