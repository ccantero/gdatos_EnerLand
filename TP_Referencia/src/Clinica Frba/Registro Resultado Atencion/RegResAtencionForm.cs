using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Ingreso_Diagnosticos;
using Clinica_Frba.Ingreso_Sintomas;

namespace Clinica_Frba.RegResAtencion
{
    public partial class RegResAtencionForm : Form
    {
        // Menu a ocultar
        MenuPrincipal menu;

        DataTable turno = new DataTable();
        string[] sintomas = new string[6];
        string[] diagnosticos = new string[6];
        int cantSintomasTotales = 0;
        int cantDiagnosticosTotales = 0;
        string[] sintomasAux = new string[51];
        string[] diagAux = new string[11];

        public RegResAtencionForm(MenuPrincipal sender, string afi)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            afiliado.Text = afi;
            fechaTurno.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            for (int i = 0; i < 51; i++)
            {
                sintomasAux[i] = "";
            }
            for (int i = 0; i < 11; i++)
            {
                diagAux[i] = "";
            }
        }

        // Método para boton Volver
        private void button2_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Método para comprobar turno ingresado
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
                           "WHERE Cod_Afiliado = " + afiliado.Text + " " +
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

        // Método para corroborar el número de bono
        private bool corroborarNumBono()
        {
            bool retorno = true;
            if (numBono.Text.Trim() == "")
            {
                retorno = false;
            }
            if (numBono.Text.Trim() == "")
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
                           "WHERE Numero = " + numBono.Text + " " +
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

        // Método para corroborar el turno ingresado
        private bool corroborarTurno()
        {
            bool retorno = true;
            if (minutosTurno.Text.Trim() == "" || horaTurno.Text.Trim() == "")
            {
                retorno = false;
                return retorno;
            }
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
                           "WHERE Cod_Afiliado = " + afiliado.Text + " " +
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

        // Método para ingresar síntomas
        private void button1_Click(object sender, EventArgs e)
        {
            if (!corroborarNumBono())
            {
                MessageBox.Show("El bono ingresado no es válido. Ingrese nuevamente el numero de bono.");
                return;
            }
            if (!corroborarTurno())
            {
                MessageBox.Show("El turno ingresado no es válido. Ingrese nuevamente los campos para turno.");
                return;
            }
            this.Visible = false;
            new IngresoDeSintomas(menu, this, ref sintomas);            
        }

        // Método para ingresar diagnosticos
        public void ingresarDiagnosticos()
        {
            new IngresoDeDiagnosticos(menu, this, ref diagnosticos);
            this.Visible = false;
        }

        // Método para corroborar síntomas ingresados
        public void corroborarSintomas(ref string[] sint)
        {
            int cont = 0;
            if (sint[5] == "no")
            {
                while (sint[cont] != "ninguno" && cont != 5)
                {
                    sintomasAux[cantSintomasTotales] = sint[cont];
                    cantSintomasTotales++;
                    cont++;
                }
                new IngresoDeDiagnosticos(menu, this, ref diagnosticos);
                this.Visible = false;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (sint[i] != "si")
                    {
                        sintomasAux[cantSintomasTotales] = sint[i];
                        cantSintomasTotales++;
                    }
                }
                new IngresoDeSintomas(menu, this, ref sintomas);
            }
        }

        // Método para corroborar diagnosticos
        public void corroborarDiagnosticos(string[] diag)
        {
            int cont = 0;
            if (diag[5] == "no")
            {
                while (diag[cont] != "ninguno" && cont != 5)
                {
                    diagAux[cantDiagnosticosTotales] = diag[cont];
                    cantDiagnosticosTotales++;
                    cont++;
                }
                this.Visible = true;
                registrarDatos();
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (diag[i] != "si")
                    {
                        diagAux[cantDiagnosticosTotales] = diag[i];
                        cantDiagnosticosTotales++;
                    }
                }
                new IngresoDeDiagnosticos(menu, this, ref diagnosticos);
            }
        }

        // Método para registrar todos los datos
        public void registrarDatos()
        {
            string sintomasConsulta = "";
            string diagnosticosConsulta = "";
            int i = 0;
            while (sintomasAux[i] != "")
            {
                if (sintomasAux[i + 1] != "")
                {
                    sintomasConsulta += sintomasAux[i] + "+";
                }
                else
                {
                    sintomasConsulta += sintomasAux[i];
                }
                i++;
            }
            i = 0;
            while (diagAux[i] != "")
            {
                if (diagAux[i + 1] != "")
                {
                    diagnosticosConsulta += diagAux[i] + "+";
                }
                else
                {
                    diagnosticosConsulta += diagAux[i];
                }
                i++;
            }




            // Todo esto de abajo lo voy a terminar cuando mati haga los stores
            /*
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            SqlCommand comando = new SqlCommand("ORACLE_FANS.agregar_resultado_consulta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@num_bono", SqlDbType.Int).Value = Convert.ToInt32(numBono.Text);
            comando.Parameters.Add("@cod_afi", SqlDbType.Int).Value = Convert.ToInt32(afiliado.Text);
            comando.Parameters.Add("@cod_turno", SqlDbType.Int).Value = Convert.ToInt32(turno.Rows[0][0].ToString());
            comando.Parameters.Add("@sintoma", SqlDbType.VarChar, 255).Value = sintomasConsulta;
            comando.Parameters.Add("@diagnostico", SqlDbType.VarChar, 255).Value = diagnosticosConsulta;
            comando.ExecuteReader();
            */



            MessageBox.Show("El resultado de la consulta del afiliado " + afiliado.Text + " correspondiente al bono numero " + numBono.Text + " ha sido ingresado correctamente.");
            menu.Visible = true;
            this.Dispose();
        }
    }
}
