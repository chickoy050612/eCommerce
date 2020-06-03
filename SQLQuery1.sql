SELECT Sales.SalesID, (CONVERT(varchar(50),Customers.LastName) + ', ' + CONVERT(varchar(50),Customers.FirstName)),  Products.ManufactCode, Products.Description, Sales.QtySold, Sales.SellingPrice
FROM Customers INNER JOIN Sales ON Customers.CustomerID = Sales.CusID
INNER JOIN Products ON Products.ProductID = Sales.ProductID
ORDER BY 1;