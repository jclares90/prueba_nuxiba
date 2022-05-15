create table usuarios(userid int identity(1,1), Login varchar(100), Nombre varchar(100), Paterno varchar(100), Materno varchar(100), primary key (userid))

create table empleados(id int identity(1,1), userid int, Sueldo money, FechaIngreso date, primary key (id), foreign key(userid) references usuarios(userid))

delete from usuarios where userid not in (6,7,9,10)

update e
set sueldo = sueldo + (sueldo * .1)
from empleados e
where year(FechaIngreso) between 2000 and 2001

select * from usuarios a
inner join empleados b
	on a.userid=b.userid
where b.Sueldo > 10000 and a.Paterno like 'T%'
order by b.FechaIngreso desc

select '<1200' grupo, count(1)  from usuarios a
inner join empleados b
	on a.userid=b.userid
where Sueldo < 1200
union
select '>=1200' grupo, count(1)  from usuarios a
inner join empleados b
	on a.userid=b.userid
where Sueldo >= 1200