CREATE TABLE [app].[EnvironmentType] (
    [EnvironmentTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (50) NOT NULL,
    [url]               NVARCHAR (50) NULL,
    [description]       NVARCHAR (50) NULL,
    [createdBy]         INT           NULL,
    [modifiedBy]        INT           NULL,
    [modified]          DATETIME      CONSTRAINT [DF__tmp_ms_xx__modif__3F115E1A] DEFAULT (getdate()) NOT NULL,
    [created]           DATETIME      CONSTRAINT [DF__tmp_ms_xx__creat__40058253] DEFAULT (getdate()) NOT NULL,
    [isActive]          BIT           CONSTRAINT [DF__tmp_ms_xx__isAct__40F9A68C] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__F53D3A206DAB7F97] PRIMARY KEY CLUSTERED ([EnvironmentTypeId] ASC)
);


