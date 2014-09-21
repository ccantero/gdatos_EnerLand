using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Cancelar_Atencion_Profesional
{
    public partial class CancelacionProfesionalForm : Form
    {
        // Menu principal a ocultar
        MenuPrincipal menu;

        int Matricula;

        public CancelacionProfesionalForm(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            Matricula = -1;
        }

        private void CargarTiposCancelacion()
        {
            box_tipoCancelacion.Items.AddRange(new object[] {"Enfermedad","Accidente","Viaje","Circunstancia Imprevista"});
            box_fecha.Items.AddRange(new object[] {"Fecha en Particular","Rango de Fechas"});
        }
        
        private void button_select_Click(object sender, EventArgs e)
        {
            RegistrarAgenda.SearchProfesionalForm BuscarProfesional = new Clinica_Frba.RegistrarAgenda.SearchProfesionalForm(this);
        }

        public void SetProfesional(int unaMatricula, string Profesional)
        {
            Matricula = unaMatricula;
            this.box_profesional.Text = Profesional;
        }

        private void box_fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (box_fecha.Text.Equals("Fecha en Particular"))
            {
                label_fechaDesde.Text = "Fecha";

                this.label_fechaDesde.Visible = true;
                this.box_fechaDesde.Visible = true;
                this.button_clean.Visible = true;
                this.button_save.Visible = true;
                
                
                label_FechaHasta.Visible = false;
                Box_FechaHasta.Visible = false;

                this.button_clean.Location = new System.Drawing.Point(66, 307);
                this.button_save.Location = new System.Drawing.Point(340, 307);

                this.groupBox1.Size = new System.Drawing.Size(474,350);
                this.ClientSize = new System.Drawing.Size(513, 380);
            }

            if (box_fecha.Text.Equals("Rango de Fechas"))
            {
                label_fechaDesde.Text = "Fecha Desde";

                this.label_fechaDesde.Visible = true;
                this.box_fechaDesde.Visible = true;
                label_FechaHasta.Visible = true;
                Box_FechaHasta.Visible = true;
                this.button_clean.Visible = true;
                this.button_save.Visible = true;

                this.Box_FechaHasta.Location = new System.Drawing.Point(151, 307);
                this.label_FechaHasta.Location = new System.Drawing.Point(6, 314);

                this.button_clean.Location = new System.Drawing.Point(66, 362);
                this.button_save.Location = new System.Drawing.Point(340, 362);

                this.groupBox1.Size = new System.Drawing.Size(474, 404);
                this.ClientSize = new System.Drawing.Size(513, 444);
            }

            
        }

        private void CancelacionProfesionalForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void CancelacionProfesionalForm_Load(object sender, EventArgs e)
        {
            CargarTiposCancelacion();

            this.label_fechaDesde.Visible = false;
            this.label_FechaHasta.Visible = false;

            this.box_fechaDesde.Visible = false;
            this.Box_FechaHasta.Visible = false;
            this.button_clean.Visible = false;
            this.button_save.Visible = false;

            this.box_fechaDesde.Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
            this.Box_FechaHasta.Value = @Clinica_Frba.Properties.Settings.Default.Fecha;
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            Matricula = -1;
            this.box_descripcion.Text = "";
            this.box_fecha.Text = "";
            this.box_fechaDesde.Value = Convert.ToDateTime(@Clinica_Frba.Properties.Settings.Default.Fecha.ToShortDateString());
            this.Box_FechaHasta.Value = Convert.ToDateTime(@Clinica_Frba.Properties.Settings.Default.Fecha.ToShortDateString());
            this.box_profesional.Text = "";
            this.box_tipoCancelacion.Text = "";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            TimeSpan Hour = new TimeSpan(23, 59, 59);
            TimeSpan diffResult = box_fechaDesde.Value.Subtract(@Clinica_Frba.Properties.Settings.Default.Fecha);

            DateTime FechaDesde;
            DateTime FechaHasta;

            FechaDesde = Convert.ToDateTime(this.box_fechaDesde.Value.ToShortDateString());
            
            if (diffResult.Days <= 1)
            {
                MessageBox.Show("No se pueden cancelar turnos con anticipación menor a 24 horas");
                return;
            }

            if (box_fecha.Text.Equals("Fecha en Particular"))
            {
                this.Box_FechaHasta.Value = FechaDesde;
            }
            else
            {
                this.Box_FechaHasta.Value = Convert.ToDateTime(this.Box_FechaHasta.Value.ToShortDateString());
            }
            
            FechaHasta = this.Box_FechaHasta.Value.Add(Hour);

            if (!SQL_Methods.Profesional_CancelarTurno( Matricula,
                                                        FechaDesde,
                                                        FechaHasta,
                                                        this.box_tipoCancelacion.Text.Trim(),
                                                        this.box_descripcion.Text.Trim()))
            {
                MessageBox.Show("No se pudieron Cancelar los Turnos en Cuestion.");
                return;
            }
            menu.Visible = true;
            this.Dispose();
            return;
        }

    }
}
