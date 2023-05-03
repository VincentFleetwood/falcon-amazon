USE FalconAmazonDB;

IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrders'))
    ALTER TABLE dbo.tblOrders DROP CONSTRAINT FK_OrderCustomer;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrderItems'))
    ALTER TABLE dbo.tblOrderItems DROP CONSTRAINT FK_OrderItemOrder;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrderItems'))
    ALTER TABLE dbo.tblOrderItems DROP CONSTRAINT FK_OrderItemProduct;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblProducts'))
    ALTER TABLE dbo.tblProducts DROP CONSTRAINT FK_ProductCategory;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblInventory'))
    ALTER TABLE dbo.tblInventory DROP CONSTRAINT FK_InventoryProduct;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblCustomer'))
    ALTER TABLE dbo.tblCustomer DROP CONSTRAINT FK_CustomerAddress;
	


IF OBJECT_ID('dbo.tblCustomers', 'U') IS NOT NULL
    DROP TABLE dbo.tblCustomers;
IF OBJECT_ID('dbo.tblOrders', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrders;
IF OBJECT_ID('dbo.tblOrderItems', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrderItems;
IF OBJECT_ID('dbo.tblProducts', 'U') IS NOT NULL
    DROP TABLE dbo.tblProducts;
IF OBJECT_ID('dbo.tblAddresses', 'U') IS NOT NULL
    DROP TABLE dbo.tblAddresses;
IF OBJECT_ID('dbo.tblInventory', 'U') IS NOT NULL
    DROP TABLE dbo.tblInventory;
IF OBJECT_ID('dbo.tblProductCategory', 'U') IS NOT NULL
    DROP TABLE dbo.tblProductCategory;