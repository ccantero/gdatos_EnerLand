using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Profesional;
using Clinica_Frba.addModProfesional;
using Clinica_Frba.Cancelar_Atencion_Profesional;

namespace Clinica_Frba.buscarProfesionalForm
{
    public partial class BuscarProfesional : Form
    {
        // Form anterior a ocultar
        public static ProfesionalABM menu;
        public static MenuPrincipal menuPpal;

        // Tabla para la consulta de afiliados
        public static DataTable TablaProfesionales = new DataTable();

        // Tabla para cargar especialidades
        public static DataTable TablaEspecialidades = new DataTable();

        // Variable para saber si se está eliminando o modificando
        public static bool eliminar = false;

        int flagMenuPpal = 0;

        // Constructor para Cancelacion de Atencion
        public BuscarProfesional(MenuPrincipal sender, int flag)
        {
            InitializeComponent();
            menuPpal = sender;
            this.Visible = true;
            this.Text = "Buscar Profesional";
            cargarComboBox();
            flagMenuPpal = flag;
        }

        public BuscarProfesional(ProfesionalABM sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.Text = "Modificar Profesional";
            eliminar = false;
            cargarComboBox();
        }

        public BuscarProfesional(ProfesionalABM sender, bool flag)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.Text = "Eliminar Profesional";
            eliminar = true;
            cargarComboBox();
        }

        // Método para botón de cruz
        private void buscarAfiliado_FormClosing(object sender, EventArgs e)
        {
            if (flagMenuPpal == 1)
            {
                menuPpal.Visible = true;
                this.Dispose();
            }
            else
            {
                menu.Visible = true;
                this.Dispose();
            }
        }

        // Método para botón limpiar
        private void button_clean_Click(object sender, EventArgs e)
        {
            //this.box_afiliado.Text = "";
            this.box_apellido.Text = "";
            this.comboBox1.Text = "";
            this.box_nombre.Text = "";
            this.box_matricula.Text = "";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
        }

        // Método para cargar profesionales en la tabla
        private void cargarProfesionales()
        {
            // Conexion al server
            SqlConnection myConnection = SQL_Methods.IniciarConnection();
            string myQuery;

            if (this.comboBox1.Text.Trim().Equals(""))
            {
                myQuery = "SELECT Matricula, Nombre, Apellido, Tipo_Documento, Numero_Documento, Direccion, Mail, Telefono, Fecha_Nac, Sexo FROM ORACLE_FANS.Profesionales " +
                          "WHERE Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                          "AND Activo = 1 " +
                          "AND Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                          "AND Matricula LIKE '%" + this.box_matricula.Text.Trim() + "%'";
            }
            else
            {
                myQuery = "SELECT P.Matricula, P.Nombre, P.Apellido, P.Tipo_Documento, P.Numero_Documento, P.Direccion, P.Mail, P.Telefono, P.Fecha_Nac, P.Sexo FROM ORACLE_FANS.Profesionales P " +
                          "JOIN ORACLE_FANS.Medico_Especialidad ME on P.Matricula = ME.Matricula " +
                          "JOIN ORACLE_FANS.Especialidades E on E.Cod_Especialidad = ME.Cod_Especialidad " +
                          "WHERE P.Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                          "AND P.Activo = 1 " +
                          "AND P.Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                          "AND P.Matricula LIKE '%" + this.box_matricula.Text.Trim() + "%' " +
                          "AND E.Descripcion = '" + this.comboBox1.Text + "'";
            }

            if (SQL_Methods.DBConnectStatus)
            {
                TablaProfesionales = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (flagMenuPpal == 1)
                {
                    //new CancelacionProfesionalForm(menuPpal, TablaProfesionales.Rows[e.RowIndex][0].ToString(), TablaProfesionales.Rows[e.RowIndex][1].ToString(), TablaProfesionales.Rows[e.RowIndex][2].ToString());
                    this.Dispose();
                    return;
                }
                ProfesionalClass prof = new ProfesionalClass();
                prof.apellido = TablaProfesionales.Rows[e.RowIndex][2].ToString();
                prof.nombre = TablaProfesionales.Rows[e.RowIndex][1].ToString();
                prof.numeroDocumento = Convert.ToInt32(TablaProfesionales.Rows[e.RowIndex][4].ToString());
                prof.matricula = Convert.ToInt32(TablaProfesionales.Rows[e.RowIndex][0].ToString());
                prof.direccion = TablaProfesionales.Rows[e.RowIndex][5].ToString();
                prof.numeroTelefono = Convert.ToInt32(TablaProfesionales.Rows[e.RowIndex][7].ToString());
                prof.mail = TablaProfesionales.Rows[e.RowIndex][6].ToString();
                prof.fechaNacimiento = Convert.ToDateTime(TablaProfesionales.Rows[e.RowIndex][8].ToString());
                prof.tipoDocumento = TablaProfesionales.Rows[e.RowIndex][3].ToString();
                prof.sexo = Convert.ToChar(TablaProfesionales.Rows[e.RowIndex][9].ToString());
                if (eliminar)
                {
                    // Se quiere eliminar Profesional
                    // Conexion al server
                    SqlConnection myConnection = SQL_Methods.IniciarConnection();
                    SqlCommand comando = new SqlCommand("ORACLE_FANS.baja_profesional", myConnection);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@mat", SqlDbType.Int).Value = Convert.ToInt32(TablaProfesionales.Rows[e.RowIndex][0].ToString());
                    comando.ExecuteReader();
                    MessageBox.Show(TablaProfesionales.Rows[e.RowIndex][2].ToString() + " " + TablaProfesionales.Rows[e.RowIndex][1].ToString() + " ha sido eliminado.");
                    menu.Visible = true;
                    this.Dispose();
                }
                else
                {
                    // Se quiere modificar un Profesional
                    new AddModProfesional(menu, true, prof);
                    this.Dispose();
                }
            }
        }

        // Metodo para boton buscar
        private void button_search_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            
            cargarProfesionales();

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaProfesionales;
            this.dataGridView1.Visible = true;
            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(boton);
            boton.HeaderText = "Action";

            if (eliminar)
            {
                boton.Text = "Delete";
            }
            else
            {
                boton.Text = "Select";
            }
            if (flagMenuPpal == 1)
            {
                boton.Text = "Select";
            }
            boton.Name = "row_button";
            boton.UseColumnTextForButtonValue = true;
        }

        private void cargarComboBox()
        {
            string myQuery = "SELECT Descripcion FROM ORACLE_FANS.Especialidades ORDER BY 1";
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaEspecialidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
            for (int i = 0; i < Convert.ToInt32(TablaEspecialidades.Rows.Count.ToString()); i++)
            {
                this.comboBox1.Items.Add(TablaEspecialidades.Rows[i][0]);
            }
        }
        private void volver_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}
