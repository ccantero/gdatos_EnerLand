using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Clinica_Frba.Profesional;

namespace Clinica_Frba.addModProfesional
{
    public partial class AddModProfesional : Form
    {
        // Formulario anterior a ocultar
        public static ProfesionalABM abmProfesional;

        // DataTable para alojar la consulta de especialidades
        public static DataTable TablaEspecialidades = new DataTable();

        // Variable para saber si se esta eliminando o modificando un profesional
        bool modificar = false;

        ProfesionalClass profesional = new ProfesionalClass();

        public AddModProfesional(ProfesionalABM sender)
        {
            InitializeComponent();
            abmProfesional = sender;
            abmProfesional.Visible = false;
            this.Visible = true;
            modificar = false;
            this.Text = "ABM Profesionales - Agregar Profesional";
            cargarEspecialidades();
        }

        public AddModProfesional(ProfesionalABM sender, bool flag, ProfesionalClass prof)
        {
            InitializeComponent();
            profesional = prof;
            nombre.Text = profesional.nombre;
            apellido.Text = profesional.apellido;
            numDoc.Text = profesional.numeroDocumento.ToString();
            direccion.Text = profesional.direccion;
            telefono.Text = profesional.numeroTelefono.ToString();
            mail.Text = profesional.mail;
            fecNac.Text = profesional.fechaNacimiento.ToString();
            matricula.Text = profesional.matricula.ToString();
            tipoDocBox.Text = profesional.tipoDocumento;
            sexoBox.Text = Convert.ToString(profesional.sexo);
            matricula.ReadOnly = true;
            numDoc.ReadOnly = true;
            fecNac.Enabled = false;            
            abmProfesional = sender;
            abmProfesional.Visible = false;
            this.Visible = true;
            modificar = flag;
            this.Text = "ABM Profesionales - Modificar Profesional";
            cargarEspecialidades();
        }

        // Método para botón de cruz
        private void agregarProfesional_FormClosing(object sender, EventArgs e)
        {
            abmProfesional.Visible = true;
            this.Dispose();
        }

        // Método para verificar especialidades ingresadas
        private bool verificarEspecialidades()
        {
            bool retorno = true;
            if (EspecialidadesCheckList.CheckedItems.Count == 0)
            {
                retorno = false;
            }
            return retorno;
        }

        // Método para botón guardar
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = SQL_Methods.IniciarConnection();
            SqlCommand comando;
            if (modificar)
            {
                if (!verificarEspecialidades())
                {
                    MessageBox.Show("Debe ingresar al menos 1 especialidad en la cual el profesional se desarrolla.");
                    return;
                }
                // Si se está modificando
                if (comprobarValoresIngresados())
                {
                    comando = new SqlCommand("ORACLE_FANS.modificarProfesional", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Matricula", SqlDbType.Int).Value = Convert.ToInt32(matricula.Text);
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 255).Value = nombre.Text;
                    comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 255).Value = apellido.Text;
                    comando.Parameters.Add("@Tipo_Documento", SqlDbType.VarChar, 6).Value = tipoDocBox.Text;
                    comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 255).Value = direccion.Text;
                    comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = Convert.ToInt32(telefono.Text);
                    comando.Parameters.Add("@Mail", SqlDbType.VarChar, 255).Value = mail.Text;
                    if (sexoBox.Text == "Hombre")
                    {
                        comando.Parameters.Add("@Sexo", SqlDbType.Char).Value = 'H';
                    }
                    else
                    {
                        comando.Parameters.Add("@Sexo", SqlDbType.Char).Value = 'M';
                    }
                    comando.ExecuteReader();
                    comando.Connection.Close();
                    for (int i = 0; i < EspecialidadesCheckList.CheckedItems.Count; i++)
                    {
                        conexion = SQL_Methods.IniciarConnection();
                        SqlCommand comando2 = new SqlCommand("ORACLE_FANS.modif_esp", conexion);
                        comando2.CommandType = CommandType.StoredProcedure;
                        comando2.Parameters.Add("@esp", SqlDbType.VarChar, 255).Value = EspecialidadesCheckList.CheckedItems[i].ToString();
                        comando2.Parameters.Add("@prof", SqlDbType.Int).Value = Convert.ToInt32(matricula.Text);
                        comando2.ExecuteReader();
                        comando2.Connection.Close();
                    }
                    MessageBox.Show(apellido.Text + " " + nombre.Text + " fue modificado exitosamente.");
                    abmProfesional.Visible = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Ingresó valores incorrectos. Por favor verifique los valores.");
                }
            }
            else
            {
                // Si se está agregando
                if (comprobarValoresIngresados())
                {
                    comando = new SqlCommand("ORACLE_FANS.altaProfesional", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 255).Value = nombre.Text;
                    comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 255).Value = apellido.Text;
                    comando.Parameters.Add("@Tipo_Documento", SqlDbType.VarChar, 6).Value = tipoDocBox.Text;
                    comando.Parameters.Add("@Numero_Documento", SqlDbType.Int).Value = Convert.ToInt32(numDoc.Text);
                    comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 255).Value = direccion.Text;
                    comando.Parameters.Add("@Telefono", SqlDbType.Int).Value = Convert.ToInt32(telefono.Text);
                    comando.Parameters.Add("@Mail", SqlDbType.VarChar, 255).Value = mail.Text;
                    comando.Parameters.Add("@Fecha_Nac", SqlDbType.DateTime).Value = Convert.ToDateTime(fecNac.Text);
                    comando.Parameters.Add("@Matricula", SqlDbType.Int).Value = Convert.ToInt32(matricula.Text);
                    if (sexoBox.Text == "Hombre")
                    {
                        comando.Parameters.Add("@Sexo", SqlDbType.Char).Value = 'H';
                    }
                    else
                    {
                        comando.Parameters.Add("@Sexo", SqlDbType.Char).Value = 'M';
                    }
                    comando.ExecuteReader();
                    comando.Connection.Close();
                    for (int i = 0; i < EspecialidadesCheckList.CheckedItems.Count; i++)
                    {
                        conexion = SQL_Methods.IniciarConnection();
                        SqlCommand comando2 = new SqlCommand("ORACLE_FANS.agregar_esp", conexion);
                        comando2.CommandType = CommandType.StoredProcedure;
                        comando2.Parameters.Add("@esp", SqlDbType.VarChar, 255).Value = EspecialidadesCheckList.CheckedItems[i].ToString();
                        comando2.Parameters.Add("@prof", SqlDbType.Int).Value = Convert.ToInt32(matricula.Text);
                        comando2.ExecuteReader();
                        comando2.Connection.Close();
                    }
                    MessageBox.Show(apellido.Text + " " + nombre.Text + " fue agregado exitosamente.");

                    if (!SQL_Methods.Usuario_Crear(1,numDoc.Text.Trim()))
                    {
                        MessageBox.Show("El usuario para el Profesional no pudo ser creado");
                    }
                    
                    abmProfesional.Visible = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Ingresó valores incorrectos. Por favor verifique los valores.");
                }
            }
        }

        // Método para verificar valores ingresados
        private bool comprobarValoresIngresados()
        {
            bool retorno = true;
            if (tipoDocBox.Text.Trim() == "" || sexoBox.Text.Trim() == "" || nombre.Text.Trim() == "" || apellido.Text.Trim() == "" || numDoc.Text.Trim() == "" || direccion.Text.Trim() == "" || telefono.Text.Trim() == "" || mail.Text.Trim() == "" || matricula.Text.Trim() == "")
            {
                retorno = false;
            }
            if (!tipoDocBox.Items.Contains(tipoDocBox.Text) || !sexoBox.Items.Contains(sexoBox.Text))
            {
                retorno = false;
            }
            if (@Clinica_Frba.Properties.Settings.Default.Fecha.Year - Convert.ToDateTime(fecNac.Text).Year < 17)
            {
                retorno = false;
            }
            return retorno;
        }

        // Método para botón volver
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            abmProfesional.Visible = true;
        }

        private void cargarTipoDoc()
        {
            this.tipoDocBox.Items.Add("D.N.I.");
            this.tipoDocBox.Items.Add("L.E.");
            this.tipoDocBox.Items.Add("L.C.");
        }

        private void cargarGenero()
        {
            this.sexoBox.Items.Add("Hombre");
            this.sexoBox.Items.Add("Mujer");
        }

        // Método para llenar la tabla de especialidades
        private void cargarEspecialidades()
        {
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();
            string myQuery = "SELECT Descripcion FROM ORACLE_FANS.Especialidades " +
                             "ORDER BY 1";
            DataTable TablaEspecialidades2 = new DataTable();
            int cantEspMedico = 0;
            if (modificar)
            {
                string query2 = "SELECT E.Descripcion FROM ORACLE_FANS.Especialidades E " +
                                "JOIN ORACLE_FANS.Medico_Especialidad ME on ME.Cod_Especialidad = E.Cod_Especialidad " +
                                "JOIN ORACLE_FANS.Profesionales P ON P.Matricula = ME.Matricula " +
                                "WHERE P.Matricula = " + matricula.Text;
                TablaEspecialidades2 = SQL_Methods.EjecutarProcedure(myConnection, query2);
                cantEspMedico = Convert.ToInt32(TablaEspecialidades2.Rows.Count.ToString());
            }
            if (SQL_Methods.DBConnectStatus)
            {
                TablaEspecialidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
                foreach (DataRow Row in TablaEspecialidades.Rows)
                {
                    this.EspecialidadesCheckList.Items.Add(Row[0].ToString().Trim());
                    if (modificar)
                    {
                        string id_Especialidad = Row[0].ToString();
                        DataRow[] Rows = TablaEspecialidades.Select("Descripcion = '" + id_Especialidad.Trim() + "'");
                        String Descripcion = Rows[0][0].ToString().Trim();
                        for (int i = 0; i < cantEspMedico; i++)
                        {
                            if (Descripcion == TablaEspecialidades2.Rows[i][0].ToString())
                            {
                                int index = this.EspecialidadesCheckList.Items.IndexOf(Descripcion);
                                this.EspecialidadesCheckList.SetItemChecked(index, true);
                            }
                        }
                    }
                }
            }
        }

        private void AddModProfesional_Load_1(object sender, EventArgs e)
        {
            cargarGenero();
            cargarTipoDoc();
        }

        // Método para botón limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            this.nombre.Text = "";
            this.apellido.Text = "";
            this.fecNac.Text = @Clinica_Frba.Properties.Settings.Default.Fecha.ToString();
            this.tipoDocBox.Text = "";
            this.sexoBox.Text = "";
            if (!modificar)
            {
                this.numDoc.Text = "";
                this.matricula.Text = "";
            }
            this.direccion.Text = "";
            this.telefono.Text = "";
            this.mail.Text = "";
            for (int i = 0; i < EspecialidadesCheckList.Items.Count; i++)
            {
                EspecialidadesCheckList.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
