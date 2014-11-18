using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using FrbaHotel.ABM_de_Cliente;

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

        //Obtiene un int de db
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
        static public bool Agregar_Huesped(Huesped unHuesped)
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
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 0));
                
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
                    cmd.Parameters.Add(new SqlParameter("@Habilitado", 0));

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
    
    
    }
}
