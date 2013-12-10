CREATE TABLE [app].[AcceptsSection8Type] (
    [acceptsSection8TypeId] INT        IDENTITY (1, 1) NOT NULL,
    [name]                  NCHAR (10) NOT NULL,
    [created]               DATETIME   CONSTRAINT [DF__AcceptsSe__creat__0D0FEE32] DEFAULT (getdate()) NOT NULL,
    [modified]              DATETIME   CONSTRAINT [DF__AcceptsSe__modif__0E04126B] DEFAULT (getdate()) NOT NULL,
    [createdBy]             INT        NULL,
    [modifiedBy]            INT        NULL,
    [isActive]              BIT        CONSTRAINT [DF__AcceptsSe__isAct__0EF836A4] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__AcceptsS__6AEF9AA145648984] PRIMARY KEY CLUSTERED ([acceptsSection8TypeId] ASC)
);


