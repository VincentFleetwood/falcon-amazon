USE FalconAmazonDB;

IF OBJECT_ID('dbo.tbl_addresses', 'U') IS NOT NULL  
    DROP TABLE dbo.tbl_addresses;

IF OBJECT_ID('dbo.tbl_users', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_users;

IF OBJECT_ID('dbo.tbl_user_tokens', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_user_tokens;