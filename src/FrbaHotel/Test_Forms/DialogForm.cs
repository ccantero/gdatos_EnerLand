using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Test_Forms
{
    public partial class DialogForm : Form
    {
        public string Titulo;
        public string Descripcion;
        public string Mensaje;
        
        
        public DialogForm(String Title, String Prompt, String Message)
        {
            InitializeComponent();
            Titulo = Title;
            Descripcion = Prompt;
            Mensaje = Message;

        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.label1.Text = Titulo;
            this.richTextBox1.Text = Mensaje;
            this.Name = Titulo;
        }
    }
}
