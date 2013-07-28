CREATE TABLE [app].[RentType] (
    [rentTypeId]  INT            NOT NULL,
    [name]        NVARCHAR (50)  NULL,
    [description] NVARCHAR (MAX) NULL,
    [created]     DATETIME       CONSTRAINT [DF__RentType__create__3E52440B] DEFAULT (getdate()) NOT NULL,
    [modified]    DATETIME       CONSTRAINT [DF__RentType__modifi__3F466844] DEFAULT (getdate()) NOT NULL,
    [createdBy]   INT            NULL,
    [modifiedBy]  INT            NULL,
    [isActive]    BIT            CONSTRAINT [DF__RentType__isActi__403A8C7D] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__RentType__82E019192F0EB187] PRIMARY KEY CLUSTERED ([rentTypeId] ASC)
);


