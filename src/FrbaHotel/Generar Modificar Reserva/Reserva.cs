﻿using System;
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
        public const int opCancelarReserva = 3; /* El cero choca con la FK idEstado_Reserva de Auditoria_Reserva */
        public const int opNuevaReserva = 1;
        public const int opModificarReserva = 2;
        public int currentHotel;
        public int currentUser;
        private DataTable dtHabReserva;

        public Reserva(Form parent, int opType)
        {
            this.parentForm = parent;
            this.operationType = opType;
            InitializeComponent();
            parent.Hide();
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

            dtHabReserva = new DataTable();

            dtHabReserva.Columns.Add("tipoHab", typeof(int));
            dtHabReserva.Columns.Add("Descripcion", typeof(String));
            dtHabReserva.Columns.Add("Cantidad", typeof(int));
            dtHabReserva.Columns.Add("Disponibles", typeof(int));

            switch (this.operationType)
            {
                case opCancelarReserva: { cancelarReserva(); break; }
                case opNuevaReserva: { nuevaReserva(); break; }
                case opModificarReserva: { modificarReserva(); break; }
                default:break;

            }

            dtpFechaDesde.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
            dtpFechaHasta.Value = @FrbaHotel.Properties.Settings.Default.Fecha;
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
                    if (currentHotel == -1)
                    {
                        command.CommandText =   "SELECT DISTINCT ht.idHotel, RTRIM(ht.Nombre) + ' | ' + ht.Calle + ' ' + CONVERT(VARCHAR(50),ht.Numero) + ' - ' + RTRIM(loc.Nombre) + ', ' + ps.Nombre + ' (' + CONVERT(VARCHAR(5),ht.Cantidad_Estrellas) + '*)' Hotel " +
                                                "FROM ENER_LAND.Habitacion hab , ENER_LAND.Tipo_Habitacion thab, ENER_LAND.Hotel ht, ENER_LAND.Localidad loc, ENER_LAND.Pais ps " +
                                                "WHERE hab.idHotel = ht.idHotel " +
                                                "AND hab.idTipo_Habitacion = thab.idTipo_Habitacion " +
                                                "AND ht.idLocalidad = loc.idLocalidad " +
                                                "AND ht.idpais = ps.idPais " +
                                                "AND ENER_LAND.CHECK_Hotel_Habilitado(ht.idHotel,@fechaInicioReserva,@FechaFinReserva) = 0 " +
                                                "AND ENER_LAND.CHECK_Habitacion_Habilitada(ht.idHotel,hab.numero, @fechaInicioReserva,@FechaFinReserva) = 0 ";
                        
                        /*
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
                         */
                    }
                    else
                    {
                        command.CommandText =   "SELECT DISTINCT ht.idHotel, RTRIM(ht.Nombre) + ' | ' + ht.Calle + ' ' + CONVERT(VARCHAR(50),ht.Numero) + ' - ' + RTRIM(loc.Nombre) + ', ' + ps.Nombre + ' (' + CONVERT(VARCHAR(5),ht.Cantidad_Estrellas) + '*)' Hotel " +
                                                "FROM ENER_LAND.Habitacion hab , ENER_LAND.Tipo_Habitacion thab, ENER_LAND.Hotel ht, ENER_LAND.Localidad loc, ENER_LAND.Pais ps " +
                                                "WHERE hab.idHotel = ht.idHotel " +
                                                "AND hab.idTipo_Habitacion = thab.idTipo_Habitacion " +
                                                "AND ht.idLocalidad = loc.idLocalidad " +
                                                "AND ht.idpais = ps.idPais " +
                                                "AND ENER_LAND.CHECK_Hotel_Habilitado(ht.idHotel,@fechaInicioReserva,@FechaFinReserva) = 0 " +
                                                "AND ENER_LAND.CHECK_Habitacion_Habilitada(ht.idHotel,hab.numero, @fechaInicioReserva,@FechaFinReserva) = 0 " + 
                                                "AND ht.idHotel = " + currentHotel.ToString();
                    }

                    if (cmbRegimenHotelRes.SelectedIndex > 0)
                    {
                        command.CommandText = command.CommandText +
                                              " AND EXISTS( SELECT 1 FROM ENER_LAND.Regimen_Hotel x1 " +
                                              " WHERE x1.idHotel = ht.idHotel " +
                                              " AND x1.idRegimen = " + cmbRegimenHotelRes.SelectedIndex.ToString() + " ) ";
                    }

                    //command.Parameters.AddWithValue("@hotelAnterior", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@fechaInicioReserva", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@FechaFinReserva", dtpFechaHasta.Value);

                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    DataRow drow = dt.NewRow();
                    cmbHotelesDisponibles.ValueMember = "idHotel";
                    cmbHotelesDisponibles.DisplayMember = "hotel";
                    cmbHotelesDisponibles.DataSource = dt;
                    cmbHotelesDisponibles.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbHotelesDisponibles.Enabled = true;

                    dgvHabDisponibles.DataSource = null;
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

                    command.CommandText =   "SELECT hab.idTipo_Habitacion,thab.Descripcion + ' - Capacidad: ' + CONVERT(VARCHAR(5),CASE hab.idTipo_Habitacion WHEN 1 THEN 0  ELSE hab.idTipo_habitacion % 1000 END) + ' p.' Descripcion, COUNT(1) Disponibles " +
                                            "FROM ENER_LAND.Habitacion hab , ENER_LAND.Tipo_Habitacion thab, ENER_LAND.Hotel ht, ENER_LAND.Localidad loc, ENER_LAND.Pais ps " +
                                            "WHERE hab.idHotel = ht.idHotel " +
                                            "AND hab.idTipo_Habitacion = thab.idTipo_Habitacion " +
                                            "AND ht.idLocalidad = loc.idLocalidad " +
                                            "AND ht.idpais = ps.idPais " +
                                            "AND ENER_LAND.CHECK_Hotel_Habilitado(ht.idHotel,@fechaInicioReserva,@FechaFinReserva) = 0 " +
                                            "AND ENER_LAND.CHECK_Habitacion_Habilitada(ht.idHotel,hab.numero, @fechaInicioReserva,@FechaFinReserva) = 0 " +
                                            "AND ht.idHotel = @idHotel " + 
                                            "GROUP BY ht.idHotel, ht.Nombre, hab.idTipo_Habitacion,thab.Descripcion";

                    command.Parameters.AddWithValue("@fechaInicioReserva", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@FechaFinReserva", dtpFechaHasta.Value);
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
            if (tbCodReserva.Text.Length > 0)
            {
                DbResultSet rs;
                if (currentHotel == -1)
                {
                    rs = DbManager.dbGetInt("SELECT COUNT(1) FROM ENER_LAND.Reserva WHERE idReserva = " + tbCodReserva.Text);
                }
                else
                {
                    rs = DbManager.dbGetInt("SELECT COUNT(1) " +
                                            "FROM ENER_LAND.Reserva x1, ENER_LAND.Reserva_Habitacion x2 " +
                                            "WHERE x1.idReserva = x2.idReserva " +
                                            "AND x2.idHotel = " + currentHotel.ToString() + " " + 
                                            "AND x1.idReserva = " + tbCodReserva.Text);
                }

                if (rs.intValue > 0)
                {
                    rs = DbManager.GetDataTable("SELECT DISTINCT  idRegimen,FechaDesde, DATEADD(DAY, Cantidad_Dias, FechaDesde) AS FechaHasta, x1.IdHotel ,x0.cantidad_huespedes " +
                                                   "FROM ENER_LAND.Reserva x0, ENER_LAND.Reserva_Habitacion x1 " +
                                                  "WHERE x0.idReserva = x1.idReserva " +
                                                    "AND x0.idReserva = " + tbCodReserva.Text);
                    dtpFechaDesde.Value = rs.dataTable.Rows[0].Field<DateTime>(1);
                    dtpFechaHasta.Value = rs.dataTable.Rows[0].Field<DateTime>(2);
                    udCantHuespedes.Value = rs.dataTable.Rows[0].Field<Int32>(4);
                    obtenerRegimenesBusqueda();
                    cmbRegimenHotelRes.SelectedValue = rs.dataTable.Rows[0].Field<Int32>(0);

                    obtenerHotelesDisponibles((int)udCantHuespedes.Value, rs.dataTable.Rows[0].Field<Int32>(3));
                    cmbHotelesDisponibles.SelectedValue = rs.dataTable.Rows[0].Field<Int32>(3);
                    obtenerRegimenesEnHotel();
                    cmbRegHotel.SelectedValue = cmbRegimenHotelRes.SelectedValue;
                    obtenerHabitacionesDisponibles();
                    obtenerHabitacionesReservaDB();
                    updateTotalReserva();
                }
                else
                {
                    MessageBox.Show("Reserva no encontrada. Probablemente proceda de un hotel distinto");
                }
            }
        }

        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {
            if (udCantHuespedes.Value <= 0)
            {
                MessageBox.Show("Debe seleccionar la cantidad de huespedes");
                return;
            }
            obtenerHotelesDisponibles((int)udCantHuespedes.Value,0);
            cmbHotelesDisponibles.Text = String.Empty;
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
            if(cmbRegimenHotelRes.SelectedValue != null)
                if ((int)cmbRegimenHotelRes.SelectedValue > 0)
                    cmbRegHotel.SelectedValue = cmbRegimenHotelRes.SelectedValue;
        }
        
        private void cmbHotelesDisponibles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obtenerRegimenesEnHotel();
            obtenerHabitacionesDisponibles();


            dgvHabitacionesReserva.DataSource = dtHabReserva;
            dgvHabitacionesReserva.Columns[0].Visible = false;

        }

        private void btnAgregarTipoHabitacion_Click(object sender, EventArgs e)
        {
            int found = 0;

            if (udCantHuespedes.Value <= 0)
            {
                MessageBox.Show("Debe especificar la cantidad de Huespedes");
                return;
            }

            if (cmbRegHotel.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe especificar el regimen de la habitacion");
                return;
            }
            
            if (!DbManager.CHECK_Hotel_Habilitado(  Convert.ToInt32(cmbHotelesDisponibles.SelectedValue.ToString()),
                                                    this.dtpFechaDesde.Value, 
                                                    this.dtpFechaHasta.Value))
            {
                MessageBox.Show("El hotel no se encontrará disponible durante el interavalo seleccionado.");
                return;
            }

            if (!DbManager.CHECK_Habitacion_Habilitada(Convert.ToInt32(cmbHotelesDisponibles.SelectedValue.ToString()),
                                                    Convert.ToInt32(dgvHabDisponibles.SelectedRows[0].Cells[2].Value),
                                                    this.dtpFechaDesde.Value,
                                                    this.dtpFechaHasta.Value))
            {
                MessageBox.Show("La Habitacion no se encontrará disponible durante el interavalo seleccionado.");
                return;
            }

            for (int i = 0; i < dgvHabitacionesReserva.Rows.Count; i++)
            {
                if ((int)dgvHabitacionesReserva.Rows[i].Cells[0].Value == (int)dgvHabDisponibles.SelectedRows[0].Cells[0].Value)
                {
                    if (/*(int)dgvHabDisponibles.SelectedRows[0].Cells[2].Value > */(int)dgvHabitacionesReserva.Rows[i].Cells[3].Value != 0)
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
            TimeSpan ts = dtpFechaHasta.Value - dtpFechaDesde.Value;

            int diffDate = (int)Math.Round(Convert.ToDouble(ts.TotalDays), 0);
            int codReserva;
            if (operationType == 1) /* Agregar Reserva */
            {
                ABM_de_Cliente.GestionHuesped formBusqueda = new FrbaHotel.ABM_de_Cliente.GestionHuesped(this);
                formBusqueda.Show();
                formBusqueda.Cargar_Busqueda(true); // Es Busqueda en Reserva
                return;
            }
            else
            {
                codReserva = Convert.ToInt32(tbCodReserva.Text);
                if (operationType == 2)
                {
                    using (SqlConnection connection = DbManager.dbConnect())
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = " UPDATE ENER_LAND.Reserva " +
                                                  " SET idRegimen=@idRegimen, " +
                                                  " fechaDesde=@fechaDesde, " +
                                                  " Cantidad_dias=@cantDias, " +
                                                  " Cantidad_huespedes=@cantHuespedes, " +
                                                  " IdEstado_Reserva=2 " +
                                                  " WHERE idReserva = @idReserva ";

                            command.Parameters.AddWithValue("@idReserva", codReserva);
                            command.Parameters.AddWithValue("@idRegimen", cmbRegHotel.SelectedValue);
                            command.Parameters.AddWithValue("@fechaDesde", dtpFechaDesde.Value);
                            command.Parameters.AddWithValue("@cantDias", diffDate);
                            command.Parameters.AddWithValue("@cantHuespedes", udCantHuespedes.Value); //TODO validar > 0
                            command.ExecuteNonQuery();
                        }
                        
		                DbManager.dbSqlStatementExec("DELETE FROM ENER_LAND.Reserva_Habitacion WHERE idReserva =" + codReserva);
                        reservarHabitaciones(codReserva);
                        registrarAuditoria(codReserva, operationType, "");
                        MessageBox.Show("Modifcacion Exitosa");
                        parentForm.Show();
                        this.Dispose();
                	}
                }
                else /* Cancelacion de Reserva */
                {
                    Dialog_Form dialogForm = new Dialog_Form("Motivo de Cancelacion",
                                                            "Favor ingrese el motivo para cancelar la reserva",
                                                            this);
                    dialogForm.Show();
                    this.Visible = false;
                }
            }
        }

        public void AgregarReserva(int idHuesped)
        {
            TimeSpan ts = dtpFechaHasta.Value - dtpFechaDesde.Value;

            int diffDate = (int)Math.Round(Convert.ToDouble(ts.TotalDays), 0);
            int codReserva;
            
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    DbResultSet rs = DbManager.dbGetInt("SELECT MAX(idReserva) FROM ENER_LAND.Reserva");
                    codReserva = rs.intValue + 1;
                    command.CommandText = " INSERT INTO ENER_LAND.Reserva VALUES (@idReserva,1,@idHuesped,@idRegimen,@fechaDesde,@cantDias,@cantHuespedes) ";

                    command.Parameters.AddWithValue("@idReserva", codReserva);
                    command.Parameters.AddWithValue("@idHuesped", idHuesped);
                    command.Parameters.AddWithValue("@idRegimen", cmbRegHotel.SelectedValue);
                    command.Parameters.AddWithValue("@fechaDesde", dtpFechaDesde.Value);
                    command.Parameters.AddWithValue("@cantDias", diffDate);
                    command.Parameters.AddWithValue("@cantHuespedes", udCantHuespedes.Value); //TODO validar > 0
                    command.ExecuteNonQuery();
                }
            }
            reservarHabitaciones(codReserva);
            registrarAuditoria(codReserva, operationType, "");
            MessageBox.Show("Reserva creada exitosamente = " + codReserva);
            parentForm.Show();
            this.Dispose();
        }
        
        public void CancelarReserva(string Motivo)
        {
            int codReserva = Convert.ToInt32(tbCodReserva.Text);

            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = " UPDATE ENER_LAND.Reserva " +
                                          " SET IdEstado_Reserva=@IdEstado_Reserva " +
                                          " WHERE idReserva = @idReserva ";

                    command.Parameters.AddWithValue("@idReserva", codReserva);
                    if (currentUser == 2) /* Usuario Guest */
                    {
                        command.Parameters.AddWithValue("@IdEstado_Reserva", 4); /* Cancelada por el Cliente */
                    }
                    else
                        command.Parameters.AddWithValue("@IdEstado_Reserva", 3); /* Cancelada por el Cliente */
                    
                    command.ExecuteNonQuery();
                }
            }
            registrarAuditoria(codReserva, operationType, Motivo);
            MessageBox.Show("Reserva cancelada");
            this.Dispose();
            parentForm.Show();
        }

        private void registrarAuditoria(int codRes, int cod, string motivoCancelacion)
        {
            using (SqlConnection connection = DbManager.dbConnect())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = " INSERT INTO ENER_LAND.Auditoria_Reserva VALUES(@audIdReserva,@audFechaSistema,@codigoEstado,@audIdUsuario,@motivo)";
                    command.Parameters.AddWithValue("@audIdReserva", codRes);
                    command.Parameters.AddWithValue("@audFechaSistema", Properties.Settings.Default.Fecha);
                    command.Parameters.AddWithValue("@codigoEstado", cod);
                    command.Parameters.AddWithValue("@audIdUsuario", currentUser);
                    if(motivoCancelacion.Equals(string.Empty))
                        command.Parameters.AddWithValue("@motivo", DBNull.Value);
                    else    
                        command.Parameters.AddWithValue("@motivo", motivoCancelacion);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void reservarHabitaciones(int codRes)
        {
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
                             " WHERE res.idEstado_Reserva = 1 " +
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
                        command.Parameters.AddWithValue("@idReserva", codRes);
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

                    dtHabReserva.Load(command.ExecuteReader());
                    dgvHabitacionesReserva.DataSource = dtHabReserva;
                    dgvHabitacionesReserva.Columns[0].Visible = false;


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

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtHabReserva.Rows.Clear();    
        }
        
        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            dtHabReserva.Rows.Clear();
        }

        private void Reserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.Show();
            this.Dispose();
        }

        private void cmbRegHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(operationType == 2)
                if (dgvHabitacionesReserva.Rows.Count > 0)
                {
                    updateTotalReserva();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Dispose();
        }
    }
}
