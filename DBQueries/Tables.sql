
/*BORRAR TABLAS*/
IF OBJECT_ID (N'Stock_Tienda', N'U') IS NOT NULL
	DROP TABLE Stock_Tienda;
GO
IF OBJECT_ID (N'Cliente_Articulo', N'U') IS NOT NULL
	DROP TABLE Cliente_Articulo;
GO
IF OBJECT_ID (N'Articulos', N'U') IS NOT NULL
	DROP TABLE Articulos;
GO
IF OBJECT_ID (N'Clientes', N'U') IS NOT NULL
	DROP TABLE Clientes;
GO
IF OBJECT_ID (N'Tienda', N'U') IS NOT NULL
	DROP TABLE Tienda;
GO
IF OBJECT_ID (N'Users', N'U') IS NOT NULL
	DROP TABLE Users;
GO
IF OBJECT_ID (N'Settings', N'U') IS NOT NULL
	DROP TABLE Settings;
GO
/*BORRAR FK DE LAS TABLAS*/
IF (OBJECT_ID('dbo.FK_STOCK_TIENDA_FK', 'F') IS NOT NULL)
	ALTER TABLE Stock_Tienda DROP CONSTRAINT FK_STOCK_TIENDA_FK;
GO
IF (OBJECT_ID('dbo.FK_STOCK_ARTICULO_FK', 'F') IS NOT NULL)
	ALTER TABLE Stock_Tienda DROP CONSTRAINT FK_STOCK_ARTICULO_FK;
GO

IF (OBJECT_ID('dbo.FK_CLIENTE_ART_FK', 'F') IS NOT NULL)
	ALTER TABLE Cliente_Articulo DROP CONSTRAINT FK_TIENDAFK;
GO
IF (OBJECT_ID('dbo.FK_ART_CLIENTE_FK', 'F') IS NOT NULL)
	ALTER TABLE Cliente_Articulo DROP CONSTRAINT FK_ARTICULOFK;
GO



/*CREAR  TABLAS*/
CREATE TABLE Clientes(
id_cliente INT IDENTITY PRIMARY KEY,
nombre NVARCHAR(50) NOT NULL,
apellidos NVARCHAR(100) NOT NULL,
direccion NVARCHAR(250)NOT NULL
);

CREATE TABLE Tienda(
id_tienda INT IDENTITY PRIMARY KEY,
sucursal NVARCHAR(100),
direccion NVARCHAR(150),
);

CREATE TABLE Articulos(
id_articulo INT IDENTITY PRIMARY KEY,
codigo NVARCHAR(100),
descripcion NVARCHAR(150),
precio DECIMAL(6,2),
imagen NVARCHAR(MAX),

);

CREATE TABLE Stock_Tienda(
id_stock_tienda INT IDENTITY PRIMARY KEY,
id_articulo_r INT NOT NULL,
id_tienda_r INT NOT NULL,
stock DECIMAL (6,3),
date_create DATETIME DEFAULT GETDATE(),

);

ALTER TABLE Stock_Tienda ADD CONSTRAINT FK_STOCK_TIENDA_FK FOREIGN KEY (id_tienda_r) REFERENCES Tienda(id_tienda);
ALTER TABLE Stock_Tienda ADD CONSTRAINT FK_STOCK_ARTICULO_FK FOREIGN KEY (id_articulo_r) REFERENCES Articulos(id_articulo);
GO

CREATE TABLE Cliente_Articulo(
id_cliente_articulo INT IDENTITY PRIMARY KEY,
id_articulo_r INT NOT NULL,
id_cliente_r INT NOT NULL,
date_create DATETIME DEFAULT GETDATE(),
);

ALTER TABLE Cliente_Articulo ADD CONSTRAINT FK_CLIENTE_ART_FK FOREIGN KEY (id_cliente_r) REFERENCES Clientes(id_cliente);
ALTER TABLE Cliente_Articulo ADD CONSTRAINT FK_ART_CLIENTE_FK FOREIGN KEY (id_articulo_r) REFERENCES Articulos(id_articulo);
go


CREATE TABLE Users
(
	id_user INT NOT NULL PRIMARY KEY IDENTITY,
	fullname NVARCHAR (50) NOT NULL,
	email NVARCHAR (50) NOT NULL UNIQUE,
	status SMALLINT NOT NULL,
	password VARBINARY (100) NOT NULL,
);
INSERT INTO Users
	(fullname, email, status, password )
values('administrador', 'carlosutcv@gmail.com', 1, ENCRYPTBYPASSPHRASE('ZGVwZXBzYVNob3BpZnkyMDIzLg==', '123456'));

CREATE TABLE Settings
(
	id_sett int NOT NULL PRIMARY KEY IDENTITY,
	code NVARCHAR (50) NOT NULL UNIQUE,
	value NVARCHAR (250) NOT NULL,
	description NVARCHAR (50) NOT NULL,

);
select * from settings
INSERT INTO Settings
	(code, value, description )
values
	('keyPassword', 'ZGVwZXBzYVNob3BpZnkyMDIzLg==', 'Clave de encriptación de password');
