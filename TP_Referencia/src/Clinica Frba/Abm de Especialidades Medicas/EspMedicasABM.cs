using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.mostrarEspecialidades;

namespace Clinica_Frba.EspMedicas
{
    public partial class EspMedicasABM : Form
    {
        // Formulario anterior a ocultar
        MenuPrincipal menu;

        // Formulario para mostrar especialidades
        MostrarEspecialidades mostrarEspecialidadesForm;

        public EspMedicasABM(MenuPrincipal sender)
        {
            menu = sender;
            sender.Visible = false;
            InitializeComponent();
            this.Visible = true;
        }

        // Método para el botón de cruz
        private void abmEspMed_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para opción volver al menú principal
        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Visible = true;
        }

        // Método para opción salir del programa
        private void salirDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Dispose();
            Application.Exit();
        }

        // Método para opción mostrar especialidades
        private void mostrarEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarEspecialidadesForm = new MostrarEspecialidades(this);
        }
    }
}
