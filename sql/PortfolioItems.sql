--Database name: portfobase

IF OBJECT_ID('dbo.PortfolioItems', 'U') IS NOT NULL
	DROP TABLE dbo.PortfolioItems; 
  
CREATE TABLE PortfolioItems (
	ID uniqueidentifier NOT NULL PRIMARY KEY DEFAULT newsequentialid(),
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(MAX),
	Image NVARCHAR(200),
	Video NVARCHAR(200)
)