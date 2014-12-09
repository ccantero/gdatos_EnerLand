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
    public partial class RegistrarEntrada_Form : Form
    {
        private Form FormPadre;
        public int currentHotel;
        public List<int> Huespedes = new List<int>();
        
        public RegistrarEntrada_Form(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void RegistrarEntrada_Form_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FormPadre.Hide();
            box_FechaIngreso.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
            button_Save.Text = "Check";
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string myQuery;
            DbResultSet rs;
            int idReserva;

            if (this.button_Save.Text.Equals("Submit"))
            {
                idReserva = Convert.ToInt32(textBox_idReserva.Text);
                int idEstadia = DbManager.Process_CheckIn(idReserva);

                foreach (int Huesped in Huespedes)
                {
                    myQuery =   "INSERT INTO ENER_LAND.Huespedes_Alojados (idEstadia, idHuesped) " +
                                "VALUES (" + idEstadia.ToString() + ", " + Huesped.ToString() + ")";

                    rs = DbManager.dbSqlStatementExec(myQuery);
                    if (rs.operationState == 1)
                    {
                        MessageBox.Show("No se pudo Agregar el Huesped. Posible fallo en la Base de Datos");
                        return;
                    }

                }
            }


            if (this.button_Save.Text.Equals("Add Huesped"))
            {
                ABM_de_Cliente.GestionHuesped formBusqueda = new FrbaHotel.ABM_de_Cliente.GestionHuesped(this);
                formBusqueda.Cargar_Busqueda();
                formBusqueda.Show();

                if (Huespedes.Count == Convert.ToInt32(textBox_CantHuespedes.Text))
                {
                    button_Save.Text = "Submit";
                }
            }


            if (this.button_Save.Text.Equals("Check"))
            {
                myQuery = "SELECT   R1.idReserva, " +
                                   "R1.idEstado_Reserva, " +
                                   "R1.Cantidad_Dias, " +
                                   "R1.Cantidad_Huespedes, " +
                                   "R1.FechaDesde, " +
                                   "R1.idHuesped, " +
                                   "R2.Descripcion " +
                          "FROM ENER_LAND.Reserva R1, ENER_LAND.Regimen R2 " +
                          "WHERE R1.idRegimen = R2.idRegimen " +
                          "AND R.idReserva = " + textBox_idReserva.Text;

                rs = DbManager.GetDataTable(myQuery);

                if (rs.dataTable.Rows.Count == 1)
                {
                    int idEstado_Reserva;
                    int Cantidad_Dias;
                    int Cantidad_Huespedes;
                    DateTime FechaDesde;
                    int idHuesped;
                    string Regimen_Descripcion;

                    button_Save.Text = "Submit";

                    idReserva = Convert.ToInt32(rs.dataTable.Rows[0]["idReserva"].ToString());
                    idEstado_Reserva = Convert.ToInt32(rs.dataTable.Rows[0]["idEstado_Reserva"].ToString());
                    Cantidad_Dias = Convert.ToInt32(rs.dataTable.Rows[0]["Cantidad_Dias"].ToString());
                    Cantidad_Huespedes = Convert.ToInt32(rs.dataTable.Rows[0]["Cantidad_Huespedes"].ToString());
                    FechaDesde = Convert.ToDateTime(rs.dataTable.Rows[0]["FechaDesde"].ToString());
                    idHuesped = Convert.ToInt32(rs.dataTable.Rows[0]["idHuesped"].ToString());
                    Regimen_Descripcion = rs.dataTable.Rows[0]["Descripcion"].ToString();

                    if (idEstado_Reserva == 3 || idEstado_Reserva == 4 || idEstado_Reserva == 5)
                    {
                        MessageBox.Show("La reserva no es correcta",
                                                "Reserva cancelada",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                        return;
                    }

                    textBox_CantHuespedes.Text = Cantidad_Huespedes.ToString();
                    textBox_CantidadDias.Text = Cantidad_Dias.ToString();
                    textBox_Regimen.Text = Regimen_Descripcion;

                    if (!FechaDesde.Equals(@FrbaHotel.Properties.Settings.Default.Fecha))
                    {
                        MessageBox.Show("La fecha de la reserva no es correcta",
                                        "Fecha erronea",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Hand);
                        return;
                    }

                    if (Cantidad_Huespedes > 1)
                    {
                        button_Save.Text = "Add Huesped";
                    }
                    else
                    {
                        button_Save.Text = "Submit";
                    }

                    Huespedes.Add(idHuesped);
                }
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

            box_FechaIngreso.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
        }

        private void textBox_idReserva_TextChanged(object sender, EventArgs e)
        {
            if (button_Save.Text == "Submit")
                button_Save.Text = "Check";
        }

        private void Cargar_Huespedes()
        {
            /* 
            myQuery =   "SELECT x1.*, x2.Total " +
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
                if (column.HeaderText.Equals("Descripcion"))
                    column.Width = 175;
                else
                    column.Width = 75;
            }
            */
        
        }

        private void RegistrarEntrada_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPadre.Show();
            this.Dispose();
        }
    }
}
