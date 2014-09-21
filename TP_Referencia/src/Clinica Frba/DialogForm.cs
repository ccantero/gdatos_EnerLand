using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.bonoFarmacia;

namespace Clinica_Frba
{
    public partial class DialogForm : Form
    {
        MenuPrincipal MenuPrincipal;
        Afiliado.AddModAfiliado Menu;
        CompraBonoFarmacia MenuCompraBonoFarmacia;
        bool MenuCompraBonoFarm;

        public DialogForm(Afiliado.AddModAfiliado sender, String Title, string Message)
        {
            InitializeComponent();
            this.Text = Title;
            this.label1.Text = Message;
            
            Menu = sender;
            sender.Visible = false;
            this.Visible = true;
            
            this.richTextBox1.Visible = false;
            this.ControlBox = false;
            MenuCompraBonoFarm = false;
        }

        public DialogForm(CompraBonoFarmacia sender, String Title, string Message)
        {
            InitializeComponent();
            this.Text = Title;


            this.label1.Text = "Numeros de Bono";
            this.textBox1.Visible = false;

            this.richTextBox1.Visible = true;
            this.richTextBox1.Text = Message;
            this.button1.Visible = false;
            this.ClientSize = new System.Drawing.Size(284, 120);

            MenuCompraBonoFarmacia = sender;
            sender.Visible = false;
            this.Visible = true;

            this.ControlBox = true;
            MenuCompraBonoFarm = true;
        }

        public DialogForm(string Message)
        {
            InitializeComponent();
            this.textBox1.Text = Message;
            this.Visible = true;
            this.ControlBox = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
            if (this.textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("El motivo no puede ser vacio");
                return;
            }

            if (MenuCompraBonoFarm)
            {
                MenuCompraBonoFarmacia.CloseForm();
                this.Dispose();
                return;
            }

            Menu.ModificarPlanMedico(this.textBox1.Text);
            this.Dispose();
            return;
        }

    }
}
