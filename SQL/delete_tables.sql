USE FalconAmazonDB;

IF OBJECT_ID('dbo.tbl_addresses', 'U') IS NOT NULL  
    DROP TABLE dbo.tbl_addresses;

IF OBJECT_ID('dbo.tbl_users', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_users;

