CREATE VIEW [dbo].[VisitDaily]
	AS SELECT ipAddress, referrerUrl, visitTime FROM [Visit] 
	   GROUP BY ipAddress
	

