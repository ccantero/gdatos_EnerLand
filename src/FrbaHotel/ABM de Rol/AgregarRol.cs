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
        
        public AgregarRol()
        {
            InitializeComponent();
            Cargar_Funcionalidades();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

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
    }
}
