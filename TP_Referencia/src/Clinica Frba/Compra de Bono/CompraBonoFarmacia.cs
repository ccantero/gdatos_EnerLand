using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Clinica_Frba.bonoFarmacia
{
    public partial class CompraBonoFarmacia : Form
    {
        // Formulario a ocultar
        public static MenuPrincipal menu;

        int importeBono;
        DataTable Precio = new DataTable();
        public CompraBonoFarmacia(MenuPrincipal sender, int codAfi, int planMed)
        {
            InitializeComponent();
            codigoAfiliado.Text = Convert.ToString(codAfi);
            planMedico.Text = Convert.ToString(planMed);
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string myQuery = "SELECT Precio_Bono_Farmacia FROM ORACLE_FANS.Planes_Medicos WHERE Cod_PlanMedico = " + planMedico.Text;
            if (SQL_Methods.DBConnectStatus)
            {
                Precio = SQL_Methods.EjecutarProcedure(conexion, myQuery);
            }
            importeBono = Convert.ToInt32(Precio.Rows[0][0].ToString());
        }

        // Método para botón de cruz
        private void bonoFarmacia_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para botón realizar compra
        private void button1_Click(object sender, EventArgs e)
        {
            int importeTotal = 0;

            for (int i = 0; i < Convert.ToInt32(cantBonos.Value); i++)
            {
                SqlConnection conexion = SQL_Methods.IniciarConnection();
                SqlCommand comando = new SqlCommand("ORACLE_FANS.darAltaBonoFarmacia", conexion);

                SqlParameter ValorDeRetorno = comando.Parameters.Add("returnParameter", SqlDbType.Int);
                ValorDeRetorno.Direction = ParameterDirection.ReturnValue;

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Cod_PlanMedico", SqlDbType.Int).Value = Convert.ToInt32(planMedico.Text);
                comando.Parameters.Add("@Cod_Afiliado", SqlDbType.Int).Value = Convert.ToInt32(codigoAfiliado.Text);
                comando.Parameters.Add("@fec_imp", SqlDbType.DateTime).Value = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
                importeTotal += importeBono;
                comando.ExecuteReader();
                comando.Connection.Close();
            }
            MessageBox.Show("Compra realizada. Importe total: $" + Convert.ToString(importeTotal));
            SqlConnection conexion2 = SQL_Methods.IniciarConnection();
            SqlCommand comando2 = new SqlCommand("ORACLE_FANS.agregar_compra", conexion2);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add("@tipo", SqlDbType.Char).Value = 'F';
            comando2.Parameters.Add("@cod_afi", SqlDbType.Int).Value = Convert.ToInt32(codigoAfiliado.Text);
            comando2.Parameters.Add("@cant_bonos", SqlDbType.Int).Value = Convert.ToInt32(cantBonos.Value);
            comando2.Parameters.Add("@importe", SqlDbType.Int).Value = importeTotal;
            comando2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
            comando2.ExecuteReader();
            comando2.Connection.Close();
        }

        // Método para botón volver
        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    
        public void CloseForm()
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}
