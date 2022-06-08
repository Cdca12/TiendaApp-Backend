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
  ProductName varchar(255) NOT NULL,
  ProductPrice decimal(13,2) NOT NULL,
  ProductImage varchar(255) NOT NULL
)
GO

CREATE TABLE Category (
  CategoryID int PRIMARY KEY IDENTITY,
  CategoryName varchar(255) NOT NULL
)
GO

-- (CategoriasProductos)
CREATE TABLE CategoryProduct (
  CategoryID int FOREIGN KEY REFERENCES Category,
  ProductID int FOREIGN KEY REFERENCES Product,
  PRIMARY KEY (CategoryID, ProductID)
)
GO

CREATE TABLE Client (
  ClientID int PRIMARY KEY IDENTITY,
  ClientName varchar(255) NOT NULL
)
GO

-- (Pedidos)
CREATE TABLE [Order] (
  OrderID int PRIMARY KEY IDENTITY,
  OrderDate date NOT NULL DEFAULT CAST(GETDATE() as date),
  OrderTotal decimal(13,2) NOT NULL,
  ClientID int FOREIGN KEY REFERENCES Client
)
GO

CREATE TABLE OrderDetail (
  OrderID int FOREIGN KEY REFERENCES [Order],
  ProductID int FOREIGN KEY REFERENCES Product,
  OrderQuantity int NOT NULL,
  OrderTotalProduct decimal(13,2) NOT NULL,
  PRIMARY KEY (OrderID, ProductID)
)
GO