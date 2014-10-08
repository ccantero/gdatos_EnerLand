using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

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

    }
}
