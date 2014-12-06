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
        public DataTable TablaFormasDePago = new DataTable();
        public DataTable TablaReservas = new DataTable();
        public ABM_de_Cliente.Huesped Huesped = new FrbaHotel.ABM_de_Cliente.Huesped();
        
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

        private void button_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }

            this.comboBox_FormaDePago.Text = String.Empty;
        
        }

        private void Factura_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPadre.Show();
            this.Dispose();
        }

        private void Factura_Form_Load(object sender, EventArgs e)
        {

            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormPadre.Hide();
            Cargar_FormasDePago();

            this.box_FechaDesde.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
            this.Box_FechaHasta.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
        }

        private void Cargar_FormasDePago()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT * FROM ENER_LAND.Forma_de_Pago");
            TablaFormasDePago = rs.dataTable;

            foreach (DataRow Row in TablaFormasDePago.Rows)
            {
                this.comboBox_FormaDePago.Items.Add(Row["Descripcion"].ToString().Trim());
            }
        }

        private void button_CheckReserva_Click(object sender, EventArgs e)
        {

            if (!DbManager.Check_Reserva(Convert.ToInt32(textBox_idReserva.Text)))
                return;


            

            string myQuery =    "SELECT * " +
                                "FROM ENER_LAND.Reserva " +
                                "WHERE idReserva = " + textBox_idReserva.Text;

            DbResultSet rs = DbManager.GetDataTable(myQuery);
            TablaReservas = rs.dataTable;

            if(TablaReservas.Rows.Count != 1)
            {
                MessageBox.Show("ERROR en BD.");
                return;
            }
            


        }
    }
}
