-- Proceso de Check Migracion

DROP TABLE ENER_LAND.Maestra
	
INSERT INTO ENER_LAND.Maestra
	SELECT	x1.Nombre Hotel_Ciudad, x2.Calle Hotel_Calle, x2.Numero Hotel_Nro_Calle, x2.Cantidad_Estrellas Hotel_CantEstrella, x2.PorcentajeRecarga Hotel_Recarga_Estrella,
			x3.Numero Habitacion_Numero, x3.Piso Habitacion_Pîso, x3.Ubicacion Habitacion_Frente, 
			x3.idTipo_Habitacion Habitacion_Tipo_Codigo, x4.Descripcion Habitacion_Tipo_Descripcion, x4.Porcentaje Habitacion_Tipo_Porcentual, 
			x6.Descripcion Regimen_Descripcion, x6.Precio Regimen_Precio,
			x8.FechaDesde Reserva_Fecha_Inicio, x8.idReserva Reserva_Codigo, x8.Cantidad_Dias Reserva_Cant_Noches,
			x9.Fecha_Ingreso Estadia_Fecha_Inicio, x9.Cantidad_Dias Estadida_Cant_Noches,
			x11.idConsumible Consumible_Codigo, x11.Descripcion Consumible_Descripcion, x11.Precio Consumible_Precio,
			x12.Cantidad Item_Factura_Cantidad, x12.PrecioUnitario Item_Factura_Monto,
			x13.idFactura Factura_Nro, x13.Fecha Factura_Fecha, x13.Total Factura_Total,
			x15.Nro_Documento Cliente_Pasaporte_Nro, x15.Apellido Cliente_Apellido, x15.Nombre Cliente_Nombre,
			x15.Fecha_Nacimiento Cliente_Fecha_Nac, CASE WHEN x15.Mail IS NULL THEN x15.Mail_Alternativo ELSE x15.Mail END Cliente_Mail,
			x15.Calle Cliente_Dom_Calle, x15.Numero Cliente_Nro_Calle, x15.Piso Cliente_Piso, x15.Departamento Cliente_Depto, x15.Nacionalidad Cliente_Nacionalidad
	INTO ENER_LAND.Maestra
	FROM	ENER_LAND.Localidad x1, ENER_LAND.Hotel x2, ENER_LAND.Habitacion x3, ENER_LAND.Tipo_Habitacion x4,
			ENER_LAND.Regimen_Hotel x5, ENER_LAND.Regimen x6, ENER_LAND.Reserva_Habitacion x7, ENER_LAND.Reserva x8,
			ENER_LAND.Estadias x9, ENER_LAND.Consumible_Reserva x10, ENER_LAND.Consumible x11, ENER_LAND.Item_Factura x12,
			ENER_LAND.Factura x13, ENER_LAND.Huespedes_Alojados x14, ENER_LAND.Huesped x15
	WHERE x1.idLocalidad = x2.idLocalidad
	AND x2.idHotel = x3.idHotel
	AND x3.idTipo_Habitacion = x4.idTipo_Habitacion
	AND x5.idHotel = x2.idHotel
	AND x5.idRegimen = x6.idRegimen
	AND x7.idHotel = x2.idHotel
	AND x7.Habitacion_Numero = x3.Numero
	AND x7.idReserva = x8.idReserva
	AND x5.idRegimen = x8.idRegimen
	AND x9.idReserva = x8.idReserva
	AND x10.idReserva = x8.idReserva
	AND x10.idConsumible = x11.idConsumible
	AND x12.Descripcion = x11.Descripcion
	AND x12.PrecioUnitario = x11.Precio
	AND x13.idReserva = x8.idReserva
	AND x13.idFactura = x12.idFactura
	AND x14.idReserva = x8.idReserva
	AND x14.idHuesped = x8.idHuesped
	AND x14.idHuesped = x15.idHuesped
	UNION ALL
	SELECT	x1.Nombre Hotel_Ciudad, x2.Calle Hotel_Calle, x2.Numero Hotel_Nro_Calle, x2.Cantidad_Estrellas Hotel_CantEstrella, x2.PorcentajeRecarga Hotel,
			x3.Numero Habitacion_Numero, x3.Piso Habitacion_Piso, x3.Ubicacion Habitacion_Frente,
			x4.idTipo_Habitacion Habitacion_Tipo_Codigo, x4.Descripcion Habitacion_Tipo_Descripcion, x4.Porcentaje Habitacion_Tipo_Porcentual,
			x6.Descripcion Regimen_Descripcion, x6.Precio Regimen_Precio,
			x8.FechaDesde Reserva_Fecha_Inicio, x8.idReserva Reserva_Codigo, x8.Cantidad_Dias Reserva_Cant_Noches,
			NULL Estadia_Fecha_Inicio, NULL Estadia_Cant_Noches, 
			NULL Consumible_Codigo, NULL Consumible_Descripcion, NULL Consumible_Precio,
			NULL Item_Factura_Cantidad, NULL Item_Factura_Monto,
			NULL Factura_Nro, NULL Factura_Fecha, NULL Factura_Total,
			x9.Nro_Documento Cliente_Pasaporte_Nro, x9.Apellido Cliente_Apellido, x9.Nombre Cliente_Nombre, x9.Fecha_Nacimiento Cliente_Fecha_Nac,
			CASE WHEN x9.Mail IS NULL THEN x9.Mail_Alternativo ELSE x9.Mail END Cliente_Mail,
			x9.Calle Cliente_Dom_Calle, x9.Numero Cliente_Nro_Calle, x9.Piso Cliente_Piso, x9.Departamento Cliente_Depto, x9.Nacionalidad Cliente_Nacionalidad
	FROM	ENER_LAND.Localidad x1, ENER_LAND.Hotel x2, ENER_LAND.Habitacion x3, ENER_LAND.Tipo_Habitacion x4, ENER_LAND.Regimen_Hotel x5, ENER_LAND.Regimen x6,
			ENER_LAND.Reserva_Habitacion x7, ENER_LAND.Reserva x8, ENER_LAND.Huesped x9
	WHERE x1.idLocalidad = x2.idLocalidad
	AND x2.idHotel = x3.IdHotel
	AND x4.idTipo_Habitacion = x3.idTipo_Habitacion
	AND x5.idHotel = x2.idHotel
	AND x5.idRegimen = x6.idRegimen
	AND x7.Habitacion_Numero = x3.Numero
	AND x7.IdHotel = x2.idHotel
	AND x7.idReserva = x8.idReserva
	AND x8.idRegimen = x6.idRegimen
	AND x8.idHuesped = x9.idHuesped
	UNION ALL
	SELECT	x1.Nombre Hotel_Ciudad, x2.Calle Hotel_Calle, x2.Numero Hotel_Nro_Calle, x2.Cantidad_Estrellas Hotel_CantEstrella, x2.PorcentajeRecarga Hotel,
			x3.Numero Habitacion_Numero, x3.Piso Habitacion_Piso, x3.Ubicacion Habitacion_Frente,
			x4.idTipo_Habitacion Habitacion_Tipo_Codigo, x4.Descripcion Habitacion_Tipo_Descripcion, x4.Porcentaje Habitacion_Tipo_Porcentual,
			x6.Descripcion Regimen_Descripcion, x6.Precio Regimen_Precio,
			x8.FechaDesde Reserva_Fecha_Inicio, x8.idReserva Reserva_Codigo, x8.Cantidad_Dias Reserva_Cant_Noches,
			NULL Estadia_Fecha_Inicio, NULL Estadia_Cant_Noches, 
			NULL Consumible_Codigo, NULL Consumible_Descripcion, NULL Consumible_Precio,
			1 Item_Factura_Cantidad, 
			x6.Precio * x4.Porcentaje + x2.PorcentajeRecarga * x2.Cantidad_Estrellas Item_Factura_Monto,
			x9.idFactura Factura_Nro, x9.Fecha Factura_Fecha, x9.Total Factura_Total,
			x10.Nro_Documento Cliente_Pasaporte_Nro, x10.Apellido Cliente_Apellido, x10.Nombre Cliente_Nombre, x10.Fecha_Nacimiento Cliente_Fecha_Nac,
			CASE WHEN x10.Mail IS NULL THEN x10.Mail_Alternativo ELSE x10.Mail END Cliente_Mail,
			x10.Calle Cliente_Dom_Calle, x10.Numero Cliente_Nro_Calle, x10.Piso Cliente_Piso, x10.Departamento Cliente_Depto, x10.Nacionalidad Cliente_Nacionalidad
	FROM	ENER_LAND.Localidad x1, ENER_LAND.Hotel x2, ENER_LAND.Habitacion x3, ENER_LAND.Tipo_Habitacion x4, ENER_LAND.Regimen_Hotel x5, ENER_LAND.Regimen x6,
			ENER_LAND.Reserva_Habitacion x7, ENER_LAND.Reserva x8, ENER_LAND.Factura x9, ENER_LAND.Huesped x10
	WHERE x1.idLocalidad = x2.idLocalidad
	AND x2.idHotel = x3.IdHotel
	AND x4.idTipo_Habitacion = x3.idTipo_Habitacion
	AND x5.idHotel = x2.idHotel
	AND x5.idRegimen = x6.idRegimen
	AND x7.Habitacion_Numero = x3.Numero
	AND x7.IdHotel = x2.idHotel
	AND x7.idReserva = x8.idReserva
	AND x8.idRegimen = x6.idRegimen
	AND x9.idReserva = x8.idReserva
	AND x8.idHuesped = x10.idHuesped
	UNION ALL
	SELECT	x1.Nombre Hotel_Ciudad, x2.Calle Hotel_Calle, x2.Numero Hotel_Nro_Calle, x2.Cantidad_Estrellas Hotel_CantEstrella, x2.PorcentajeRecarga Hotel,
			x3.Numero Habitacion_Numero, x3.Piso Habitacion_Piso, x3.Ubicacion Habitacion_Frente,
			x4.idTipo_Habitacion Habitacion_Tipo_Codigo, x4.Descripcion Habitacion_Tipo_Descripcion, x4.Porcentaje Habitacion_Tipo_Porcentual,
			x6.Descripcion Regimen_Descripcion, x6.Precio Regimen_Precio,
			x8.FechaDesde Reserva_Fecha_Inicio, x8.idReserva Reserva_Codigo, x8.Cantidad_Dias Reserva_Cant_Noches,
			x9.Fecha_Ingreso Estadia_Fecha_Inicio, x9.Cantidad_Dias Estadia_Cant_Noches, 
			NULL Consumible_Codigo, NULL Consumible_Descripcion, NULL Consumible_Precio,
			NULL Item_Factura_Cantidad, NULL Item_Factura_Monto,
			NULL Factura_Nro, NULL Factura_Fecha, NULL Factura_Total,
			x10.Nro_Documento Cliente_Pasaporte_Nro, x10.Apellido Cliente_Apellido, x10.Nombre Cliente_Nombre, x10.Fecha_Nacimiento Cliente_Fecha_Nac,
			CASE WHEN x10.Mail IS NULL THEN x10.Mail_Alternativo ELSE x10.Mail END Cliente_Mail,
			x10.Calle Cliente_Dom_Calle, x10.Numero Cliente_Nro_Calle, x10.Piso Cliente_Piso, x10.Departamento Cliente_Depto, x10.Nacionalidad Cliente_Nacionalidad
	FROM	ENER_LAND.Localidad x1, ENER_LAND.Hotel x2, ENER_LAND.Habitacion x3, ENER_LAND.Tipo_Habitacion x4, ENER_LAND.Regimen_Hotel x5, ENER_LAND.Regimen x6,
			ENER_LAND.Reserva_Habitacion x7, ENER_LAND.Reserva x8, ENER_LAND.Estadias x9, ENER_LAND.Huesped x10
	WHERE x1.idLocalidad = x2.idLocalidad
	AND x2.idHotel = x3.IdHotel
	AND x4.idTipo_Habitacion = x3.idTipo_Habitacion
	AND x5.idHotel = x2.idHotel
	AND x5.idRegimen = x6.idRegimen
	AND x7.Habitacion_Numero = x3.Numero
	AND x7.IdHotel = x2.idHotel
	AND x7.idReserva = x8.idReserva
	AND x8.idRegimen = x6.idRegimen
	AND x9.idReserva = x8.idReserva
	AND x8.idHuesped = x10.idHuesped
	
SELECT COUNT(*) FROM gd_esquema.Maestra --
UNION ALL
SELECT COUNT(*) FROM ENER_LAND.Maestra
