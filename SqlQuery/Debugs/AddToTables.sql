use H1PD021123_Gruppe1;

--INSERT INTO PRODUCTS--
--INSERT INTO dbo.Products (Name, Description, PurchasePrice, Location, AmountInStock, Unit, SalesPrice)
--VALUES ('Nokia', '6310', 150, 'A-03-D1', 120, 'pieces', 999), ('Iphone', '4s', 2.197, 'A-03-D2', 72, 'pieces', 6.995),
--('Netværkskabel', 'UTP Cat6 Hvid', 2.55, 'B-06-A2', 300, 'meter', 6), ('RJ45-stik', 'UTP Solid', 2, 'B-06-A1', 1000, 'pieces', 6),
--('Linux pocket guide', 'Quick guide for linux', 59, 'F-03-E9', 3, 'pieces', 299)

---------------------------------------------------------------------------------------------

--INSERT INTO PERSON--
--INSERT INTO dbo.Persons (FirstName, LastName, PhoneNumber, Mail, Address, Role, CreationTimeStamp)
--VALUES ('Martin', 'Danmark', '67 88 92 010', 'Martin@live.dk', '{"country":"Danmark","zipCode":"100","city":"Aalvrg","roadName":"test","doorNumber":"20"}', 'Customer', '2021-01-04 00:00:00.000'), 
--('Henning', 'Larsen', '79 21 22 02', 'HenningLarsen@gmail.com', '{"country":"United Kingdom","zipCode":"N1P 3AF","city":"London","roadName":"Essex Rd","doorNumber":"108"}', 'Customer', '2021-02-06 00:00:00.000'),
--('Rasmus', 'Hansen', '90 23 50 15', 'Rasmus@Hansen.dk', '{"country":"Italien","zipCode":"30100","city":"Venedig","roadName":"Fondamenta Zen","doorNumber":"4925"}', 'Customer', '2023-04-15 00:00:00.000'), 
--('Erling', 'Jörgensen', '20 59 00 00', 'ErJorg@gotmail.com', '{"country":"Island","zipCode":"302","city":"Akranes","roadName":"Þjóðbraut","doorNumber":"28"}', 'Customer', '2023-04-18 00:00:00.000'),
--('Kenneth', 'Larsen', '32 99 10 20', 'Larsen@live.com', '{"country":"Norge","zipCode":"5730","city":"Ulvik","roadName":"Eikjeledbakkjen","doorNumber":"9"}', 'Customer', '2023-04-20 00:00:00.000')


---------------------------------------------------------------------------------------------

--INSER INTO COMPANIES--
--INSERT INTO dbo.Companies (Name, Road, HouseNumber, ZipCode, city, Country, Currency, Cvr, Email)
--VALUES ('Lithia Motors', 'Eithenburgerer', '291', '99-852', 'Altana', 'United States of America', 'USD', '05-5761613', 'mallory.hermiston@cormier.info'),
--('Reynolds, Krajcik and Abernathy', 'óíkanska', '2F', '99221', 'Akunst', 'Polen', 'EUR', '21-9433300', 'lakin.collin@bradtke.com'),
--('Lynch, Bayer and Bergstrom', 'Ubergrans', '33', '981', 'kalskunska', 'Tyskland', 'EUR', '56-4584689', 'kschmidt@oreilly.biz')

---------------------------------------------------------------------------------------------

--INSERT INTO ORDER--
--INSERT INTO dbo.Orders (CreationTimestamp, DoneTimestamp, CustomerId, State, TotalOrderPrice)
--VALUES ('2021-01-04 00:00:00.000', '2021-01-21 00:00:00.000', 1, 'Done', 6.995), 
--('2021-02-06 00:00:00.000', '2021-02-12 00:00:00.000', 2, 'Done', 72),
--('2023-04-15 00:00:00.000', '', 3, 'Packaged', 999),
--('2023-04-18 00:00:00.000', '', 4, 'Approved', 299),
--('2023-04-20 00:00:00.000', '', 5, 'Created', 120),
--('2023-04-20 00:00:00.000', '', 2, 'Created', 12),
--('2022-02-04 00:00:00.000', '2022-02-10 00:00:00.000', 1, 'Done', 299)


---------------------------------------------------------------------------------------------

--INSERT INTO ORDERLIST--
--INSERT INTO dbo.OrdersList(OrdersId, ProductId, Amount)
--VALUES (1, 2, 1), (2, 4, 2), (2, 3, 10), (3, 1, 1), (4, 5, 1), (5, 3, 20), (6, 4, 2), (7, 5, 1)

---------------------------------------------------------------------------------------------

--SELECT
--SELECT Id FROM dbo.OrdersList WHERE ordersId = 1 AND productId = 1