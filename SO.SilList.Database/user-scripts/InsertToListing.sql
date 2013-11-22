USE [SilList]
GO

DELETE FROM [data].[Listing]
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

-- Listing Type
INSERT INTO [app].[ListingType] ([name],[description],[createdBy ],[modifiedBy],[created],[modified],[isActive])
     VALUES
           (N'SAMPLE 1' --<name, nvarchar(50),>
           ,N'SAMPLE 1' --<description, nvarchar(max),>
           ,NULL -- <createdBy , int,>
           , NULL -- <modifiedBy, int,>
           ,GETDATE() -- <created, datetime,>
           ,GETDATE() -- <modified, datetime,>
           ,1 -- <isActive, bit,>
		   )
GO


Declare @site_id integer
Select TOP 1 @site_id = [siteid] FROM [app].[Site] 

-- Listing Category
INSERT INTO [app].[ListingCategoryType]  ( [name],[description],[createdBy ],[modifiedBy],[created],[modified],[isActive] )
	VALUES (N'sample listing category 1 name'           ,N'sample listing category 1 descr'           ,NULL           ,NULL           ,GETDATE()           ,GETDATE()           ,1) 


DECLARE @newly_added_listingCategoryType_id integer
SET @newly_added_listingCategoryType_id = @@IDENTITY


 declare @listing_type_id integer
set @listing_type_id = 1 -- todo: get from real table (or set and get like Site)

-- Insert some listings

INSERT INTO [data].[Listing]
           ([listingId]
           ,[title]
           ,[description]
           ,[siteId]
           ,[listingTypeId]
           ,[price]
           ,[address]
           ,[cityTypeId]
           ,[stateTypeId]
           ,[countryTypeId]
           ,[zip]
           ,[phone]
           ,[fax]
           ,[startDate]
           ,[endDate]
           ,[entryStatusTypeId]
           ,[createdBy ]
           ,[modifiedBy]
           ,[created]
           ,[modified]
           ,[isActive])
     VALUES
           (NEWID()
           ,N'listing a'
           ,N'listing a' -- <description, nvarchar(max),>
           ,@site_id
           ,@newly_added_listingCategoryType_id -- @listing_type_id -- <listingTypeId, int,>
           ,1.1 -- <price, decimal(18,0),>
           ,N'listing a'
           ,1 -- <cityTypeId, int,>
           ,1 -- <stateTypeId, int,>
           ,1 -- <countryTypeId, int,>
           ,11 -- <zip, int,>
           ,N'11' -- <phone, nvarchar(50),>
           ,N'11' -- listing a'<fax, nvarchar(50),>
           ,N'2013-10-27' -- <startDate, date,>
           ,N'2014-10-27' -- <endDate, date,>
           ,1 -- <entryStatusTypeId, int,>
           ,NULL -- <createdBy , int,>
           ,NULL -- <modifiedBy, int,>
           ,N'2013-10-27' -- <created, datetime,>
           ,N'2013-10-27' -- <modified, datetime,>
           ,1 -- <isActive, bit,>
		   )



INSERT INTO [data].[Listing]
           ([listingId]
           ,[title]
           ,[description]
           ,[siteId]
           ,[listingTypeId]
           ,[price]
           ,[address]
           ,[cityTypeId]
           ,[stateTypeId]
           ,[countryTypeId]
           ,[zip]
           ,[phone]
           ,[fax]
           ,[startDate]
           ,[endDate]
           ,[entryStatusTypeId]
           ,[createdBy ]
           ,[modifiedBy]
           ,[created]
           ,[modified]
           ,[isActive])
     VALUES
           (NEWID()
           ,N'listing b'
           ,N'listing b' -- <description, nvarchar(max),>
           ,@site_id
           ,@newly_added_listingCategoryType_id -- @listing_type_id -- <listingTypeId, int,>
           ,1.1 -- <price, decimal(18,0),>
           ,N'listing b'
           ,1 -- <cityTypeId, int,>
           ,1 -- <stateTypeId, int,>
           ,1 -- <countryTypeId, int,>
           ,11 -- <zip, int,>
           ,N'11' -- <phone, nvarchar(50),>
           ,N'11' -- listing a'<fax, nvarchar(50),>
           ,N'2013-10-27' -- <startDate, date,>
           ,N'2014-10-27' -- <endDate, date,>
           ,1 -- <entryStatusTypeId, int,>
           ,NULL -- <createdBy , int,>
           ,NULL -- <modifiedBy, int,>
           ,N'2013-10-27' -- <created, datetime,>
           ,N'2013-10-27' -- <modified, datetime,>
           ,1 -- <isActive, bit,>
		   )




INSERT INTO [data].[Listing]
           ([listingId]
           ,[title]
           ,[description]
           ,[siteId]
           ,[listingTypeId]
           ,[price]
           ,[address]
           ,[cityTypeId]
           ,[stateTypeId]
           ,[countryTypeId]
           ,[zip]
           ,[phone]
           ,[fax]
           ,[startDate]
           ,[endDate]
           ,[entryStatusTypeId]
           ,[createdBy ]
           ,[modifiedBy]
           ,[created]
           ,[modified]
           ,[isActive])
     VALUES
           (NEWID()
           ,N'listing c'
           ,N'listing c' -- <description, nvarchar(max),>
           ,@site_id
           ,@newly_added_listingCategoryType_id -- @listing_type_id -- <listingTypeId, int,>
           ,1.1 -- <price, decimal(18,0),>
           ,N'listing c'
           ,1 -- <cityTypeId, int,>
           ,1 -- <stateTypeId, int,>
           ,1 -- <countryTypeId, int,>
           ,11 -- <zip, int,>
           ,N'11' -- <phone, nvarchar(50),>
           ,N'11' -- listing a'<fax, nvarchar(50),>
           ,N'2013-10-27' -- <startDate, date,>
           ,N'2014-10-27' -- <endDate, date,>
           ,1 -- <entryStatusTypeId, int,>
           ,NULL -- <createdBy , int,>
           ,NULL -- <modifiedBy, int,>
           ,N'2013-10-27' -- <created, datetime,>
           ,N'2013-10-27' -- <modified, datetime,>
           ,1 -- <isActive, bit,>
		   )



INSERT INTO [data].[Listing]
           ([listingId]
           ,[title]
           ,[description]
           ,[siteId]
           ,[listingTypeId]
           ,[price]
           ,[address]
           ,[cityTypeId]
           ,[stateTypeId]
           ,[countryTypeId]
           ,[zip]
           ,[phone]
           ,[fax]
           ,[startDate]
           ,[endDate]
           ,[entryStatusTypeId]
           ,[createdBy ]
           ,[modifiedBy]
           ,[created]
           ,[modified]
           ,[isActive])
     VALUES
           (NEWID()
           ,N'listing d'
           ,N'listing d' -- <description, nvarchar(max),>
           ,@site_id
           ,@newly_added_listingCategoryType_id -- @listing_type_id -- <listingTypeId, int,>
           ,1.1 -- <price, decimal(18,0),>
           ,N'listing d'
           ,1 -- <cityTypeId, int,>
           ,1 -- <stateTypeId, int,>
           ,1 -- <countryTypeId, int,>
           ,11 -- <zip, int,>
           ,N'11' -- <phone, nvarchar(50),>
           ,N'11' -- listing a'<fax, nvarchar(50),>
           ,N'2013-10-27' -- <startDate, date,>
           ,N'2014-10-27' -- <endDate, date,>
           ,1 -- <entryStatusTypeId, int,>
           ,NULL -- <createdBy , int,>
           ,NULL -- <modifiedBy, int,>
           ,N'2013-10-27' -- <created, datetime,>
           ,N'2013-10-27' -- <modified, datetime,>
           ,1 -- <isActive, bit,>
		   )
GO
