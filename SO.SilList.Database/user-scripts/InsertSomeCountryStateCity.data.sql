USE [SilList]
GO

DELETE FROM [app].[CityType]
GO

DELETE FROM [app].[StateType]
GO

DELETE FROM  [app].[CountryType]
GO

DECLARE @date_now date
SET @date_now = GETDATE()
declare @date_ends date
set @date_ends = getdate() + 100

SET IDENTITY_INSERT [app].[CountryType] ON
INSERT INTO [app].[CountryType] ([countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (1, N'US', N'2013-11-20 19:27:54', N'2013-11-20 19:27:54', NULL, NULL, 1)
INSERT INTO [app].[CountryType] ([countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (2, N'Canada', N'2013-11-20 19:28:00', N'2013-11-20 19:28:00', NULL, NULL, 1)
INSERT INTO [app].[CountryType] ([countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (3, N'France', N'2013-11-20 19:28:04', N'2013-11-20 19:28:04', NULL, NULL, 1)
INSERT INTO [app].[CountryType] ([countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (4, N'Armenia', N'2013-11-20 19:31:38', N'2013-11-20 19:31:38', NULL, NULL, 1)
SET IDENTITY_INSERT [app].[CountryType] OFF
GO

SET IDENTITY_INSERT [app].[StateType] ON
INSERT INTO [app].[StateType] ([stateTypeId], [stateCode], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (1, N'CA', 1, N'California', N'2013-11-20 19:28:16', N'2013-11-20 19:28:16', NULL, NULL, 1)
INSERT INTO [app].[StateType] ([stateTypeId], [stateCode], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (2, N'NV', 1, N'Nevada', N'2013-11-20 19:28:35', N'2013-11-20 19:28:35', NULL, NULL, 1)
INSERT INTO [app].[StateType] ([stateTypeId], [stateCode], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (3, N'FL', 1, N'Florida', N'2013-11-20 19:30:24', N'2013-11-20 19:30:24', NULL, NULL, 1)
SET IDENTITY_INSERT [app].[StateType] OFF
GO

SET IDENTITY_INSERT [app].[CityType] ON
INSERT INTO [app].[CityType] ([cityTypeId], [stateTypeId], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (1, 1, 1, N'Los Angeles', N'2013-11-20 19:28:57', N'2013-11-20 19:28:57', NULL, NULL, 1)
INSERT INTO [app].[CityType] ([cityTypeId], [stateTypeId], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (2, 1, 1, N'San Francisco', N'2013-11-20 19:32:51', N'2013-11-20 19:32:51', NULL, NULL, 1)
INSERT INTO [app].[CityType] ([cityTypeId], [stateTypeId], [countryTypeId], [name], [created], [modified], [createdBy], [modifiedBy], [isActive]) VALUES (3, 4, 4, N'Yerevan', N'2013-11-20 19:33:16', N'2013-11-20 19:33:16', NULL, NULL, 1)
SET IDENTITY_INSERT [app].[CityType] OFF
GO