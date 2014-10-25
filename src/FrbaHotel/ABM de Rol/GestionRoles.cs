using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class GestionRoles : Form
    {
        public Form MenuPrincipal;
        
        public GestionRoles(Form parentForm)
        {
            InitializeComponent();
            this.MenuPrincipal = parentForm;
        }

        private void GestionRoles_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales
            
            this.CenterToScreen();
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MenuPrincipal.Hide();
        
        }

        private void GestionRoles_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void agregarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Load_Menu();
            
            AgregarRol UserControlAgregarRol = new FrbaHotel.ABM_de_Rol.AgregarRol();
            this.Controls.Add(UserControlAgregarRol);
            UserControlAgregarRol.Location = new System.Drawing.Point(0, 20);
            UserControlAgregarRol.Name = "UserControlAgregarRol";
            //UserControlAgregarRol.Size = new System.Drawing.Size(252, 218);
        }

        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Load_Menu();
        }

        private void eliminarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Load_Menu();
        }

        private void Load_Menu()
        {
            this.Controls.Add(this.menuStrip1);
        }

    }
}
