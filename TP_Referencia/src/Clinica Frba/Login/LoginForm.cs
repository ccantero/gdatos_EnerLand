using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Security.Cryptography;

using Clinica_Frba;

namespace Clinica_Frba.Login
{
    public partial class LoginForm : Form
    {
        MenuPrincipal menu;

        public LoginForm(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.ShowDialog();
        }

        

        // Metodo para boton aceptar
        public void botonAceptar_Click(object sender, EventArgs e)
        {
            // Variable para determinar si el login fue correcto o no
            bool errorLogin = false;

            // Conexion al server
            SqlConnection myConnection = SQL_Methods.IniciarConnection();

            try
            {
                // Comando donde cargo el store procedure para la validacion del usuario
                SqlCommand comando = new SqlCommand("ORACLE_FANS.proc_login", myConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@user_name", SqlDbType.VarChar, 10).Value = this.usuario.Text;

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds, "Usuarios");
                if (ds.Tables["Usuarios"].Rows.Count == 0)
                {
                    // No existe el nombre de usuario
                    errorLogin = true;
                }
                else
                {
                    // El usuario existe
                    if (ds.Tables["Usuarios"].Rows[0]["estado"].ToString().Trim().Equals("False"))
                    {
                        // Usuario no activo
                        MessageBox.Show("El usuario con el que desea ingresar esta inhabilitado.", "Usuario Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.contraseña.Text = "";
                        this.usuario.Text = "";
                        this.usuario.Select();
                        return;

                    }

                    if (ds.Tables["Usuarios"].Rows[0]["usuario_intentos_fallidos"].ToString().Equals("0"))
                    {
                        // Es la cuarta vez que se intenta iniciar sesion
                        this.deshabilitarUsuario(this.usuario.Text, myConnection);
                        MessageBox.Show("Ud. ha sido bloqueado, comuniquese con su administrador para que lo desbloquee.", "Usuario bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //errorLogin = true;
                        //return;
                    }
                    else
                    {
                        // Intento valido de inicio de sesion
                        if (ds.Tables["Usuarios"].Rows[0]["password"].ToString() == encriptar(this.contraseña.Text))
                        {
                            // La contraseña es correcta
                            //this.Visible = false;
                            int idRol = Convert.ToInt32(ds.Tables["Usuarios"].Rows[0]["id_Rol"].ToString());
                            int numero_documento = -1;
                            if (idRol != 2)
                            {
                                numero_documento = Convert.ToInt32(ds.Tables["Usuarios"].Rows[0]["username"].ToString());
                            }

                            menu.SetRol(idRol, numero_documento); 
                            this.Dispose();
                            return;
                        }
                        else
                        {
                            // La contraseña es incorrecta
                            errorLogin = true;
                            this.registrarLoginInvalido(this.usuario.Text, myConnection);
                        }
                    }
                }
                
                if (errorLogin)
                {
                    MessageBox.Show("Usuario o contraseña inválidos");
                }
                this.contraseña.Text = "";
                this.usuario.Text = "";
                this.usuario.Select();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Error en la aplicación: " + excepcion.Message);
            }
            finally
            {

            }
        }

        // Metodo para boton cancelar
        public void botonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Metodo para encriptacion de contraseña
        static string encriptar(string contraseña)
        {
            SHA256 ShaM = SHA256.Create();
            byte[] data = ShaM.ComputeHash(Encoding.Default.GetBytes(contraseña));
            StringBuilder sbuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuilder.Append(data[i].ToString("x2"));
            }

            return sbuilder.ToString();
        }

        // Metodo para deshabilitar usuario
        private void deshabilitarUsuario(string usuario, SqlConnection conexion)
        {
            SqlCommand comando = new SqlCommand("ORACLE_FANS.deshabilitar_usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@user_name", SqlDbType.VarChar, 10).Value = usuario;
            comando.ExecuteReader();
        }

        // Metodo para registrar login invalido
        private void registrarLoginInvalido(string usuario, SqlConnection conexion)
        {
            SqlCommand comando = new SqlCommand("ORACLE_FANS.intentos_fallidos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@user_name", SqlDbType.VarChar, 10).Value = usuario;
            comando.ExecuteReader();
        }
    }
}
