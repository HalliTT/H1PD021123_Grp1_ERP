use H1PD021123_Gruppe1;

--ADD INTO PRODUCTS--
--INSERT INTO dbo.Products (Name, PurchasePrice, Location, AmountInStock, Unit, SalesPrice)
--VALUES ('Test 4', 200, 'Somewhere', 3, 'Meter', 300)
---------------------------------------------------------------------------------------------

--ADD INTO PERSON--
--INSERT INTO dbo.Persons (FirstName, LastName, PhoneNumber, Mail, Address, Role, CreationTimeStamp)
--VALUES ('My Name 3', 'My next name', '20 59 00 00', 'dk@dk.dk', 'Somewhere', 'ADMIN', '')
---------------------------------------------------------------------------------------------

--ADD INTO PERSON--
--INSERT INTO dbo.Orders (CreationTimestamp, DoneTimestamp, CustomerId, State, TotalOrderPrice)
--VALUES ('', '', 3, 'GO AWAY', 100)
---------------------------------------------------------------------------------------------

--ADD INTO ORDERLIST--
--INSERT INTO dbo.OrdersList(OrdersId, ProductId, Amount)
--VALUES (1, 1, 3)
---------------------------------------------------------------------------------------------

SELECT Id FROM dbo.OrdersList WHERE ordersId = 1 AND productId = 1