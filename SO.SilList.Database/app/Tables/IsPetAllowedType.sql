CREATE TABLE [app].[IsPetAllowedType] (
    [isPetAllowedTypeId] INT        IDENTITY (1, 1) NOT NULL,
    [name]               NCHAR (10) NOT NULL,
    [created]            DATETIME   CONSTRAINT [DF__IsPetAllo__creat__0FEC5ADD] DEFAULT (getdate()) NOT NULL,
    [modified]           DATETIME   CONSTRAINT [DF__IsPetAllo__modif__10E07F16] DEFAULT (getdate()) NOT NULL,
    [createdBy]          INT        NULL,
    [modifiedBy]         INT        NULL,
    [isActive]           BIT        CONSTRAINT [DF__IsPetAllo__isAct__11D4A34F] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__IsPetAll__51EECFF656261969] PRIMARY KEY CLUSTERED ([isPetAllowedTypeId] ASC)
);


