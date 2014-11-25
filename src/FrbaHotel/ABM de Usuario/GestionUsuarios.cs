using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class GestionUsuarios : Form
    {
        public Form MenuPrincipal;
        public UserControl_BuscarUsuario UserControlBuscarUsuario;
        public UserControl_Usuario UserControlAgregarUsuario;

        public GestionUsuarios(Form parentForm)
        {
            InitializeComponent();
            this.MenuPrincipal = parentForm;
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales
            
            this.CenterToScreen();
            
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MenuPrincipal.Hide();
            Load_Menu();
        }

        public void Load_Menu()
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlBuscarUsuario = new UserControl_BuscarUsuario(this);

            this.Controls.Add(UserControlBuscarUsuario);
            UserControlBuscarUsuario.Location = new System.Drawing.Point(0, 20);
            UserControlBuscarUsuario.Name = "UserControlBuscarUsuario";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlAgregarUsuario = new UserControl_Usuario(this);
            this.Controls.Add(UserControlAgregarUsuario);
            UserControlAgregarUsuario.Location = new Point(0, 20);
            UserControlAgregarUsuario.Name = "UserControlAgregarUsuario";
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Menu();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Menu();
            UserControlBuscarUsuario.flag_deletion = true;
        }

        private void GestionUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        public void Modificar_Usuario(Usuario unUsuario)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlAgregarUsuario = new UserControl_Usuario(this);
            this.Controls.Add(UserControlAgregarUsuario);
            UserControlAgregarUsuario.Location = new System.Drawing.Point(0, 20);
            UserControlAgregarUsuario.Name = "UserControlAgregarUsuario";

            UserControlAgregarUsuario.Cargar_Usuario(unUsuario);
        }
    }
}
