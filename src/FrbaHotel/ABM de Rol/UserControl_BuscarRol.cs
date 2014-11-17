using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class UserControl_BuscarRol : UserControl
    {
        private Form FormPadre;
        public static DataTable TablaRoles = new DataTable();
        public Boolean flag_deletion = false;

        public UserControl_BuscarRol(Form parent)
        {
            InitializeComponent();
            FormPadre = parent;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string query_str;
            DbResultSet rs;

            if(flag_deletion)
                query_str = "SELECT * FROM ENER_LAND.Rol " +
                            "WHERE Descripcion LIKE '%" + textBox_RolName.Text.Trim() + "%' " +
                            "AND Habilitado = 1";
            else
                query_str = "SELECT * FROM ENER_LAND.Rol WHERE Descripcion LIKE '%" + textBox_RolName.Text.Trim() + "%'";
                

            rs = DbManager.GetDataTable(query_str);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaRoles = rs.dataTable;

            if (TablaRoles.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado roles");
                return;
            }
            
            this.dataGrid_Roles.Columns.Clear();
            this.dataGrid_Roles.DataSource = TablaRoles;
            this.dataGrid_Roles.Visible = true;
            this.dataGrid_Roles.Columns["idRol"].Visible = false;
            this.dataGrid_Roles.Columns["Habilitado"].Visible = false;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGrid_Roles.Columns.Add(btn);
            btn.HeaderText = "Action";

            if (flag_deletion)
            {
                btn.Text = "Delete";
            }
            else
            {
                btn.Text = "Select";
            }

            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;

        }

        private void dataGrid_Roles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string query_str;
            int id_Rol;

            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                id_Rol = Convert.ToInt32(TablaRoles.Rows[e.RowIndex]["idRol"].ToString());
                
                if (flag_deletion)
                {
                    switch (id_Rol)
                    {
                        case 1:
                            MessageBox.Show("El Rol Administrador no debe ser modificado");
                            return;
                        case 2:
                            MessageBox.Show("El Rol Recepcionista no debe ser modificado");
                            return;
                        case 3:
                            MessageBox.Show("El Rol Guest no debe ser modificado");
                            return;
                    }

                    query_str = "UPDATE ENER_LAND.Rol SET Habilitado = 0 WHERE idRol = " + id_Rol.ToString();
                    DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo borrar el Rol creado previamente. Falla en la BD");

                    this.dataGrid_Roles.Columns.Clear();
                    ((GestionRoles)FormPadre).Load_Menu();
                }
                else
                {
                    ((GestionRoles)FormPadre).Load_Menu();
                    ((GestionRoles)FormPadre).Modificar_Rol(id_Rol);
                }
            
            }
        }

    }
}
