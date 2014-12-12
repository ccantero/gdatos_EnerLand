using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class GestionHabitacion : Form
    {
        int idHotel;
        String hotelDesc;
        DataGridViewRow habitacion;
        int numHabitacion;
        ABM_de_Hotel.GestionHoteles parentForm;

        int optype;
        public GestionHabitacion(ABM_de_Hotel.GestionHoteles parent, int inIdHotel, String inHotelDesc)
        {
            idHotel = inIdHotel;
            hotelDesc = inHotelDesc;
            InitializeComponent();
            this.CenterToScreen();
            parentForm = parent;
            parent.Enabled = false;
            lblHotel.Text = hotelDesc;
            getTipos();
            optype = 0; //alta
        }

        public GestionHabitacion(ABM_de_Hotel.GestionHoteles parent, int inIdHotel, String inHotelDesc, DataGridViewRow inHabitacion)
        {
            idHotel = inIdHotel;
            hotelDesc = inHotelDesc;
            habitacion = inHabitacion;
            InitializeComponent();
            this.CenterToScreen();
            parentForm = parent;
            parent.Enabled = false;
            lblHotel.Text = hotelDesc;
            getTipos();
            tbNumHabitacion.Text = habitacion.Cells[0].Value.ToString();
            cbTipoHabitacion.SelectedValue = habitacion.Cells[1].Value;
            tbPisoHabitacion.Text = habitacion.Cells[3].Value.ToString();

            if (habitacion.Cells[4].Value.ToString() == "Contrafrente")
                cbUbicacionHab.SelectedIndex = 0;
            else
                cbUbicacionHab.SelectedIndex = 1;
            tbDescHabitacion.Text = habitacion.Cells[5].Value.ToString();

            optype = 1; //modificacion
            cbTipoHabitacion.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            DbResultSet rs = DbManager.dbGetInt("SELECT COUNT(1) FROM ENER_LAND.Habitacion WHERE idHotel = " + idHotel + " AND Numero = " + tbNumHabitacion.Text + " AND Numero != " + habitacion.Cells[0].Value.ToString());

            if (rs.intValue == 0)
            {
                char tipoUbicacion;

                if (cbUbicacionHab.Text == "Contrafrente")
                    tipoUbicacion = 'N';
                else tipoUbicacion = 'S';
                using (SqlConnection connection = DbManager.dbConnect())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        if (optype == 0)
                        {
                            command.CommandText = "INSERT INTO ENER_LAND.Habitacion " +
                                                  "VALUES (@numHab,@idHotel,@tipo,@piso,@ubicacion,@desc,0)";
                            command.Parameters.AddWithValue("@numHab", tbNumHabitacion.Text);
                            command.Parameters.AddWithValue("@idHotel", idHotel);
                            command.Parameters.AddWithValue("@tipo", cbTipoHabitacion.SelectedValue);
                            command.Parameters.AddWithValue("@piso", tbPisoHabitacion.Text);
                            command.Parameters.AddWithValue("@ubicacion", tipoUbicacion);
                            command.Parameters.AddWithValue("@desc", tbDescHabitacion.Text);
                        }
                        else
                        {
                            command.CommandText = "UPDATE ENER_LAND.Habitacion " +
                                                  "SET Numero = @numHab , " +
                                                  "idTipo_Habitacion = @tipo , " +
                                                  "Piso = @piso , " +
                                                  "Ubicacion =  @ubicacion ," +
                                                  "Descripcion = @desc " +
                                                  "WHERE IdHotel = @idHotel " +
                                                  "AND Numero = @prevNumHab";
                            command.Parameters.AddWithValue("@numHab", tbNumHabitacion.Text);
                            command.Parameters.AddWithValue("@tipo", cbTipoHabitacion.SelectedValue);
                            command.Parameters.AddWithValue("@piso", tbPisoHabitacion.Text);
                            command.Parameters.AddWithValue("@ubicacion", tipoUbicacion);
                            command.Parameters.AddWithValue("@desc", tbDescHabitacion.Text);
                            command.Parameters.AddWithValue("@idHotel", idHotel);
                            command.Parameters.AddWithValue("@prevNumHab", habitacion.Cells[0].Value);
                        }

                        int recordsAffected = command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
                this.Close();
                this.Dispose();
                
            }
            else
                MessageBox.Show("Error al impactar cambios, el numero de habitación ingresado ya se encuentra registrado.", "ABM Habitaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Dispose();
        }

        private void getTipos()
        {

            String query;

            query = "SELECT idTipo_Habitacion idTipo,Descripcion FROM ENER_LAND.Tipo_Habitacion";

            query += " ORDER BY Descripcion ASC";

            DbResultSet rs = DbManager.GetDataTable(query);
            DataRow drow = rs.dataTable.NewRow();
            rs.dataTable.Rows.InsertAt(drow, 0);
            cbTipoHabitacion.ValueMember = "idTipo";
            cbTipoHabitacion.DisplayMember = "Descripcion";
            cbTipoHabitacion.DataSource = rs.dataTable;
            cbTipoHabitacion.DropDownStyle = ComboBoxStyle.DropDown;
            cbTipoHabitacion.Enabled = true;

        }

        private void GestionHabitacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Enabled = true;
        }

        private void tbdigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
