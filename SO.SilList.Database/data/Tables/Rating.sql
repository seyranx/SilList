CREATE TABLE [data].[Rating] (
    [ratingId]   UNIQUEIDENTIFIER NOT NULL,
    [rating]     INT              NULL,
    [review]     NVARCHAR (50)    NULL,
    [memberId]   INT              NULL,
    [created]    DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([ratingId] ASC),
    CONSTRAINT [FK_Rating_Member] FOREIGN KEY ([memberId]) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE
);


