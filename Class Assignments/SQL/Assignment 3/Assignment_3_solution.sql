use  HandsON

--Class Assignmet 3

select * from dept;
select * from emp;

/* 1. Retrieve a list of MANAGERS. */
select * from emp where job = 'manager'

/* 2. Find out the names and salaries of all employees earning more than 1000 per month.  */

select ename , sal from emp where sal > 1000 

/* 3. Display the names and salaries of all employees except JAMES. */

select ename , sal from emp where ename <> 'james' 

/* 4. Find out the details of employees whose names begin with ‘S’. */
select * from emp where ename like'S%'

/* 5. Find out the names of all employees that have ‘A’ anywhere in their name. */
select ename from emp where ename like '%A%'

/* 6. Find out the names of all employees that have ‘L’ as their third character in 
their name. */
select ename from emp where ename like '__L%'

/* 7. Compute daily salary of JONES. */
select ename , sal/30 from emp where ename = 'jones'

/* 8. Calculate the total monthly salary of all employees. */
select sum(sal) as [Total salary] from emp 

/* 9. Print the average annual salary . */
select avg(sal) * 12 as [Annal salary] from emp

/* 10. Select the name, job, salary, department number of all employees except 
SALESMAN from department number 30. */

select ename,job,sal, deptno from emp where  not job = 'salesman' and  deptno =30


-- some sub querys
select ename , job , sal from emp where job =
										(select job from emp  where ename ='allen') and sal > (select sal from emp where empno = 7654)

/* return department numbers and their minimum salaries, excluding departments where the minimum salary is less than or equal to the minimum salary of department 20.  */
select deptno, min(sal) from emp 
group by DEPTNO
having  min(sal) > (select min(sal) from emp where DEPTNO = 20)

-- return employees whose salary is less than the highest SALESMAN salary.
select ename, sal , job from emp where sal <any (select sal from emp where job = 'salesman') 