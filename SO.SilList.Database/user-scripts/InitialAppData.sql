USE [SilList]
GO

-- -----------------------------------------------------

DELETE FROM [app].[ListingStatusType]
GO

set IDENTITY_INSERT [app].[ListingStatusType] ON
INSERT INTO [app].[ListingStatusType] ([listingStatusTypeId], [name]) VALUES ( 1, 'Pending')
INSERT INTO [app].[ListingStatusType] ([listingStatusTypeId], [name]) VALUES ( 2, 'Approved')
INSERT INTO [app].[ListingStatusType] ([listingStatusTypeId], [name]) VALUES ( 3, 'Declined')
set IDENTITY_INSERT [app].[ListingStatusType] OFF

GO

-- -----------------------------------------------------

DELETE FROM [app].[MemberRoleType]
GO
set IDENTITY_INSERT [app].[MemberRoleType] ON

INSERT INTO [app].[MemberRoleType] ([memberRoleTypeId], [name], [description], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (1, N'Admin', N'Administrator', N'2014-04-02 11:08:27', N'2014-04-02 11:08:27', NULL, NULL, 1)
INSERT INTO [app].[MemberRoleType] ([memberRoleTypeId], [name], [description], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (2, N'User', N'Users', N'2014-04-02 11:11:29', N'2014-04-02 11:11:29', NULL, NULL, 1)
set IDENTITY_INSERT [app].[MemberRoleType] OFF
GO
