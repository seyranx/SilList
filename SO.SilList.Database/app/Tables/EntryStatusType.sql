CREATE TABLE [app].[EntryStatusType] (
    [entryStatusTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (50) NOT NULL,
    [createdBy]         INT           NULL,
    [modifiedBy]        INT           NULL,
    [modified]          DATETIME      CONSTRAINT [DF__StatusTyp__modif__351DDF8C] DEFAULT (getdate()) NOT NULL,
    [created]           DATETIME      CONSTRAINT [DF__StatusTyp__creat__361203C5] DEFAULT (getdate()) NOT NULL,
    [isActive]          BIT           CONSTRAINT [DF_StatusType_isActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_StatusType] PRIMARY KEY CLUSTERED ([entryStatusTypeId] ASC)
);

