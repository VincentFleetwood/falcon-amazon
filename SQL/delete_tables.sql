USE FalconAmazonDB;

IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tbl_addresses'))
    ALTER TABLE dbo.tbl_addresses DROP CONSTRAINT FK_address_user;

IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tbl_user_tokens'))
    ALTER TABLE dbo.tbl_user_tokens DROP CONSTRAINT FK_user_tokens_user;

IF OBJECT_ID('dbo.tbl_addresses', 'U') IS NOT NULL  
    DROP TABLE dbo.tbl_addresses;

IF OBJECT_ID('dbo.tbl_users', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_users;

IF OBJECT_ID('dbo.tbl_user_tokens', 'U') IS NOT NULL
    DROP TABLE dbo.tbl_user_tokens;