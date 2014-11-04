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
    public partial class UserControl_Rol : UserControl
    {
        public DataTable TablaFuncionalidades = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        public DataTable TablaRoles = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        public DataTable TablaRolesFuncionalidades = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        private Form FormPadre;
        const string single_quote = "\'";
        public int Rol_Id;


        public UserControl_Rol(Form Parent)
        {
            InitializeComponent();
            Cargar_Funcionalidades();
            FormPadre = Parent;
            Rol_Id = -1;
        }

        private void Cargar_Funcionalidades()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT * FROM ENER_LAND.Funcionalidad");
            TablaFuncionalidades = rs.dataTable;

            foreach (DataRow Row in TablaFuncionalidades.Rows)
            {
                this.checkedListBox_Funcionalidades.Items.Add(Row[1].ToString().Trim());
            }
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (!Check_Fields())
                return;
            
            if (Rol_Id == -1)
                Agregar_Rol();
            else
                Modificar_Rol();

            ((GestionRoles)FormPadre).Load_Menu();
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            this.textBox_RolName.Text = String.Empty;
            
            foreach (int i in this.checkedListBox_Funcionalidades.CheckedIndices)
            {
                this.checkedListBox_Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
            
            this.checkBox_ActiveRol.CheckState = CheckState.Unchecked;

            this.textBox_RolName.Select();

            Rol_Id = -1;
        }

        private void Agregar_Rol()
        {
            int rol_Habilitado = 0;
            bool error_flag = false;
            string query_str;

            if(this.checkBox_ActiveRol.Checked)
                rol_Habilitado = 1;

            int idRol = DbManager.Agregar_Rol(this.textBox_RolName.Text.Trim(), rol_Habilitado);
            if (idRol != -1)
            {
                foreach (var Funcionalidad in this.checkedListBox_Funcionalidades.CheckedItems)
                {
                    DataRow[] Rows = TablaFuncionalidades.Select("Descripcion = '" + Funcionalidad.ToString().Trim() + "'");
                    if (Rows.Length > 0)
                    {
                        
                        int IdFuncionalidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
                        if (!DbManager.Agregar_Funcionalidad(idRol, IdFuncionalidad))
                        {
                            error_flag = true;
                        }
                    }
                }

                if (error_flag)
                {
                    query_str = "DELETE FROM ENER_LAND.Rol_Funcionalidad WHERE idRol = " + idRol.ToString();
                    DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo borrar el Rol creado previamente. Falla en la BD");


                    query_str = "DELETE FROM ENER_LAND.Rol WHERE idRol = " + idRol.ToString();
                    unResultSet = DbManager.dbSqlStatementExec(query_str);

                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo borrar el Rol creado previamente. Falla en la BD");
                }
            }
        }

        private void Modificar_Rol()
        {
            DbResultSet rs;
            bool error_flag = false;
            int rol_Habilitado = 0;

            if (this.checkBox_ActiveRol.Checked)
                rol_Habilitado = 1;


            string query_str =  "UPDATE ENER_LAND.Rol " +
                                "SET Descripcion = " + single_quote + this.textBox_RolName.Text.Trim() + single_quote + ", " +
                                "Habilitado = " + rol_Habilitado.ToString().Trim() + " " +
                                "WHERE idRol = " + Rol_Id.ToString();

            rs = DbManager.dbSqlStatementExec(query_str);
            if (rs.operationState == 1 && !error_flag)
            {
                MessageBox.Show("Falló el renombrado del Rol");
                error_flag = true;
                return;
            }

            query_str = "DELETE FROM ENER_LAND.Rol_Funcionalidad " +
                        "WHERE idRol = " + Rol_Id.ToString();

            rs = DbManager.dbSqlStatementExec(query_str);
            if (rs.operationState == 1 && !error_flag)
            {
                MessageBox.Show("Falló el la eliminación de funcionalidades asociadas a un rol");
                error_flag = true;
                return;
            }

            if (!error_flag)
            {

                foreach (var Funcionalidad in this.checkedListBox_Funcionalidades.CheckedItems)
                {
                    DataRow[] Rows = TablaFuncionalidades.Select("Descripcion = '" + Funcionalidad.ToString().Trim() + "'");
                    if (Rows.Length > 0)
                    {

                        int IdFuncionalidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
                        if (!DbManager.Agregar_Funcionalidad(Rol_Id, IdFuncionalidad))
                        {
                            error_flag = true;
                        }
                    }
                }

                if (error_flag)
                {
                    query_str = "DELETE FROM ENER_LAND.Rol_Funcionalidad WHERE idRol = " + Rol_Id.ToString();
                    DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
                    if (unResultSet.operationState == 1)
                        MessageBox.Show("No se pudo borrar el Rol creado previamente. Falla en la BD");
                }
            }
        }        
        
        public void Cargar_Rol(int idRol)
        {
            DbResultSet rs;
            string query_str =  "SELECT * FROM ENER_LAND.Rol " +
                                "WHERE idRol = " + idRol.ToString();

            rs = DbManager.GetDataTable(query_str);
            if (rs.operationState == 1)
            {
                MessageBox.Show("Falló la busqueda");
                return;
            }
            TablaRoles = rs.dataTable;

            query_str =  "SELECT * FROM ENER_LAND.Rol_Funcionalidad " +
                         "WHERE idRol = " + idRol.ToString();
            
            rs = DbManager.GetDataTable(query_str);
            if (rs.operationState == 1)
            {
                MessageBox.Show("Falló la busqueda");
                return;
            }

            TablaRolesFuncionalidades = rs.dataTable;

            foreach (DataRow Row in TablaRolesFuncionalidades.Rows)
            {
                int id_Funcionalidad = Convert.ToInt32(Row[1]);
                DataRow[] Rows = TablaFuncionalidades.Select("idFuncionalidad = '" + id_Funcionalidad.ToString().Trim() + "'");
                String Descripcion = Rows[0][1].ToString().Trim();
                int index = checkedListBox_Funcionalidades.Items.IndexOf(Descripcion);
                checkedListBox_Funcionalidades.SetItemChecked(index, true);    
            }


            if (TablaRoles.Rows[0][2].ToString().Equals("1")) // Rol Activo
            {
                this.checkBox_ActiveRol.CheckState = CheckState.Checked;
            }

            this.textBox_RolName.Text = TablaRoles.Rows[0][1].ToString();

            Rol_Id = idRol;
        }

        private bool Check_Fields()
        {
            if (this.textBox_RolName.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre de Rol es Obligatorio");
                return false;
            }

            if (this.checkedListBox_Funcionalidades.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por lo menos una funcionalidad debe estar seleccionada.");
                return false;
            }

            return true;
        }
        
    }
}
