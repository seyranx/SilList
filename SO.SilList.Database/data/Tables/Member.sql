CREATE TABLE [data].[Member] (
    [memberId]          INT           NOT NULL IDENTITY,
    [siteId]            INT           NULL,
    [firstName]         NVARCHAR (50) NULL,
    [lastName]          NVARCHAR (50) NULL,
    [address]           NVARCHAR (50) NULL,
    [city]              NVARCHAR (50) NULL,
    [state]             NVARCHAR (50) NULL,
    [zip]               NVARCHAR (50) NULL,
    [email]             NVARCHAR (50) NULL,
    [username]          NVARCHAR (50) NULL,
    [password]          NVARCHAR (50) NULL,
    [phone]             NVARCHAR (50) NULL,
    [isEmailConfirmed]  BIT           DEFAULT ((0)) NULL,
    [ipAddress]         NVARCHAR (50) NULL,
    [lastLogin]         DATETIME      DEFAULT (getdate()) NOT NULL,
    [isEmailSubscribed] BIT           DEFAULT ((0)) NULL,
    [created]           DATETIME      DEFAULT (getdate()) NOT NULL,
    [modified]          DATETIME      DEFAULT (getdate()) NOT NULL,
    [createdBy]         INT           NULL,
    [modifiedBy]        INT           NULL,
    [isActive]          BIT           DEFAULT ((1)) NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([memberId] ASC),
	CONSTRAINT [FK_Member_Site] FOREIGN KEY ([siteId]) REFERENCES [app].[Site] ([siteId])
);


