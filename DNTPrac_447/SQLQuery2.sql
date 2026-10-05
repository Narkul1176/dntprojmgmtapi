select * from sys.tables
exec sp_help Employees

select * from __EFMigrationsHistory
select * from Employees
select * from Department
select * from Customers
select * from Location

delete from Department
truncate table Employees

insert into Customers(CustomerName,CustomerEmail,Address,CreatedBy,CreatedOn, City)
				values('Rahul Pandey','rahul@gmail.com','Delhi','System',GETDATE(),'Pune')
insert into Employees(EmployeeName,Gender,Address,DepartmentId,CreatedBy,CreatedOn)
				values('Pranil Fulker','M','Pune',2,'System',GETDATE())