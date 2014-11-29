using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form_ListadoEstadistico : Form
    {
        public Form MenuPrincipal;

        public Form_ListadoEstadistico(Form parentForm)
        {
            InitializeComponent();
            this.MenuPrincipal = parentForm;
        }

        private void Form_ListadoEstadistico_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MenuPrincipal.Hide();
        }
    }
}
