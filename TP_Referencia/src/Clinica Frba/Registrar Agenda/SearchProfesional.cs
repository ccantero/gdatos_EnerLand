using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.RegistrarAgenda
{
    public partial class SearchProfesionalForm : Form
    {
        public static MenuPrincipal menu;
        public static PedirTurno.PedirTurnoForm menuPedirTurno;
        public static Cancelar_Atencion_Profesional.CancelacionProfesionalForm menuCancelarTurno;
        public static DataTable TablaProfesionales = new DataTable(); //DataTable para Alojar La consulta de Profesionales
        public static DataTable TablaEspecialidades = new DataTable(); //DataTable para Alojar La consulta de Especialidades
        public static bool PedirTurno;
        public static DateTime FechaTurno;
        public static bool CancelarTurno;

        // Definicion para Registrar Agenda
        public SearchProfesionalForm(MenuPrincipal FormularioPadre)
        {
            InitializeComponent();
            menu = FormularioPadre;
            FormularioPadre.Visible = false;
            this.Visible = true;
            PedirTurno = false;
            CancelarTurno = false;
        }

        // Definicion para Pedir Turno
        public SearchProfesionalForm(PedirTurno.PedirTurnoForm FormularioPadre, DateTime Fecha)
        {
            InitializeComponent();
            menuPedirTurno = FormularioPadre;
            FormularioPadre.Visible = false;
            this.Visible = true;
            PedirTurno = true;
            FechaTurno = Fecha;
            CancelarTurno = false;
        }

        // Definicion para Cancelar Turno [ Profesional ]
        public SearchProfesionalForm(Cancelar_Atencion_Profesional.CancelacionProfesionalForm FormularioPadre)
        {
            InitializeComponent();
            menuCancelarTurno = FormularioPadre;
            FormularioPadre.Visible = false;
            this.Visible = true;
            PedirTurno = false;
            CancelarTurno =true;
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            this.box_apellido.Text = "";
            this.box_especialidad.Text = "";
            this.box_Matricula.Text = "";
            this.box_nombre.Text = "";          
            //TablaUsuario.Clear();
            //this.dataGridView1.DataSource = TablaUsuario;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            CargarProfesional();

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaProfesionales;
            this.dataGridView1.Visible = true;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Select";
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
        }

        private void SearchProfesionalForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            if (menu == null)
            {
                menuPedirTurno.Visible = true;
                this.Dispose();
                return;
            }
            menu.Visible = true;
            
            this.Dispose();
        }

        private void CargarProfesional()
        {
            string myQuery = "";
            int Matricula;

            if (PedirTurno)
            {
                if (this.box_Matricula.Text.Trim().Equals(""))
                {
                    Matricula = -1;
                }
                else
                {
                    Matricula = Convert.ToInt32(this.box_Matricula.Text.Trim());
                }

                TablaProfesionales = SQL_Methods.Profesional_Listar(Matricula,
                                                                    this.box_nombre.Text.Trim(),
                                                                    this.box_apellido.Text.Trim(),
                                                                    this.box_especialidad.Text.Trim(),
                                                                    FechaTurno);
                return;
            }


            if (this.box_especialidad.Text.Trim().Equals(""))
            {
                myQuery = "SELECT " +
                          "P.Matricula, P.Nombre, P.Apellido " +
                          "FROM " +
                          "ORACLE_FANS.Profesionales P " +
                          "WHERE P.Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                          "AND P.Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                          "AND P.Matricula LIKE '%" + this.box_Matricula.Text.Trim() + "%' ";

                
            }
            else
            {
                DataRow[] Rows = TablaEspecialidades.Select("Descripcion = '" + this.box_especialidad.Text.Trim() + "'");
                int Cod_Especialidad;
                if (Rows.Length > 0)
                {
                    Cod_Especialidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
                    myQuery = "SELECT " +
                              "P.Matricula, P.Nombre, P.Apellido, E.Descripcion As Especialidad " +
                              "FROM " +
                              "ORACLE_FANS.Profesionales P, ORACLE_FANS.Especialidades E, " +
                              "ORACLE_FANS.Tipo_Especialidad T, ORACLE_FANS.Medico_Especialidad ME " +
                              "WHERE ME.Cod_Especialidad = E.Cod_Especialidad " +
                              "AND E.Cod_Tipo_Especialidad = T.Cod_Tipo_Especialidad " +
                              "AND P.Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                              "AND P.Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                              "AND P.Matricula LIKE '%" + this.box_Matricula.Text.Trim() + "%' " +
                              "AND ME.Cod_Especialidad = " + Cod_Especialidad.ToString();
                }
            }

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaProfesionales = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }

        }

        private void CargarEspecialidades()
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Especialidades ORDER BY 3";

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaEspecialidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }

            for (int i = 0; i < Convert.ToInt32(TablaEspecialidades.Rows.Count.ToString()); i++)
            {
                this.box_especialidad.Items.Add(TablaEspecialidades.Rows[i][2]);
            }

        }
              
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Action"))
            {
                int Matricula = Convert.ToInt32(TablaProfesionales.Rows[e.RowIndex]["Matricula"].ToString());
                

                if (PedirTurno)
                {

                    DataRow[] Rows = TablaEspecialidades.Select("Descripcion = '" + 
                                                                TablaProfesionales.Rows[e.RowIndex]["Especialidad"].ToString().Trim() +
                                                                "'");
                    int Cod_Especialidad;
                    if (Rows.Length != 1)
                    {
                        return;                        

                    }

                    Cod_Especialidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
                    menuPedirTurno.SetProfesional(Matricula,
                                                  Cod_Especialidad,
                                                  TablaProfesionales.Rows[e.RowIndex]["Nombre"].ToString() + " " +
                                                  TablaProfesionales.Rows[e.RowIndex]["Apellido"].ToString());
                        menuPedirTurno.Visible = true;
                        this.Dispose();
                        return;
                }

                if (CancelarTurno)
                {
                    menuCancelarTurno.SetProfesional(Matricula,
                                                    TablaProfesionales.Rows[e.RowIndex]["Nombre"].ToString() + " " +
                                                    TablaProfesionales.Rows[e.RowIndex]["Apellido"].ToString());

                    menuCancelarTurno.Visible = true;
                    this.Dispose();
                    return;
                }
                
                string myQuery = "SELECT FechaInicio, FechaFinal FROM ORACLE_FANS.Cartilla_Medica " +
                                 "WHERE Matricula =  " + Matricula.ToString();
                
                SqlConnection myConnection;
                myConnection = SQL_Methods.IniciarConnection();

                if (SQL_Methods.DBConnectStatus)
                {
                    DataTable Aux = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
                    if (Aux.Rows.Count > 0)
                    {
                        DateTime FechaInicio = Convert.ToDateTime(Aux.Rows[0][0].ToString());
                        DateTime FechaFinal = Convert.ToDateTime(Aux.Rows[0][1].ToString());

                        MessageBox.Show("Este profesional ya tiene una Agenda Profesional en Progreso" + System.Environment.NewLine +
                                        "Fecha Desde = " + FechaInicio.ToShortDateString() + System.Environment.NewLine +
                                        "Fecha Hasta = " + FechaFinal.ToShortDateString());
                        return;
                    }
                }     
                
                new RegistrarAgendaForm(menu, Matricula);
                this.Dispose();
            }
        }

        private void SearchProfesionalForm_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
        }


    }
}
