USE [SilList]
GO

DELETE FROM [data].[Job]
GO

DECLARE @date_now date
SET @date_now = GETDATE()

-- Create new site and remember the id
INSERT INTO [app].[Site]
           ([name] ,[domain] ,[description] ,[logo] ,[logoUrl] ,[created] ,[modified] ,[createdBy] ,[modifiedBy] ,[isActive])
     VALUES (N'new_site' ,N'domain for new site',N'descr', '', '', @date_now, @date_now, NULL ,NULL ,1)
GO
DECLARE @newly_added_site_id integer
SET @newly_added_site_id = @@IDENTITY

-- Insert some job listings
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive]) 
	VALUES (N'2e50d2a9-1af0-404b-a4b1-4861d681a68c', @newly_added_site_id, N'a', N'aa', NULL, N'aaa', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'b', N'bb', NULL, N'bbb', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'c', N'cc', NULL, N'ccc', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'd', N'dd', NULL, N'ddd', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'e', N'ee', NULL, N'eee', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'f', N'ff', NULL, N'fff', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'g', N'gg', NULL, N'ggg', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), @newly_added_site_id, N'h', N'hh', NULL, N'hhh', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, 1, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1)
