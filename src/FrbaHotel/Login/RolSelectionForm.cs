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
        private string[,] roles;

        public RolSelectionForm(String Title, String Prompt, string[,] items, Form padre)
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
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            int idRol = -1;
            int idHotel = -1;

            for (int i = 0; i < roles.GetLength(0); i++)
            {
                if (roles[i, 1].Equals(this.comboBox1.Text.Trim()))
                {
                    if(roles[i, 2].Equals("Hotel"))
                        idHotel = Convert.ToInt32(roles[i, 0]);

                    if (roles[i, 2].Equals("Rol"))
                        idRol = Convert.ToInt32(roles[i, 0]);

                }
            }

            if (idRol != -1)
            {
                
                ((LoginForm)parentForm).currentRol = idRol;
                this.Dispose();
            }

            if (idHotel != -1)
            {

                ((LoginForm)parentForm).currentHotel = idHotel;
                this.Dispose();
            }

            ((LoginForm)parentForm).CargarMenu();
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
