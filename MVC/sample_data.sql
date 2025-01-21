CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    CompanyName NVARCHAR(50) NOT NULL,
    ContactName NVARCHAR(50),
    ContactTitle NVARCHAR(50),
    Address NVARCHAR(100),
    City NVARCHAR(50),
    Region NVARCHAR(50),
    PostalCode NVARCHAR(20),
    Country NVARCHAR(50),
    Phone NVARCHAR(20),
    Fax NVARCHAR(20),
    HomePage NVARCHAR(MAX)
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX),
    Picture VARBINARY(MAX)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(40) NOT NULL,
    SupplierID INT NOT NULL,
    CategoryID INT NOT NULL,
    QuantityPerUnit NVARCHAR(20),
    UnitPrice DECIMAL(18, 2) CHECK (UnitPrice >= 0),
    UnitsInStock SMALLINT CHECK (UnitsInStock >= 0),
    UnitsOnOrder SMALLINT CHECK (UnitsOnOrder >= 0),
    ReorderLevel SMALLINT CHECK (ReorderLevel >= 0),
    Discontinued BIT NOT NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage)
VALUES 
('Supplier Of Books', 'Bruce Wayne', 'Sales Manager', '13 Elm Str', 'Emerald city', 'CA', '12345', 'US', '555-1234', '555-5678', 'http://www.example.com'),
('Samsung', 'Kim John Ihn', 'Marketing Manager', '42 Green Str', 'Diamond city', 'TX', '67890', 'US', '555-8765', '555-4321', 'http://www.example.com'),
('Farmers market', 'Tim Cook', 'Cashier', '78 Tree Str', 'Ruby city', 'NY', '11223', 'US', '555-1122', '555-3344', 'http://www.example.com');


INSERT INTO Categories (CategoryName, Description, Picture)
VALUES 
('Books', 'Buy some books', 1),
('Phones', 'Buy iPhone or Android', 1),
('Food', 'Buy something to eat', 1);

INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
VALUES 
('Lord of the Rings', 1, 1, '1', 20.00, 100, 50, 10, 0),
('iPhone 15 PRO Max', 2, 2, '1', 15.00, 200, 30, 5, 0),
('Banana', 3, 3, '5', 25.00, 150, 20, 15, 1);