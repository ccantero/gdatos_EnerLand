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
        public int currentUser;
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

            if (!CheckFields())
                return; 

            if (this.button_Save.Text.Equals("Submit"))
            {
                idReserva = Convert.ToInt32(textBox_idReserva.Text);
                int idEstadia = DbManager.Process_CheckIn(idReserva, currentHotel, currentUser);

                if (idEstadia < 0)
                {
                    MessageBox.Show("No se pudo procesar el Check-In",
                                    "Reserva cancelada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                        return;
                }

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

                MessageBox.Show("Check-In Correcto");
                FormPadre.Show();
                this.Dispose();
                return;
            }


            if (this.button_Save.Text.Equals("Add Huesped"))
            {
                ABM_de_Cliente.GestionHuesped formBusqueda = new FrbaHotel.ABM_de_Cliente.GestionHuesped(this);
                formBusqueda.Show();
                formBusqueda.Cargar_Busqueda(false); // No es Busqueda Reserva
            }

            if (this.button_Save.Text.Equals("Check"))
            {
                myQuery = "SELECT DISTINCT idHotel " +
                          "FROM ENER_LAND.Reserva_Habitacion R " +
                          "WHERE R.idReserva = " + textBox_idReserva.Text + " " +
                          "AND R.idHotel = " + currentHotel.ToString();

                rs = DbManager.GetDataTable(myQuery);

                if (rs.operationState == 1)
                {
                    MessageBox.Show("Fallo en BD");
                    return;
                }

                if (rs.dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("La reserva no corresponde al hotel en el que se encuentra logueado.",
                                                "Hotel incorrecto",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                    return;
                }
                
                myQuery = "SELECT   R1.idReserva, " +
                                   "R1.idEstado_Reserva, " +
                                   "R1.Cantidad_Dias, " +
                                   "R1.Cantidad_Huespedes, " +
                                   "R1.FechaDesde, " +
                                   "R1.idHuesped, " +
                                   "H.Habilitado, " +
                                   "R2.Descripcion " +
                          "FROM ENER_LAND.Reserva R1, ENER_LAND.Regimen R2, ENER_LAND.Huesped H " +
                          "WHERE R1.idRegimen = R2.idRegimen " +
                          "AND H.idHuesped = R1.idHuesped " +
                          "AND R1.idReserva = " + textBox_idReserva.Text;

                rs = DbManager.GetDataTable(myQuery);

                if (rs.dataTable.Rows.Count == 1)
                {
                    int idEstado_Reserva;
                    int Cantidad_Dias;
                    int Cantidad_Huespedes;
                    int habilitado;
                    DateTime FechaDesde;
                    int idHuesped;
                    string Regimen_Descripcion;

                    idReserva = Convert.ToInt32(rs.dataTable.Rows[0]["idReserva"].ToString());
                    idEstado_Reserva = Convert.ToInt32(rs.dataTable.Rows[0]["idEstado_Reserva"].ToString());
                    Cantidad_Dias = Convert.ToInt32(rs.dataTable.Rows[0]["Cantidad_Dias"].ToString());
                    Cantidad_Huespedes = Convert.ToInt32(rs.dataTable.Rows[0]["Cantidad_Huespedes"].ToString());
                    FechaDesde = Convert.ToDateTime(rs.dataTable.Rows[0]["FechaDesde"].ToString());
                    idHuesped = Convert.ToInt32(rs.dataTable.Rows[0]["idHuesped"].ToString());
                    habilitado = Convert.ToInt32(rs.dataTable.Rows[0]["Habilitado"].ToString());
                    Regimen_Descripcion = rs.dataTable.Rows[0]["Descripcion"].ToString();

                    if (idEstado_Reserva == 3 || idEstado_Reserva == 4 || idEstado_Reserva == 5)
                    {
                        MessageBox.Show("La reserva no es correcta",
                                                "Reserva cancelada",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Hand);
                        return;
                    }

                    if (habilitado == 0)
                    {
                        MessageBox.Show("El Huesped se encuentra inhabilitado",
                                        "Huesped Incorrecto",
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

            Cargar_Huespedes();
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

        public void Cargar_Huespedes()
        {
            string myQuery;
            DbResultSet rs;
            Boolean flag = true;

            myQuery =   "SELECT idHuesped, Apellido, Nombre " +
                        "FROM ENER_LAND.Huesped ";
            
            foreach (int idHuesped in Huespedes)
	        {
		        if(flag)
                {
                    myQuery = myQuery + "WHERE idHuesped = " + idHuesped.ToString() + " ";
                    flag = false;
                }
                else
                    myQuery = myQuery + "OR idHuesped = " + idHuesped.ToString() + " ";
	        }


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

            this.dataGrid_Huespedes.Columns.Clear();
            this.dataGrid_Huespedes.AllowUserToAddRows = false;
            this.dataGrid_Huespedes.AllowUserToOrderColumns = false;

            this.dataGrid_Huespedes.DataSource = rs.dataTable;
            this.dataGrid_Huespedes.Visible = true;

            foreach (DataGridViewColumn column in dataGrid_Huespedes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column.HeaderText.Equals("Descripcion"))
                    column.Width = 175;
                else
                    column.Width = 75;
            }

            if (Huespedes.Count == Convert.ToInt32(textBox_CantHuespedes.Text))
            {
                button_Save.Text = "Submit";
            }
        
        }

        private void RegistrarEntrada_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPadre.Show();
            this.Dispose();
        }

        private bool CheckFields()
        {
            if (textBox_idReserva.Text.Equals(String.Empty))
            {
                MessageBox.Show("Numero de Reserva no puede ser vacio",
                                    "Numero de Reserva Incorrecto",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Hand
                                   );
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.Match(textBox_idReserva.Text, "^[1-9][0-9]+$").Success)
            {
                MessageBox.Show("Numero de Reserva debe contener unicamente numeros",
                                    "Numero de Reserva Incorrecto",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Hand
                                   );
                return false;
            }


            return true;

        }
    
    }
}
