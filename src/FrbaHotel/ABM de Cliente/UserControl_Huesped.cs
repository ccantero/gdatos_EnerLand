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
        public UserControl_Huesped()
        {
            InitializeComponent();
            CargarTipoDoc();
        }


        public void Cargar_Huesped(Huesped unHuesped)
        {
            if(unHuesped.idLocalidad != -1)
                Cargar_Localidad(unHuesped.idLocalidad);

            this.textBox_Apellido.Text = unHuesped.Apellido;
            this.textBox_Calle.Text = unHuesped.Calle;
            this.textBox_DNI.Text = unHuesped.Numero.ToString();
            this.textBox_mail.Text = unHuesped.Mail;
            this.textBox_Nacionalidad.Text = unHuesped.Nacionalidad;
            this.textBox_Name.Text = unHuesped.Nombre;
            this.textBox_Numero.Text = unHuesped.Numero.ToString();
            this.textBox_Piso.Text = unHuesped.Piso.ToString();
            this.textBox_Telefono.Text = unHuesped.Telefono.ToString();
            this.textBox_Departamento.Text = unHuesped.Departamento.ToString();

            this.ComboBox_TipoDoc.Text = unHuesped.Tipo_Documento;
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
    }
}
