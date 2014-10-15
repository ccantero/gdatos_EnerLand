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
            

            MessageBox.Show(cmbHoteles.SelectedIndex.ToString());
            parentForm.Hide();

            DbResultSet rs = DbManager.GetDataTable("SELECT IdPais, Nombre FROM ENER_LAND.Pais");

            DataRow drow = rs.dataTable.NewRow();

            drow[0] = -1;
            drow[1] = "";
            rs.dataTable.Rows.InsertAt(drow, 0);

            cmbPaises.ValueMember = "idPais";
            cmbPaises.DisplayMember = "Nombre";
            cmbPaises.DataSource = rs.dataTable;

            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidades.DropDownStyle = ComboBoxStyle.DropDown;
            cmbEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;

            getRegimenes();
        }

        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedIndex != 0 )
            {
                DbResultSet rs = DbManager.GetDataTable("SELECT idLocalidad, Nombre FROM ENER_LAND.Localidad ORDER BY Nombre ASC"/* WHERE + Join para obtener localidades en funcion de area padre, no necesario según alcance */);
                DataRow drow = rs.dataTable.NewRow();
                drow[0] = -1;
                drow[1] = "";
                rs.dataTable.Rows.InsertAt(drow, 0);
                cmbLocalidades.ValueMember = "idLocalidad";
                cmbLocalidades.DisplayMember = "Nombre";
                cmbLocalidades.DataSource = rs.dataTable;
                cmbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbLocalidades.Enabled = true;
            }
            refreshHoteles(sender, e);
        }

        private void GestionHoteles_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentForm.Show();
        }

        private void cmbCiudades_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (cmbLocalidades.SelectedIndex != 0)
                cmbEstrellas.Enabled = true;

            refreshHoteles(sender, e);

       }

        private void cmbEstrellas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            refreshHoteles(sender,e);

        }

        private void refreshHoteles(object sender, EventArgs e)
        {
            String query;

            query = "SELECT idHotel,RTRIM(Nombre) Nombre FROM ENER_LAND.Hotel WHERE 1=1 ";
            
            if (cmbPaises.SelectedIndex > 0)
                query += " AND idPais = " + cmbPaises.SelectedValue;
            if (cmbLocalidades.SelectedIndex > 0)
                query += " AND idLocalidad = " + cmbLocalidades.SelectedValue;
            if (cmbEstrellas.SelectedIndex > 0)
                query +=" AND Cantidad_Estrellas = " + cmbEstrellas.Text;

            query += " ORDER BY Nombre ASC";

            DbResultSet rs = DbManager.GetDataTable(query);
            DataRow drow = rs.dataTable.NewRow();
            drow[0] = -1;
            drow[1] = "";
            rs.dataTable.Rows.InsertAt(drow, 0);
            cmbHoteles.ValueMember = "idHotel";
            cmbHoteles.DisplayMember = "Nombre";
            cmbHoteles.DataSource = rs.dataTable;
            cmbHoteles.DropDownStyle = ComboBoxStyle.DropDown;
            cmbHoteles.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPaises.SelectedIndex = 0;
            cmbLocalidades.SelectedIndex = 0;
            cmbEstrellas.SelectedIndex = -1;
        }

        private void getRegimenes()
        {
            clbRegimenes.Items.Clear();
            DbResultSet rs = DbManager.GetDataTable("SELECT idRegimen,Descripcion,CASE WHEN  (SELECT rh.idRegimen FROM ENER_LAND.Regimen_Hotel rh WHERE rh.idHotel=" + cmbHoteles.SelectedIndex + " AND rh.idRegimen=r.idRegimen) >0 THEN 1 ELSE 0 END  CHECKED FROM ENER_LAND.Regimen r");
            foreach(DataRow row in rs.dataTable.Rows){
                CheckState status;
                
                if (row.Field<Int32>(2) > 0)
                    status = CheckState.Checked;
                else
                    status = CheckState.Unchecked;

               clbRegimenes.Items.Add(row[1].ToString(), status);
            }
                
        }

        private void cmbHoteles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getRegimenes();
        }

    }
}
