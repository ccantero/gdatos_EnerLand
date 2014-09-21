using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.addModProfesional;
using Clinica_Frba.buscarProfesionalForm;

namespace Clinica_Frba.Profesional
{
    public partial class ProfesionalABM : Form
    {
        // Formulario anterior a ocultar
        MenuPrincipal menu;

        // Formulario para agregar profesionales
        AddModProfesional abmAgregarProfesional;

        // Formulario para buscar profesionales y luego eliminar o modificar
        BuscarProfesional buscarAfiliadoForm;

        // Constructor
        public ProfesionalABM(MenuPrincipal sender)
        {
            menu = sender;
            sender.Visible = false;
            InitializeComponent();
            this.Visible = true;
        }

        // Método para el botón de cruz
        private void abmProfesional_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para opción salir del programa
        private void salirDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Dispose();
            Application.Exit();
        }

        // Método para opción volver al menú principal
        private void salirAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Visible = true;
        }

        // Método para opción agregar profesional
        private void agregarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abmAgregarProfesional = new AddModProfesional(this);
        }

        // Método para opción modificar profesional
        private void modificarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarAfiliadoForm = new BuscarProfesional(this);
        }

        // Método para opción eliminar profesional
        private void eliminarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarAfiliadoForm = new BuscarProfesional(this, true);
        }
    }
}
