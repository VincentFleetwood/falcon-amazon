USE FalconAmazonDB;

IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrders'))
    ALTER TABLE dbo.tblOrders DROP CONSTRAINT FK_OrderCustomer;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrderItems'))
    ALTER TABLE dbo.tblOrderItems DROP CONSTRAINT FK_OrderItemOrder;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblOrderItems'))
    ALTER TABLE dbo.tblOrderItems DROP CONSTRAINT FK_OrderItemProduct;

IF OBJECT_ID('dbo.tblCustomers', 'U') IS NOT NULL
    DROP TABLE dbo.tblCustomers;
IF OBJECT_ID('dbo.tblOrders', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrders;
IF OBJECT_ID('dbo.tblOrderItems', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrderItems;
IF OBJECT_ID('dbo.tblProducts', 'U') IS NOT NULL
    DROP TABLE dbo.tblProducts;