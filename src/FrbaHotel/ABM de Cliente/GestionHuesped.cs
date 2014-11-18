using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class GestionHuesped : Form
    {
        public Form MenuPrincipal;
        public UserControl_BuscarHuesped UserControlBuscarHuesped;
        public UserControl_Huesped UserControlHuesped;

        public GestionHuesped(Form parentForm)
        {
            InitializeComponent();
            this.MenuPrincipal = parentForm;
        }

        private void GestionHuesped_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MenuPrincipal.Hide();
            Load_Menu();
        }

        private void GestionHuesped_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        public void Load_Menu()
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlBuscarHuesped = new UserControl_BuscarHuesped(this);
            this.Controls.Add(UserControlBuscarHuesped);
            UserControlBuscarHuesped.Location = new System.Drawing.Point(0, 20);
            UserControlBuscarHuesped.Name = "UserControlBuscarHuesped";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        public void Modificar_Huesped(Huesped unHuesped)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlHuesped = new UserControl_Huesped(this);
            this.Controls.Add(UserControlHuesped);
            UserControlHuesped.Location = new System.Drawing.Point(0, 20);
            UserControlHuesped.Name = "UserControlHuesped";

            UserControlHuesped.Cargar_Huesped(unHuesped);
        }

        private void agregarHuéspedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(this.menuStrip1);

            UserControlHuesped = new UserControl_Huesped(this);
            this.Controls.Add(UserControlHuesped);
            UserControlHuesped.Location = new Point(0, 10);
            UserControlHuesped.Name = "UserControlHuesped";
        }

        private void modificarHuéspedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Menu();
        }

        private void eliminarHuéspedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Menu();
            UserControlBuscarHuesped.flag_deletion = true;
        }
    }
}
