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
    public partial class GestionHoteles : Form
    {
        public Form parentForm;
        public GestionHoteles(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        private void GestionHoteles_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            

            MessageBox.Show(parentForm.Text + "closing");
            parentForm.Hide();

            DbResultSet rs = DbManager.GetDataTable("SELECT IdPais, Nombre FROM ENER_LAND.Pais");

            DataRow drow = rs.dataTable.NewRow();

            drow[0] = -1;
            drow[1] = "";
            rs.dataTable.Rows.InsertAt(drow, 0);

             comboBox1.ValueMember = "idPais";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DataSource = rs.dataTable;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0 )
            {
                DbResultSet rs = DbManager.GetDataTable("SELECT idLocalidad, Nombre FROM ENER_LAND.Localidad ORDER BY Nombre ASC"/* WHERE + Join para obtener localidades en funcion de area padre, no necesario según alcance */);
                DataRow drow = rs.dataTable.NewRow();
                drow[0] = -1;
                drow[1] = "";
                rs.dataTable.Rows.InsertAt(drow, 0);
                comboBox2.ValueMember = "idLocalidad";
                comboBox2.DisplayMember = "Nombre";
                comboBox2.DataSource = rs.dataTable;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.Enabled = true;
            }
        }
    }
}
