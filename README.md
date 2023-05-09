# **ERP System - Console App**

## **Group info**

- H1PD021123
- Group 1
- Marcus, Niclas, Haraldur

## **Table of contents**

- [General info](#general-info)
- [Technologies](#technologies)
- [Setup](#setup)
- [License](#license)
- [Docs](#Docs)
- [SqlQuery](#SqlQuery)

## **General info**

This project is simple ERP system that is made for console app.

This project is written in **C#** and has a Database wich utilies **MS SQL** to save, create, update and delete data of Customer, Company, Products and Sales.

This project is using **TECHCOOL** to create screen and dispaly in console.

`Additional: Too See how the code is structured:` [Database](./Docs/DatabaseDiagram.pdf) // [Classes](./Docs/ClassDiagram.pdf)

## **Technologies**

**This project is written with:**

- C#
- MS SQL

**This project is created with:**

- .Net version: 6.0
- Microsoft.Data.SqlClient version: 5.1.0
- Newtonsoft: 13.0.3
- TECHCOOL version: 1.3.2

## **Setup**

To run this project:

```
$ cd Src
$ dotnet run
```

## **License**

- [License](./LICENSE)

## **Docs**

- [Agreements](./Docs/Aftale.pdf)
- [Burn Down](./Docs/BurnDown.xlsx)
- [Requirement specification](./Docs/Kravspecifikation.pdf)
- [Screen diagram](./Docs/ScreenDiagram.pdf)
- [Database diagram](./Docs/DatabaseDiagram.pdf)
- [Class diagram](./Docs/ClassDiagram.pdf)

## **SqlQuery**

- [Companies](./SqlQuery/CreateCompaniesTable.sql)
- [OrdersList](./SqlQuery/CreateOrdersListTable.sql)
- [orders](./SqlQuery/CreateOrdersTable.sql)
- [Person](./SqlQuery/CreatePersonTable.sql)
- [Product](./SqlQuery/CreateProductTable.sql)
