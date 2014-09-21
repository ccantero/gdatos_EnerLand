using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Clinica_Frba.GenerarReceta
{
    public partial class GenerarRecetaForm : Form
    {
        // Formulario anterior a ocultar
        private MenuPrincipal menu;

        // Código de turno
        private DataTable turno = new DataTable();
        
        public GenerarRecetaForm(MenuPrincipal sender, string afi)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            numeroAfiliado.Text = afi;
            numeroAfiliado.ReadOnly = true;
            enLetras1.Text = "Uno";
            enLetras2.Text = "Uno";
            enLetras3.Text = "Uno";
            enLetras4.Text = "Uno";
            enLetras5.Text = "Uno";
            fechaTurno.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            fecha1.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            fecha2.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            fecha3.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            fecha4.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            fecha5.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            cargarMedicamentos();
        }

        // Método para setear afiliado
        public void setearAfiliado(string afi)
        {
            numeroAfiliado.Text = afi;
        }

        // Metodo para boton de cruz
        private void generarReceta_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Metodo para boton volver
        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cantMed1.Value = 1;
            cantMed2.Value = 1;
            cantMed3.Value = 1;
            cantMed4.Value = 1;
            cantMed5.Value = 1;
            numeroBono.Text = "";
            med1.Text = "";
            med2.Text = "";
            med3.Text = "";
            med4.Text = "";
            med5.Text = "";
        }

        // Método para comprobar turno
        private bool comprobarTurno()
        {
            bool retorno = true;
            if (horaTurno.Text.Trim() == "" || minutosTurno.Text.Trim() == "")
            {
                retorno = false;
                return retorno;
            }
            int añoTurno = Convert.ToDateTime(fechaTurno.Text).Year;
            int mesTurno = Convert.ToDateTime(fechaTurno.Text).Month;
            int diaTurno = Convert.ToDateTime(fechaTurno.Text).Day;
            DateTime fecha = new DateTime(añoTurno, mesTurno, diaTurno);
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT * FROM ORACLE_FANS.Turnos " +
                           "WHERE Cod_Afiliado = " + numeroAfiliado.Text + " " +
                           "AND Fecha = '" + fecha.ToString() + " " + horaTurno.Text + ":" + minutosTurno.Text + ":00' " +
                           "AND habilitado = 1";
            turno = SQL_Methods.EjecutarProcedure(conexion, query);
            if (turno.Rows.Count == 0)
            {
                retorno = false;
                MessageBox.Show("La fecha del turno ingresada no es válida. Ingrese nuevamente los campos fecha, hora y minutos.");
            }
            return retorno;
        }

        private bool comprobarValoresTurno()
        {
            bool retorno = true;
            if (minutosTurno.Text.Trim() == "" || horaTurno.Text.Trim() == "")
            {
                retorno = false;
            }
            return retorno;
        }

        // Método para botón generar receta
        private void button3_Click(object sender, EventArgs e)
        {
            if (!comprobarBono())
            {
                return;
            }
            if (!comprobarMedicamentos(Convert.ToInt32(cantMed.Value)))
            {
                MessageBox.Show("Debe ingresar medicamentos existentes en las opciones que se ofrecen. Re ingrese los medicamentos.");
                return;
            }
            if (!comprobarNombresMedicamentos(Convert.ToInt32(cantMed.Value)))
            {
                MessageBox.Show("Debe ingresar medicamentos distintos en la misma receta. Re ingrese los medicamentos.");
                return;
            }
            if (numeroAfiliado.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un número de afiliado.");
                return;
            }
            if (!comprobarValoresTurno())
            {
                MessageBox.Show("Debe ingresar valores en los campos de turno válidos. La hora y los minutos del turno deben ser los de las opciones ofrecidas. Re ingrese los valores.");
                return;
            }
            if (comprobarTurno())
            {
                int[] cantidades = new int[5];
                string[] medicamentos = new string[5];
                DateTime[] prescripciones = new DateTime[5];
                cantidades[0] = Convert.ToInt32(cantMed1.Value);
                prescripciones[0] = Convert.ToDateTime(fecha1.Text);
                cantidades[1] = Convert.ToInt32(cantMed2.Value);
                prescripciones[1] = Convert.ToDateTime(fecha2.Text);
                cantidades[2] = Convert.ToInt32(cantMed3.Value);
                prescripciones[2] = Convert.ToDateTime(fecha3.Text);
                cantidades[3] = Convert.ToInt32(cantMed4.Value);
                prescripciones[3] = Convert.ToDateTime(fecha4.Text);
                cantidades[4] = Convert.ToInt32(cantMed5.Value);
                prescripciones[4] = Convert.ToDateTime(fecha5.Text);
                if (med1.Text.Trim() != "")
                {
                    medicamentos[0] = med1.Text;
                }
                else
                {
                    medicamentos[0] = "ninguno";
                }

                if (med2.Text.Trim() != "")
                {
                    medicamentos[1] = med2.Text;
                }
                else
                {
                    medicamentos[1] = "ninguno";
                }

                if (med3.Text.Trim() != "")
                {
                    medicamentos[2] = med3.Text;
                }
                else
                {
                    medicamentos[2] = "ninguno";
                }

                if (med4.Text.Trim() != "")
                {
                    medicamentos[3] = med4.Text;
                }
                else
                {
                    medicamentos[3] = "ninguno";
                }

                if (med5.Text.Trim() != "")
                {
                    medicamentos[4] = med5.Text;
                }
                else
                {
                    medicamentos[4] = "ninguno";
                }
                if (comprobarBono())
                {
                    for (int i = 0; i < Convert.ToInt32(cantMed.Value); i++)
                    {
                        SqlConnection conexion = SQL_Methods.IniciarConnection();
                        SqlCommand comando = new SqlCommand("ORACLE_FANS.crearReceta", conexion);
                        SqlCommand comando2 = new SqlCommand("ORACLE_FANS.medicamentosRecetadosP", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@num_bono", SqlDbType.Int).Value = Convert.ToInt32(numeroBono.Text);
                        comando.Parameters.Add("@Cod_Turno", SqlDbType.Int).Value = turno.Rows[0][0].ToString();
                        comando2.Parameters.Add("@nom_med", SqlDbType.VarChar, 255).Value = medicamentos[i];
                        comando2.Parameters.Add("@cant_med", SqlDbType.Int).Value = cantidades[i];
                        comando2.Parameters.Add("@pres_med", SqlDbType.DateTime).Value = prescripciones[i];
                        comando2.Parameters.Add("@cod_turno", SqlDbType.Int).Value = turno.Rows[0][0].ToString();
                        comando.ExecuteReader();
                        comando.Connection.Close();
                        comando2.ExecuteReader();
                        comando2.Connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ingresó algún valor de forma incorrecta. Por favor re-ingrese los valores.");
                }
            }
        }

        private bool comprobarBono()
        {
            bool retorno = true;
            if (numeroBono.Text.Trim() == "")
            {
                MessageBox.Show("No ingresó ningún número de bono. Ingrese un número de bono para su verificación.");
                retorno = false;
                return retorno;
            }
            int fechaActual = 0;
            fechaActual += @Clinica_Frba.Properties.Settings.Default.Fecha.Day;
            fechaActual += @Clinica_Frba.Properties.Settings.Default.Fecha.Month * 100;
            fechaActual += @Clinica_Frba.Properties.Settings.Default.Fecha.Year * 10000;
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT * FROM ORACLE_FANS.Bono_Farmacia " +
                           "WHERE Numero = " + numeroBono.Text + " " +
                           "AND Activo = 1 " +
                           "AND Fecha_Impresion <= '" + fechaActual.ToString() + "' " +
                           "AND Fecha_Vencimiento > '" + fechaActual.ToString() + "' ";

            DataTable bonos = new DataTable();
            bonos = SQL_Methods.EjecutarProcedure(conexion, query);
            if (bonos.Rows.Count != 0)
            {
                MessageBox.Show("El bono ingresado es correcto.");
            }
            else
            {
                MessageBox.Show("El bono ingresado es incorrecto o ya venció.");
                retorno = false;
                return retorno;
            }
            return retorno;
        }

        private void cantMed1_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cantMed1.Value))
            {
                case 1:
                    enLetras1.Text = "Uno";
                    break;
                case 2:
                    enLetras1.Text = "Dos";
                    break;
                case 3:
                    enLetras1.Text = "Tres";
                    break;
            }
        }

        private void cantMed2_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cantMed2.Value))
            {
                case 1:
                    enLetras2.Text = "Uno";
                    break;
                case 2:
                    enLetras2.Text = "Dos";
                    break;
                case 3:
                    enLetras2.Text = "Tres";
                    break;
            }
        }

        private void cantMed3_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cantMed3.Value))
            {
                case 1:
                    enLetras3.Text = "Uno";
                    break;
                case 2:
                    enLetras3.Text = "Dos";
                    break;
                case 3:
                    enLetras3.Text = "Tres";
                    break;
            }
        }

        private void cantMed4_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cantMed4.Value))
            {
                case 1:
                    enLetras4.Text = "Uno";
                    break;
                case 2:
                    enLetras4.Text = "Dos";
                    break;
                case 3:
                    enLetras4.Text = "Tres";
                    break;
            }
        }

        private void cantMed5_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cantMed5.Value))
            {
                case 1:
                    enLetras5.Text = "Uno";
                    break;
                case 2:
                    enLetras5.Text = "Dos";
                    break;
                case 3:
                    enLetras5.Text = "Tres";
                    break;
            }
        }

        // Método para cargar medicamentos
        private void cargarMedicamentos()
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            string query = "SELECT Descripcion FROM ORACLE_FANS.Medicamentos_Acomodados";
            DataTable tablaMedicamentos = new DataTable();
            tablaMedicamentos = SQL_Methods.EjecutarProcedure(conexion, query);
            for (int i = 0; i < Convert.ToInt32(tablaMedicamentos.Rows.Count.ToString()); i++)
            {
                med1.Items.Add(tablaMedicamentos.Rows[i][0]);
                med2.Items.Add(tablaMedicamentos.Rows[i][0]);
                med3.Items.Add(tablaMedicamentos.Rows[i][0]);
                med4.Items.Add(tablaMedicamentos.Rows[i][0]);
                med5.Items.Add(tablaMedicamentos.Rows[i][0]);
            }
        }

        // Método para comprobar nombres de medicamentos
        private bool comprobarMedicamentos(int cant)
        {
            bool retorno = true;
            switch (cant)
            {
                case 1:
                    break;
                case 2:
                    if (med1.Text == med2.Text)
                    {
                        retorno = false;
                    }
                    break;
                case 3:
                    if (med1.Text == med2.Text || med1.Text == med3.Text
                        || med2.Text == med3.Text)
                    {
                        retorno = false;
                    }
                    break;
                case 4:
                    if (med1.Text == med2.Text || med1.Text == med3.Text
                        || med1.Text == med4.Text || med2.Text == med3.Text
                        || med2.Text == med4.Text || med3.Text == med4.Text)
                    {
                        retorno = false;
                    }
                    break;
                case 5:
                    if (med1.Text == med2.Text || med1.Text == med3.Text
                        || med1.Text == med4.Text || med1.Text == med5.Text
                        || med2.Text == med3.Text || med2.Text == med4.Text
                        || med2.Text == med5.Text || med3.Text == med4.Text
                        || med3.Text == med5.Text || med4.Text == med5.Text)
                    {
                        retorno = false;
                    }
                    break;
            }
            return retorno;
        }

        // Método para verificar existencia de medicamentos en la base de datos
        private bool comprobarNombresMedicamentos(int cant)
        {
            bool retorno = true;
            switch (cant)
            {
                case 1:
                    if (!med1.Items.Contains(med1.Text))
                    {
                        retorno = false;
                        return retorno;
                    }
                    break;
                case 2:
                    if (!med1.Items.Contains(med1.Text)
                        || !med2.Items.Contains(med2.Text))
                    {
                        retorno = false;
                        return retorno;
                    }
                    break;
                case 3:
                    if (!med1.Items.Contains(med1.Text)
                        || !med2.Items.Contains(med2.Text)
                        || !med3.Items.Contains(med3.Text))
                    {
                        retorno = false;
                        return retorno;
                    }
                    break;
                case 4:
                    if (!med1.Items.Contains(med1.Text)
                        || !med2.Items.Contains(med2.Text)
                        || !med3.Items.Contains(med3.Text)
                        || !med4.Items.Contains(med4.Text))
                    {
                        retorno = false;
                        return retorno;
                    }
                    break;
                case 5:
                    if (!med1.Items.Contains(med1.Text)
                        || !med2.Items.Contains(med2.Text)
                        || !med3.Items.Contains(med3.Text)
                        || !med4.Items.Contains(med4.Text)
                        || !med5.Items.Contains(med5.Text))
                    {
                        retorno = false;
                        return retorno;
                    }
                    break;
            }
            return retorno;
        }
    }
}
