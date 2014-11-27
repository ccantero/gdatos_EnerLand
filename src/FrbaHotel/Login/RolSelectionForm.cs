using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class RolSelectionForm : Form
    {
        private Form parentForm;
        private int idUsuario;
        private string[,] roles;

        public RolSelectionForm(String Title, String Prompt, string[,] items, Form padre, int id_Usuario)
        {
            InitializeComponent();
            this.label_Prompt.Text = Prompt;
            this.Text = Title;
            parentForm = padre;

            roles = items;

            for (int i = 0; i < roles.GetLength(0); i++)
			{
                this.comboBox1.Items.Add(roles[i, 1]);
			}
            idUsuario = id_Usuario;

            
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            int idRol = -1;

            for (int i = 0; i < roles.GetLength(0); i++)
            {
                if (roles[i, 1].Equals(this.comboBox1.Text.Trim()))
                    idRol = Convert.ToInt32(roles[i, 0]);
            }

            if (idRol != -1)
            {
                ((LoginForm)parentForm).CargarMenu(idUsuario, idRol);
                //parentForm.Visible = true;
                this.Dispose();
            }
        }

        private void RolSelectionForm_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            parentForm.Hide();
        }
    }
}
