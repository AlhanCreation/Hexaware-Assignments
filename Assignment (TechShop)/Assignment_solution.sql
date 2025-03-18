-- Task 1

-- 1. Create the database named "TechShop"
create database TechShop;
-- use database 
use TechShop;

--2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables based on the provided schema.
--3. Create an ERD (Entity Relationship Diagram) for the database.
--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity.


create table  Customers(
CustomerID numeric(4,0) primary key,
FirstName  varchar(15) not null,
LastName   varchar(15),
Email      varchar(30),
Phone      numeric (10),
CustomerAddress    varchar(30)
);

create table  Products(
ProductID numeric(4,0) primary key,
ProductName  varchar(15),
ProductDescription varchar(35),
Price decimal(10,2)
);

create table Orders (
OrderID numeric(10,0) primary key,
CustomerID numeric (4,0),
OrderDate date,
TotalAmount decimal(10,2)
constraint fk_001 foreign key (CustomerID) 
references Customers(CustomerID),
)

create table OrderDetails(
OrderDetailID numeric(4,0) primary key,
OrderID numeric(10,0),
ProductID numeric (4,0),
Quantity int,
constraint fk_002 foreign key(orderID) references Orders(OrderID),
constraint fk_003 foreign key (ProductID) references Products(ProductID)
);

create table Inventory (
InventoryID numeric (4,0) primary key,
ProductID numeric(4,0)  foreign key references Products(ProductID),
QuantityInStock int,
LastStockUpdate date 
);

--5. Insert at least 10 sample records into each of the following tables.
--a. Customers
--b. Products
--c. Orders
--d. OrderDetails

insert into Customers (CustomerID, FirstName, LastName, Email, Phone, CustomerAddress)
values
(1001, 'John', 'Doe', 'john.doe@email.com', 9876543210, '123 Main St'),
(1002, 'Jane', 'Smith', 'jane.smith@email.com', 9123456789, '456 Elm St'),
(1003, 'Alice', 'Brown', 'alice.brown@email.com', 9988776655, '789 Pine St'),
(1004, 'Bob', 'Wilson', 'bob.wilson@email.com', 9556677889, '101 Oak St'),
(1005, 'Charlie', 'Davis', 'charlie.davis@email.com', 9778899001, '202 Maple St'),
(1006, 'David', 'White', 'david.white@email.com', 9887766554, '303 Birch St'),
(1007, 'Emma', 'Taylor', 'emma.taylor@email.com', 9665544332, '404 Cedar St'),
(1008, 'Frank', 'Anderson', 'frank.anderson@email.com', 9111222333, '505 Walnut St'),
(1009, 'Grace', 'Harris', 'grace.harris@email.com', 9223344556, '606 Cherry St'),
(1010, 'Henry', 'Martin', 'henry.martin@email.com', 9334455667, '707 Spruce St');


insert into Products (ProductID, ProductName, ProductDescription, Price)
values
(2001, 'Laptop', 'High-performance laptop', 1200.99),
(2002, 'Smartphone', 'Latest model smartphone', 899.49),
(2003, 'Tablet', '10-inch screen tablet', 499.99),
(2004, 'Smartwatch', 'Fitness tracking smartwatch', 199.99),
(2005, 'Headphones', 'Noise-canceling headphones', 149.95),
(2006, 'Keyboard', 'Mechanical gaming keyboard', 89.99),
(2007, 'Mouse', 'Wireless ergonomic mouse', 49.99),
(2008, 'Monitor', '24-inch LED monitor', 179.99),
(2009, 'Printer', 'All-in-one color printer', 229.99),
(2010, 'External SSD', '1TB portable SSD', 139.99);


insert into Orders (OrderID, CustomerID, OrderDate, TotalAmount)
values
(30001, 1001, '2025-03-01', 1399.48),
(30002, 1002, '2025-03-02', 899.49),
(30003, 1003, '2025-03-03', 499.99),
(30004, 1004, '2025-03-04', 229.99),
(30005, 1005, '2025-03-05', 179.99),
(30006, 1006, '2025-03-06', 89.99),
(30007, 1007, '2025-03-07', 49.99),
(30008, 1008, '2025-03-08', 149.95),
(30009, 1009, '2025-03-09', 199.99),
(30010, 1010, '2025-03-10', 1200.99);


insert INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity)
values
(4001, 30001, 2001, 1),
(4002, 30001, 2005, 1),
(4003, 30002, 2002, 1),
(4004, 30003, 2003, 1),
(4005, 30004, 2009, 1),
(4006, 30005, 2008, 1),
(4007, 30006, 2006, 1),
(4008, 30007, 2007, 1),
(4009, 30008, 2005, 1),
(4010, 30009, 2004, 1);


insert into Inventory (InventoryID, ProductID, QuantityInStock, LastStockUpdate)
values
(5001, 2001, 50, '2025-02-28'),
(5002, 2002, 75, '2025-02-28'),
(5003, 2003, 100, '2025-02-28'),
(5004, 2004, 120, '2025-02-28'),
(5005, 2005, 200, '2025-02-28'),
(5006, 2006, 150, '2025-02-28'),
(5007, 2007, 175, '2025-02-28'),
(5008, 2008, 90, '2025-02-28'),
(5009, 2009, 60, '2025-02-28'),
(5010, 2010, 110, '2025-02-28');


--Tasks 2: Select, Where, Between, AND, LIKE:

--1. Write an SQL query to retrieve the names and emails of all customers.

select FirstName,email from Customers

--2. Write an SQL query to list all orders with their order dates and corresponding customer names.

SELECT 
    Orders.OrderID, 
    Orders.OrderDate, 
    Customers.FirstName, 
    Customers.LastName
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

--3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.

insert into Customers(CustomerID,FirstName,email,CustomerAddress) 
values
(1011 ,'Alhan','alhanapsiddique@gmail.com','Nagpur');                   -- its importent to add customerID as it is p.k

--4 Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.

select * from Products;
update Products set Price = Price*1.10;

--5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables.
--   Allow users to input the order ID as a parameter.


--6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.

insert into Orders (OrderID, CustomerID, OrderDate)
values
(30011, 1001, '2025-03-21');

--7 Write an SQL query to update the contact information (e.g., email and address) of a specific
--   customer in the "Customers" table. Allow users to input the customer ID and new contact
--    information.