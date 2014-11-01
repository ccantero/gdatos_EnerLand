using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class Reserva : Form
    {
        public Form parentForm;
        public int operationType;
        public const int nuevaReserva = 1;
        public const int modificarReserva = 2;

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
            if (this.operationType == modificarReserva)
            {
                tbCodReserva.Visible = true;
                lblCodReserva.Visible = true;
                btnReserva.Visible = true;
            }
            else
            {
                tbCodReserva.Visible = false;
                lblCodReserva.Visible = false;
                btnReserva.Visible = false;
            }

        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            DbResultSet rs = DbManager.dbGetInt("SELECT COUNT(1) FROM ENER_LAND.Reserva WHERE idReserva = " + tbCodReserva.Text);

            if (rs.intValue > 0)
            {
                rs = DbManager.GetDataTable("SELECT  idRegimen,FechaDesde, DATEADD(MONTH, Cantidad_Dias, FechaDesde) AS FechaHasta, x1.IdHotel , RTRIM(x3.Nombre) + ' - ' + x3.Calle + ' ' + CONVERT(VARCHAR,x3.Numero) AS Descripcion " + 
                                               "FROM ENER_LAND.Reserva x0, ENER_LAND.Reserva_Habitacion x1, ENER_LAND.Habitacion x2, ENER_LAND.Hotel "+ 
                                              "WHERE x0.idReserva = x1.idReserva " + 
                                                "AND x1.Habitacion_Numero=x2.Numero " +
                                                "AND x1.IdHotel=x2.IdHotel " + 
                                                "AND x1.IdHotel=x3.IdHotel " + 
                                                "AND x0.idReserva = " + tbCodReserva.Text);

                 MessageBox.Show(rs.dataTable.Rows[0].Field<Int32>(0).ToString());
                 dtpFechaDesde.Value = rs.dataTable.Rows[0].Field<DateTime>(1);
                 dtpFechaHasta.Value = rs.dataTable.Rows[0].Field<DateTime>(2);

                 MessageBox.Show(rs.dataTable.Rows[0].Field<Int32>(3).ToString());



            }
        }

    }
}
