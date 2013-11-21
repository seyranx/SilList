USE [SilList]
GO

DELETE FROM [app].[EntryStatusType]
GO

set IDENTITY_INSERT [app].[EntryStatusType] ON
INSERT INTO [app].[EntryStatusType] ([entryStatusTypeId], [name]) VALUES ( 1, 'Pending')
INSERT INTO [app].[EntryStatusType] ([entryStatusTypeId], [name]) VALUES ( 2, 'Approved')
INSERT INTO [app].[EntryStatusType] ([entryStatusTypeId], [name]) VALUES ( 3, 'Declined')
GO

set IDENTITY_INSERT [app].[EntryStatusType] OFF

