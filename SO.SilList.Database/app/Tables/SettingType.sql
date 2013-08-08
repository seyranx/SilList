CREATE TABLE [app].[SettingType] (
    [settingTypeId]     INT            IDENTITY (1, 1) NOT NULL,
    [siteId]            INT            NULL,
    [name]              NVARCHAR (50)  NULL,
    [value]             NVARCHAR (50)  NULL,
    [description]       NVARCHAR (MAX) NULL,
    [environmentTypeId] INT            NULL,
    [createdBy]         INT            NULL,
    [modifiedBy]        INT            NULL,
    [modified]          DATETIME       CONSTRAINT [DF__tmp_ms_xx__modif__43D61337] DEFAULT (getdate()) NOT NULL,
    [created]           DATETIME       CONSTRAINT [DF__tmp_ms_xx__creat__44CA3770] DEFAULT (getdate()) NOT NULL,
    [isActive]          BIT            CONSTRAINT [DF__tmp_ms_xx__isAct__45BE5BA9] DEFAULT ((1)) NOT NULL,
    [groupName]         NVARCHAR(50)   NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__E0FDAA34E44FCEEE] PRIMARY KEY CLUSTERED ([settingTypeId] ASC),
    CONSTRAINT [FK_SettingType_EnvironmentType] FOREIGN KEY ([environmentTypeId]) REFERENCES [app].[EnvironmentType] ([EnvironmentTypeId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_SettingType_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId]) ON DELETE CASCADE ON UPDATE CASCADE
);




