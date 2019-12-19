--views
CREATE VIEW Jugadas_Por_Tiempo
AS SELECT Clientes.Nombre,Clientes.Apellido,Jugadas.monto,Jugadas.Fecha_Jugada
FROM Clientes
 inner join Jugadas on Jugadas.Cliente = Clientes.idC

CREATE VIEW Todo_de_Clientes
AS SELECT * FROM Clientes


CREATE VIEW Todo_Jugadas
AS SELECT * FROM Jugadas

CREATE VIEW Todo_Loteria
AS SELECT * FROM Loteria

-----PROCEDURES
CREATE PROC Jugadas_Por_Dia
@fecha date
AS 
	BEGIN
		SELECT * FROM Jugadas WHERE Fecha_Jugada = @fecha
	END


CREATE PROC Cliente_Especifico
@nombre nvarchar(50),
@apellido nvarchar(50),
@cedula nvarchar(13)
AS
BEGIN
	SELECT * FROM Clientes WHERE Nombre = @nombre and Apellido = @apellido and Cedula = @cedula
END



-----INSERT



CREATE PROC Insertar_Cliente
@nombre nvarchar(50),
@apellido nvarchar(50),
@cedula nvarchar(13),
@direccion ntext
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Clientes WHERE Cedula = @cedula)
		begin
			INSERT INTO Clientes(Nombre,Apellido,Cedula,Direccion) VALUES(@nombre,@apellido,@cedula,@direccion)
		end
	ELSE
		begin
			PRINT 'Cliente no valido';
		end
END

CREATE PROC Insertar_Loteria
@nombre varchar(15),
@horario time
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Loteria WHERE Nombre_Loteria = @nombre)
		begin
			INSERT INTO Loteria (Nombre_Loteria,horario) VALUES(@nombre,@horario)
		end
	ELSE 
		begin
			PRINT'Loteria no aceptada';
		end
END


-----UPDATES
CREATE  PROC Mod_Clientes
@nombre nvarchar(50),
@apellido nvarchar(50),
@cedula nvarchar(13),
@direccion ntext
AS 
BEGIN
	IF exists(SELECT * FROM Clientes WHERE Cedula = @cedula)
		begin
			UPDATE Clientes 
			SET Nombre = @nombre,Apellido = @apellido,Direccion = @direccion
			WHERE Cedula = @cedula
		end
	ELSE 
		begin
			PRINT'Cliente no existente para modificar'
		end
END

CREATE PROC Mod_Loteria
@id int,
@nombre varchar(15),
@horario time
AS
BEGIN
	UPDATE Loteria 
	SET Nombre_Loteria = @nombre,horario = @horario
	WHERE id = @id
END



