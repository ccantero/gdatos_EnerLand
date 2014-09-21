using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Clinica_Frba.Afiliado;
using Clinica_Frba.RegistrarAgenda;

namespace Clinica_Frba.PedirTurno
{
    public partial class PedirTurnoForm : Form
    {
        MenuPrincipal menu;

        public static Afiliado.Afiliado elAfiliado;
        public static int Matricula;
        public static int Cod_Especialidad;
        public static int Cod_Afiliado;

        public PedirTurnoForm(MenuPrincipal FormularioPadre)
        {
            InitializeComponent();
            menu = FormularioPadre;
            menu.Visible = false;
            this.Visible = true;
            this.Combo_fecha.Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
            Cod_Afiliado = -1;
        }

        public PedirTurnoForm(MenuPrincipal FormularioPadre, int idAfiliado, string NombreAfiliado)
        {
            InitializeComponent();
            menu = FormularioPadre;
            menu.Visible = false;
            this.Visible = true;
            this.Combo_fecha.Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
            Cod_Afiliado = idAfiliado;

            this.box_Afiliado.Text = NombreAfiliado;
            this.button_Select_Afiliado.Visible = false;

            this.label_fecha.Visible = true;
            this.Combo_fecha.Visible = true;

            this.label_medico.Visible = true;
            this.box_medico.Visible = true;
            this.button_select_medico.Visible = true;
        }
        
        private void button_Select_Afiliado_Click(object sender, EventArgs e)
        {
            SearchAfiliado formAfiliado = new SearchAfiliado(this);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (this.comboBox_hora.Text.Equals(""))
            {
                this.box_medico.Text = "";
                return;
            }
            
            DateTime Fecha;
            DateTime Hora;

            //Fecha = this.Combo_fecha.Value;
            Fecha = Convert.ToDateTime(this.Combo_fecha.Value.ToShortDateString());
            
            Hora = Convert.ToDateTime(this.comboBox_hora.Text);
            TimeSpan Hour = new TimeSpan(Hora.Hour, Hora.Minute, 0);
            DateTime FechaTurno = Fecha.Add(Hour);

            if (Cod_Afiliado == -1)
            {
                Cod_Afiliado = elAfiliado.Cod_Afiliado;
            }
            
            if (SQL_Methods.Turno_Registrar(Matricula, Cod_Especialidad,Cod_Afiliado, FechaTurno) == -1)
            {
                MessageBox.Show("No se pudo agregar el turno.");
                return;
            }
            
            menu.Visible = true;
            this.Dispose();
            return;
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            this.box_Afiliado.Text = " ";
            this.box_medico.Text = "";
            this.Combo_fecha.Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
        }

        public void SetAfiliado(Afiliado.Afiliado unPaciente)
        {
            elAfiliado = unPaciente;
            this.box_Afiliado.Text = elAfiliado.Nombre + " " + elAfiliado.Apellido;

            this.label_fecha.Visible = true;
            this.Combo_fecha.Visible = true;

            this.label_medico.Visible = true;
            this.box_medico.Visible = true;
            this.button_select_medico.Visible = true;
        }

        public void SetProfesional(int idMedico, int idEspecialidad, string NombreMedico)
        {
            Matricula = idMedico;
            Cod_Especialidad = idEspecialidad;
            this.box_medico.Text = NombreMedico;

            CargarHorarios();

            this.label_horario.Visible = true;
            this.comboBox_hora.Visible = true;

            this.button_save.Visible = true;
            this.button_Clean.Visible = true;
        }

        private void PedirTurnoForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            if (menu.IsDisposed)
            {
                this.Dispose();
                return;
            }
            menu.Visible = true;
            this.Dispose();
        }

        private void button_select_medico_Click(object sender, EventArgs e)
        {
            SearchProfesionalForm BuscarProfesional = new SearchProfesionalForm(this, this.Combo_fecha.Value);
        }

        private void PedirTurnoForm_Load(object sender, EventArgs e)
        {
            this.label_medico.Visible = false;
            this.box_medico.Visible = false;
            this.button_select_medico.Visible = false;

            this.label_fecha.Visible = false;
            this.Combo_fecha.Visible = false;

            this.label_horario.Visible = false;
            this.comboBox_hora.Visible = false;
            
            this.button_save.Visible = false;
            this.button_Clean.Visible = false;
        }

        private void CargarHorarios()
        {
            DataTable TurnosOcupados = new DataTable();
            DataTable TurnosDisponibles = new DataTable();


            

            if (Cod_Afiliado == -1)
            {
                Cod_Afiliado = elAfiliado.Cod_Afiliado;
            }
            
            this.comboBox_hora.Items.Clear();

            TurnosDisponibles = SQL_Methods.Profesional_ListarTurnosDisponibles(Matricula, this.Combo_fecha.Value);

            foreach (DataRow Row in TurnosDisponibles.Rows)
            {
                this.comboBox_hora.Items.Add(Row[0].ToString().Substring(0, 5));
            }

            TurnosOcupados = SQL_Methods.Afiliado_ListarTurnosOcupados(Cod_Afiliado, this.Combo_fecha.Value);

            foreach (DataRow Row in TurnosOcupados.Rows)
            {
                this.comboBox_hora.Items.Remove(Row[0].ToString().Substring(0, 5));
            }

            TurnosOcupados.Rows.Clear();

            TurnosOcupados = SQL_Methods.Profesional_ListarTurnosOcupados(Matricula, this.Combo_fecha.Value);

            foreach (DataRow Row in TurnosOcupados.Rows)
            {
                this.comboBox_hora.Items.Remove(Row[0].ToString().Substring(0, 5));
            }

            if (this.comboBox_hora.Items.Count == 0)
            {
                MessageBox.Show("No hay turnos disponibles");
                this.box_medico.Text = "";

                this.comboBox_hora.Visible = false;
                this.button_Clean.Visible = false;
                this.button_save.Visible = false;
            }
        }

        private void Combo_fecha_ValueChanged(object sender, EventArgs e)
        {
            Matricula = -1;
            this.box_medico.Text = "";
        }

    }
}
