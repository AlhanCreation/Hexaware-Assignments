create database It_firm
use It_firm

CREATE TABLE Clients (
    Client_ID numeric (4,0)  PRIMARY KEY,
    Cname varchar(40) NOT NULL,
    Address varchar(30),
    Email varchar(30) UNIQUE,
    Phone numeric(10),
    Business varchar(20) NOT NULL
);

create table Departments (
	Deptno numeric(2) PRIMARY KEY,
    Dname VARCHAR(15) NOT NULL,
    Loc VARCHAR(20)
)

create table Employees (
EmpNo numeric (4) primary key,
Ename varchar(20) not null,
job	  varchar (15),
Salary numeric(7) check (Salary>0),
Deptno numeric (2) , 
foreign key (Deptno) references Departments(Deptno)
)


CREATE TABLE Projects (
    Project_ID numeric(3) PRIMARY KEY,
    Descr VARCHAR(30) NOT NULL,
    Start_Date DATE,
    Planned_End_Date DATE,
    Actual_End_date DATE,
    Budget numeric(10) CHECK (Budget > 0),
    Client_ID numeric(4),
    FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
    CHECK (Actual_End_date > Planned_End_Date)
);

CREATE TABLE EmpProjectTasks (
    Project_ID numeric(3),
    Empno numeric(4),
    Start_Date DATE,
    End_Date DATE,
    Task varchar(25) NOT NULL,
    Status varchar(15) NOT NULL,
    PRIMARY KEY (Project_ID, Empno),
    FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
    FOREIGN KEY (Empno) REFERENCES Employees(Empno)
);

INSERT INTO Clients (Client_ID, Cname, Address, Email, Phone, Business)
VALUES (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing'),
       (1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
	   (1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller'),
       (1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional');

INSERT INTO Departments (Deptno, Dname, Loc)
VALUES (10, 'Design', 'Pune'),
		 (20, 'Development', 'Pune'),
			 (30, 'Testing', 'Mumbai'),
				(40, 'Document', 'Mumbai');


INSERT INTO Employees (Empno, Ename, Job, Salary, Deptno)
VALUES (7001, 'Sandeep', 'Analyst', 25000, 10),
		(7002, 'Rajesh', 'Designer', 30000, 10),
		 (7003, 'Madhav', 'Developer', 40000, 20),
		  (7004, 'Manoj', 'Developer', 40000, 20),
           (7005, 'Abhay', 'Designer', 35000, 10),
            (7006, 'Uma', 'Tester', 30000, 30),
			 (7007, 'Gita', 'Tech. Writer', 30000, 40),
			  (7008, 'Priya', 'Tester', 35000, 30),
			   (7009, 'Nutan', 'Developer', 45000, 20),
				(7010, 'Smita', 'Analyst', 20000, 10),
				 (7011, 'Anand', 'Project Mgr', 65000, 10);

-- Insert data into Projects table
INSERT INTO Projects (Project_ID, Descr, Start_Date, Planned_End_Date, Actual_End_date, Budget, Client_ID)
VALUES (401, 'Inventory', '01-Apr-11', '01-Oct-11', '31-Oct-11', 150000, 1001),
		 (402, 'Accounting', '01-Aug-11', '01-Jan-12', NULL, 500000, 1002),
		 (403, 'Payroll', '01-Oct-11', '31-Dec-11', NULL, 75000, 1003),
		 (404, 'Contact Mgmt', '01-Nov-11', '31-Dec-11', NULL, 50000, 1004);

-- Insert data into EmpProjectTasks table
INSERT INTO EmpProjectTasks (Project_ID, Empno, Start_Date, End_Date, Task, Status) VALUES 
(401, 7001, '01-Apr-11', '20-Apr-11', 'System Analysis', 'Completed'),
(401, 7002, '21-Apr-11', '30-May-11', 'System Design', 'Completed'),
(401, 7003, '01-Jun-11', '15-Jul-11', 'Coding', 'Completed'),
(401, 7004, '18-Jul-11', '01-Sep-11', 'Coding', 'Completed'),
(401, 7006, '03-Sep-11', '15-Sep-11', 'Testing', 'Completed'),
(401, 7009, '18-Sep-11', '05-Oct-11', 'Code Change', 'Completed'),
(401, 7008, '06-Oct-11', '16-Oct-11', 'Testing', 'Completed'),
(401, 7007, '06-Oct-11', '22-Oct-11', 'Documentation', 'Completed'),
(401, 7011, '22-Oct-11', '31-Oct-11', 'Sign off', 'Completed'),
(402, 7010, '01-Aug-11', '20-Aug-11', 'System Analysis', 'Completed'),
(402, 7002, '22-Aug-11', '30-Sep-11', 'System Design', 'Completed'),
(402, 7004, '01-Oct-11', NULL, 'Coding', 'In Progress');

SELECT * FROM Clients;
SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;
SELECT * FROM EmpProjectTasks;
