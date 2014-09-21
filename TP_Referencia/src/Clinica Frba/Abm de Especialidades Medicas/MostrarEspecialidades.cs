using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Clinica_Frba.EspMedicas;

namespace Clinica_Frba.mostrarEspecialidades
{
    public partial class MostrarEspecialidades : Form
    {
        // Formulario anterior a ocultar
        public static EspMedicasABM abmEspMedicas;

        // Formulario para cargar especialidades
        public static DataTable TablaEspecialidades;

        public MostrarEspecialidades(EspMedicasABM sender)
        {
            InitializeComponent();
            abmEspMedicas = sender;
            abmEspMedicas.Visible = false;
            this.Visible = true;
            cargarEspecialidades();
        }

        // Método para botón de cruz
        private void mostrarEspecialidades_FormClosing(object sender, EventArgs e)
        {
            abmEspMedicas.Visible = true;
            this.Dispose();
        }

        // Método para mostrar especialidades
        private void cargarEspecialidades()
        {
            string myQuery = "SELECT T.Descripcion, E.Descripcion " + 
                             "FROM ORACLE_FANS.Especialidades E " +
                             "JOIN ORACLE_FANS.Tipo_Especialidad T on E.Cod_Tipo_Especialidad = T.Cod_Tipo_Especialidad " +
                             "ORDER BY 1, 2";

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaEspecialidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in TablaEspecialidades.Rows)
                {
                    this.dataGridView1.Rows.Add(Row[0].ToString(), Row[1].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            abmEspMedicas.Visible = true;
        }
    }
}
