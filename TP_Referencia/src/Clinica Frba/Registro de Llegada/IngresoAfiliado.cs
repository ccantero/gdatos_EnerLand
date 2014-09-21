using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.RegistroLlegada;

namespace Clinica_Frba.Ingreso_afiliado
{
    public partial class IngresoAfiliado : Form
    {
        DataTable turno = new DataTable();
        DataTable bonoIngresado = new DataTable();
        string codigo_turno;
        RegistroLlegadaForm menuAnt;

        public IngresoAfiliado(RegistroLlegadaForm sender, string cod)
        {
            InitializeComponent();
            menuAnt = sender;
            this.Visible = true;
            this.CenterToScreen();
            codigo_turno = cod;
        }

        // Método para boton Aceptar
        private void button1_Click(object sender, EventArgs e)
        {
            if (afiliado.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un número de afiliado.");
                afiliado.Select();
                return;
            }
            if (bono.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un número de bono.");
                bono.Select();
                return;
            }
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT * FROM ORACLE_FANS.Turnos " +
                           "WHERE Cod_Afiliado = " + afiliado.Text + " " +
                           "AND Cod_Turno = " + codigo_turno;
            turno = SQL_Methods.EjecutarProcedure(conexion, query);
            if (turno.Rows.Count == 0)
            {
                MessageBox.Show("El afiliado ingresado no tenía el turno ingresado anteriormente. Ingrese nuevamente el número de afiliado o vuelva e ingrese nuevamente el turno.");
                return;
            }
            else
            {
                MessageBox.Show("El afiliado ingresado es correcto.");
                string query2 = "SELECT * FROM ORACLE_FANS.Bono_Consulta " +
                           "WHERE Cod_Afiliado = " + afiliado.Text + " " +
                           "AND Numero = " + bono.Text +
                           "AND Numero_Consulta is null ";
                bonoIngresado = SQL_Methods.EjecutarProcedure(conexion, query2);
                if (bonoIngresado.Rows.Count == 0)
                {
                    MessageBox.Show("El bono ingresado es incorrecto. Ingrese nuevamente el bono.");
                    return;
                }
                else
                {
                    MessageBox.Show("El bono ingresado es correcto.");
                    SqlCommand comando = new SqlCommand("ORACLE_FANS.ActualizarConsulta", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Numero_Bono", SqlDbType.Int).Value = Convert.ToInt32(bono.Text);
                    comando.Parameters.Add("@Cod_Afiliado", SqlDbType.Int).Value = Convert.ToInt32(afiliado.Text);
                    comando.Parameters.Add("@Cod_Turno", SqlDbType.Int).Value = Convert.ToInt32(turno.Rows[0][0].ToString());
                    comando.ExecuteReader();
                    menuAnt.cerrarForm();
                    this.Dispose();
                    return;
                }
            }
        }

        // Método para corroborar bono
        private void corroborarBono()
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT * FROM ORACLE_FANS.Bono_Consulta " +
                           "WHERE Cod_Afiliado = " + afiliado.Text + " " +
                           "AND Numero = " + bono.Text +
                           "AND Numero_Consulta is null ";
            bonoIngresado = SQL_Methods.EjecutarProcedure(conexion, query);
            if (bonoIngresado.Rows.Count == 0)
            {
                MessageBox.Show("El bono ingresado es incorrecto. Ingrese nuevamente el bono.");
                return;
            }
        }

        // Método para boton Cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }
    }
}
