-- Create database
USE master
GO
CREATE DATABASE TiendaApp;
GO

USE TiendaApp;
GO

-- Create tables

-- (Productos)
CREATE TABLE Product (
  ProductID int PRIMARY KEY IDENTITY,
  ProductName varchar(255),
  ProductPrice int
)
GO

CREATE TABLE Category (
  CategoryID int PRIMARY KEY IDENTITY,
  CategoryName varchar(255)
)
GO

-- (CategoriasProductos)
CREATE TABLE ProductCategory (
  ProductID int FOREIGN KEY REFERENCES Product,
  CategoryID int FOREIGN KEY REFERENCES Category,
  PRIMARY KEY (ProductID, CategoryID)
)
GO

CREATE TABLE Client (
  ClientID int PRIMARY KEY IDENTITY,
  ClientName varchar(255)
)
GO

-- (Pedidos)
CREATE TABLE [Order] (
  OrderID int PRIMARY KEY IDENTITY,
  OrderDate date,
  OrderTotal decimal(13,2),
  ClientID int FOREIGN KEY REFERENCES Client
)
GO

CREATE TABLE OrderDetail (
  OrderID int FOREIGN KEY REFERENCES [Order],
  ProductID int FOREIGN KEY REFERENCES Product,
  OrderQuantity int,
  PRIMARY KEY (OrderID, ProductID)
)
