using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Usuario;
using System.Windows.Forms;

namespace FrbaHotel
{
   
    class DbManager
    {

        #region Variables de Clase
        public static bool DBConnectStatus = false;
        #endregion

        static public SqlConnection dbConnect()
        {
            SqlConnection dbSession;
            
            dbSession = new SqlConnection(Properties.Settings.Default.connectionString );
            try
            {
                dbSession.Open();
                DBConnectStatus = true;
                return dbSession;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        //Obtiene un set de datos de db.
        static public DbResultSet GetDataTable(string selectCommand)
        {
            try
            {
                // Create a new data adapter based on the specified query.

                SqlConnection dbsession = DbManager.dbConnect();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, dbsession);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DbResultSet rs = new DbResultSet();

                rs.dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(rs.dataTable);
                return rs;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Obtiene un array int de db
        static public DbResultSet dbGetIntArray(string selectCommand)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectCommand;
                cmd.Connection = dbsession;
                SqlDataReader dr = cmd.ExecuteReader();
                DbResultSet rs = new DbResultSet();
                int i=0;
                rs.intArrayValue = new int[1];
                rs.intArrayValue[0] = 0;
                while (dr.Read())
                {
                    if (i!=0)
                        Array.Resize(ref rs.intArrayValue, i + 1);
                    rs.intArrayValue.SetValue(dr.GetInt32(0),i);
                    i++;
                    
                }
 
                dbsession.Close();
                return rs;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Obtiene un int de db
        static public DbResultSet dbGetInt(string selectCommand)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectCommand;
                cmd.Connection = dbsession;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                DbResultSet rs = new DbResultSet();
                rs.intValue = dr.GetInt32(0);
                dbsession.Close();
                return rs;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Obtiene un double de db
        static public DbResultSet dbGetDouble(string selectCommand)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectCommand;
                cmd.Connection = dbsession;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                DbResultSet rs = new DbResultSet();
                rs.doubleValue = dr.GetDouble(0);
                dbsession.Close();
                return rs;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Obtiene un string desde db.
        static public DbResultSet dbGetString(string selectCommand)
        {
            try
            {

                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectCommand;
                cmd.Connection = dbsession;
                SqlDataReader dr = cmd.ExecuteReader();
                
                dr.Read();        
                DbResultSet rs = new DbResultSet();
                if (!dr.IsDBNull(0))
                {
                    rs.strValue = dr.GetString(0);
                }
                dbsession.Close();
                return rs;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Obtiene un string desde db.
        static public DbResultSet dbGetDateTime(string selectCommand)
        {
            try
            {

                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = selectCommand;
                cmd.Connection = dbsession;
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                DbResultSet rs = new DbResultSet();
                if (!dr.IsDBNull(0))
                {
                    rs.dateValue = dr.GetDateTime(0);
                }
                dbsession.Close();
                return rs;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Inserta datos en DB desde una sentencia predefinida.
        static public DbResultSet dbSqlStatementExec(string insertCommand)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = insertCommand;
                cmd.Connection = dbsession;
                cmd.ExecuteNonQuery();
                dbsession.Close();

                DbResultSet rs = new DbResultSet();
                return rs;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DbResultSet rs = new DbResultSet();
                rs.operationState = 1;
                return rs;
            }
        }

        //Inserta un Rol en DB
        static public int Agregar_Rol(string NombreRol, int habilitado)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Agregar_Rol", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NombreRol", NombreRol));
                cmd.Parameters.Add(new SqlParameter("@habilitado", habilitado));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                }
                catch (SqlException)
                {
                    MessageBox.Show("El Rol que usted está intentado crear ya existe");
                    return -1;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }

        //Inserta un Rol en DB
        static public bool Agregar_Funcionalidad(int idRol, int idFuncionalidad)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Agregar_Funcionalidad", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idRol", idRol));
                cmd.Parameters.Add(new SqlParameter("@idFuncionalidad", idFuncionalidad));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                    if (resultado != 0)
                        return false;

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        //Inserta un Huesped en DB
        static public int Agregar_Huesped(Huesped unHuesped)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Agregar_Huesped", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento",unHuesped.Tipo_Documento));
	            cmd.Parameters.Add(new SqlParameter("@Nro_Documento",unHuesped.Nro_Documento));
	            cmd.Parameters.Add(new SqlParameter("@Nombre",unHuesped.Nombre));
	            cmd.Parameters.Add(new SqlParameter("@Apellido",unHuesped.Apellido));
	            cmd.Parameters.Add(new SqlParameter("@Mail",unHuesped.Mail));
	            cmd.Parameters.Add(new SqlParameter("@Telefono",unHuesped.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Calle",unHuesped.Calle));
                cmd.Parameters.Add(new SqlParameter("@Numero",unHuesped.Numero));
                if(unHuesped.Piso == -1)
                    cmd.Parameters.Add(new SqlParameter("@Piso", DBNull.Value));
                else
	                cmd.Parameters.Add(new SqlParameter("@Piso",unHuesped.Piso));

                if (unHuesped.Departamento == '\0')
                    cmd.Parameters.Add(new SqlParameter("@Departamento", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Departamento", unHuesped.Departamento));

	            cmd.Parameters.Add(new SqlParameter("@idLocalidad",unHuesped.idLocalidad));
	            cmd.Parameters.Add(new SqlParameter("@idPais",unHuesped.idPais));
	            cmd.Parameters.Add(new SqlParameter("@Fecha_Nacimiento",unHuesped.Fecha_Nacimiento));
	            cmd.Parameters.Add(new SqlParameter("@Nacionalidad",unHuesped.Nacionalidad));
                if (unHuesped.Habilitado)
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 1));
                else
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", Convert.ToChar("0")));

                
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                    if (resultado < 0)
                        return -1;

                    return resultado;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    return -1;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        
        }

        //Modifica un Huesped en DB
        static public bool Modificar_Huesped(Huesped unHuesped)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Modificar_Huesped", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idHuesped", unHuesped.idHuesped));
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento", unHuesped.Tipo_Documento));
                cmd.Parameters.Add(new SqlParameter("@Nro_Documento", unHuesped.Nro_Documento));
                cmd.Parameters.Add(new SqlParameter("@Nombre", unHuesped.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", unHuesped.Apellido));
                cmd.Parameters.Add(new SqlParameter("@Mail", unHuesped.Mail));
                cmd.Parameters.Add(new SqlParameter("@Telefono", unHuesped.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Calle", unHuesped.Calle));
                cmd.Parameters.Add(new SqlParameter("@Numero", unHuesped.Numero));
                if (unHuesped.Piso == -1)
                    cmd.Parameters.Add(new SqlParameter("@Piso", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Piso", unHuesped.Piso));

                if (unHuesped.Departamento == '\0')
                    cmd.Parameters.Add(new SqlParameter("@Departamento", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Departamento", unHuesped.Departamento));

                cmd.Parameters.Add(new SqlParameter("@idLocalidad", unHuesped.idLocalidad));
                cmd.Parameters.Add(new SqlParameter("@idPais", unHuesped.idPais));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", unHuesped.Fecha_Nacimiento));
                cmd.Parameters.Add(new SqlParameter("@Nacionalidad", unHuesped.Nacionalidad));
                if (unHuesped.Habilitado)
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 1));
                else
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", Convert.ToChar("0")));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                    if (resultado != 0)
                        return false;

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        //Inserta un Usuario en DB
        static public int Agregar_Usuario(Usuario unUsuario)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Agregar_Usuario", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username",unUsuario.username));
	            cmd.Parameters.Add(new SqlParameter("@contraseña",unUsuario.password));
	            cmd.Parameters.Add(new SqlParameter("@Nombre",unUsuario.Nombre));
	            cmd.Parameters.Add(new SqlParameter("@Apellido",unUsuario.Apellido));
	            cmd.Parameters.Add(new SqlParameter("@Tipo_Documento",unUsuario.Tipo_Documento));
	            cmd.Parameters.Add(new SqlParameter("@Nro_Documento",unUsuario.Nro_Documento));
	            cmd.Parameters.Add(new SqlParameter("@Mail",unUsuario.Mail));
	            cmd.Parameters.Add(new SqlParameter("@Telefono",unUsuario.Telefono));
	            cmd.Parameters.Add(new SqlParameter("@Calle",unUsuario.Calle));
	            cmd.Parameters.Add(new SqlParameter("@Numero",unUsuario.Numero));
                
                if (unUsuario.Piso == -1)
                    cmd.Parameters.Add(new SqlParameter("@Piso", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Piso", unUsuario.Piso));

                if (unUsuario.Departamento == '\0')
                    cmd.Parameters.Add(new SqlParameter("@Departamento", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Departamento", unUsuario.Departamento));

                cmd.Parameters.Add(new SqlParameter("@idLocalidad", unUsuario.idLocalidad));
                cmd.Parameters.Add(new SqlParameter("@idPais", unUsuario.idPais));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", unUsuario.Fecha_Nacimiento));
                if (unUsuario.Habilitado)
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 1));
                else
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", Convert.ToChar("0")));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                    if (resultado == -1)
                        return -1;

                    return resultado;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    return -1;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }

        }

        //Modifica un Huesped en DB
        static public bool Modificar_Huesped(Usuario unUsuario)
        {
            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Modificar_Usuario", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idUsuario", unUsuario.idUsuario));
                cmd.Parameters.Add(new SqlParameter("@contraseña", unUsuario.password));
                cmd.Parameters.Add(new SqlParameter("@Nombre", unUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", unUsuario.Apellido));
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento", unUsuario.Tipo_Documento));
                cmd.Parameters.Add(new SqlParameter("@Nro_Documento", unUsuario.Nro_Documento));
                cmd.Parameters.Add(new SqlParameter("@Mail", unUsuario.Mail));
                cmd.Parameters.Add(new SqlParameter("@Telefono", unUsuario.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Calle", unUsuario.Calle));
                cmd.Parameters.Add(new SqlParameter("@Numero", unUsuario.Numero));

                if (unUsuario.Piso == -1)
                    cmd.Parameters.Add(new SqlParameter("@Piso", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Piso", unUsuario.Piso));

                if (unUsuario.Departamento == '\0')
                    cmd.Parameters.Add(new SqlParameter("@Departamento", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@Departamento", unUsuario.Departamento));

                cmd.Parameters.Add(new SqlParameter("@idLocalidad", unUsuario.idLocalidad));
                cmd.Parameters.Add(new SqlParameter("@idPais", unUsuario.idPais));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", unUsuario.Fecha_Nacimiento));
                if (unUsuario.Habilitado)
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 1));
                else
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", Convert.ToChar("0")));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                    if (resultado != 0)
                        return false;

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        //Actualiza el estado de reserva
        static public bool Actualizar_Reserva()
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.ActualizarReservas", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FechaActual", FechaActual));

                try
                {
                    cmd.ExecuteReader();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return false;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        //Verifica si la reserva es correcta para Facturar
        static public bool Check_Reserva(int idReserva, int idHotel)
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;
            Boolean status = false;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.CheckReserva", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReservaId", idReserva));
                cmd.Parameters.Add(new SqlParameter("@HotelId", idHotel));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());

                    switch (resultado)
                    {
                        case 0:
                            {
                                status = true;
                                break;
                            }
                        case -1:
                            {
                                MessageBox.Show("El Numero de Reserva es Incorrecto",
                                                "Reserva Inexistente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -2:
                            { 
                                MessageBox.Show("La reserva seleccionada corresponde a otro hotel",
                                                "Hotel Incorrecto",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -3:
                            {
                                MessageBox.Show("La reserva indicada aun no se ha hecho efectiva.",
                                                "Reserva incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -4:
                            {
                                {
                                    MessageBox.Show("La estadia permanece activa. Favor realizar el Check-Out",
                                                    "Check-Out Pendiente",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Hand);
                                    break;
                                }
                            }
                        case -5:
                            {
                                {
                                    MessageBox.Show("La estadia seleccionada ya ha sido facturada.",
                                                    "Factura Existente",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Hand);
                                    break;
                                }
                            }
                    }
                    
                    return status;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return status;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return status;
            }

        }

        // Crea factura, e items de factura para una determinada estadia
        static public void Facturar_Estadia(int idEstadia, int idPago)
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Facturar", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EstadiaId", idEstadia));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaActual));
                cmd.Parameters.Add(new SqlParameter("@idPago", idPago));

                try
                {
                    cmd.ExecuteNonQuery();
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        
        }

        // Verifica si una estadia es correcta para registrar consumibles
        static public bool Check_Estadia(int idReserva, int idHotel)
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;
            Boolean status = false;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.CheckEstadia", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReservaId", idReserva));
                cmd.Parameters.Add(new SqlParameter("@HotelId", idHotel));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());

                    switch (resultado)
                    {
                        case 0:
                            {
                                status = true;
                                break;
                            }
                        case -1:
                            {
                                MessageBox.Show("El Numero de Reserva es Incorrecto",
                                                "Reserva Inexistente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -2:
                            {
                                MessageBox.Show("La reserva seleccionada corresponde a otro hotel",
                                                "Hotel Incorrecto",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -3:
                            {
                                MessageBox.Show("La reserva indicada aun no se ha hecho efectiva.",
                                                "Reserva incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -4:
                            {
                                MessageBox.Show("No se ha realizado el Check-In para esta Reserva.",
                                                "Estadia incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -5:
                            {
                                {
                                    MessageBox.Show("La estadia ya no se encuentra Activa",
                                                    "Check-Out Realizado",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Hand);
                                    break;
                                }
                            }
                        case -6:
                            {
                                {
                                    MessageBox.Show("La estadia seleccionada ya ha sido facturada.",
                                                    "Factura Existente",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Hand);
                                    break;
                                }
                            }
                    }

                    return status;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return status;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return status;
            }

        }

        // Verifica si una estadia es correcta para proceder con el Check-Out
        static public bool Proceess_CheckOut(int idReserva, int idHotel)
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;
            Boolean status = false;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Process_CheckOut", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReservaId", idReserva));
                cmd.Parameters.Add(new SqlParameter("@HotelId", idHotel));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaActual));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());

                    switch (resultado)
                    {
                        case 0:
                            {
                                status = true;
                                break;
                            }
                        case -1:
                            {
                                MessageBox.Show("El Numero de Reserva es Incorrecto",
                                                "Reserva Inexistente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -2:
                            {
                                MessageBox.Show("La reserva seleccionada corresponde a otro hotel",
                                                "Hotel Incorrecto",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -3:
                            {
                                MessageBox.Show("La reserva indicada aun no se ha hecho efectiva.",
                                                "Reserva incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -4:
                            {
                                MessageBox.Show("No se ha realizado el Check-In para esta Reserva.",
                                                "Estadia incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -5:
                            {
                                MessageBox.Show("La estadia ya no se encuentra Activa",
                                                 "Check-Out Realizado",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Hand);
                                break;
                            }
                        case -6:
                            {
                                MessageBox.Show("La estadia seleccionada no puede ser cancelada un dia anterior a la fecha de Reserva.",
                                                "Fecha de Egreso Incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -7:
                            {
                                MessageBox.Show("La estadia seleccionada no puede ser cancelada en el dia de la fecha.",
                                                "Fecha de Egreso Incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                    }

                    return status;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return status;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return status;
            }
        }

        // Verifica si una reserva es correcta para proceder con el Check-In
        static public int Process_CheckIn(int idReserva, int idHotel, int idUsuario)
        {
            DateTime FechaActual = @FrbaHotel.Properties.Settings.Default.Fecha;
            int idEstadia = -1;

            try
            {
                SqlConnection dbsession = DbManager.dbConnect();
                SqlCommand cmd = new SqlCommand("ENER_LAND.Process_CheckIn", dbsession);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReservaId", idReserva));
                cmd.Parameters.Add(new SqlParameter("@HotelId", idHotel));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaActual));
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", idUsuario));
                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                try
                {
                    cmd.ExecuteNonQuery();
                    int resultado = Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());

                    switch (resultado)
                    {
                        case -1:
                            {
                                MessageBox.Show("El Numero de Reserva es Incorrecto",
                                                "Reserva Inexistente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -2:
                            {
                                MessageBox.Show("La reserva seleccionada corresponde a otro hotel",
                                                "Hotel Incorrecto",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -3:
                            {
                                MessageBox.Show("La reserva indicada ya se encuentra efectiva.",
                                                "Reserva incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -4:
                            {
                                MessageBox.Show("Reserva cancelada.",
                                                "Reserva incorrecta",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -5:
                            {
                                MessageBox.Show("La reserva indicada tiene otro dia de Ingreso",
                                                 "Fecha Incorrecta",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Hand);
                                break;
                            }
                        case -6:
                            {
                                MessageBox.Show("Existe un Check-In para la reserva seleccionada",
                                                "Estadia Existente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -7:
                            {
                                MessageBox.Show("El usuario no existe",
                                                "Usuario Inexistente",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        case -8:
                            {
                                MessageBox.Show("El usuario no se encuentra habilitado",
                                                "Usuario Inhabilitado",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                                break;
                            }
                        default:
                            {
                                idEstadia = resultado;
                                break;
                            }
                    }

                    return idEstadia;
                }
                catch (Exception e)
                {
                    MessageBox.Show("[ERROR] - " + e.ToString());
                    MessageBox.Show("[ERROR] - " + e.Message);
                    return idEstadia;
                    throw;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return idEstadia;
            }
        }
    }
}
