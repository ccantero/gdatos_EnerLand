using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form_ListadoEstadistico : Form
    {
        public Form MenuPrincipal;
        private int TrimestreInicio;
        private int TrimestreFin;

        public Form_ListadoEstadistico(Form parentForm)
        {
            InitializeComponent();
            this.MenuPrincipal = parentForm;
            Cargar_Anios();
            Cargar_Meses();
            Cargar_Listados();
        }

        private void Form_ListadoEstadistico_Load(object sender, EventArgs e)
        {
            // Metodos Cutufiales

            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            MenuPrincipal.Hide();
        }

        private void Cargar_Anios()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT DISTINCT YEAR(FechaDesde) Anio FROM ENER_LAND.Reserva ORDER BY 1");

            foreach (DataRow Row in rs.dataTable.Rows)
            {
                this.comboBox_Anio.Items.Add(Row["Anio"].ToString().Trim());
            }
        }

        private void Cargar_Meses()
        {
            this.ComboBox_DateFrom.Items.Add("Enero");
            this.ComboBox_DateFrom.Items.Add("Febrero");
            this.ComboBox_DateFrom.Items.Add("Marzo");
            this.ComboBox_DateFrom.Items.Add("Abril");
            this.ComboBox_DateFrom.Items.Add("Mayo");
            this.ComboBox_DateFrom.Items.Add("Junio");
            this.ComboBox_DateFrom.Items.Add("Julio");
            this.ComboBox_DateFrom.Items.Add("Agosto");
            this.ComboBox_DateFrom.Items.Add("Septiembre");
            this.ComboBox_DateFrom.Items.Add("Octubre");
        }

        private void Cargar_Listados()
        {
            this.ComboBox_Listados.Items.Add("TOP 5 - Hoteles con más reservas Canceladas");
            this.ComboBox_Listados.Items.Add("TOP 5 - Hoteles con más Consumibles Facturados");
            this.ComboBox_Listados.Items.Add("TOP 5 - Hoteles con más Tiempo fuera de Servicio");
            this.ComboBox_Listados.Items.Add("TOP 5 - Habitaciones más solitadas");
            this.ComboBox_Listados.Items.Add("TOP 5 - Clientes con más puntos");
        }
        
        private void Form_ListadoEstadistico_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void ComboBox_DateFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.ComboBox_DateFrom.SelectedIndex)
            {
                // ABM usuario
                case 0:
                    {
                        this.ComboBox_To.Text = "Marzo";
                        TrimestreInicio = 1;
                        TrimestreFin = 3;
                        break;
                    }
                case 1:
                    {
                        this.ComboBox_To.Text = "Abril"; 
                        TrimestreInicio = 2;
                        TrimestreFin = 4;
                        break;
                    }
                case 2:
                    {
                        this.ComboBox_To.Text = "Mayo";
                        TrimestreInicio = 3;
                        TrimestreFin = 5;
                        break;
                    }
                case 3: 
                    { 
                        this.ComboBox_To.Text = "Junio"; 
                        TrimestreInicio = 4; 
                        TrimestreFin = 6; 
                        break; 
                    }
                case 4: 
                    { this.ComboBox_To.Text = "Julio"; 
                        TrimestreInicio = 5; 
                        TrimestreFin = 7; 
                        break; 
                    }
                case 5: 
                    { this.ComboBox_To.Text = "Agosto"; 
                        TrimestreInicio = 6; 
                        TrimestreFin = 8; 
                        break; 
                    }
                case 6: 
                    { this.ComboBox_To.Text = "Septiembre"; 
                        TrimestreInicio = 7; 
                        TrimestreFin = 9; 
                        break; 
                    }
                case 7: 
                    { this.ComboBox_To.Text = "Octubre"; 
                        TrimestreInicio = 8; 
                        TrimestreFin = 10; 
                        break; 
                    }
                case 8: 
                    { this.ComboBox_To.Text = "Noviembre"; 
                        TrimestreInicio = 9; 
                        TrimestreFin = 11; 
                        break; 
                    }
                case 9: 
                    { this.ComboBox_To.Text = "Diciembre"; 
                        TrimestreInicio = 10; 
                        TrimestreFin = 12; 
                        break; 
                    }
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            DbResultSet rs;
            string myQuery = String.Empty;
            switch (this.ComboBox_Listados.SelectedIndex)
            {
                case 0:
                    {
                        myQuery =   "SELECT TOP 5 Nombre, COUNT(1) Cantidad " +
                                    "FROM ENER_LAND.ReservasCanceladas " +
                                    "WHERE YEAR(Fecha) = " + this.comboBox_Anio.SelectedItem.ToString() + " " +
                                    "AND MONTH(Fecha) >= " + TrimestreInicio.ToString() + " " +
                                    "AND MONTH(Fecha) <= " + TrimestreFin.ToString() + " " +
                                    "GROUP BY Nombre " +
                                    "ORDER BY 2 DESC";
                        break;
                    }
                case 1:
                    {
                        myQuery =   "SELECT TOP 5 Nombre, SUM(Cantidad) Cantidad " +
                                    "FROM ENER_LAND.ConsumiblesFacturados " +
                                    "WHERE YEAR(Fecha) = " + this.comboBox_Anio.SelectedItem.ToString() + " " +
                                    "AND MONTH(Fecha) >= " + TrimestreInicio.ToString() + " " +
                                    "AND MONTH(Fecha) <= " + TrimestreFin.ToString() + " " +
                                    "GROUP BY Nombre " +
                                    "ORDER BY 2 DESC";
                        break;
                    }
                case 2:
                    {
                        myQuery =   "SELECT TOP 5 x2.Nombre, SUM(Cantidad_Dias) Cantidad " +
                                    "FROM ENER_LAND.Hotel_Inhabilitado x1, ENER_LAND.Hotel x2 " +
                                    "WHERE x1.IdHotel = x2.idHotel " +
                                    "AND YEAR(FechaInicio) = " + this.comboBox_Anio.SelectedItem.ToString() + " " +
                                    "AND MONTH(FechaInicio) >= " + TrimestreInicio.ToString() + " " +
                                    "AND MONTH(FechaInicio) <= " + TrimestreFin.ToString() + " " +
                                    "GROUP BY x1.IdHotel, x2.Nombre " +
                                    "ORDER BY 2 DESC";
                        break;
                    }
                case 3:
                    {
                        myQuery =   "SELECT TOP 5 Nombre, Habitacion_Numero, SUM(Cantidad_Dias) CantidadDias, COUNT(idReserva) 'Veces Utilizada' " +
                                    "FROM ENER_LAND.HabitacionesOcupadas " +
                                    "WHERE YEAR(Fecha_Ingreso) = " + this.comboBox_Anio.SelectedItem.ToString() + " " +
                                    "AND MONTH(Fecha_Ingreso) >= " + TrimestreInicio.ToString() + " " +
                                    "AND MONTH(Fecha_Ingreso) <= " + TrimestreFin.ToString() + " " +
                                    "GROUP BY Nombre, Habitacion_Numero " +
                                    "ORDER BY 3 DESC";
                        break;
                    }
                case 4:
                    {
                        myQuery =   "SELECT TOP 5 Apellido, Nombre, SUM(Puntos) Puntaje " +
                                    "FROM ENER_LAND.PuntajeHuespedes " +
                                    "WHERE YEAR(FechaDesde) = " + this.comboBox_Anio.SelectedItem.ToString() + " " +
                                    "AND MONTH(FechaDesde) >= " + TrimestreInicio.ToString() + " " +
                                    "AND MONTH(FechaDesde) <= " + TrimestreFin.ToString() + " " +
                                    "GROUP BY idHuesped, Apellido, Nombre " +
                                    "ORDER BY 3 DESC";
                        break;
                    }
            }

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            this.dataGridView_Listado.Columns.Clear();
            this.dataGridView_Listado.AllowUserToAddRows = false;
            this.dataGridView_Listado.AllowUserToOrderColumns = false;

            this.dataGridView_Listado.DataSource = rs.dataTable;
            this.dataGridView_Listado.Visible = true;

            foreach (DataGridViewColumn column in dataGridView_Listado.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


    }
}
