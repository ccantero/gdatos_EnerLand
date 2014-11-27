using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class UserControl_BuscarUsuario : UserControl
    {
        private Form FormPadre;
        public static DataTable TablaUsuarios = new DataTable();
        public Boolean flag_deletion = false;

        public UserControl_BuscarUsuario(Form parent)
        {
            InitializeComponent();
            FormPadre = parent;
        }
        
        private void UserControl_BuscarUsuario_Load(object sender, EventArgs e)
        {
            this.comboBox_TipoDocumento.Items.Clear();
            this.comboBox_TipoDocumento.Items.Add("C.I.");
            this.comboBox_TipoDocumento.Items.Add("D.N.I");
            this.comboBox_TipoDocumento.Items.Add("Pasaporte");
        }

        private void dataGrid_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query_str;
            Usuario unUsuario;
            
            if (e.ColumnIndex == 18 && e.RowIndex > -1)
            {
                unUsuario = CargarDatosUsuario(e.RowIndex);

                if (flag_deletion)
                {
                    query_str = "UPDATE ENER_LAND.Usuario SET Habilitado = 0 WHERE idUsuario = " + unUsuario.idUsuario.ToString();
                    DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo inhabilitar el Usuario creado previamente. Falla en la BD");

                    MessageBox.Show("El Usuario " + unUsuario.Nombre + " " + unUsuario.Apellido + " ha sido deshabilitado");

                    this.dataGrid_Usuarios.Columns.Clear();
                    ((GestionUsuarios)FormPadre).Load_Menu();
                    return;
                }

                ((GestionUsuarios)FormPadre).Load_Menu();
                ((GestionUsuarios)FormPadre).Modificar_Usuario(unUsuario);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DbResultSet rs;

            if (this.textBox_nombre.Text.Trim().Equals("") &&
               this.textBox_apellido.Text.Trim().Equals("") &&
               this.comboBox_TipoDocumento.Text.Trim().Equals("") &&
               this.textBox_username.Text.Trim().Equals("") &&
               this.textbox_NroDocumento.Text.Trim().Equals("") &&
               this.textBox_Mail.Text.Trim().Equals("")
               )
            {
                MessageBox.Show("Debe introducir al menos un criterio de búsqueda");
                return;
            }
            
            string myQuery =   "SELECT * " +
                               "FROM ENER_LAND.Usuario " +
                               "WHERE username LIKE '%" + this.textBox_username.Text.Trim() + "%'" +
                               "AND idUsuario NOT IN ( 1, 2) " +
                               "AND ( " + "ISNULL(Nombre,'-') = '-' OR Nombre LIKE '%" + this.textBox_nombre.Text.Trim() + "%' )" +
	                           "AND ( " + "ISNULL(Apellido,'-') = '-' OR Apellido LIKE '%" + this.textBox_apellido.Text.Trim() + "%' )" +
                               "AND ( " + "ISNULL(Mail,'-') = '-' OR Mail LIKE '%" + this.textBox_Mail.Text.Trim() + "%' )" +
                               "AND ( " + "ISNULL(Tipo_Documento,'-') = '-' OR Tipo_Documento LIKE '%" + this.comboBox_TipoDocumento.Text.Trim() + "%' )";

            if (!this.textbox_NroDocumento.Text.Trim().Equals(""))
                myQuery = myQuery + " AND Nro_Documento = " + this.textBox_Mail.Text.Trim();

            if (flag_deletion)
                myQuery = myQuery + " AND Habilitado = 1";


            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaUsuarios = rs.dataTable;

            if (TablaUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado Usuarios");
                return;
            }

            this.dataGrid_Usuarios.Columns.Clear();
            this.dataGrid_Usuarios.AllowUserToAddRows = false;
            this.dataGrid_Usuarios.AllowUserToOrderColumns = false;

            this.dataGrid_Usuarios.DataSource = TablaUsuarios;
            this.dataGrid_Usuarios.Visible = true;

            this.dataGrid_Usuarios.Columns["idUsuario"].Visible = false;
            this.dataGrid_Usuarios.Columns["Contraseña"].Visible = false;
            this.dataGrid_Usuarios.Columns["idLocalidad"].Visible = false;
            this.dataGrid_Usuarios.Columns["idPais"].Visible = false;
            this.dataGrid_Usuarios.Columns["habilitado"].Visible = false;
            this.dataGrid_Usuarios.Columns["intentosFallidos"].Visible = false;
            this.dataGrid_Usuarios.Columns["Fecha_Nacimiento"].Visible = false;
            this.dataGrid_Usuarios.Columns["Calle"].Visible = false;
            this.dataGrid_Usuarios.Columns["Numero"].Visible = false;
            this.dataGrid_Usuarios.Columns["Piso"].Visible = false;
            this.dataGrid_Usuarios.Columns["Departamento"].Visible = false;

            foreach (DataGridViewColumn column in dataGrid_Usuarios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGrid_Usuarios.Columns.Add(btn);
            btn.HeaderText = "Action";

            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
            if (flag_deletion)
                btn.Text = "Delete";
            else
                btn.Text = "Select";
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

            this.dataGrid_Usuarios.Columns.Clear();
        }

        private Usuario CargarDatosUsuario(int fila)
        {
            Usuario unUsuario = new Usuario();

            unUsuario.Apellido = TablaUsuarios.Rows[fila]["Apellido"].ToString();
            unUsuario.Calle = TablaUsuarios.Rows[fila]["Calle"].ToString();

            if (!TablaUsuarios.Rows[fila]["Departamento"].ToString().Equals(""))
                unUsuario.Departamento = Convert.ToChar(TablaUsuarios.Rows[fila]["Departamento"].ToString());
            
            if(!TablaUsuarios.Rows[fila]["Fecha_Nacimiento"].ToString().Equals(""))
                unUsuario.Fecha_Nacimiento = Convert.ToDateTime(TablaUsuarios.Rows[fila]["Fecha_Nacimiento"].ToString());
            
            if (TablaUsuarios.Rows[fila]["Habilitado"].ToString().Trim().Equals("1"))
            {
                unUsuario.Habilitado = true;
            }
            else
            {
                unUsuario.Habilitado = false;
            }

            if (TablaUsuarios.Rows[fila]["idLocalidad"].ToString().Equals(""))
            {
                unUsuario.idLocalidad = -1;
            }
            else
            {
                unUsuario.idLocalidad = Convert.ToInt32(TablaUsuarios.Rows[fila]["idLocalidad"].ToString());
            }

            if (TablaUsuarios.Rows[fila]["idPais"].ToString().Equals(""))
            {
                unUsuario.idPais = -1;
            }
            else
            {
                unUsuario.idPais = Convert.ToInt32(TablaUsuarios.Rows[fila]["idPais"].ToString());
            }

            unUsuario.idUsuario = Convert.ToInt32(TablaUsuarios.Rows[fila]["idUsuario"].ToString());
            unUsuario.Mail = TablaUsuarios.Rows[fila]["Mail"].ToString();
            unUsuario.Nombre = TablaUsuarios.Rows[fila]["Nombre"].ToString();

            if(!TablaUsuarios.Rows[fila]["Nro_Documento"].ToString().Equals(""))
                unUsuario.Nro_Documento = Convert.ToInt32(TablaUsuarios.Rows[fila]["Nro_Documento"].ToString());

            if(!TablaUsuarios.Rows[fila]["Numero"].ToString().Equals(""))
                unUsuario.Numero = Convert.ToInt32(TablaUsuarios.Rows[fila]["Numero"].ToString());
            
            if (!TablaUsuarios.Rows[fila]["Piso"].ToString().Equals(""))
                unUsuario.Piso = Convert.ToInt32(TablaUsuarios.Rows[fila]["Piso"].ToString());

            if (TablaUsuarios.Rows[fila]["Telefono"].ToString().Equals(""))
            {
                unUsuario.Telefono = -1;
            }
            else
            {
                unUsuario.Telefono = Convert.ToInt32(TablaUsuarios.Rows[fila]["Telefono"].ToString());
            }

            unUsuario.Tipo_Documento = TablaUsuarios.Rows[fila]["Tipo_Documento"].ToString();

            unUsuario.username = TablaUsuarios.Rows[fila]["username"].ToString();

            unUsuario.password = TablaUsuarios.Rows[fila]["contraseña"].ToString();
            return unUsuario;
        }
    }
}
