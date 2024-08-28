CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Name NVARCHAR(100) NOT NULL       
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),  
    Name NVARCHAR(100) NOT NULL,      
    CategoryId INT,                  
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
SELECT 
    Products.Name AS ProductName, 
    Categories.Name AS CategoryName
FROM 
    Products
LEFT JOIN 
    Categories ON Products.CategoryId = Categories.Id;
