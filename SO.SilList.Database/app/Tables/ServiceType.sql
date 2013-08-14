CREATE TABLE [app].[ServiceType] (
    [serviceTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [description]   NVARCHAR (MAX) NULL,
    [name]          NVARCHAR (50)  NULL,
    [siteId]        INT            NULL,
    [created]       DATETIME       CONSTRAINT [DF__ServiceTy__creat__3E52440B] DEFAULT (getdate()) NOT NULL,
    [modified]      DATETIME       CONSTRAINT [DF__ServiceTy__modif__3F466844] DEFAULT (getdate()) NOT NULL,
    [createdBy]     INT            NULL,
    [modifiedBy]    INT            NULL,
    [isActive]      BIT            NOT NULL DEFAULT ((1)),
    CONSTRAINT [PK__ServiceT__FB4CEA3930848AD8] PRIMARY KEY CLUSTERED ([serviceTypeId] ASC)
);



