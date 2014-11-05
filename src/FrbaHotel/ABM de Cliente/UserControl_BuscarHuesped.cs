using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class UserControl_BuscarHuesped : UserControl
    {
        private Form FormPadre;

        public UserControl_BuscarHuesped(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }
    }
}
