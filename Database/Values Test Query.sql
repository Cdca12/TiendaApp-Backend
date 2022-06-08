-- Insert test values
USE TiendaApp;
GO

-- Product
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice],[ProductImage]) VALUES ('Tenis 1', 100, 'tenis1.jpg');
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice],[ProductImage]) VALUES ('Tenis 2', 200, 'tenis2.jpg');
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice],[ProductImage]) VALUES ('Tenis 3', 300, 'tenis3.jpg');
--
--SELECT * FROM Product;


-- Category
INSERT INTO Category (CategoryName) VALUES ('Category 1');
INSERT INTO Category (CategoryName) VALUES ('Category 2');
INSERT INTO Category (CategoryName) VALUES ('Category 3');
--
--SELECT * FROM Category;


-- CategoryProduct
INSERT INTO CategoryProduct (CategoryID, ProductID)
VALUES 
	(1, 2), (1, 3),
	(2, 1), (2, 3),
	(3, 1), (3, 2);
--
--SELECT * FROM CategoryProduct;


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
--SELECT * FROM [Order];

-- OrderDetail 
INSERT INTO OrderDetail (OrderID, ProductID, OrderQuantity, OrderTotalProduct)
VALUES 
	(1, 2, 1, 200), (1, 1, 1, 100),
	(2, 3, 1, 300), (2, 2, 1, 200), (2, 1, 1, 100),
	(3, 3, 3, 900);
--
--SELECT * FROM OrderDetail;