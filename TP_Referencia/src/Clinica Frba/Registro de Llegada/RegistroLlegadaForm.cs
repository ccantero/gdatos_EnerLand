using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Ingreso_afiliado;

namespace Clinica_Frba.RegistroLlegada

{
    public partial class RegistroLlegadaForm : Form
    {
        // Menu principal a ocultar
        MenuPrincipal menu;

        // Tabla para almacenar los turnos
        DataTable turnos = new DataTable();

        public RegistroLlegadaForm(MenuPrincipal sender, string prof, string nomProf, string apeProf)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            matricula.Text = prof;
            matricula.ReadOnly = true;
            profesional.Text = apeProf + " " + nomProf;
            profesional.ReadOnly = true;
            cargarTurnos();
        }

        // Método para cargar turnos del profesional
        private void cargarTurnos()
        {
            int fecha = 0;
            int fechaMas1 = 0;
            int minutosMas15 = @Clinica_Frba.Properties.Settings.Default.Fecha.Minute + 15;
            fecha += @Clinica_Frba.Properties.Settings.Default.Fecha.Day;
            fecha += @Clinica_Frba.Properties.Settings.Default.Fecha.Month * 100;
            fecha += @Clinica_Frba.Properties.Settings.Default.Fecha.Year * 10000;
            fechaMas1 = fecha + 1;
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT Cod_Turno, Fecha FROM ORACLE_FANS.Turnos " +
                           "WHERE Matricula = " + matricula.Text + " " +
                           "AND habilitado = 0 " +
                           "AND Fecha >= '" + fecha.ToString() + " " + @Clinica_Frba.Properties.Settings.Default.Fecha.Hour.ToString() + ":" + minutosMas15.ToString() + ":" + @Clinica_Frba.Properties.Settings.Default.Fecha.Second.ToString() + "' " +
                           "AND Fecha < '" + fechaMas1.ToString() + "'";
            turnos = SQL_Methods.EjecutarProcedure(conexion, query);
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = turnos;
            dataGridView1.Visible = true;
            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(boton);
            boton.HeaderText = "Action";
            boton.Text = "Ingresar Afiliado";
            boton.Name = "row_button";
            boton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
        }

        // Método para boton select en la tabla de turnos
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                new IngresoAfiliado(this, turnos.Rows[e.RowIndex][0].ToString());
            }
        }

        // Método para cerrar form
        public void cerrarForm()
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para boton volver
        private void button1_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}
