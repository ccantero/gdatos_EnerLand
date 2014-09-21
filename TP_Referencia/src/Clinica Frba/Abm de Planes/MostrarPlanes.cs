using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Clinica_Frba.Planes;

namespace Clinica_Frba.mostrarPlan
{
    public partial class MostrarPlanes : Form
    {
        // Formulario anterior a ocultar
        public static PlanesABM abmPlanes;

        // Formulario para cargar planes médicos
        public static DataTable TablaPlanes;

        public MostrarPlanes(PlanesABM sender)
        {
            InitializeComponent();
            abmPlanes = sender;
            abmPlanes.Visible = false;
            this.Visible = true;
            cargarPlanes();
        }

        // Método para mostrar planes médicos
        private void cargarPlanes()
        {
            string myQuery = "SELECT Descripcion, Precio_Bono_Consulta, Precio_Bono_Farmacia " +
                             "FROM ORACLE_FANS.Planes_Medicos " +
                             "ORDER by 1";
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaPlanes = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in TablaPlanes.Rows)
                {
                    this.dataGridView1.Rows.Add(Row[0].ToString(), Row[1].ToString(), Row[2].ToString());
                }
            }
        }

        // Método para botón de cruz
        private void mostrarPlanes_FormClosing(object sender, EventArgs e)
        {
            abmPlanes.Visible = true;
            this.Dispose();
        }

        // Método para botón volver
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            abmPlanes.Visible = true;
        }
    }
}
