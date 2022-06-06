-- Insert test values

-- Product
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Producto 1', 100);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Producto 2', 200);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Producto 3', 300);
--
--SELECT * FROM Product;


-- Category
INSERT INTO Category (CategoryName) VALUES ('Category 1');
INSERT INTO Category (CategoryName) VALUES ('Category 2');
INSERT INTO Category (CategoryName) VALUES ('Category 3');
--
--SELECT * FROM Category;


-- ProductCategory
INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES 
	(1, 2), (1, 3),
	(2, 1), (2, 3),
	(3, 1), (3, 2);
--
--SELECT * FROM ProductCategory;


-- Client
INSERT INTO Client (ClientName) VALUES ('Client 1');
INSERT INTO Client (ClientName) VALUES ('Client 2');
INSERT INTO Client (ClientName) VALUES ('Client 3');
--
--SELECT * FROM Client;


-- Order
INSERT INTO [Order] (OrderDate, OrderTotal, ClientID) VALUES (GETDATE(), 100, 1);
INSERT INTO [Order] (OrderDate, OrderTotal, ClientID) VALUES (GETDATE(), 200, 2);
INSERT INTO [Order] (OrderDate, OrderTotal, ClientID) VALUES (GETDATE(), 300, 3);
--
SELECT * FROM [Order];

-- OrderDetail 
INSERT INTO OrderDetail (OrderID, ProductID, OrderQuantity)
VALUES 
	(1, 2, 1), (1, 1, 2),
	(2, 3, 1), (2, 2, 1), (2, 1, 1),
	(3, 3, 3);
--
--SELECT * FROM OrderDetail;