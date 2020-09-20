CREATE TABLE Products (
    Id int identity(1,1) primary key,
    SKU int,
    ProductName nvarchar(200),
    Description nvarchar(max),
    Price decimal(14,2),
	CategoryId int
);

CREATE TABLE Categories (
    Id int identity(1,1) primary key,
    CategoryName nvarchar(50)
);

Go

CREATE PROCEDURE GetFeaturedProducts
AS
BEGIN
SET NOCOUNT ON
 
SELECT 
	Products.*,
	Categories.CategoryName
	FROM Products
		INNER JOIN Categories  
			ON Products.CategoryId = Categories.Id
	WHERE Products.SKU < 40000
 
END

Go

CREATE PROCEDURE GetProducts
(@Category nvarchar(50))
AS
BEGIN
SET NOCOUNT ON
 
SELECT 
	Products.*,
	Categories.CategoryName
	FROM Products
		INNER JOIN Categories  
			ON Products.CategoryId = Categories.Id
	WHERE @Category is null or @Category = Categories.CategoryName
 
END

Go

CREATE PROCEDURE GetCategories
AS
BEGIN
SET NOCOUNT ON
 
SELECT *
	FROM Categories
 
END