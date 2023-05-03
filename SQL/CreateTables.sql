USE FalconAmazonDB;

CREATE TABLE tblCustomers
(
    CustomerID int IDENTITY(10000, 1) NOT NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    EmailAddress nvarchar(100) UNIQUE NOT NULL,
    PhoneNumber nvarchar(20) UNIQUE NOT NULL,
    DOB date NOT NULL,
    AddressID int NOT NULL,

    CONSTRAINT PK_Customer PRIMARY KEY (CustomerID),

    CONSTRAINT FK_CustomerAddress FOREIGN KEY (AddressID) REFERENCES dbo.tblAddresses(AddressID)
);

CREATE TABLE tblProductCategory
(
	CategoryID int IDENTITY(10000, 1) NOT NULL,
	CategoryName nvarchar(100) NOT NULL,
	CategoryDescription nvarchar(200) NULL,

	CONSTRAINT PK_Category PRIMARY KEY (CategoryID),
);

CREATE TABLE tblProducts
(
    ProductID int IDENTITY(10000, 1) NOT NULL,
    ProductName nvarchar(50) NOT NULL,
    ProductDescription nvarchar(255) NOT NULL,
    ProductPrice decimal(10,2) NOT NULL,
    CategoryID int NOT NULL,

    CONSTRAINT PK_Product PRIMARY KEY (ProductID),
	CONSTRAINT FK_ProductCategory FOREIGN KEY (CategoryID) REFERENCES dbo.tblProductCategory(CategoryID)
);

CREATE TABLE tblInventory
(
    InventoryID int IDENTITY(10000, 1) NOT NULL,
    ProductID int NOT NULL,
    ProductQuantity int NOT NULL,
    ProductStatus nvarchar(20) NOT NULL,

    CONSTRAINT PK_Inventory PRIMARY KEY (InventoryID),
    CONSTRAINT FK_InventoryProduct FOREIGN KEY (ProductID)
    REFERENCES dbo.tblProducts(ProductID)
);

CREATE TABLE tblOrders
(
    OrderID int IDENTITY(10000, 1) NOT NULL,
    CustomerID int NULL,
    OrderDate date NOT NULL,
    OrderTotal decimal(10,2) NOT NULL,

    CONSTRAINT PK_Order PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderCustomer FOREIGN KEY(CustomerID)
    REFERENCES dbo.tblCustomers(CustomerID) ON DELETE SET NULL
);

CREATE TABLE tblOrderItems
(
    OrderItemID int IDENTITY(10000, 1) NOT NULL,
    OrderID int NOT NULL,
    ProductID int NOT NULL,
    Quantity int NOT NULL,
    PricePerUnit decimal(10,2) NOT NULL,

    CONSTRAINT PK_OrderItem PRIMARY KEY (OrderItemID),
    CONSTRAINT FK_OrderItemOrder FOREIGN KEY(OrderID)
    REFERENCES dbo.tblOrders(OrderID),
    CONSTRAINT FK_OrderItemProduct FOREIGN KEY(ProductID)
    REFERENCES dbo.tblProducts(ProductID)
);

CREATE TABLE tblAddresses
(
	AddressID int IDENTITY(10000, 1) NOT NULL,
	AddressLine1 nvarchar(100) NOT NULL,
	AddressLine2 nvarchar(100) NULL,
	City nvarchar(50) NOT NULL,
	Postcode nvarchar(20) NOT NULL,
	Country nvarchar(50) NOT NULL,

	CONSTRAINT PK_Address PRIMARY KEY (AddressID),
);
