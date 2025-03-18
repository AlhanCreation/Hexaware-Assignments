use  HandsON
CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY, 
    DNAME VARCHAR(20), 
    LOC VARCHAR(20) 
);

CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY, 
    ENAME VARCHAR(20) NOT NULL, 
    JOB VARCHAR(20), 
    MGR_ID INT, -- Nullable (some employees don’t have a manager)
    HIREDATE DATE, 
    SAL NUMERIC(8,2), -- Stores salaries with decimals
    COMM NUMERIC(8,2), -- Nullable (Commission can be NULL)
    DEPTNO INT, 
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO), 
    FOREIGN KEY (MGR_ID) REFERENCES EMP(EMPNO) -- Self-referential FK
);

INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES 
(10, 'ACCOUNTING', 'NEW YORK'), 
(20, 'RESEARCH', 'DALLAS'), 
(30, 'SALES', 'CHICAGO'), 
(40, 'OPERATIONS', 'BOSTON');

INSERT INTO EMP (EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO) VALUES 
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

select * from dept
select * from emp


--1. List all employees whose name begins with 'A'.
select * from emp where ename like 'A%' 

--2.  Select all those employees who don't have a manager. 
select * from emp where mgr_id is null 

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select empno,ename,sal from emp where sal between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise. 
select empno, ename, sal as oldSalary , sal*(1.10) as newSalary ,dname from emp 
left join DEPT on dept.DEPTNO = emp.DEPTNO
where dept.DEPTNO=20

--5. Find the number of CLERKS employed. Give it a descriptive heading.
select count(*) as TotalClerks from emp where job='clerk'
--another solution
select job ,count(job) as ClearksEmpNumber from emp group by job having job='clerk'

--6. Find the average salary for each job type and the number of people employed in each job. 
select job,avg(sal) as AvgSalary ,COUNT(job) as NumberOfPeopleEmployed from emp group by job

--7. List the employees with the lowest and highest salary. 
select empno,ename,sal from emp where sal = (select min(sal) from emp) 
Union
select empno,ename,sal from emp where sal = (select max(sal) from emp) 

--10. For each department, list its name and number together with the total salary paid to employees in that department.
SELECT d.deptno, d.dname, SUM(e.sal) AS TotalSalaryPaid
FROM emp e
JOIN dept d ON e.deptno = d.deptno
GROUP BY d.deptno, d.dname;


--15. Find all managers who have more than 2 employees reporting to them
select mgr_id, count(empno) as num_emp from emp group by mgr_id having count(empno)>=2



select deptno , job , sum(sal) as sum from emp 
group by deptno,job
order by DEPTNO;



