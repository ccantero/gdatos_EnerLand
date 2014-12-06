using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Facturar
{
    public partial class Factura_Form : Form
    {
        private Form FormPadre;
        
        public Factura_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            DbResultSet rs;

            string myQuery =   "SELECT * " +
                               "FROM ENER_LAND.Item_Factura " +
                               "WHERE idFactura = 2396745 ";
            


            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            if (rs.dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado Usuarios");
                return;
            }

            this.dataGrid_ItemFactura.Columns.Clear();
            this.dataGrid_ItemFactura.AllowUserToAddRows = false;
            this.dataGrid_ItemFactura.AllowUserToOrderColumns = false;

            this.dataGrid_ItemFactura.DataSource = rs.dataTable;
            this.dataGrid_ItemFactura.Visible = true;

            this.dataGrid_ItemFactura.Columns["idFactura"].Visible = false;

            foreach (DataGridViewColumn column in dataGrid_ItemFactura.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if(column.HeaderText.Equals("Descripcion"))
                    column.Width = 175;
                else
                    column.Width = 75;
            }
        }
    }
}
