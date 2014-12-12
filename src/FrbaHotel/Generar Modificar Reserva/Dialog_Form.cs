using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Dialog_Form : Form
    {
        public Form parent_Form;

        public Dialog_Form(String Title, String Prompt, Form formPadre)
        {
            InitializeComponent();
            this.label_Prompt.Text = Prompt;
            this.Text = Title;
            parent_Form = formPadre;
            parent_Form.Hide();
            this.Show();
        }

        private void Dialog_Form_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Reserva)parent_Form).CancelarReserva(this.Textbox.Text);
            parent_Form.Show();
            this.Dispose();
        }
    }
}
