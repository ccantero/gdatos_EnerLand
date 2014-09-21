using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Rol;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class Rol_Form : Form
    {
        public static MenuPrincipal menu; //Formulario Principal. Para poder ocultar el formulario anterior
        
        AddModRol FormAlta;
        SearchRol FormSearch;

        public Rol_Form(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
        }

        private void agregarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlta = new AddModRol(this);
        }

        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch = new SearchRol(this);
        }

        private void eliminarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch = new SearchRol(this, true);
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Dispose();
            Application.Exit();
        }

        private void Rol_Form_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            menu.Visible = true;
            this.Dispose();
        } 
    }
}
