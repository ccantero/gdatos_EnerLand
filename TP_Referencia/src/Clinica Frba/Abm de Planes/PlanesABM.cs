using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.mostrarPlan;

namespace Clinica_Frba.Planes
{
    public partial class PlanesABM : Form
    {
        // Formulario anterior a ocultar
        MenuPrincipal menu;

        public PlanesABM(MenuPrincipal sender)
        {
            menu = sender;
            sender.Visible = false;
            InitializeComponent();
            this.Visible = true;
        }

        // Método para el botón de cruz
        private void abmPlanes_FormClosing(object sender, EventArgs e)
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

        // Método para opción salir de aplicación
        private void salirDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Dispose();
            Application.Exit();
        }

        // Método para opción mostrar planes médicos
        private void mostrarPlanesMédicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarPlanes mostrarPlanForm = new MostrarPlanes(this);
        }
    }
}
