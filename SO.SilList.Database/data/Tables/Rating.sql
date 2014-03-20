CREATE TABLE [data].[Rating] (
    [ratingId]   UNIQUEIDENTIFIER NOT NULL,
    [recordId]   UNIQUEIDENTIFIER NOT NULL,
    [rating]     INT              NULL,
    [review]     NVARCHAR (50)    NULL,
    [memberId]   INT              NULL,
    [created]    DATETIME         CONSTRAINT [DF__Rating__created__6A30C649] DEFAULT (getdate()) NOT NULL,
    [modified]   DATETIME         CONSTRAINT [DF__Rating__modified__6B24EA82] DEFAULT (getdate()) NOT NULL,
    [createdBy]  INT              NULL,
    [modifiedBy] INT              NULL,
    [isActive]   BIT              CONSTRAINT [DF__Rating__isActive__4A18FC72] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Rating__2D290CA98C11B272] PRIMARY KEY CLUSTERED ([ratingId] ASC),
    CONSTRAINT [FK_Rating_Member] FOREIGN KEY ([memberId]) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE
);




