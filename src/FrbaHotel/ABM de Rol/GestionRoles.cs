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
        private UserControl_BuscarRol UserControlBuscarRol;
        private UserControl_Rol UserControlAgregarRol;

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

            Load_Menu();
        
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void agregarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlAgregarRol = new FrbaHotel.ABM_de_Rol.UserControl_Rol(this);
            this.Controls.Add(UserControlAgregarRol);
            UserControlAgregarRol.Location = new System.Drawing.Point(0, 20);
            UserControlAgregarRol.Name = "UserControlAgregarRol";
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
            UserControlBuscarRol.flag_deletion = true;
        }

        public void Load_Menu()
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlBuscarRol = new UserControl_BuscarRol(this);

            this.Controls.Add(UserControlBuscarRol);
            UserControlBuscarRol.Location = new System.Drawing.Point(0, 20);
            UserControlBuscarRol.Name = "UserControlBuscarRol";
        }

        private void GestionRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        public void Modificar_Rol(int idRol)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlAgregarRol = new FrbaHotel.ABM_de_Rol.UserControl_Rol(this);
            this.Controls.Add(UserControlAgregarRol);
            UserControlAgregarRol.Location = new System.Drawing.Point(0, 20);
            UserControlAgregarRol.Name = "UserControlAgregarRol";

            UserControlAgregarRol.Cargar_Rol(idRol);

        }
    }
}
