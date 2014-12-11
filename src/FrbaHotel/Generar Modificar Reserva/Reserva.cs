using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Reserva : Form
    {
        public Form parentForm;
        public int operationType;
        public const int opCancelarReserva = 0;
        public const int opNuevaReserva = 1;
        public const int opModificarReserva = 2;
        private DataTable dtHabReserva;

        public Reserva(Form parent, int opType)
        {
            this.parentForm = parent;
            this.operationType = opType;
            InitializeComponent();
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dtpFechaDesde.CustomFormat = "dd-MM-yyyy";
            dtpFechaHasta.CustomFormat = "dd-MM-yyyy";
            obtenerRegimenesBusqueda();
            switch (this.operationType)
            {
                case opCancelarReserva: { cancelarReserva(); break; }
                case opNuevaReserva: { nuevaReserva(); break; }
                case opModificarReserva: { modificarReserva(); break; }
                default:break;

            }
            
        }

        private void cancelarReserva()
        {
            tbCodReserva.Visible = true;
            lblCodReserva.Visible = true;
            btnReserva.Visible = true;
        }

        private void nuevaReserva()
        {
            tbCodReserva.Visible = false;
            lblCodReserva.Visible = false;
            btnReserva.Visible = false; 
            
        }

        private void modificarReserva()
        {
            tbCodReserva.Visible = true;
            lblCodReserva.Visible = true;
            btnReserva.Visible = true;
        }

        private void obtenerRegimenesBusqueda()
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT r.idRegimen,r.Descripcion + ' ($' + CONVERT(VARCHAR(100),r.precio) + ')' descripcion " +
                    "FROM ENER_LAND.Regimen r " +
                    "WHERE r.Habilitado = 1";

                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    DataRow drow = dt.NewRow();
                    drow[0] = -1;
                    drow[1] = "";
                    dt.Rows.InsertAt(drow, 0);
                    cmbRegimenHotelRes.ValueMember = "idRegimen";
                    cmbRegimenHotelRes.DisplayMember = "descripcion";
                    cmbRegimenHotelRes.DataSource = dt;
                    cmbRegimenHotelRes.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbRegimenHotelRes.Enabled = true;
                }
            }
        }

        private void obtenerHotelesDisponibles(int cantHuespuedes, int ultimoHotelReserva)
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = " SELECT ht.idHotel,RTRIM(ht.Nombre) + ' | ' + ht.Calle + ' ' + CONVERT(VARCHAR(50),ht.Numero) + ' - ' + RTRIM(loc.Nombre) + ', ' + ps.Nombre + ' (' + CONVERT(VARCHAR(5),ht.Cantidad_Estrellas) + '*)' Hotel" +
                    " FROM ENER_LAND.Habitacion hab , ENER_LAND.Tipo_Habitacion thab, ENER_LAND.Hotel ht, ENER_LAND.Localidad loc, ENER_LAND.Pais ps" +
                    " WHERE hab.Habilitado = 1" +
                    " AND (ht.idHotel = @hotelAnterior OR EXISTS (" +
                    " SELECT 1" +
                    " FROM ENER_LAND.Reserva res, ENER_LAND.Reserva_Habitacion rhab" +
                    " WHERE res.idReserva=rhab.idReserva" +
                    "  AND NOT (@fechaResDesde BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde)" +
                    "       OR " + 
                    "       @fechaResHasta BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde))" +
                    "  AND rhab.idHotel=hab.idHotel" +
                    "  AND hab.numero=rhab.Habitacion_numero " + 
                    " ))" +
                    " AND hab.idTipo_Habitacion=thab.idTipo_Habitacion" +
                    " AND hab.IdHotel=ht.idHotel" +
                    " AND ht.idLocalidad=loc.idLocalidad" +
                    " AND ht.idPais=ps.idPais" +
                    " GROUP BY ht.idHotel,ht.Nombre,ht.Calle,ht.Numero,ps.Nombre,loc.Nombre,ht.Cantidad_Estrellas" +
                    " HAVING SUM(CASE hab.idTipo_Habitacion WHEN 1 THEN 0  ELSE hab.idTipo_habitacion % 1000 END)>=" + cantHuespuedes +
                    " ORDER BY 1,2 ASC";

                    command.Parameters.AddWithValue("@hotelAnterior", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@fechaResDesde", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@fechaResHasta", dtpFechaHasta.Value);
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    DataRow drow = dt.NewRow();
                    cmbHotelesDisponibles.ValueMember = "idHotel";
                    cmbHotelesDisponibles.DisplayMember = "hotel";
                    cmbHotelesDisponibles.DataSource = dt;
                    cmbHotelesDisponibles.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbHotelesDisponibles.Enabled = true;
                }
            }
        }

        private void obtenerHabitacionesDisponibles()
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = " SELECT hab.idTipo_Habitacion,thab.Descripcion + ' - Capacidad: ' + CONVERT(VARCHAR(5),CASE hab.idTipo_Habitacion WHEN 1 THEN 0  ELSE hab.idTipo_habitacion % 1000 END) + ' p.' Descripcion, COUNT(1) Disponibles" +
                    " FROM ENER_LAND.Habitacion hab , ENER_LAND.Tipo_Habitacion thab, ENER_LAND.Hotel ht" +
                    " WHERE hab.Habilitado = 1" +
                    " AND NOT EXISTS (" +
                    " SELECT 1" +
                    " FROM ENER_LAND.Reserva res, ENER_LAND.Reserva_Habitacion rhab" +
                    " WHERE res.idEstado_reserva = 1 " +
                    " AND res.idReserva=rhab.idReserva" +
                    " AND (@fechaResDesde BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde)" +
                    " OR @fechaResHasta BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde))" +
                    " AND rhab.idHotel=hab.idHotel" +
                    " AND rhab.Habitacion_numero = hab.numero" +
                    " )" +
                    " AND hab.idTipo_Habitacion=thab.idTipo_Habitacion" +
                    " AND hab.IdHotel=ht.idHotel" +
                    " AND hab.IdHotel= @idHotel " +
                    " GROUP BY ht.idHotel,ht.Nombre,ht.Calle,ht.Numero,hab.idTipo_Habitacion,thab.Descripcion";

                    command.Parameters.AddWithValue("@fechaResDesde", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@fechaResHasta", dtpFechaHasta.Value);
                    command.Parameters.AddWithValue("@idHotel", cmbHotelesDisponibles.SelectedValue);
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    dgvHabDisponibles.DataSource = dt;
                    dgvHabDisponibles.Columns[0].Visible = false;



                }
            }
        }


        private void btnReserva_Click(object sender, EventArgs e)
        {
            DbResultSet rs = DbManager.dbGetInt("SELECT COUNT(1) FROM ENER_LAND.Reserva WHERE idReserva = " + tbCodReserva.Text);

            if (rs.intValue > 0)
            {
                rs = DbManager.GetDataTable("SELECT DISTINCT  idRegimen,FechaDesde, DATEADD(DAY, Cantidad_Dias, FechaDesde) AS FechaHasta, x1.IdHotel ,x0.cantidad_huespedes " + 
                                               "FROM ENER_LAND.Reserva x0, ENER_LAND.Reserva_Habitacion x1 "+ 
                                              "WHERE x0.idReserva = x1.idReserva " + 
                                                "AND x0.idReserva = " + tbCodReserva.Text);
                dtpFechaDesde.Value = rs.dataTable.Rows[0].Field<DateTime>(1);
                 dtpFechaHasta.Value = rs.dataTable.Rows[0].Field<DateTime>(2);
                 udCantHuespedes.Value =rs.dataTable.Rows[0].Field<Int32>(4);
                 obtenerRegimenesBusqueda();
                 cmbRegimenHotelRes.SelectedValue =  rs.dataTable.Rows[0].Field<Int32>(0);

                 obtenerHotelesDisponibles((int)udCantHuespedes.Value, rs.dataTable.Rows[0].Field<Int32>(3));
                 cmbHotelesDisponibles.SelectedValue = rs.dataTable.Rows[0].Field<Int32>(3);
                 obtenerRegimenesEnHotel();
                 cmbRegHotel.SelectedValue = cmbRegimenHotelRes.SelectedValue;
                 obtenerHabitacionesDisponibles();
                 obtenerHabitacionesReservaDB();
                 updateTotalReserva();
            }
        }

        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {
            obtenerHotelesDisponibles((int)udCantHuespedes.Value,0);
        }

        private void obtenerRegimenesEnHotel()
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT r.idRegimen,r.Descripcion + ' ($' + CONVERT(VARCHAR(100),r.precio) + ')' descripcion " +
                    "FROM ENER_LAND.Regimen_Hotel rh, ENER_LAND.Regimen r " +
                    "WHERE r.idRegimen=rh.idRegimen " +
                    "AND rh.idHotel=@idHotel " +
                    "AND r.Habilitado = 1";

                    command.Parameters.AddWithValue("@idHotel", cmbHotelesDisponibles.SelectedValue);
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    DataRow drow = dt.NewRow();
                    drow[0] = -1;
                    drow[1] = "";
                    dt.Rows.InsertAt(drow, 0);
                    cmbRegHotel.ValueMember = "idRegimen";
                    cmbRegHotel.DisplayMember = "descripcion";
                    cmbRegHotel.DataSource = dt;
                    cmbRegHotel.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbRegHotel.Enabled = true;
                }
            }
            if ((int)cmbRegimenHotelRes.SelectedValue > 0)
                cmbRegHotel.SelectedValue = cmbRegimenHotelRes.SelectedValue;
        }
        private void cmbHotelesDisponibles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obtenerRegimenesEnHotel();
            obtenerHabitacionesDisponibles();

            dtHabReserva = new DataTable();

            dtHabReserva.Columns.Add("tipoHab", typeof(int));
            dtHabReserva.Columns.Add("Descripcion", typeof(String));
            dtHabReserva.Columns.Add("Cantidad", typeof(int));
            dtHabReserva.Columns.Add("Disponibles", typeof(int));
            dgvHabitacionesReserva.DataSource = dtHabReserva;
            dgvHabitacionesReserva.Columns[0].Visible = false;

        }

        private void btnAgregarTipoHabitacion_Click(object sender, EventArgs e)
        {
            int found = 0;
            for (int i = 0; i < dgvHabitacionesReserva.Rows.Count; i++)
            {
                if ((int)dgvHabitacionesReserva.Rows[i].Cells[0].Value == (int)dgvHabDisponibles.SelectedRows[0].Cells[0].Value)
                {
                    if ((int)dgvHabDisponibles.SelectedRows[0].Cells[2].Value > (int)dgvHabitacionesReserva.Rows[i].Cells[2].Value)
                    {
                        dgvHabitacionesReserva.Rows[i].Cells[2].Value = (int)dgvHabitacionesReserva.Rows[i].Cells[2].Value + 1;
                        dgvHabitacionesReserva.Rows[i].Cells[3].Value = (int)dgvHabitacionesReserva.Rows[i].Cells[3].Value - 1;
                    }
                    found = 1;
                }
            }
            if (found == 0)
            {
                DataRow drow = dtHabReserva.NewRow();
                drow[0] = dgvHabDisponibles.SelectedRows[0].Cells[0].Value;
                drow[1] = dgvHabDisponibles.SelectedRows[0].Cells[1].Value;
                drow[2] = "1";
                drow[3] = (int) dgvHabDisponibles.SelectedRows[0].Cells[2].Value - 1;
                dtHabReserva.Rows.Add(drow);
            }
            updateTotalReserva();
            
        }

        private void btnQuitarHabitacion_Click(object sender, EventArgs e)
        {
            if (dgvHabitacionesReserva.SelectedRows.Count > 0)
            {
                if ((int)dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value > 0)
                {
                    dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value = (int)dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value - 1;
                    dgvHabitacionesReserva.SelectedRows[0].Cells[3].Value = (int)dgvHabitacionesReserva.SelectedRows[0].Cells[3].Value + 1;
                }
                else
                    if ((int)dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value == 0)
                        dgvHabitacionesReserva.Rows.Remove(dgvHabitacionesReserva.SelectedRows[0]);
            }
            updateTotalReserva();
        }

        private void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            if (dgvHabitacionesReserva.SelectedRows.Count > 0)
            {
                if ((int)dgvHabitacionesReserva.SelectedRows[0].Cells[3].Value > 0)
                {
                    dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value = (int)dgvHabitacionesReserva.SelectedRows[0].Cells[2].Value + 1;
                    dgvHabitacionesReserva.SelectedRows[0].Cells[3].Value = (int)dgvHabitacionesReserva.SelectedRows[0].Cells[3].Value - 1;
                }
            }
            updateTotalReserva();
        }
        
        private void updateTotalReserva()
        {
            

            DbResultSet rs;
            double total = 0;
            for (int i = 0; i < dgvHabitacionesReserva.Rows.Count; i++) {
                rs = DbManager.dbGetDouble("SELECT ht.Cantidad_Estrellas*ht.PorcentajeRecarga + th.Porcentaje*r.Precio * CASE th.idTipo_Habitacion WHEN 1 THEN 0  ELSE th.idTipo_habitacion % 1000 END " +
                    " FROM ENER_LAND.Hotel ht, ENER_LAND.Tipo_Habitacion th, ENER_LAND.Regimen r" +
                    " WHERE ht.idHotel = " +  cmbHotelesDisponibles.SelectedValue +
                    " AND r.idRegimen = " + cmbRegHotel.SelectedValue + 
                    " AND th.idTipo_Habitacion = " + dgvHabitacionesReserva.Rows[i].Cells[0].Value);

                total = total + rs.doubleValue * (int)dgvHabitacionesReserva.Rows[i].Cells[2].Value;
            }
            lbTotalReserva.Text = "Total: u$s " + total.ToString();
            lbTotalReserva.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           TimeSpan ts = dtpFechaHasta.Value - dtpFechaDesde.Value ;

           int diffDate = (int) Math.Round(Convert.ToDouble(ts.TotalDays),0);
           int codReserva;
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    DbResultSet rs = DbManager.dbGetInt("SELECT MAX(idReserva) FROM ENER_LAND.Reserva");
                    codReserva = rs.intValue + 1;
                    command.CommandText = " INSERT INTO ENER_LAND.Reserva VALUES (@idReserva,1,1,@idRegimen,@fechaDesde,@cantDias,@cantHuespedes) ";

                    command.Parameters.AddWithValue("@idReserva",rs.intValue +1 );
                    command.Parameters.AddWithValue("@idRegimen",cmbRegHotel.SelectedValue);
                    command.Parameters.AddWithValue("@fechaDesde", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@cantDias",diffDate);
                    command.Parameters.AddWithValue("@cantHuespedes",udCantHuespedes.Value); //TODO validar > 0
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    for (int i = 0; i < dgvHabitacionesReserva.Rows.Count; i++)
                    {


                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT INTO ENER_LAND.Reserva_Habitacion   (idReserva,IdHotel,Habitacion_Numero) SELECT TOP(@cantHabitaciones)  @idReserva,ht.idHotel,hab.Numero" +
                             " FROM ENER_LAND.Habitacion hab , ENER_LAND.Hotel ht " +
                             " WHERE hab.Habilitado = 1 " +
                             " AND NOT EXISTS (" +
                             " SELECT 1" +
                             " FROM ENER_LAND.Reserva res, ENER_LAND.Reserva_Habitacion rhab " +
                             " WHERE res.idEstadoReserva = 1 " +
                             " AND res.idReserva=rhab.idReserva " +
                             " AND (@fechaResDesde BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde)" +
                             " OR @fechaResHasta BETWEEN res.FechaDesde AND DATEADD(DAY,res.Cantidad_Dias,res.FechaDesde))" +
                             " AND rhab.idHotel=hab.idHotel" +
                             " AND rhab.Habitacion_numero = hab.numero" +
                             " ) " +
                             " AND hab.IdHotel=ht.idHotel " +
                             " AND hab.IdHotel= @idHotel" +
                             " AND hab.idTipo_Habitacion = @idTipoHabitacion";


                            command.Parameters.AddWithValue("@cantHabitaciones", (int)dgvHabitacionesReserva.Rows[i].Cells[2].Value);
                            command.Parameters.AddWithValue("@idReserva", codReserva);
                            command.Parameters.AddWithValue("@fechaResDesde", dtpFechaDesde.Value);
                            command.Parameters.AddWithValue("@fechaResHasta", dtpFechaHasta.Value);
                            command.Parameters.AddWithValue("@idHotel", cmbHotelesDisponibles.SelectedValue);
                            command.Parameters.AddWithValue("@idTipoHabitacion", dgvHabitacionesReserva.Rows[i].Cells[0].Value);

                            command.ExecuteNonQuery();
                     }
                }
                
            }
            
        }
        private void obtenerHabitacionesReservaDB()
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = " SELECT thab.idTipo_habitacion tipoHab ,thab.Descripcion + ' - Capacidad: ' + CONVERT(VARCHAR(5),CASE hab.idTipo_Habitacion WHEN 1 THEN 0  ELSE hab.idTipo_habitacion % 1000 END) + ' p.' Descripcion, COUNT(1) Cantidad, 0 AS Disponibles " +
                    " FROM ENER_LAND.Reserva res, ENER_LAND.Reserva_Habitacion rhab, ENER_LAND.Habitacion hab, ENER_LAND.Tipo_Habitacion thab " +
                    " WHERE res.idReserva=" + tbCodReserva.Text +
                    " AND res.idReserva=rhab.idReserva" +
                    " AND rhab.IdHotel=hab.IdHotel" +
                    " AND rhab.Habitacion_Numero=hab.Numero" +
                    " AND hab.idTipo_Habitacion = thab.idTipo_Habitacion" +
                    " GROUP BY  thab.idTipo_habitacion,thab.Descripcion,hab.idTipo_Habitacion";

                 


                    DataTable dt = new DataTable();
                    dt.Columns.Add("tipoHab", typeof(int));
                    dt.Columns.Add("Descripcion", typeof(String));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("Disponibles", typeof(int));
                    dt.Load(command.ExecuteReader());
                    dgvHabitacionesReserva.DataSource = dt;
                   // dgvHabitacionesReserva.Columns[0].Visible = false;


                    for (int i = 0; i < dgvHabDisponibles.Rows.Count; i++)
                        for (int j = 0; j < dgvHabitacionesReserva.Rows.Count; j++)
                        {
                           if (dgvHabDisponibles.Rows[i].Cells[0].Value.ToString() == dgvHabitacionesReserva.Rows[j].Cells[0].Value.ToString())
                            {
                                dgvHabitacionesReserva.Rows[j].Cells[3].Value = dgvHabDisponibles.Rows[i].Cells[2].Value;
                            }
                        }

                }
            }
        
        }
    }
}
