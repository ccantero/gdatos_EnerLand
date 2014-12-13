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
    public partial class BajaHabitacion : Form
    {
        public Form parentForm;
        private int idHotel;
        private int numeroHabitacion;

        public BajaHabitacion(Form parent, int p_idHotel, int p_idHabitacion)
        {
            this.parentForm = parent;
            this.idHotel = p_idHotel;
            this.numeroHabitacion = p_idHabitacion;
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
        { Int32 count;
           using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    
                    command.CommandText = " SELECT COUNT(1) "+
                                          " FROM ENER_LAND.Reserva res, ENER_LAND.Reserva_Habitacion hab "+
                                          " WHERE res.idReserva=hab.idReserva AND IdHotel=@idHotel AND hab.habitacion_numero=@numero"+
                                          " AND" +
                                          " ( res.FechaDesde BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                          " OR "+
                                          " DATEADD(DAY,Cantidad_dias,res.FechaDesde) BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                          " ) ";

                    command.Parameters.AddWithValue("@idHotel", idHotel);
                    command.Parameters.AddWithValue("@numero", numeroHabitacion );
                    command.Parameters.AddWithValue("@fechaDesde", dtpFechaInicioDeshabilitado.Value);
                    command.Parameters.AddWithValue("@cantDias", udDiasDeshabilitados.Value);
                     count = (Int32)command.ExecuteScalar();
                    if (count != 0)
                        MessageBox.Show("No se puede deshabilitar la habitación, reservas en curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           if (count == 0)
           {
               using (SqlConnection connection = DbManager.dbConnect())
               {
                   using (SqlCommand command = new SqlCommand())
                   {
                       command.Connection = connection;
                       command.CommandType = CommandType.Text;

                       command.CommandText = "SELECT COUNT(1) " +
                                             "FROM ENER_LAND.Reserva res, " +
                                             "ENER_LAND.Reserva_Habitacion hab,ENER_LAND.Estadias est " +
                                             "WHERE res.idReserva=hab.idReserva AND IdHotel=@idHotel AND hab.habitacion_numero = @numero " +
                                             "AND " +
                                             "( est.Fecha_Ingreso BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                             "OR " +
                                             "DATEADD(DAY,est.Cantidad_Dias,est.Fecha_Ingreso)  BETWEEN @fechaDesde AND DATEADD(DAY,@cantDias,@fechaDesde) " +
                                             ") " +
                                             "AND res.idReserva=est.idReserva ";

                       command.Parameters.AddWithValue("@idHotel", idHotel);
                       command.Parameters.AddWithValue("@numero", numeroHabitacion);
                       command.Parameters.AddWithValue("@fechaDesde", dtpFechaInicioDeshabilitado.Value);
                       command.Parameters.AddWithValue("@cantDias", udDiasDeshabilitados.Value);
                       count = (Int32)command.ExecuteScalar();
                       if (count != 0)
                           MessageBox.Show("No se puede deshabilitar la habitacion, estadias en curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
               }

           }
           if (count == 0)
           {
               //DbManager.dbSqlStatementExec("UPDATE ENER_LAND.Hotel SET Habilitado =0 WHERE idHotel=" +idHotel);
               
               using (SqlConnection connection = DbManager.dbConnect())
               {
                   using (SqlCommand command = new SqlCommand())
                   {
                       command.Connection = connection;
                       command.CommandType = CommandType.Text;

                       command.CommandText = "INSERT INTO ENER_LAND.Habitacion_Inhabilitada VALUES (@idHotel,@numero,@fechaInicio,@cantDias,@motivo)";

                       command.Parameters.AddWithValue("@idHotel", idHotel);
                       command.Parameters.AddWithValue("@numero", numeroHabitacion);
                       command.Parameters.AddWithValue("@fechaInicio", dtpFechaInicioDeshabilitado.Value);
                       command.Parameters.AddWithValue("@cantDias", udDiasDeshabilitados.Value);
                       command.Parameters.AddWithValue("@motivo", tbMotivo.Text);
                       command.ExecuteNonQuery();
                       
                       this.Close();
                       this.Dispose();
                   }
               }
           }
        }

        private void BajaHotel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentForm.Enabled = true;
        }
    }
}
