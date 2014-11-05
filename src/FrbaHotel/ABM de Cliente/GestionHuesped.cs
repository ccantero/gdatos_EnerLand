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

            UserControl_BuscarHuesped BuscarHuesped = new UserControl_BuscarHuesped(this);
            this.Controls.Add(BuscarHuesped);
            BuscarHuesped.Location = new System.Drawing.Point(0, 20);
            BuscarHuesped.Name = "UserControlBuscarHuesped";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }
    }
}
