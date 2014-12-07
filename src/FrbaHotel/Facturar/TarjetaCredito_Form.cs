using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FrbaHotel.Facturar
{
    public partial class TarjetaCredito_Form : Form
    {
        private Form FormPadre;
        
        public TarjetaCredito_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

            if (!CheckFields())
                return;

            ((Factura_Form)FormPadre).tarjetaDeCredito.AnioVencimiento = Convert.ToInt32(comboBox_AnioVencimiento.Text);
            ((Factura_Form)FormPadre).tarjetaDeCredito.MesVencimiento = Convert.ToInt32(comboBox_MesVencimiento.Text);
            ((Factura_Form)FormPadre).tarjetaDeCredito.Cod_Seguridad = Convert.ToInt32(this.textBox_CodSeguridad.Text);
            ((Factura_Form)FormPadre).tarjetaDeCredito.Numero_Tarjeta = textBox_NroTarjeta.Text;
            ((Factura_Form)FormPadre).tarjetaDeCredito.Titular = textBox_Titular.Text;

            ((Factura_Form)FormPadre).PagoTarjetaCredito = true;
            ((Factura_Form)FormPadre).Facturar();
            ((Factura_Form)FormPadre).Show();
            this.Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ((Factura_Form)FormPadre).Show();
            this.Dispose();
        }

        private void TarjetaCredito_Form_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormPadre.Hide();

            for (int i = 1; i < 13; i++)
            {
                this.comboBox_MesVencimiento.Items.Add(i.ToString());
            }

            for (int i = @FrbaHotel.Properties.Settings.Default.Fecha.Year; i < (@FrbaHotel.Properties.Settings.Default.Fecha.Year + 10); i++)
            {
                this.comboBox_AnioVencimiento.Items.Add(i.ToString());
            }

        }

        private bool CheckString(string toCheck, string Type)
        {
            string expresion;

            if (Type.Equals("NAME"))
            {
                expresion = "^[0-9]+$";
                if (Regex.Match(toCheck, expresion).Success)
                    return false;
                else
                    return true;
            }
            
            if (Type.Equals("CREDIT_CARD"))
            {
                expresion = "^[1-9][0-9]{15}$";
                if (Regex.Match(toCheck, expresion).Success)
                    return true;
                else
                    return false;
            }

            if (Type.Equals("SECURITY_CODE"))
            {
                expresion = "^[1-9][0-9]{2}$";
                if (Regex.Match(toCheck, expresion).Success)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool CheckFields()
        {
            if (textBox_Titular.Text.Equals(string.Empty))
            {
                MessageBox.Show("Titular no puede no contener datos",
                                "Falta nombre del titular",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }

            if (!CheckString(this.textBox_Titular.Text, "NAME"))
            {
                MessageBox.Show("El nombre y el apellido no pueden estar compuestos de numeros unicamente",
                                "Datos del Titular Incorrectos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }

            if (textBox_NroTarjeta.Text.Length != 16)
            {
                MessageBox.Show("Numero de Tarjeta con cantidad distinta.",
                                "Numero de Tarjeta Incorrecto",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }
            
            if (!CheckString(this.textBox_NroTarjeta.Text, "CREDIT_CARD"))
            {
                MessageBox.Show("Numero de Tarjeta debe contener unicamente numeros",
                                "Numero de Tarjeta Incorrecto",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }
            if (textBox_CodSeguridad.Text.Length != 3)
            {
                MessageBox.Show("Codigo de Seguridad debe tener 3 caracteres",
                                "Codigo de Seguridad Incorrecto",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }

            if (!CheckString(this.textBox_CodSeguridad.Text, "SECURITY_CODE"))
            {
                MessageBox.Show("Codigo de Seguridad debe contener solo numeros",
                                 "Codigo de Seguridad Incorrecto",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return false;
            }
            int Anio = Convert.ToInt32(comboBox_AnioVencimiento.Text);

            if (Anio == @FrbaHotel.Properties.Settings.Default.Fecha.Year)
            {
                int Mes = Convert.ToInt32(comboBox_MesVencimiento.Text);
                if (Mes < @FrbaHotel.Properties.Settings.Default.Fecha.Month)
                {
                    MessageBox.Show("Tarjeta de Credito Vencida",
                                    "Fecha de Vencimiento Incorrecta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand
                                    );
                    return false;
                }
            }

            return true;

        }
    }
}
