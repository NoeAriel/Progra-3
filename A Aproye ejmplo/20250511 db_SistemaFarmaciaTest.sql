CREATE DATABASE db_farmaciaPrograTest;
GO

USE db_farmaciaPrograTest;
GO

CREATE TABLE tbl_usuarios (
    CodigoEmpleado INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Email VARCHAR(100),
    Rol VARCHAR(45),
    Usuario VARCHAR(50),
    Contrasena VARCHAR(255),
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45)
);
GO

CREATE TABLE tbl_proveedores (
    CodigoProveedor INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100),
    Nit VARCHAR(20),
    Telefono INT,
    Email VARCHAR(100),
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45)
);
GO

CREATE TABLE tbl_categorias (
    CodigoCategoria INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100),
    Descripcion VARCHAR(255),
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45)
);
GO

CREATE TABLE tbl_medicamentos (
    CodigoMedicamento INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(255),
    UnidadMedida VARCHAR(20),
    Precio DECIMAL(10, 2),
    Stock DECIMAL(15, 2),
    FechaVencimiento DATETIME,
    CodigoCategoria INT,
    CodigoProveedor INT,
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45),
    FOREIGN KEY (CodigoCategoria) REFERENCES tbl_categorias(CodigoCategoria),
    FOREIGN KEY (CodigoProveedor) REFERENCES tbl_proveedores(CodigoProveedor)
);
Go

CREATE TABLE tbl_clientes (
    CodigoCliente INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100),
    Nit VARCHAR(20),
    Telefono INT,
    Direccion VARCHAR(100),
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45)
);
GO

CREATE TABLE tbl_ventas (
    CodigoVenta INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    FechaVenta DATETIME,
    CodigoCliente INT,
    TipoPago VARCHAR(50),
    Vendedor VARCHAR(45),
    Estado VARCHAR(15),
    FechaAuditoria DATETIME,
    UsuarioAuditoria VARCHAR(45),
    FOREIGN KEY (CodigoCliente) REFERENCES tbl_clientes(CodigoCliente)
);
GO

CREATE TABLE tbl_detalle_ventas (
    CodigoDetalleVenta INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CodigoVenta INT,
    CodigoMedicamento INT,
    Cantidad DECIMAL(10, 2),
    PrecioUnitario DECIMAL(10, 2),
    Descuento DECIMAL(10, 2),
    Impuesto DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    FOREIGN KEY (CodigoVenta) REFERENCES tbl_ventas(CodigoVenta),
    FOREIGN KEY (CodigoMedicamento) REFERENCES tbl_medicamentos(CodigoMedicamento)
);
GO