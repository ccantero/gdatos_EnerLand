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
    public partial class UserControl_Huesped : UserControl
    {
        public Boolean flag_Modificacion;
        public Huesped huesped_A_Modificar;
        
        public UserControl_Huesped()
        {
            InitializeComponent();
            CargarTipoDoc();
            flag_Modificacion = false;
        }

        public void Cargar_Huesped(Huesped unHuesped)
        {
            flag_Modificacion = true;            
            huesped_A_Modificar = unHuesped;
            
            if (unHuesped.idLocalidad != -1)
                Cargar_Localidad(unHuesped.idLocalidad);

            this.textBox_Apellido.Text = unHuesped.Apellido;
            this.textBox_Calle.Text = unHuesped.Calle;
            this.textBox_DNI.Text = unHuesped.Numero.ToString();
            this.textBox_mail.Text = unHuesped.Mail;
            this.textBox_Nacionalidad.Text = unHuesped.Nacionalidad;
            this.textBox_Name.Text = unHuesped.Nombre;
            this.textBox_Numero.Text = unHuesped.Numero.ToString();
            this.textBox_Piso.Text = unHuesped.Piso.ToString();
            if (unHuesped.Telefono != -1)
                this.textBox_Telefono.Text = unHuesped.Telefono.ToString();

            this.textBox_Departamento.Text = unHuesped.Departamento.ToString();

            this.ComboBox_TipoDoc.Text = unHuesped.Tipo_Documento;

            if (unHuesped.Habilitado)
                this.checkBox_Habilitado.CheckState = CheckState.Checked;
            else
                this.checkBox_Habilitado.CheckState = CheckState.Unchecked;
        }

        private void Cargar_Localidad(int idLocalidad)
        {
            DbResultSet rs;
            string myQuery = "SELECT DESCRIPCION FROM ENER_LAND.Localidad WHERE idLocalidad = " + idLocalidad.ToString();

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            this.textBox_Localidad.Text = rs.dataTable.Rows[0][0].ToString();

        }

        private void CargarTipoDoc()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT DISTINCT Tipo_Documento FROM ENER_LAND.Huesped");

            foreach (DataRow Row in rs.dataTable.Rows)
            {
                this.ComboBox_TipoDoc.Items.Add(Row[0].ToString().Trim());
            }

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (!Check_Unique_Mail())
                MessageBox.Show("Mail no es unico. Existe otro huesped con el mismo Mail. Verifique e intente nuevamente");
        }

        private void Button_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }

            this.Box_FecNac.Text = string.Empty;
            this.ComboBox_TipoDoc.Text = string.Empty;

        }

        private Boolean Check_Unique_Mail()
        {
            DbResultSet rs;

            if (flag_Modificacion)
            {
                rs = DbManager.GetDataTable("SELECT idHuesped FROM ENER_LAND.Huesped WHERE Mail = '" +
                                            this.textBox_mail.Text.Trim() + "'" +
                                            " AND idHuesped <> " + huesped_A_Modificar.idHuesped
                                            );

                if (rs.dataTable.Rows.Count == 0)
                    return true;
            };

            rs = DbManager.GetDataTable("SELECT idHuesped FROM ENER_LAND.Huesped WHERE Mail = '" + 
                                                    this.textBox_mail.Text.Trim() + "'"
                                                    );

            if (rs.dataTable.Rows.Count == 0)
                return true;


            return false;
        }
    }
}
