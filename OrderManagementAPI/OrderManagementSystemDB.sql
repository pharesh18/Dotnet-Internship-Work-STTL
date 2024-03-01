use OrderManagementSystemDB;

CREATE TABLE Customer (
    CustomerId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(30) NOT NULL,
    Email NVARCHAR(50) UNIQUE NOT NULL,
    Address NVARCHAR(500) NOT NULL
);


INSERT INTO Customer (Name, Email, Address) VALUES
('Haresh Prajapati', 'haresh@gmail.com', 'Ahmedabad'),
('Vishnu Prajapati', 'vishnu@gmail.com', 'Ahmedabad'),
('Mohit Chauhan', 'mohit@gmail.com', 'Ahmedabad'),
('Manav Patel', 'manav@gmail.com', 'Ahmedabad'),
('Dev Mistri', 'dev@gmail.com', 'Ahmedabad')


CREATE TABLE Product (
    ProductId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0)
);

INSERT INTO Product (Name, Description, Price, StockQuantity) VALUES
('Frankie', 'Delicious rolled Indian street food', 80, 50),
('Vadapav', 'Spicy and flavorful street snack', 20, 100),
('Pizza', 'Classic Italian pizza with your favorite toppings', 250, 30),
('Burger', 'Juicy beef or veggie patty with fresh veggies', 140, 40),
('Sushi', 'Japanese delicacy with fresh fish and rice', 80, 20);


CREATE TABLE [Order] (
    OrderId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId) NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL CHECK (TotalAmount >= 0),
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Shipped', 'Delivered'))
);


INSERT INTO [Order] (CustomerId, OrderDate, TotalAmount, Status) VALUES
(1, '2024-02-29 10:00:00', 0.00, 'Pending'),
(1, '2024-02-29 11:30:00', 0.00, 'Pending'),
(1, '2024-02-29 12:45:00', 0.00, 'Pending'),
(1, '2024-02-29 14:15:00', 0.00, 'Pending'),
(1, '2024-02-29 15:30:00', 0.00, 'Pending');


CREATE TABLE OrderItem (
    OrderItemId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    OrderId INT FOREIGN KEY REFERENCES [Order](OrderId) NOT NULL,
    ProductId INT FOREIGN KEY REFERENCES Product(ProductId) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10, 2) NOT NULL CHECK (UnitPrice >= 0)
);

INSERT INTO OrderItem (OrderId, ProductId, Quantity, UnitPrice) VALUES
(1, 1, 2, 50.00),
(1, 1, 1, 25.00),
(1, 1, 2, 30.50);


