USE [SilList]
GO

DELETE FROM [data].[Business]
GO

DECLARE @date_now date
SET @date_now = GETDATE()

-- Create new site and remember the id
INSERT INTO [app].[Site]
           ([name] ,[domain] ,[description] ,[logo] ,[logoUrl] ,[created] ,[modified] ,[createdBy] ,[modifiedBy] ,[isActive])
     VALUES (N'new_site business' ,N'domain for new site',N'descr business', N'', N'', @date_now, @date_now, NULL ,NULL ,1)
GO

DECLARE @newly_added_site_id integer
SET @newly_added_site_id = @@IDENTITY

-- Insert some job listings
DECLARE @date_now date
SET @date_now = GETDATE()
declare @date_ends date
set @date_ends = getdate() + 100

INSERT INTO [data].[Business] 
		([businessId], [siteId], [name], [address], [cityTypeId], [stateTypeId], [countryTypeId], 
		[zip], [phone], [fax], [startDate], [endDate], 
		[entryStatusTypeId], [createdBy], 
		[modifiedBy], [modified], [created], [isActive], [url]) 
VALUES (NEWID(), @newly_added_site_id, N'business 1', N'zzz 1 str', NULL, NULL, NULL, 
		91111, N'', NULL, @date_now, @date_ends, 
		1, NULL, 
		NULL, @date_now, @date_now, 1, N'zzz.c0m')

INSERT INTO [data].[Business] 
		([businessId] , [siteId], 
		[name], [address], 
		[phone], [startDate], [endDate], 
		[entryStatusTypeId],  
		 [url]) 
VALUES ( NEWID(), @newly_added_site_id, 
		N'business 2', N'zzz 2 str', N'5555555555',  @date_now, @date_ends, 
		1, N'zzz.c0m 2')

INSERT INTO [data].[Business] 
		([businessId] , [siteId], 
		[name], [address], 
		[phone], [startDate], [endDate], 
		[entryStatusTypeId],  
		 [url]) 
VALUES ( NEWID(), @newly_added_site_id, 
		N'business 3', N'zzz 3 str', N'5555555555',  @date_now, @date_ends, 
		1, N'zzz.c0m 3')
	
INSERT INTO [data].[Business] 
		([businessId] , [siteId], 
		[name], [address], 
		[phone], [startDate], [endDate], 
		[entryStatusTypeId],  
		 [url]) 
VALUES ( NEWID(), @newly_added_site_id, 
		N'business 4', N'zzz 4 str', N'5555555555',  @date_now, @date_ends, 
		1, N'zzz.c0m 4')
		
GO