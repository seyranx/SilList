USE [SilList]
GO

DELETE FROM [data].[Car]
GO

--DECLARE @date_now date
--SET @date_now = GETDATE()

---- Create new site and remember the id
--INSERT INTO [app].[Site]
--           ([name] ,[domain] ,[description] ,[logo] ,[logoUrl] ,[created] ,[modified] ,[createdBy] ,[modifiedBy] ,[isActive])
--     VALUES (N'new_site' ,N'domain for new site',N'descr', '', '', @date_now, @date_now, NULL ,NULL ,1)
--GO
--DECLARE @newly_added_site_id integer
--SET @newly_added_site_id = @@IDENTITY

-- Insert some job listings
INSERT INTO [data].[Car] ([carId], [modelTypeId], [year], [millage], [price], [vin], [description], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [carBodyTypeId], [siteId], [transmissionTypeId], [carEngineTypeId], [carDriveTypeId], [carFuelTypeId], [carDoorTypeId], [exteriorColorTypeId], [interiorColorTypeId], [startDate], [endDate], [entryStatusTypeId], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), NULL, 2013, 12, 12, N'121212', N'1212', N'1212', 1, 1, 1, 91255, N'12', N'12', 1, 1, 3, 4, 7, 5, 1, 7, 6, N'2013-11-04', N'2013-12-06', 1, N'2013-11-21 18:02:07', N'2013-11-21 18:02:07', NULL, NULL, 1)
INSERT INTO [data].[Car] ([carId], [modelTypeId], [year], [millage], [price], [vin], [description], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [carBodyTypeId], [siteId], [transmissionTypeId], [carEngineTypeId], [carDriveTypeId], [carFuelTypeId], [carDoorTypeId], [exteriorColorTypeId], [interiorColorTypeId], [startDate], [endDate], [entryStatusTypeId], [created], [modified], [createdBy], [modifiedBy], [isActive]) 
	VALUES (NEWID(), NULL, 2012, 23, 23, N'23', N'23', N'23', 1, 1, 1, 23, N'23432as23', NULL, 2, 1, 5, 4, 3, 5, 1, 7, 7, N'2013-11-04', N'2013-11-08', 1, N'2013-11-21 18:04:57', N'2013-11-21 18:04:57', NULL, NULL, 1)
INSERT INTO [data].[Car] ([carId], [modelTypeId], [year], [millage], [price], [vin], [description], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [carBodyTypeId], [siteId], [transmissionTypeId], [carEngineTypeId], [carDriveTypeId], [carFuelTypeId], [carDoorTypeId], [exteriorColorTypeId], [interiorColorTypeId], [startDate], [endDate], [entryStatusTypeId], [created], [modified], [createdBy], [modifiedBy], [isActive]) 
	VALUES (NEWID(), NULL, 2014, 45, 45, N'23', N'23', N'23', 1, 1, 1, 23, N'23432as23', NULL, 2, 1, 5, 4, 3, 5, 1, 7, 7, N'2013-11-04', N'2013-11-08', 1, N'2013-11-21 18:04:57', N'2013-11-21 18:04:57', NULL, NULL, 1)
INSERT INTO [data].[Car] ([carId], [modelTypeId], [year], [millage], [price], [vin], [description], [address], [cityTypeId], [stateTypeId], [countryTypeId], [zip], [phone], [fax], [carBodyTypeId], [siteId], [transmissionTypeId], [carEngineTypeId], [carDriveTypeId], [carFuelTypeId], [carDoorTypeId], [exteriorColorTypeId], [interiorColorTypeId], [startDate], [endDate], [entryStatusTypeId], [created], [modified], [createdBy], [modifiedBy], [isActive])
	VALUES (NEWID(), NULL, 2015, 67, 67, N'121212', N'1212', N'1212', 1, 1, 1, 91255, N'12', N'12', 1, 1, 3, 4, 7, 5, 1, 7, 6, N'2013-11-04', N'2013-12-06', 1, N'2013-11-21 18:02:07', N'2013-11-21 18:02:07', NULL, NULL, 1)
