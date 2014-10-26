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
    public partial class AgregarRol : UserControl
    {
        public static DataTable TablaFuncionalidades = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        private Form FormPadre;
        const string single_quote = "\'";


        public AgregarRol(Form Parent)
        {
            InitializeComponent();
            Cargar_Funcionalidades();
            FormPadre = Parent;
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
            Agregar_Rol();
            //GestionRoles FormGestionRoles = (GestionRoles)FormPadre;
            //FormGestionRoles.Load_Menu();
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
        }

        private void Agregar_Rol()
        {
            int rol_Habilitado = 0;

            if(this.checkBox_ActiveRol.Checked)
                rol_Habilitado = 1;

            string query_str =  "INSERT INTO ENER_LAND.Rol " +
                                "VALUES ( " +
                                single_quote + this.textBox_RolName.Text.Trim() + single_quote +
                                ", " + 
                                single_quote + rol_Habilitado.ToString().Trim() + single_quote +
                                " ) ";

            //Test_Forms.DialogForm formDebug = new FrbaHotel.Test_Forms.DialogForm("Query", "Query", query_str);
            //formDebug.Show();
            DbManager.dbSqlStatementExec(query_str);
        }
    }
}
