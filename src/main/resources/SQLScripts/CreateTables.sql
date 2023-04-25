USE FalconAmazonDB;

CREATE TABLE Customers
(
    CustomerID int IDENTITY(10000, 1) NOT NULL,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    EmailAddress nvarchar(100) UNIQUE NOT NULL,
    PhoneNumber nvarchar(20) UNIQUE NOT NULL,
    DOB date NOT NULL,

    CONSTRAINT PK_Customer PRIMARY KEY (CustomerID)
);

CREATE TABLE Products
(
    ProductID int IDENTITY(10000, 1) NOT NULL,
    ProductName nvarchar(50) NOT NULL,
    ProductDescription nvarchar(255) NOT NULL,
    ProductPrice decimal(10,2) NOT NULL,
    Category nvarchar(50) NOT NULL,

    CONSTRAINT PK_Product PRIMARY KEY (ProductID)
);

CREATE TABLE Orders
(
    OrderID int IDENTITY(10000, 1) NOT NULL,
    CustomerID int NOT NULL,
    OrderDate date NOT NULL,
    OrderTotal decimal(10,2) NOT NULL,

    CONSTRAINT PK_Order PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderCustomer FOREIGN KEY(CustomerID)
    REFERENCES dbo.Customers(CustomerID)
);

CREATE TABLE OrderItems
(
    OrderItemID int IDENTITY(10000, 1) NOT NULL,
    OrderID int NOT NULL,
    ProductID int NOT NULL,
    Quantity int NOT NULL,
    PricePerUnit decimal(10,2) NOT NULL,

    CONSTRAINT PK_OrderItem PRIMARY KEY (OrderItemID),
    CONSTRAINT FK_OrderItemOrder FOREIGN KEY(OrderID)
    REFERENCES dbo.Orders(OrderID),
    CONSTRAINT FK_OrderItemProduct FOREIGN KEY(ProductID)
    REFERENCES dbo.Products(ProductID)
);