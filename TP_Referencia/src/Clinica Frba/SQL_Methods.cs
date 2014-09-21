using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using Clinica_Frba.Afiliado;

namespace Clinica_Frba
{
    class SQL_Methods // Clase Abstracta. Nunca se instanciará
    {
        #region Variables de Clase
            public static bool DBConnectStatus = false;      
        #endregion

        static public SqlConnection IniciarConnection()
        {
            SqlConnection myConnection;

            myConnection = new SqlConnection(@Clinica_Frba.Properties.Settings.Default.GD2C2013ConnectionString);
            try
            {
                myConnection.Open();
                DBConnectStatus = true;
                return myConnection;
            }
            catch (Exception e)
            {
                DBConnectStatus = false;
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        static public DataTable EjecutarProcedure(SqlConnection myConnection, string myQuery)
        {
            SqlDataAdapter miDataAdapter;
            DataSet miDataSet;
            DataTable unaDataTable = new DataTable();

            miDataAdapter = new SqlDataAdapter(myQuery, myConnection);
            miDataSet = new DataSet();
            miDataAdapter.Fill(miDataSet, "Tabla");
            unaDataTable = miDataSet.Tables["Tabla"];
            miDataSet.Dispose();
            miDataAdapter.Dispose();
            
            return unaDataTable;
        }

        static public int Rol_DarAlta(String Nombre)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.agregar_Un_Rol", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@unRol", Nombre));
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
            return -1;
        }
        
        static public bool Rol_DarBaja(int idRol)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {          
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.dar_BajaRol", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    MessageBox.Show("El Rol ya está dado de baja");
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Rol_AgregarFuncionalidad(int idRol, int idFuncionalidad)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.agregar_Una_Funcionalidad", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_Funcionalidad", idFuncionalidad));
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Rol_Renombrar(int idRol, String NombreRol)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.modificar_NombreRol", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre_Rol", NombreRol));
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Rol Inexistente");
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Rol_EliminarFuncionalidades(int idRol)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.EliminarFuncionalidades", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error Fatal al Eliminar Funcionalidades");
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Rol_Habilitar(int idRol)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.modificarRol_HabilitarRol", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error inesperado");
                    return false;
                    throw;
                }
            }
            return true;
        }
        
        static public int Afiliado_DarAlta(Afiliado.Afiliado  NuevoAfiliado)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.alta_Afiliado", myConnection);

                

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_PlanMedico", NuevoAfiliado.Cod_PlanMedico));
                cmd.Parameters.Add(new SqlParameter("@Nombre", NuevoAfiliado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", NuevoAfiliado.Apellido));
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento", NuevoAfiliado.Tipo_Documento));
                cmd.Parameters.Add(new SqlParameter("@Numero_Documento", NuevoAfiliado.Numero_Documento));
                cmd.Parameters.Add(new SqlParameter("@Direccion", NuevoAfiliado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", NuevoAfiliado.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mail", NuevoAfiliado.Mail));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Nac", NuevoAfiliado.Fecha_Nac));
                cmd.Parameters.Add(new SqlParameter("@Sexo", NuevoAfiliado.Sexo));
                cmd.Parameters.Add(new SqlParameter("@Estado_Civil", NuevoAfiliado.Estado_Civil));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.Message.ToString());
                    return -1;
                    throw;
                }
            }
            return -1;
        }

        static public int Afiliado_DarAltaFamiliar(Afiliado.Afiliado NuevoAfiliado)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Alta_Familiar", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_afiliado", NuevoAfiliado.Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@Cod_PlanMedico", NuevoAfiliado.Cod_PlanMedico));
                cmd.Parameters.Add(new SqlParameter("@Nombre", NuevoAfiliado.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", NuevoAfiliado.Apellido));
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento", NuevoAfiliado.Tipo_Documento));
                cmd.Parameters.Add(new SqlParameter("@Numero_Documento", NuevoAfiliado.Numero_Documento));
                cmd.Parameters.Add(new SqlParameter("@Direccion", NuevoAfiliado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", NuevoAfiliado.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mail", NuevoAfiliado.Mail));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Nac", NuevoAfiliado.Fecha_Nac));
                cmd.Parameters.Add(new SqlParameter("@Sexo", NuevoAfiliado.Sexo));
                cmd.Parameters.Add(new SqlParameter("@Estado_Civil", NuevoAfiliado.Estado_Civil));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.Message.ToString());
                    return -1;
                    throw;
                }
            }
            return -1;
        }

        static public bool Afiliado_DarBaja(int idAfiliado, DateTime Fecha)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.baja_Afiliado", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", idAfiliado));
                cmd.Parameters.Add(new SqlParameter("@Fecha_Baja", Fecha));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.Message.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Afiliado_ModificarDatos(Afiliado.Afiliado NuevoAfiliado)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.modificar_Afiliado", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", NuevoAfiliado.Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@Tipo_Documento", NuevoAfiliado.Tipo_Documento));
                cmd.Parameters.Add(new SqlParameter("@Direccion", NuevoAfiliado.Direccion));
                cmd.Parameters.Add(new SqlParameter("@Telefono", NuevoAfiliado.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Mail", NuevoAfiliado.Mail));
                cmd.Parameters.Add(new SqlParameter("@Sexo", NuevoAfiliado.Sexo));
                cmd.Parameters.Add(new SqlParameter("@Estado_Civil", NuevoAfiliado.Estado_Civil));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.Message.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Afiliado_ModificarPlanMedico(int Cod_Afiliado, int Cod_PlanMedicoAnt, int Cod_PlanMedicoActual, string Motivo)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.insertar_Historico", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@Cod_PlanMedico_Nuevo", Cod_PlanMedicoActual));
                cmd.Parameters.Add(new SqlParameter("@Cod_PlanMedico_Anterior", Cod_PlanMedicoAnt));
                cmd.Parameters.Add(new SqlParameter("@FechaModificacion",@Clinica_Frba.Properties.Settings.Default.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Motivo", Motivo));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public int Profesional_AgregarCartilla(int Matricula, DateTime FechaDesde, DateTime FechaHasta)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.AgregarCartilla", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@FechaDesde", FechaDesde));
                cmd.Parameters.Add(new SqlParameter("@FechaHasta", FechaHasta));

                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                try
                {
                    reader = cmd.ExecuteReader();
                    return Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return -1;
                    throw;
                }
            }
            return -1;
        }

        static public bool Profesional_AgregarAgenda(int Matricula, DateTime Hora, int Dia)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.AgregarAAgenda", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@dia", Dia));
                cmd.Parameters.Add(new SqlParameter("@hora", Hora));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public DataTable Profesional_Listar(int Matricula, string Nombre, string Apellido, string Especialidad, DateTime FechaTurno)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListarMedicos", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                if (Matricula == -1)
                {
                    cmd.Parameters.Add(new SqlParameter("@Matricula", DBNull.Value));

                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                }

                cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));

                if (Especialidad.Equals(""))
                {
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", Especialidad));
                }
                
                
                

                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaTurno));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Profesional_ListarTurnosOcupados(int Matricula, DateTime FechaTurno)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListarTurnosOcupados", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaTurno));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Afiliado_ListarTurnosOcupados(int Cod_Afiliado, DateTime FechaTurno)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListarTurnosOcupadosAfiliado", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaTurno));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Profesional_ListarTurnosDisponibles(int Matricula, DateTime FechaTurno)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListarTurnosDisponibles", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaTurno));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public int Turno_Registrar(int Matricula, int Cod_Especialidad, int Cod_Afiliado, DateTime Fecha)
        {

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Turno_Registrar", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@Cod_Especialidad", Cod_Especialidad));
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));


                SqlParameter ValorDeRetorno = cmd.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;
                try
                {
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(ValorDeRetorno.SqlValue.ToString());
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return -1;
                    throw;
                }
            }
            return -1;
        }

        static public bool Profesional_CancelarTurno(int Matricula, DateTime FechaDesde, DateTime FechaHasta, 
                                                    string TipoCancelacion, string Descripcion)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Profesional_CancelarTurno", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", Matricula));
                cmd.Parameters.Add(new SqlParameter("@FechaDesde", FechaDesde));
                cmd.Parameters.Add(new SqlParameter("@FechaHasta", FechaHasta));
                cmd.Parameters.Add(new SqlParameter("@TipoCancelacion", TipoCancelacion));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@FechaHoy", @Clinica_Frba.Properties.Settings.Default.Fecha));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }



        static public DataTable Afiliado_ListarTurnos(int Cod_Afiliado, DateTime FechaTurno)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Afiliado_ListarTurnos", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Afiliado", Cod_Afiliado));
                cmd.Parameters.Add(new SqlParameter("@FechaTurno", FechaTurno));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }


        static public bool Afiliado_DarBajaTurno(int Cod_Turno, DateTime FechaActual, string TipoCancelacion, string Descripcion)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Afiliado_DarBajaTurno", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_Turno", Cod_Turno));
                cmd.Parameters.Add(new SqlParameter("@Fecha", FechaActual));
                cmd.Parameters.Add(new SqlParameter("@TipoCancelacion", TipoCancelacion.Trim()));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public bool Usuario_Crear(int idRol, string username)
        {
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.Usuario_Crear", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@id_Rol", idRol));
                try
                {
                    reader = cmd.ExecuteReader();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("[SQL_Methods] - " + e.ToString());
                    return false;
                    throw;
                }
            }
            return true;
        }

        static public DataTable Listado_Top5Cancelaciones(int Anio, int mes, int idRol)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListadoDeCancelaciones", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Anio", Anio));
                cmd.Parameters.Add(new SqlParameter("@mes", mes));
                cmd.Parameters.Add(new SqlParameter("@idRol", idRol));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Listado_Top5Bonos(int Anio, int mes)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListadoBonosFarmaciaVencidosPorAfiliadoSemestral", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Anio", Anio));
                cmd.Parameters.Add(new SqlParameter("@mes", mes));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Listado_Top5Especialidades(int Anio, int mes)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListadoDeEspecialidadesConMasBonosVendidos", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Anio", Anio));
                cmd.Parameters.Add(new SqlParameter("@mes", mes));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }

        static public DataTable Listado_Top10Afiliados(int Anio, int mes)
        {
            SqlConnection myConnection;
            DataTable unaDataTable = new DataTable();

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("ORACLE_FANS.ListadoDeBonosCompradosYUsadosPorDistintoAfiliado", myConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Anio", Anio));
                cmd.Parameters.Add(new SqlParameter("@mes", mes));
                reader = cmd.ExecuteReader();
                unaDataTable.Load(reader);
            }
            return unaDataTable;
        }
    
    }
}
