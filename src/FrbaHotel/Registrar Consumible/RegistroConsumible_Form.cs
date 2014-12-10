using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class RegistroConsumible_Form : Form
    {
        private Form FormPadre;
        public DataTable TablaConsumbiles = new DataTable();
        public int currentHotel;

        public RegistroConsumible_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void RegistroConsumible_Form_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormPadre.Hide();
            Cargar_Consumibles();
        }

        private void Cargar_Consumibles()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT * FROM ENER_LAND.Consumible");
            TablaConsumbiles = rs.dataTable;

            foreach (DataRow Row in TablaConsumbiles.Rows)
            {
                this.comboBox_Consumible.Items.Add(Row["Descripcion"].ToString().Trim());
            }
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string myQuery;
            DbResultSet rs;
            
            if (!Check_Estadia())
                return;

            int idConsumible = Convert.ToInt32(TablaConsumbiles.Rows[this.comboBox_Consumible.SelectedIndex]["idConsumible"].ToString());

            for (int i = 0; i < Box_Cantidad.Value; i++)
            {
                myQuery =   "INSERT INTO ENER_LAND.Consumible_Estadia (idEstadia, idConsumible) " +
                            "VALUES ( " + textBox_idEstadia.Text + ", " + idConsumible.ToString() + ")";

                rs = DbManager.dbSqlStatementExec(myQuery);
                if (rs.operationState == 1)
                {
                    MessageBox.Show("Falló la documentacion del Consumible");
                }
            }

            Cargar_DataGrid();
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

            comboBox_Consumible.Text = String.Empty;
            dataGrid_Consumibles.Columns.Clear();

            Box_Cantidad.Value = 1;
            textBox_idReserva.Select();
        }

        private void button_CheckReserva_Click(object sender, EventArgs e)
        {
            if (textBox_idReserva.Text.Equals(String.Empty))
                return;

            if (!System.Text.RegularExpressions.Regex.Match(textBox_idReserva.Text, "^[0-9]+$").Success)
            {
                MessageBox.Show("IdReserva no puede ser nulo ni contener caracteres no numéricos.",
                                "idReserva Incorrecto",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Hand
                               );
                return;
            }

            if (!Check_Estadia())
                return;
        }

        private Boolean Check_Estadia()
        {
            if (!DbManager.Check_Estadia(Convert.ToInt32(textBox_idReserva.Text), currentHotel))
                return false;

            string myQuery = "SELECT idEstadia, H.Apellido, H.Nombre, x1.Descripcion " +
                             "FROM ENER_LAND.Reserva R, ENER_LAND.Estadias E, ENER_LAND.Huesped H, ENER_LAND.Regimen x1 " +
                             "WHERE R.idReserva = E.idReserva " +
                             "AND R.idHuesped = H.idHuesped " +
                             "AND R.idRegimen = x1.idRegimen " +
                             "AND R.idReserva = " + textBox_idReserva.Text;
            
            DbResultSet rs = DbManager.GetDataTable(myQuery);


            if (rs.dataTable.Rows.Count != 1)
            {
                MessageBox.Show("ERROR en BD. No puede existir mas de un idEstadia para el mismo idReserva");
                return false;
            }

            textBox_idEstadia.Text = rs.dataTable.Rows[0]["idEstadia"].ToString();
            textBox_Huesped.Text = rs.dataTable.Rows[0]["Apellido"].ToString() + ", " + rs.dataTable.Rows[0]["Nombre"].ToString();
            textBox_Regimen.Text = rs.dataTable.Rows[0]["Descripcion"].ToString();

            Cargar_DataGrid();

            return true;

        }

        private void RegistroConsumible_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPadre.Show();
            this.Dispose();
        }

        private void comboBox_Consumible_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Precio = Convert.ToInt32(TablaConsumbiles.Rows[this.comboBox_Consumible.SelectedIndex]["Precio"].ToString());
            int Cantidad = Convert.ToInt32(Box_Cantidad.Value);

            this.textBox_Total.Text = (Precio * Cantidad).ToString();
        }

        private void Box_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (!this.comboBox_Consumible.Text.Equals(String.Empty))
            {
                int Precio = Convert.ToInt32(TablaConsumbiles.Rows[this.comboBox_Consumible.SelectedIndex]["Precio"].ToString());
                int Cantidad = Convert.ToInt32(Box_Cantidad.Value);

                this.textBox_Total.Text = (Precio * Cantidad).ToString();
            }
        }

        private void Cargar_DataGrid()
        {
            DbResultSet rs;
            string myQuery;
            
            myQuery =   "SELECT COUNT(1) Cantidad, C.Descripcion, C.Precio PrecioUnitario, SUM(C.Precio) Total " +
                        "FROM ENER_LAND.Consumible_Estadia CE, ENER_LAND.Consumible C " +
                        "WHERE CE.idConsumible = C.idConsumible " +
                        "AND CE.idEstadia = " + textBox_idEstadia.Text + " " +
                        "GROUP BY C.idConsumible, C.Descripcion, C.Precio";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
            {
                MessageBox.Show("Falló la busqueda");
                return;
            }

            this.dataGrid_Consumibles.Columns.Clear();
            this.dataGrid_Consumibles.AllowUserToAddRows = false;
            this.dataGrid_Consumibles.AllowUserToOrderColumns = false;

            this.dataGrid_Consumibles.DataSource = rs.dataTable;
            this.dataGrid_Consumibles.Visible = true;
        }

    }
}
