USE [SilList]
GO

DELETE FROM [data].[Job]
GO

-- Create new site and remember the id
INSERT INTO [app].[Site]
           ([name] ,[domain] ,[description] ,[logo] ,[logoUrl] ,[created] ,[modified] ,[createdBy] ,[modifiedBy] ,[isActive])
     VALUES ('new_site' ,'domain for new site','descr','','' ,GETDATE(),GETDATE() ,NULL ,NULL ,1)
GO
DECLARE @newly_added_site_id integer
SET @newly_added_site_id = @@IDENTITY

-- Insert some job listings
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved]) 
	VALUES (N'2e50d2a9-1af0-404b-a4b1-4861d681a68c', @newly_added_site_id, N'a', N'a', NULL, N'a', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'eeeees', N'ee e', NULL, N'e', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'a', N'a', NULL, N'a', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'eeeees', N'ee e', NULL, N'e', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'a', N'a', NULL, N'a', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'eeeees', N'ee e', NULL, N'e', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'a', N'a', NULL, N'a', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-27', N'2013-10-27 12:36:34', NULL, NULL, 1, 0)
INSERT INTO [data].[Job] ([jobId], [siteId], [title], [description], [jobTypeId], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [isTravelRequired], [isTelecomute], [jobCompanyId], [entryStatusTypeId], [startDate], [endDate], [created], [modified], [createdBy], [modifiedBy], [isActive], [isApproved])
	VALUES (NEWID(), @newly_added_site_id, N'eeeees', N'ee e', NULL, N'e', NULL, NULL, NULL, 2, NULL, NULL, 1, 1, NULL, NULL, N'0001-01-01', N'0001-01-01', N'2013-10-30', N'2013-10-30 21:15:12', NULL, NULL, 1, 0)
