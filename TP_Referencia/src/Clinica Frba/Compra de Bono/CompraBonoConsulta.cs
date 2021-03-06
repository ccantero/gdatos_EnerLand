﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Clinica_Frba.bonoConsulta
{
    public partial class CompraBonoConsulta : Form
    {
        // Formulario anterior a ocultar
        public static MenuPrincipal menu;

        int importeBono;
        DataTable Precio = new DataTable();

        public CompraBonoConsulta(MenuPrincipal sender, int codAfi, int planMed)
        {
            InitializeComponent();
            codigoAfiliado.Text = Convert.ToString(codAfi);
            planMedico.Text = Convert.ToString(planMed);
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string myQuery = "SELECT Precio_Bono_Consulta FROM ORACLE_FANS.Planes_Medicos WHERE Cod_PlanMedico = " + planMedico.Text;
            if (SQL_Methods.DBConnectStatus)
            {
                Precio = SQL_Methods.EjecutarProcedure(conexion, myQuery);
            }
            importeBono = Convert.ToInt32(Precio.Rows[0][0].ToString());
        }

        // Método para botón de cruz
        private void bonoConsulta_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para botón realizar compra
        private void button1_Click(object sender, EventArgs e)
        {
            int importeTotal = 0;
            for (int i = 0; i < Convert.ToInt32(cantidadBonos.Value.ToString()); i++)
            {
                SqlConnection conexion = SQL_Methods.IniciarConnection();
                SqlCommand comando = new SqlCommand("ORACLE_FANS.darAltaBonoConsulta", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Cod_PlanMedico", SqlDbType.Int).Value = Convert.ToInt32(planMedico.Text);
                comando.Parameters.Add("@Cod_Afiliado", SqlDbType.Int).Value = Convert.ToInt32(codigoAfiliado.Text);
                comando.Parameters.Add("@Fecha_Impresion", SqlDbType.DateTime).Value = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
                importeTotal += importeBono;
                comando.ExecuteReader();
                comando.Connection.Close();
            }
            MessageBox.Show("Compra realizada. Importe total: $" + Convert.ToString(importeTotal));
            SqlConnection conexion2 = SQL_Methods.IniciarConnection();
            SqlCommand comando2 = new SqlCommand("ORACLE_FANS.agregar_compra", conexion2);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.Add("@tipo", SqlDbType.Char).Value = 'C';
            comando2.Parameters.Add("@cod_afi", SqlDbType.Int).Value = Convert.ToInt32(codigoAfiliado.Text);
            comando2.Parameters.Add("@cant_bonos", SqlDbType.Int).Value = Convert.ToInt32(cantidadBonos.Value);
            comando2.Parameters.Add("@importe", SqlDbType.Int).Value = importeTotal;
            comando2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
            comando2.ExecuteReader();
            comando2.Connection.Close();
            menu.Visible = true;
            this.Dispose();
        }

        // Método para botón volver
        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}
