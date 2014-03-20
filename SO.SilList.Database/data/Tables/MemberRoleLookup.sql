CREATE TABLE [data].[MemberRoleLookup] (
    [memberRoleLookupId] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [memberRoleTypeId]   INT              NULL,
    [memberId]           INT              NULL,
    [created]            DATETIME         DEFAULT (getdate()) NOT NULL,
    [modified]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [createdBy]          INT              NULL,
    [modifiedBy]         INT              NULL,
    [isActive]           BIT              DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([memberRoleLookupId] ASC),
    CONSTRAINT [FK_MemberRoleLookup_Member] FOREIGN KEY ([memberId]) REFERENCES [data].[Member] ([memberId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_MemberRoleLookup_MemberRoleType] FOREIGN KEY ([memberRoleTypeId]) REFERENCES [app].[MemberRoleType] ([memberRoleTypeId]) ON DELETE CASCADE ON UPDATE CASCADE
);

