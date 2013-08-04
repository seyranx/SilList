CREATE TABLE [app].[TransmissionType] (
    [transmissionTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (50)  NULL,
    [description]        NVARCHAR (MAX) NULL,
    [created]            DATETIME       CONSTRAINT [DF__Transmiss__creat__16CE6296] DEFAULT (getdate()) NOT NULL,
    [modified]           DATETIME       CONSTRAINT [DF__Transmiss__modif__17C286CF] DEFAULT (getdate()) NOT NULL,
    [createdBy]          INT            NULL,
    [modifiedBy]         INT            NULL,
    [isActive]           BIT            CONSTRAINT [DF__Transmiss__isAct__18B6AB08] DEFAULT ((1)) NULL,
    CONSTRAINT [PK__Transmis__C0F3E13CEE73D97F] PRIMARY KEY CLUSTERED ([transmissionTypeId] ASC)
);


