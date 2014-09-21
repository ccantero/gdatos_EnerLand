using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Clinica_Frba.PedirTurno;
using Clinica_Frba.Cancelar_Atencion_Afiliado;



namespace Clinica_Frba.Afiliado
{
    public partial class SearchAfiliado : Form
    {
        public static MenuPrincipal menuPpal;
        public static AfiliadoABM menu;
        public static PedirTurnoForm menuPedirTurno;
        public static CancelacionAfiliadoForm menuCancelarTurnoAfiliado;

        public static DataTable TablaUsuario = new DataTable(); //DataTable para Alojar La consulta de Usuarios
        public static bool Flag_deletion;
        public static bool Flag_Turno;
        public static bool Flag_CancelarTurno;

		
        // Constructor para Mod Afiliado
        public SearchAfiliado(AfiliadoABM sender) 
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            Flag_deletion = false;
            Flag_Turno = false;
            Flag_CancelarTurno = false;
            this.Text = "Buscar Afiliado";
        }

        // Constructor de ABM Afiliado
        public SearchAfiliado(AfiliadoABM sender, bool flag) 
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.Text = "Eliminar Afiliado";
            Flag_deletion = true;
            Flag_Turno = false;
            Flag_CancelarTurno = false;
        }

        // Constructor para Pedir Turno
        public SearchAfiliado(PedirTurnoForm sender)
        {
            InitializeComponent();
            menuPedirTurno = sender;
            menuPedirTurno.Visible = false;
            this.Visible = true;
            Flag_deletion = false;
            Flag_Turno = true;
            Flag_CancelarTurno = false;
        }

        // Constructor para Cancelar Turno [Profesional]
        public SearchAfiliado(CancelacionAfiliadoForm sender)
        {
            InitializeComponent();
            menuCancelarTurnoAfiliado = sender;
            menuCancelarTurnoAfiliado.Visible = false;
            this.Visible = true;
            Flag_deletion = false;
            Flag_Turno = false;
            Flag_CancelarTurno = true;
        }
        
        private void SearchAfiliado_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {

            if (Flag_CancelarTurno)
            {
                menuCancelarTurnoAfiliado.Visible = true;
                this.Dispose();
                return;
            }
            
            if (Flag_Turno)
            {
                menuPedirTurno.Visible = true;
                this.Dispose();
                return;
            }

            menu.Visible = true;           
            this.Dispose();
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            this.box_codafiliado.Text = "";
            this.box_apellido.Text = "";
            this.box_nombre.Text = "";
            this.box_dni.Text = "";
            //TablaUsuario.Clear();
            //this.dataGridView1.DataSource = TablaUsuario;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
            

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            CargarUsuarios();

            if (TablaUsuario.Rows.Count == 0)
            {
                return;
            }
			
			this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaUsuario;

            this.dataGridView1.Visible = true;

            dataGridView1.Columns["Cod_PlanMedico"].Visible = false;
            dataGridView1.Columns["Tipo_Documento"].Visible = false;
            dataGridView1.Columns["Direccion"].Visible = false;
            dataGridView1.Columns["Telefono"].Visible = false;
            dataGridView1.Columns["Mail"].Visible = false;
            dataGridView1.Columns["Fecha_Nac"].Visible = false;
            dataGridView1.Columns["Sexo"].Visible = false;
            dataGridView1.Columns["Estado_Civil"].Visible = false;
            dataGridView1.Columns["Cant_Familiares_A_Cargo"].Visible = false;
            dataGridView1.Columns["Activo"].Visible = false;
            dataGridView1.Columns["Fecha_Baja"].Visible = false;
            
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(btn);
            
            btn.HeaderText = "Action";

            if (Flag_deletion)
            {
                btn.Text = "Delete";
            }
            else
            {
                btn.Text = "Select";
            }
					
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
        }

        private void CargarUsuarios()
        {
            TablaUsuario.Rows.Clear();


            if (this.box_nombre.Text.Trim().Equals("") && 
                this.box_apellido.Text.Trim().Equals("") &&
                this.box_codafiliado.Text.Trim().Equals("") &&
                this.box_dni.Text.Trim().Equals("")
                )
            {
                MessageBox.Show("Debe introducir al menos un criterio de búsqueda");
                return;
            }
            
            string myQuery = "SELECT * FROM ORACLE_FANS.Afiliados " +
                             "WHERE Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                             "AND Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                             "AND Cod_Afiliado LIKE '%" + this.box_codafiliado.Text.Trim() + "%' " +
                             "AND Numero_Documento LIKE '%" + this.box_dni.Text.Trim() + "%' " +
                             " AND Activo = 1";          

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaUsuario = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Afiliado paciente = new Afiliado();
            paciente = CargarDatosAfiliado(e.RowIndex);
			
			if (e.ColumnIndex == 15 && e.RowIndex > -1)
            {
                int idAfiliado = Convert.ToInt32(TablaUsuario.Rows[e.RowIndex][0].ToString());
                
                if (Flag_Turno)
                {
                    menuPedirTurno.SetAfiliado(paciente);
                    menuPedirTurno.Visible = true;
                    this.Dispose();
                    return;   
                }

                if (Flag_CancelarTurno)
                {
                    menuCancelarTurnoAfiliado.SetAfiliado(paciente);
                    menuCancelarTurnoAfiliado.Visible = true;
                    this.Dispose();
                    return; 
                }
               
                if (Flag_deletion)
                {
                    if (!SQL_Methods.Afiliado_DarBaja(idAfiliado, @Clinica_Frba.Properties.Settings.Default.Fecha))
                    {
                        MessageBox.Show(idAfiliado.ToString() + "no pudo ser eliminado.");
                        return;
                    }
                    
                    MessageBox.Show(TablaUsuario.Rows[e.RowIndex][0].ToString() + " ha sido eliminado.");
                    menu.Visible = true;
                    this.Dispose();
                    return;
                }

                new AddModAfiliado(menu, paciente);
                this.Dispose();
            }
        }

        private Afiliado CargarDatosAfiliado(int fila)
        {
            Afiliado paciente = new Afiliado();
            paciente.Cod_Afiliado = Convert.ToInt32(TablaUsuario.Rows[fila][0].ToString());
            paciente.Cod_PlanMedico = Convert.ToInt32(TablaUsuario.Rows[fila][1].ToString());
            paciente.Apellido = TablaUsuario.Rows[fila][3].ToString();
            paciente.Nombre = TablaUsuario.Rows[fila][2].ToString();
            paciente.Tipo_Documento = TablaUsuario.Rows[fila][4].ToString();
            paciente.Numero_Documento = Convert.ToInt32(TablaUsuario.Rows[fila][5].ToString());
            paciente.Direccion = TablaUsuario.Rows[fila][6].ToString();
            paciente.Telefono = Convert.ToInt32(TablaUsuario.Rows[fila][7].ToString());
            paciente.Mail = TablaUsuario.Rows[fila][8].ToString();
            paciente.Fecha_Nac = Convert.ToDateTime(TablaUsuario.Rows[fila][9].ToString());
            if (TablaUsuario.Rows[fila][10].ToString().Trim().Equals(""))
            {
                paciente.Sexo = '\0';
            }
            else
            {
                paciente.Sexo = Convert.ToChar(TablaUsuario.Rows[fila][10].ToString());
            }
            paciente.Estado_Civil = TablaUsuario.Rows[fila][11].ToString();
            if (!TablaUsuario.Rows[fila][12].ToString().Trim().Equals(""))
            {
                paciente.CantFamiliaresACargo = Convert.ToInt32(TablaUsuario.Rows[fila][12].ToString());
            }
            
            

            return paciente;
        }

        
    }
}
