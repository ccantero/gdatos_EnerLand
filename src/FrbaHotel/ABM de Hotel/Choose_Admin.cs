using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class Choose_Admin : Form
    {
        private Form parentForm;
        private string[,] Administradores;

        public Choose_Admin(String Title, String Prompt, string[,] items, Form padre)
        {
            InitializeComponent();
            this.label_Prompt.Text = Prompt;
            this.Text = Title;
            parentForm = padre;

            Administradores = items;

            for (int i = 0; i < Administradores.GetLength(0); i++)
            {
                this.comboBox1.Items.Add(Administradores[i, 1]);
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            AdminChoosing();
        }

        private void Choose_Admin_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            parentForm.Hide();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AdminChoosing();
            }
        }

        private void AdminChoosing()
        {
            int idUsuario = -1;

            for (int i = 0; i < Administradores.GetLength(0); i++)
            {
                if (Administradores[i, 1].Equals(this.comboBox1.Text.Trim()))
                {
                    idUsuario = Convert.ToInt32(Administradores[i, 0]);
                }
            }

            if (idUsuario != -1)
            {
                ((GestionHoteles)parentForm).SaveData(idUsuario);
            }
            else
            {
                MessageBox.Show("No se pudo seleccionar el Administrador");
            }

            parentForm.Show();
            this.Dispose();
        }
    }
}
