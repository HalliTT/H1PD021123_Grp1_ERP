USE H1PD021123_Gruppe1 SELECT Orders.Id AS OrderId, Persons.*, Products.Name, OrdersList.Amount FROM Orders
INNER JOIN Persons ON Orders.Id = Persons.Id

JOIN OrdersList ON Orders.Id = OrdersList.OrdersId
JOIN Products ON OrdersList.ProductId = Products.Id