using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Cancelar_Atencion_Afiliado
{
    public partial class CancelacionAfiliadoForm : Form
    {
        // Menu principal a ocultar
        MenuPrincipal menu;

        DataTable TablaTurnos = new DataTable();
        static public int Cod_Afiliado;

        public CancelacionAfiliadoForm(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            Cod_Afiliado = -1;
            CargarTiposCancelacion();
        }

        public CancelacionAfiliadoForm(MenuPrincipal sender, int id_Afiliado, string Afiliado)
        {
            DataTable TablaAfiliados = new DataTable();
            
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            Cod_Afiliado = id_Afiliado;
            CargarTiposCancelacion();

            this.box_Afiliado.Text = Afiliado;
            this.button_select_Afiliado.Visible = false;
            
        }
        private void button_clean_Click(object sender, EventArgs e)
        {
            Cod_Afiliado = -1;
            this.box_Afiliado.Text = "";
            this.box_descripcion.Text = "";
            this.box_tipoCancelacion.Text = "";
        }

        private void button_select_Afiliado_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            Afiliado.SearchAfiliado BuscarAfiliado = new Clinica_Frba.Afiliado.SearchAfiliado(this);
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        public void SetAfiliado(Afiliado.Afiliado Paciente)
        {
            this.box_Afiliado.Text = Paciente.Apellido + " " + Paciente.Nombre;
            Cod_Afiliado = Paciente.Cod_Afiliado;
        }

        private void CargarTurnos()
        {
            DateTime Fecha = @Clinica_Frba.Properties.Settings.Default.Fecha;
            
            Fecha = @Clinica_Frba.Properties.Settings.Default.Fecha.AddDays(1);
            TablaTurnos = SQL_Methods.Afiliado_ListarTurnos(Cod_Afiliado, Fecha);
            
        }

        private void button_SearchTurno_Click(object sender, EventArgs e)
        {
            CargarTurnos();

            if (TablaTurnos.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado turnos");
                return;
            }

            this.dataGridView1.AllowUserToAddRows = false;

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = TablaTurnos;
            this.dataGridView1.Visible = true;
            DataGridViewTextBoxColumn DiaSemana = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Hora = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGridView1.Columns.Add(DiaSemana);
            this.dataGridView1.Columns.Add(Hora);
            DiaSemana.HeaderText = "Dia Semana";
            Hora.HeaderText = "Hora";
            this.dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Delete";
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;

            int ColumnaFecha = this.dataGridView1.Columns.IndexOf(DiaSemana);
            int ColumnaHora = this.dataGridView1.Columns.IndexOf(Hora);
            foreach (DataGridViewRow Row in dataGridView1.Rows)
	        {
                Row.Cells[ColumnaFecha].Value = GetWeekDay(Row.Cells[1].Value.ToString().Trim());
                Row.Cells[ColumnaHora].Value = Row.Cells[3].Value.ToString().Trim().Substring(0,5);
        	}

            //int index;
            //index = this.dataGridView1.Columns["Dia_de_Semana"].DisplayIndex;
            this.dataGridView1.Columns["Cod_Turno"].DisplayIndex = 0;
            this.dataGridView1.Columns[ColumnaFecha].DisplayIndex = 1;
            this.dataGridView1.Columns["Fecha"].DisplayIndex = 2;
            this.dataGridView1.Columns[ColumnaHora].DisplayIndex = 3;

            this.dataGridView1.Columns["Dia_De_Semana"].Visible = false;
            this.dataGridView1.Columns["Time"].Visible = false;

            this.dataGridView1.RowHeadersVisible = false;
        }
        
        private void CargarTiposCancelacion()
        {
            box_tipoCancelacion.Items.AddRange(new object[] { "Enfermedad", "Accidente", "Viaje", "Circunstancia Imprevista" });
        }

        private string GetWeekDay(string dayofWeek)
        {
            switch (dayofWeek)
            {
                case "Monday":
                    return "Lunes";
                case "Tuesday":
                    return "Martes";
                case "Wednesday":
                    return "Miercoles";
                case "Thursday":
                    return "Jueves";
                case "Friday":
                    return "Viernes";
                case "Saturday":
                    return "Sabado";
                default:
                    return "";
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Action"))
            {
                int Cod_Turno = Convert.ToInt32(TablaTurnos.Rows[e.RowIndex][0].ToString());
                if (!SQL_Methods.Afiliado_DarBajaTurno(Cod_Turno, @Clinica_Frba.Properties.Settings.Default.Fecha,
                                                       box_tipoCancelacion.Text.Trim(), box_descripcion.Text.Trim()))
                {
                    MessageBox.Show("El turno no pudo ser eliminado.");
                    return;
                }

                menu.Visible = true;
                this.Dispose();
                return;
            }
        }
    }
}
