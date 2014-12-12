using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class UserControl_BuscarHuesped : UserControl
    {
        private Form FormPadre;
        public static DataTable TablaHuespedes = new DataTable();
        public Boolean flag_deletion;
        public Boolean flag_busqueda;
        public Boolean flag_busquedaReserva;

        public UserControl_BuscarHuesped(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
            flag_deletion = false;
            flag_busqueda = false;
            flag_busquedaReserva = false;
        }

        private void UserControl_BuscarHuesped_Load(object sender, EventArgs e)
        {
            this.comboBox_TipoDocumento.Items.Clear();
            this.comboBox_TipoDocumento.Items.Add("C.I.");
            this.comboBox_TipoDocumento.Items.Add("D.N.I");
            this.comboBox_TipoDocumento.Items.Add("Pasaporte");
        }
        
        private void button_search_Click(object sender, EventArgs e)
        {   
            DbResultSet rs;

            if (!Check_Fields())
            {
                this.textBox_nombre.Select();
                return;
            } 

            string myQuery =    "SELECT	x1.idHuesped, " +
                                "x1.Apellido, " +
		                        "x1.Nombre, " +
		                        "x1.Tipo_Documento, " +
		                        "x1.Nro_Documento, " +
		                        "x1.Fecha_Nacimiento, " +
		                        "x1.Nacionalidad, " +
		                        "Mail = CASE WHEN x1.Mail IS NULL THEN x1.Mail_Alternativo ELSE x1.Mail END, " +
		                        "x1.Calle, " +
		                        "x1.Numero, " +
		                        "x1.Piso, " +
		                        "x1.Departamento, " +
		                        "x1.idLocalidad, " +
                                "x1.idPais, " +
		                        "x1.Telefono, " +
		                        "x1.Habilitado, " +
		                        "MailIncorrecto = CASE WHEN x1.Mail IS NULL THEN 1 ELSE 0 END " +
                                "FROM ENER_LAND.Huesped x1 " +
                                "WHERE Nombre LIKE '%" + this.textBox_nombre.Text.Trim() + "%' " +
                                "AND Apellido LIKE '%" + this.textBox_apellido.Text.Trim() + "%' " +
                                "AND Tipo_Documento LIKE '%" + this.comboBox_TipoDocumento.Text.Trim() + "%' " +
                                "AND ( Mail LIKE '%" + this.textBox_Mail.Text.Trim() + "%' " +
                                      "OR Mail_Alternativo LIKE '%" + this.textBox_Mail.Text.Trim() + "%' " +
                                ")";

            if (!this.textbox_NroDocumento.Text.Trim().Equals(""))
                myQuery = myQuery + " AND Nro_Documento = " + this.textbox_NroDocumento.Text.Trim();

            if (flag_deletion || flag_busqueda)
                myQuery = myQuery + " AND Habilitado = 1";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaHuespedes = rs.dataTable;

            if (TablaHuespedes.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado Huespedes");
                return;
            }

            this.dataGrid_Huespedes.Columns.Clear();
            this.dataGrid_Huespedes.AllowUserToAddRows = false;
            this.dataGrid_Huespedes.AllowUserToOrderColumns = false;
            
            this.dataGrid_Huespedes.DataSource = TablaHuespedes;
            this.dataGrid_Huespedes.Visible = true;
            
            this.dataGrid_Huespedes.Columns["idLocalidad"].Visible = false;
            this.dataGrid_Huespedes.Columns["idPais"].Visible = false;
            this.dataGrid_Huespedes.Columns["idHuesped"].Visible = false;
            this.dataGrid_Huespedes.Columns["MailIncorrecto"].Visible = false;
            this.dataGrid_Huespedes.Columns["Habilitado"].Visible = false;
            this.dataGrid_Huespedes.Columns["Telefono"].Visible = false;
            this.dataGrid_Huespedes.Columns["Calle"].Visible = false;
            this.dataGrid_Huespedes.Columns["Numero"].Visible = false;
            this.dataGrid_Huespedes.Columns["Piso"].Visible = false;
            this.dataGrid_Huespedes.Columns["Departamento"].Visible = false;
            this.dataGrid_Huespedes.Columns["Fecha_Nacimiento"].Visible = false;

            foreach (DataGridViewColumn column in dataGrid_Huespedes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGrid_Huespedes.Columns.Add(btn);
            btn.HeaderText = "Action";
            
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
            if(flag_deletion)
                btn.Text = "Delete";
            else
                btn.Text = "Select";

        }

        private void dataGrid_Huespedes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query_str;
            Huesped unHuesped;

            if (e.ColumnIndex == 17 && e.RowIndex > -1)
            {
                unHuesped = CargarDatosAfiliado(e.RowIndex);
                
                if(flag_deletion)
                {
                    query_str = "UPDATE ENER_LAND.Huesped SET Habilitado = 0 WHERE idHuesped = " + unHuesped.idHuesped.ToString();
                    DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo borrar el Rol creado previamente. Falla en la BD");

                    MessageBox.Show("El Usuario " + unHuesped.Nombre + " " + unHuesped.Apellido + " ha sido deshabilitado");

                    this.dataGrid_Huespedes.Columns.Clear();
                    ((GestionHuesped)FormPadre).Load_Menu();
                    return;
                }

                if (flag_busqueda)
                {
                    if (flag_busquedaReserva)
                    {
                        GestionHuesped Form_GestionHuesped = (GestionHuesped)FormPadre;
                        Generar_Modificar_Reserva.Reserva Form_Reserva = (Generar_Modificar_Reserva.Reserva)Form_GestionHuesped.MenuPrincipal;
                        Form_Reserva.AgregarReserva(unHuesped.idHuesped);
                        Form_Reserva.Visible = true;
                        Form_GestionHuesped.Dispose();
                        return;
                    }
                    
                    ((Registrar_Estadia.RegistrarEntrada_Form)((GestionHuesped)FormPadre).MenuPrincipal).Huespedes.Add(unHuesped.idHuesped);
                    ((Registrar_Estadia.RegistrarEntrada_Form)((GestionHuesped)FormPadre).MenuPrincipal).Cargar_Huespedes();
                    ((Registrar_Estadia.RegistrarEntrada_Form)((GestionHuesped)FormPadre).MenuPrincipal).Visible = true;
                    ((GestionHuesped)FormPadre).Dispose();
                    return;
                }
                ((GestionHuesped)FormPadre).Load_Menu();
                ((GestionHuesped)FormPadre).Modificar_Huesped(unHuesped);
            }
        }

        private Huesped CargarDatosAfiliado(int fila)
        {
            Huesped cliente = new Huesped();
            cliente.Apellido = TablaHuespedes.Rows[fila]["Apellido"].ToString();
            cliente.Calle = TablaHuespedes.Rows[fila]["Calle"].ToString();
            if (!TablaHuespedes.Rows[fila]["Departamento"].ToString().Equals(""))
                cliente.Departamento = Convert.ToChar(TablaHuespedes.Rows[fila]["Departamento"].ToString());
            cliente.Fecha_Nacimiento = Convert.ToDateTime(TablaHuespedes.Rows[fila]["Fecha_Nacimiento"].ToString());
            if (TablaHuespedes.Rows[fila]["Habilitado"].ToString().Trim().Equals("1"))
            {
                cliente.Habilitado = true;
            }
            else
            {
                cliente.Habilitado = false;
            }

            cliente.idHuesped = Convert.ToInt32(TablaHuespedes.Rows[fila]["idHuesped"].ToString());
            if (TablaHuespedes.Rows[fila]["idLocalidad"].ToString().Equals(""))
            {
                cliente.idLocalidad = -1;
            }
            else
            {
                cliente.idLocalidad = Convert.ToInt32(TablaHuespedes.Rows[fila]["idLocalidad"].ToString());
            }

            if (TablaHuespedes.Rows[fila]["idPais"].ToString().Equals(""))
            {
                cliente.idPais = -1;
            }
            else
            {
                cliente.idPais = Convert.ToInt32(TablaHuespedes.Rows[fila]["idPais"].ToString());
            }
            
            cliente.Mail = TablaHuespedes.Rows[fila]["Mail"].ToString();
            cliente.Nacionalidad = TablaHuespedes.Rows[fila]["Nacionalidad"].ToString();
            cliente.Nombre = TablaHuespedes.Rows[fila]["Nombre"].ToString();
            cliente.Nro_Documento = Convert.ToInt32(TablaHuespedes.Rows[fila]["Nro_Documento"].ToString());
            cliente.Numero = Convert.ToInt32(TablaHuespedes.Rows[fila]["Numero"].ToString());
            if (!TablaHuespedes.Rows[fila]["Piso"].ToString().Equals(""))
                cliente.Piso = Convert.ToInt32(TablaHuespedes.Rows[fila]["Piso"].ToString());

            if (TablaHuespedes.Rows[fila]["Telefono"].ToString().Equals(""))
            {
                cliente.Telefono = -1;
            }
            else
            {
                cliente.Telefono = Convert.ToInt32(TablaHuespedes.Rows[fila]["Telefono"].ToString());
            }
            
            cliente.Tipo_Documento = TablaHuespedes.Rows[fila]["Tipo_Documento"].ToString();

            return cliente;
        }

        private void CargarTipoDoc()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT DISTINCT Tipo_Documento FROM ENER_LAND.Huesped");

            foreach (DataRow Row in rs.dataTable.Rows)
            {
                this.comboBox_TipoDocumento.Items.Add(Row[0].ToString().Trim());
            }

        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }

            this.dataGrid_Huespedes.Columns.Clear();
            this.comboBox_TipoDocumento.Text = String.Empty;
            this.textBox_nombre.Select();
        }

        private void button_AddHuesped_Click(object sender, EventArgs e)
        {
            ((GestionHuesped)FormPadre).Load_Menu();
            ((GestionHuesped)FormPadre).AgregarHuesped();
            ((GestionHuesped)FormPadre).UserControlHuesped.flag_NOTABM = true; ;
            ((GestionHuesped)FormPadre).UserControlHuesped.flag_busquedaReserva = flag_busquedaReserva;
        }

        public void BuscarHuesped(Boolean busquedaReserva)
        {
            button_AddHuesped.Visible = true;
            flag_busqueda = true;
            flag_busquedaReserva = busquedaReserva;
        }

        private Boolean Check_Fields()
        {
            if (this.textBox_nombre.Text.Trim().Equals("") &&
               this.textBox_apellido.Text.Trim().Equals("") &&
               this.comboBox_TipoDocumento.Text.Trim().Equals("") &&
               this.textbox_NroDocumento.Text.Trim().Equals("") &&
               this.textBox_Mail.Text.Trim().Equals("")
               )
            {
                MessageBox.Show("Debe introducir al menos un criterio de búsqueda");
                return false;
            }

            Boolean flag = true;


            foreach (var item in this.comboBox_TipoDocumento.Items)
            {
                if (!comboBox_TipoDocumento.Text.Equals(String.Empty))
                {
                    if (comboBox_TipoDocumento.Text.Equals(item.ToString()))
                    {
                        flag = false;
                    }
                }
                else
                    flag = false;
            }

            if (flag)
            {
                MessageBox.Show("Tipo de Documento desconocido.");
                return false;
            }

            if (!textbox_NroDocumento.Text.Equals(String.Empty))
            {
                if (!System.Text.RegularExpressions.Regex.Match(textbox_NroDocumento.Text, "^[1-9][0-9]+$").Success)
                {
                    MessageBox.Show("Numero de Documento debe contener unicamente numeros",
                                        "Numero de Documento Incorrecto",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Hand
                                       );
                    return false;
                }
            }
            return true;
        }
    }
}
