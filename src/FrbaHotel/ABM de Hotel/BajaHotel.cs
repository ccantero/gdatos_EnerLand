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
    public partial class BajaHotel : Form
    {
        public Form parentForm;
        private int idHotel;

        public BajaHotel(Form parent, int p_idHotel)
        {
            this.parentForm = parent;
            this.idHotel = p_idHotel;
            InitializeComponent();
        }

        private void BajaHotel_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dtpFechaInicioDeshabilitado.CustomFormat = "dd-MM-yyyy";
            dtpFechaInicioDeshabilitado.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {   
            Int32 count;
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                   command.Connection = connection;
                   command.CommandType = CommandType.Text;
                   /*
                   command.CommandText = "SELECT COUNT(1) " +
                                         "FROM ENER_LAND.Reserva res, " +
                                         "ENER_LAND.Reserva_Habitacion RH, ENER_LAND.Reservas R " +
                                         "WHERE rr.idReserva=rh.idReserva " +
                                         "AND rh.IdHotel=@idHotel " +
                                         "AND " +
                                         "( est.Fecha_Ingreso BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                         "OR " +
                                         "DATEADD(DAY,est.Cantidad_Dias,est.Fecha_Ingreso)  BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                         ") " +
                                         "AND res.idReserva=est.idReserva ";
                   */
                   command.CommandText = "SELECT COUNT(1) " +
                                         "FROM ENER_LAND.Reserva R, ENER_LAND.Reserva_Habitacion RH " +
                                         "WHERE R.idReserva = RH.idReserva " +
                                         "AND RH.IdHotel = @idHotel " +
                                         "AND R.idEstado_Reserva IN ( 1, 2, 6 ) " +
                                         "AND ( " +
	                                     "@FechaBaja BETWEEN R.FechaDesde AND DATEADD(d, Cantidad_Dias, R.FechaDesde) " +
                                         "OR	DATEADD(d, @CantDiasBaja, @FechaBaja) BETWEEN R.FechaDesde AND DATEADD(d, Cantidad_Dias, R.FechaDesde) " +
                                         "OR	R.FechaDesde BETWEEN @FechaBaja AND DATEADD(d, @CantDiasBaja, @FechaBaja) " +
                                         ") ";

                   command.Parameters.AddWithValue("@idHotel", idHotel);
                   command.Parameters.AddWithValue("@FechaBaja", dtpFechaInicioDeshabilitado.Value);
                   command.Parameters.AddWithValue("@CantDiasBaja", udDiasDeshabilitados.Value);
                   count = (Int32)command.ExecuteScalar();
                   if (count != 0)
                       MessageBox.Show("No se puede deshabilitar el hotel, reservas en curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
                if (count == 0)
                {              
                    using (SqlCommand command = new SqlCommand())
                    {
                       command.Connection = connection;
                       command.CommandType = CommandType.Text;

                       command.CommandText = "INSERT INTO ENER_LAND.Hotel_Inhabilitado VALUES (@idHotel,@fechaInicio,@cantDias,@motivo)";

                       command.Parameters.AddWithValue("@idHotel", idHotel);
                       command.Parameters.AddWithValue("@fechaInicio", dtpFechaInicioDeshabilitado.Value);
                       command.Parameters.AddWithValue("@cantDias", udDiasDeshabilitados.Value);
                       command.Parameters.AddWithValue("@motivo", tbMotivo.Text);
                       command.ExecuteNonQuery();

                       parentForm.Show();
                       this.Close();
                       this.Dispose();
                    }
                }
            }
        }

        private void BajaHotel_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
            this.Dispose();
        }
    }
}
