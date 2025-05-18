
create database db_MenuLogin;
GO

use db_MenuLogin;
GO

-- Creación de Tabla Empleados
create table tbl_Empleados
(
	CodigoEmpleado int primary key not null identity(1,1),
	Nombre varchar (50),
	Cargo varchar (50),
	Salario decimal (10,2),
	FechaContratacion DateTime,
	Estado varchar (20),
	UsuarioSistema varchar (50),
	FechaSistema DateTime
);
GO
-- Tabla Usuarios
create table tbl_Usuarios 
(
	CodigoUsuario int primary key not null identity(1,1),
	CodigoEmpleado int,
	NombreUsuario varchar(50),
	Contrasenia varchar(50),
	Rol varchar(50),
	Estado varchar(20),
	UsuarioSistema varchar(50),
	FechaSistema datetime,
	foreign key (CodigoEmpleado) references tbl_Empleados(CodigoEmpleado)
);
GO

Select * from tbl_Empleados;

Insert into tbl_Empleados (Nombre, Cargo, Salario, FechaContratacion, Estado, UsuarioSistema, FechaSistema)
values 
('Juan Pérez', 'Gerente', 60000.00, GETDATE(), 'Activo', 'admin', GETDATE()),
('María López', 'Enfermera', 80000.00, GETDATE(), 'Activo', 'admin', GETDATE()),
('Carlos García', 'Doctor', 50000.00, GETDATE(), 'Activo', 'admin', GETDATE());


Select * from tbl_Usuarios;

Insert into tbl_Usuarios (CodigoEmpleado, NombreUsuario, Contrasenia, Rol, Estado, UsuarioSistema, FechaSistema)
VALUES 
(1, 'juanp', '123', 'Gerente', 'Activo', 'admin', GETDATE()),
(2, 'marial', 'guate333', 'Asistente', 'Activo', 'admin', GETDATE()),
(3, 'carlosg', 'umg321', 'Doctor', 'Activo', 'admin', GETDATE());


