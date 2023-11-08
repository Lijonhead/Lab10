--SELECT p.ProductName, p.UnitPrice, c.CategoryName
--FROM Products p
--JOIN Categories c ON p.CategoryID = c.CategoryID
--ORDER BY c.CategoryName, p.ProductName;

--SELECT c.CompanyName, COUNT(o.OrderID) NumberOfOrders
--FROM Customers c
--JOIN Orders o ON c.CustomerID = o.CustomerID
--GROUP BY c.CompanyName
--ORDER BY COUNT(o.OrderID) DESC;

--SELECT e.EmployeeID, e.FirstName, e.LastName, t.TerritoryDescription
--FROM Employees e
--JOIN EmployeeTerritories et ON e.EmployeeID = et.EmployeeID
--JOIN Territories t ON et.TerritoryID = t.TerritoryID;