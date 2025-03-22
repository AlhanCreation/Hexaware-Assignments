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

select * from Orders
select * from OrderDetails

--Tasks 2: Select, Where, Between, AND, LIKE:

/* 1. Write an SQL query to retrieve the names and emails of all customers.  */

	select FirstName,email from Customers

/* 2. Write an SQL query to list all orders with their order dates and corresponding customer names.  */

	SELECT Orders.OrderID, Orders.OrderDate, Customers.FirstName, Customers.LastName
	FROM Orders, Customers
	WHERE Orders.CustomerID = Customers.CustomerID;

/* 3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.
   its importent to add customerID as it is p.k  */

	insert into Customers(CustomerID,FirstName,email,CustomerAddress) 
	values(1011 ,'Alhan','alhanapsiddique@gmail.com','Nagpur');    

/* 4 Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%. */

	select * from Products;
	update Products set Price = Price*1.10;

/* 5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. 
   Allow users to input the order ID as a parameter.  */

	Declare @inputOrderId numeric (10,0)
	SET @inputOrderId = 30011; 
	DELETE FROM OrderDetails WHERE OrderID = @inputOrderId;
	delete from Orders where OrderID = @inputOrderId 

/* 6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.  */

	insert into Orders (OrderID, CustomerID, OrderDate)
	values
	(30011, 1001, '2025-03-21');

/* 7 Write an SQL query to update the contact information (e.g., email and address) of a specific
   customer in the "Customers" table. Allow users to input the customer ID and new contact information. */

   update  customers set email = @emaild , set CustomerAddress = @customerAddress where customerID =@customerID  
   select * from customers 
   --OR
   CREATE PROCEDURE UpdateCustomerContact
    @customerID numeric (4,0),
    @email varchar(25),
    @customerAddress varchar(30)
AS
BEGIN
    UPDATE customers
    SET email = @email, CustomerAddress = @customerAddress
    WHERE customerID = @customerID;
END;

EXEC UpdateCustomerContact @customerID = 1001, 
                           @email = ' newemail@example.com', 
                           @customerAddress = '123 New Street, City, Country';

/* 8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
table based on the prices and quantities in the "OrderDetails" table. */
UPDATE Orders 
SET TotalAmount = (
    SELECT SUM(p.Price * od.Quantity) 
    FROM OrderDetails od
    JOIN Products p ON od.ProductID = p.ProductID
    WHERE od.OrderID = Orders.OrderID
);
d table orders

delete  orders
/* 9. Write an SQL query to delete all orders and their associated order details for a specific 
customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID 
as a parameter. */
Declare @customerID numeric (10,0)
	SET @customerID = 1007; 
	delete from OrderDetails where OrderID = (select OrderID from Orders where customerid = @customerid);
	delete from Orders where customerID = @customerID

/* 10. Write an SQL query to insert a new electronic gadget product into the "Products" table, 
including product name, category, price, and any other relevant details.  */
select * from products 
insert into Products (ProductID,ProductName,ProductDescription,Price) values (2011,'Mouse','wireless mouse',499)

/* 11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
"Pending" to "Shipped"). Allow users to input the order ID and the new status. */ 

update Orders set status = 'Shipped' where OrderID=30001

/* 12. Write an SQL query to calculate and update the number of orders placed by each customer 
in the "Customers" table based on the data in the "Orders" table. */	

--Not solved


-- Task 3
/* 1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., 
customer name) for each order. */

select O.OrderID,C.FirstName, C.LastName, C.Email,C.Phone  
from orders O 
inner join customers C On O.CustomerId = C.CustomerID

/*2. Write an SQL query to find the total revenue generated by each electronic gadget product. 
Include the product name and the total revenue.   */

Select  P.ProductName ,P.ProductID  , sum(O.Quantity * P.Price) as [Total revenue] 
from OrderDetails O 
INNER JOIN Products as P
ON O.productID = P.ProductID
Group by  P.ProductID,P.ProductName
Order BY 'Total revenue' desc
	
/*3. Write an SQL query to list all customers who have made at least one purchase. Include their 
names and contact information. */
SELECT Distinct C.CustomerID, FirstName, C.LastName , C.Email, C.Phone 
from  Customers C 
INNER JOIN Orders O
ON C.CustomerID = O.CustomerID

/*4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
total quantity ordered. Include the product name and the total quantity ordered.  */
Select P.ProductName, sum(O.Quantity) as [Total Quntity]
From Products as P 
Join OrderDetails as O ON O.ProductID = P.ProductID
Group by P.ProductName 
Order by sum(O.Quantity) Desc

/*5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding 
categories. */
-- The schema does not have a Category column or a separate Categories table.  
-- To retrieve a list of electronic gadgets along with their categories, we need to modify the schema accordingly.

-- Add a new column for product categories
ALTER TABLE Products ADD ProductCategories VARCHAR(20);
-- Update product categories for electronic gadgets
UPDATE Products SET ProductCategories = 'Electronics Gadgets' WHERE ProductName IN ('Laptop', 'SmartPhone', 'Tablet', 'SmartWatch');
-- Update product categories for computer peripherals
UPDATE Products SET ProductCategories = 'Computer Peripherals' WHERE ProductName IN ('Mouse', 'Keyboard', 'Printer', 'Monitor');

-- Retrieve a list of electronic gadgets along with their corresponding categories
SELECT ProductID, ProductName, ProductCategories 
FROM Products 
WHERE ProductCategories = 'Electronics Gadgets';

/*6. Write an SQL query to calculate the average order value for each customer. Include the 
customer's name and their average order value. */

select O.CustomerID, C.FirstName,C.LastName,Avg(O.TotalAmount) as Avg_order_value 
from Customers C 
join Orders O 
ON C.CustomerID = O.CustomerID 
Group by C.FirstName,C.LastName , O.CustomerID

/*7. Write an SQL query to find the order with the highest total revenue. Include the order ID, 
customer information, and the total revenue.*/

SELECT TOP 1  O.OrderID, C.FirstName,  C.LastName, SUM(OD.Quantity * P.Price) AS [Total Revenue] 
FROM OrderDetails OD
INNER JOIN Products P ON OD.ProductID = P.ProductID
INNER JOIN Orders O ON OD.OrderID = O.OrderID
INNER JOIN Customers C ON C.CustomerID = O.CustomerID
GROUP BY O.OrderID, C.FirstName, C.LastName
ORDER BY [Total Revenue] DESC;


/*8. Write an SQL query to list electronic gadgets and the number of times each product has been 
ordered.*/

select P.ProductName, P.ProductCategories , Count(OD.orderID) as TotalOrders
From Products P   
Inner join OrderDetails OD 
ON P.ProductID = OD.ProductID  
where P.ProductCategories = 'Electronics Gadgets'
Group by P.ProductName , P.ProductCategories 

/*9. Write an SQL query to find customers who have purchased a specific electronic gadget product. 
Allow users to input the product name as a parameter.*/

CREATE PROCEDURE GetCustomersByProduct   
    @ProductName VARCHAR(50)
AS
SELECT C.FirstName, C.LastName, P.ProductName, P.ProductCategories  
FROM Customers C  
JOIN Orders O ON O.CustomerID = C.CustomerID  
JOIN OrderDetails OD ON OD.OrderID = O.OrderID  
INNER JOIN Products P ON OD.ProductID = P.ProductID  
WHERE P.ProductName = @ProductName;

EXEC GetCustomersByProduct 'Headphones';
DROP PROCEDURE GetCustomersByProduct;

/* 10. Write an SQL query to calculate the total revenue generated by all orders placed within a 
specific time period. Allow users to input the start and end dates as parameters. */

CREATE PROCEDURE GetTotalRevenueByDate  
    @StartDate DATE,  
    @EndDate DATE  
AS  
BEGIN  
    SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue  
    FROM Orders O  
    JOIN OrderDetails OD ON O.OrderID = OD.OrderID  
    JOIN Products P ON OD.ProductID = P.ProductID  
    WHERE O.OrderDate BETWEEN @StartDate AND @EndDate;  
END;

EXEC GetTotalRevenueByDate '2025-03-01', '2025-03-10';


/*Task 4. Subquery and its type:*/  

/*1. Write an SQL query to find out which customers have not placed any orders.*/ 
select C.FirstName , C.LastName from Customers C where NOT EXISTS (select 1 from Orders O where C.CustomerID=O.CustomerID)
SELECT C.FirstName , C.LastName FROM Customers C left JOIN Orders O ON C.CustomerID = O.CustomerID where O.OrderID is null

/*2. Write an SQL query to find the total number of products available for sale. */ 
select sum(QuantityInStock) as AvailableProducts from Inventory  

/*3. Write an SQL query to calculate the total revenue generated by TechShop.  */

SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue
FROM OrderDetails OD
JOIN Products P ON OD.ProductID = P.ProductID;

/*4. Write an SQL query to calculate the average quantity ordered for products in a specific category. 
Allow users to input the category name as a parameter.*/ 
SELECT AVG(TotalQuantity) AS AvgQuantityOrdered
FROM (
    SELECT SUM(OD.Quantity) AS TotalQuantity
    FROM OrderDetails OD
    JOIN Products P ON OD.ProductID = P.ProductID
    WHERE P.ProductCategories = 'Electronics Gadgets'
    GROUP BY P.ProductID
) AS SubQuery;
 
/*5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users 
to input the customer ID as a parameter. */

CREATE PROCEDURE GetTotalRevenueByCustomer
    @CustomerID NUMERIC(4,0)
AS
BEGIN
    SELECT C.CustomerID, C.FirstName, C.LastName, 
           SUM(OD.Quantity * P.Price) AS TotalRevenue
    FROM Customers C
    JOIN Orders O ON C.CustomerID = O.CustomerID
    JOIN OrderDetails OD ON O.OrderID = OD.OrderID
    JOIN Products P ON OD.ProductID = P.ProductID
    WHERE C.CustomerID = @CustomerID
    GROUP BY C.CustomerID, C.FirstName, C.LastName;
END;

EXEC GetTotalRevenueByCustomer 1001;


select * from orders
select * from customers
select * from orderdetails
select * from Products


/*6. Write an SQL query to find the customers who have placed the most orders. List their names 
and the number of orders they've placed. */
WITH OrderCounts AS (
    SELECT C.CustomerID, C.FirstName, C.LastName, COUNT(O.OrderID) AS TotalOrders
    FROM Customers C
    JOIN Orders O ON C.CustomerID = O.CustomerID
    GROUP BY C.CustomerID, C.FirstName, C.LastName
)
SELECT OC.CustomerID, OC.FirstName, OC.LastName, OC.TotalOrders
FROM OrderCounts OC
WHERE OC.TotalOrders = (SELECT MAX(TotalOrders) FROM OrderCounts);

/*7. Write an SQL query to find the most popular product category, which is the one with the highest 
total quantity ordered across all orders. */

SELECT C.CustomerID, C.FirstName, C.LastName, COUNT(DISTINCT O.OrderID) AS TotalOrders
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
GROUP BY C.CustomerID, C.FirstName, C.LastName
ORDER BY TotalOrders DESC;



/*8. Write an SQL query to find the customer who has spent the most money (highest total revenue) 
on electronic gadgets. List their name and total spending. */

/*9. Write an SQL query to calculate the average order value (total revenue divided by the number of 
orders) for all customers. */


