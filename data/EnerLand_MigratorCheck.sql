-- Proceso de Check Migracion

BEGIN
	
	-- Check de Hotel_Ciudad
	IF EXISTS (	
				SELECT 1
				FROM gd_esquema.Maestra
				WHERE NOT EXISTS ( SELECT 1 FROM ENER_LAND.Localidad WHERE Nombre = Hotel_Ciudad )
			  )
		RAISERROR('Existen Ciudades no migradas',16,1);
	
	-- Check de Hotel_Calle
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS ( SELECT 1 FROM ENER_LAND.Hotel WHERE Calle = Hotel_Calle )
				)
		RAISERROR('Existen Calles de Hoteles no migradas',16,1);
	
	-- Check de Hotel_Nro_Calle
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS ( SELECT 1 FROM ENER_LAND.Hotel WHERE Numero = Hotel_Nro_Calle )
				)
		RAISERROR('Existen Numeros de Calles de Hoteles no migradas',16,1);
	
	-- Check de Hotel_Calle + Hotel_Nro_Calle
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS ( SELECT 1 FROM ENER_LAND.Hotel WHERE Calle = Hotel_Calle AND Numero = Hotel_Nro_Calle )
				)
		RAISERROR('Existen Hoteles no migrados',16,1);
	
	-- Check de Hotel_Ciudad + Hotel_Calle + Hotel_Nro_Calle
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS	(	
											SELECT 1 FROM ENER_LAND.Hotel h, ENER_LAND.Localidad l
											WHERE Calle = Hotel_Calle 
											AND Numero = Hotel_Nro_Calle 
											AND h.idLocalidad = l.idLocalidad
											AND l.Nombre = Hotel_Ciudad
										)
				)
		RAISERROR('Existen Hoteles no migrados',16,1);
	
	-- Check de Hotel_Ciudad + Hotel_Calle + Hotel_Nro_Calle + Hotel_CantEstrella
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS	(	
											SELECT 1 FROM ENER_LAND.Hotel h, ENER_LAND.Localidad l
											WHERE Calle = Hotel_Calle 
											AND Numero = Hotel_Nro_Calle 
											AND h.idLocalidad = l.idLocalidad
											AND l.Nombre = Hotel_Ciudad
											AND h.Cantidad_Estrellas = Hotel_CantEstrella
										)
				)
		RAISERROR('Existen Hoteles no migrados',16,1);
	
	-- Check de Hotel_Ciudad + Hotel_Calle + Hotel_Nro_Calle + Hotel_CantEstrella + Hotel_Recarga_Estrella
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS	(	
											SELECT 1 FROM ENER_LAND.Hotel h, ENER_LAND.Localidad l
											WHERE Calle = Hotel_Calle 
											AND Numero = Hotel_Nro_Calle 
											AND h.idLocalidad = l.idLocalidad
											AND l.Nombre = Hotel_Ciudad
											AND h.Cantidad_Estrellas = Hotel_CantEstrella
											AND h.PorcentajeRecarga = Hotel_Recarga_Estrella
										)
				)
		RAISERROR('Existen Hoteles no migrados',16,1);
		
	-- Check de Hotel_Ciudad
	-- Hotel_Calle
	-- Hotel_Nro_Calle
	-- Hotel_CantEstrella
	-- Hotel_Recarga_Estrella
	-- Check de Habitacion_Numero
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS	(	
											SELECT 1 
											FROM ENER_LAND.Hotel h, ENER_LAND.Localidad l, ENER_LAND.Habitacion Hab
											WHERE Calle = Hotel_Calle 
											AND h.Numero = Hotel_Nro_Calle 
											AND h.idLocalidad = l.idLocalidad
											AND l.Nombre = Hotel_Ciudad
											AND h.Cantidad_Estrellas = Hotel_CantEstrella
											AND h.PorcentajeRecarga = Hotel_Recarga_Estrella
											AND Hab.Numero = Habitacion_Numero
											AND h.idHotel = Hab.IdHotel
										)
				)
		RAISERROR('Existen Habitaciones no migradas',16,1);
	
	-- Check de Hotel_Ciudad
	-- Hotel_Calle
	-- Hotel_Nro_Calle
	-- Hotel_CantEstrella
	-- Hotel_Recarga_Estrella
	-- Habitacion_Numero
	-- Habitacion_Frente
	
	IF EXISTS	(
					SELECT 1
					FROM gd_esquema.Maestra
					WHERE NOT EXISTS	(	
											SELECT 1 
											FROM ENER_LAND.Hotel h, ENER_LAND.Localidad l, ENER_LAND.Habitacion Hab
											WHERE Calle = Hotel_Calle 
											AND h.Numero = Hotel_Nro_Calle 
											AND h.idLocalidad = l.idLocalidad
											AND l.Nombre = Hotel_Ciudad
											AND h.Cantidad_Estrellas = Hotel_CantEstrella
											AND h.PorcentajeRecarga = Hotel_Recarga_Estrella
											AND Hab.Numero = Habitacion_Numero
											AND Hab.Ubicacion = Habitacion_Frente
											AND h.idHotel = Hab.IdHotel
										)
				)
		RAISERROR('Existen Habitaciones no migradas',16,1);
	
END;


--SELECT TOP 10 * FROM gd_esquema.Maestra