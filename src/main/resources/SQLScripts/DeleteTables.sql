USE FalconAmazonDB;

IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.Orders'))
    ALTER TABLE dbo.Orders DROP CONSTRAINT FK_OrderCustomer;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.OrderItems'))
    ALTER TABLE dbo.OrderItems DROP CONSTRAINT FK_OrderItemOrder;
IF EXISTS(SELECT * FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.OrderItems'))
    ALTER TABLE dbo.OrderItems DROP CONSTRAINT FK_OrderItemProduct;

IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
    DROP TABLE dbo.Customers;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL
    DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.OrderItems', 'U') IS NOT NULL
    DROP TABLE dbo.OrderItems;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;