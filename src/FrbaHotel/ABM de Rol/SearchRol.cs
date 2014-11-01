using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class SearchRol : UserControl
    {
        private Form FormPadre;

        public SearchRol(Form parent)
        {
            InitializeComponent();
            FormPadre = parent;
        }

        private void SearchRol_Load(object sender, EventArgs e)
        {

        }
    }
}
