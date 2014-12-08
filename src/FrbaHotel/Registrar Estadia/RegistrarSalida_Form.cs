using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class RegistrarSalida_Form : Form
    {
        private Form FormPadre;
        public int currentHotel;
        
        public RegistrarSalida_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void RegistrarSalida_Form_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormPadre.Hide();
            box_FechaEgreso.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
            button_Save.Text = "Check";
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
             foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }

            box_FechaEgreso.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (button_Save.Text == "Check")
            {
                string myQuery = "SELECT H.Apellido, H.Nombre " +
                                "FROM ENER_LAND.Reserva R, ENER_LAND.Huesped H " +
                                "WHERE R.idHuesped = H.idHuesped " +
                                "AND R.idReserva = " + textBox_idReserva.Text;

                DbResultSet rs = DbManager.GetDataTable(myQuery);

                if (rs.dataTable.Rows.Count == 1)
                {
                    button_Save.Text = "Submit";
                    textBox_Huesped.Text = rs.dataTable.Rows[0]["Apellido"].ToString() + ", " +
                                           rs.dataTable.Rows[0]["Nombre"].ToString();

                    
                }
                else
                {
                    MessageBox.Show("La reserva no es correcta",
                                    "Reserva Incorrecta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                }
                return;
            }
            
            int idReserva = Convert.ToInt32(textBox_idReserva.Text);
            Boolean status = DbManager.Proceess_CheckOut(idReserva, currentHotel);

            if (status)
            {
                MessageBox.Show("Check-Out correcto");
                FormPadre.Show();
                this.Dispose();
            }

        }

        private void RegistrarSalida_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPadre.Show();
            this.Dispose();
        }

        private void textBox_idReserva_TextChanged(object sender, EventArgs e)
        {
            if (button_Save.Text == "Submit")
                button_Save.Text = "Check";
        }
        
    }
}
