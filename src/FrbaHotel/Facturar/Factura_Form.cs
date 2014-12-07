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
        public int currentHotel;
        
        public Factura_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            DbResultSet rs;

            if (!Check_Reserva())
                return;

            if (comboBox_FormaDePago.Text.Equals(String.Empty))
                return;

            int idEstadia = Convert.ToInt32(this.textBox_idEstadia.Text);

            DataRow[] Rows = TablaFormasDePago.Select("Descripcion = '" + this.comboBox_FormaDePago.Text.ToString().Trim() + "'");
            int idPago = Convert.ToInt32(Rows[0][0].ToString().Trim());


            DbManager.Facturar_Estadia(idEstadia, idPago);

            string myQuery =    "SELECT x1.*, x2.Total " +
                                "FROM ENER_LAND.Item_Factura x1, ENER_LAND.Factura x2 " +
                                "WHERE x1.idFactura = x2.idFactura " +
                                "AND x2.idEstadia = " + idEstadia.ToString();

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
            {
                MessageBox.Show("Falló la busqueda");
                return;
            }
            if (rs.dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado datos");
                return;
            }

            textBox_FacturaNro.Text = rs.dataTable.Rows[0]["idFactura"].ToString();
            textBox_Total.Text = rs.dataTable.Rows[0]["Total"].ToString();

            this.dataGrid_ItemFactura.Columns.Clear();
            this.dataGrid_ItemFactura.AllowUserToAddRows = false;
            this.dataGrid_ItemFactura.AllowUserToOrderColumns = false;

            this.dataGrid_ItemFactura.DataSource = rs.dataTable;
            this.dataGrid_ItemFactura.Visible = true;

            this.dataGrid_ItemFactura.Columns["idFactura"].Visible = false;
            this.dataGrid_ItemFactura.Columns["Total"].Visible = false;

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

            this.dataGrid_ItemFactura.Columns.Clear();
            this.box_FechaDesde.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
            this.Box_FechaHasta.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
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
            if (textBox_idReserva.Text.Equals(String.Empty))
                return;

            if (!Check_Reserva())
                return;
            
        }

        private Boolean Check_Reserva()
        {
            if (!DbManager.Check_Reserva(Convert.ToInt32(textBox_idReserva.Text), currentHotel))
                return false;

            string myQuery = "SELECT idEstadia, H.Apellido, H.Nombre, E.Fecha_Ingreso, E.Cantidad_Dias " +
                                "FROM ENER_LAND.Reserva R, ENER_LAND.Estadias E, ENER_LAND.Huesped H " +
                                "WHERE R.idReserva = E.idReserva " +
                                "AND R.idHuesped = H.idHuesped " +
                                "AND R.idReserva = " + textBox_idReserva.Text;

            DbResultSet rs = DbManager.GetDataTable(myQuery);

            if (rs.dataTable.Rows.Count != 1)
            {
                MessageBox.Show("ERROR en BD. No puede existir mas de un idEstadia para el mismo idReserva");
                return false;
            }

            textBox_idEstadia.Text = rs.dataTable.Rows[0]["idEstadia"].ToString();
            textBox_Huesped.Text = rs.dataTable.Rows[0]["Apellido"].ToString() + ", " + rs.dataTable.Rows[0]["Nombre"].ToString();

            box_FechaDesde.Value = Convert.ToDateTime(rs.dataTable.Rows[0]["Fecha_Ingreso"].ToString());
            Box_FechaHasta.Value = box_FechaDesde.Value.AddDays(Convert.ToDouble(rs.dataTable.Rows[0]["Cantidad_Dias"].ToString()));

            return true;
        
        }
      
    }
}
