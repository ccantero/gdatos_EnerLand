using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Security.Cryptography;

namespace FrbaHotel.Login
{
    public partial class LoginForm : Form
    {
        public Form MenuPrincipal;

        public LoginForm(Form parentForm)
        {
            InitializeComponent();
            MenuPrincipal = parentForm;
            //MenuPrincipal.Visible = false;
            //this.ShowDialog();
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
        private void deshabilitarUsuario(string usuario)//, SqlConnection conexion)
        {
            /*SqlCommand comando = new SqlCommand("ORACLE_FANS.deshabilitar_usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@user_name", SqlDbType.VarChar, 10).Value = usuario;
            comando.ExecuteReader();*/
        }

        // Metodo para registrar login invalido
        private void registrarLoginInvalido(string usuario)//, SqlConnection conexion)
        {
            /*SqlCommand comando = new SqlCommand("ORACLE_FANS.intentos_fallidos", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@user_name", SqlDbType.VarChar, 10).Value = usuario;
            comando.ExecuteReader();*/
        }
        
        private void LoginForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void botonCancelar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botonAceptar_Click_1(object sender, EventArgs e)
        {
            // Variable para determinar si el login fue correcto o no
            bool errorLogin = false;
            try
            {

                String query;


                if (this.usuario.Text.Length == 0) errorLogin = true;
                if (this.contraseña.Text.Length == 0) errorLogin = true;

                if (errorLogin == false)
                {
                    query = " SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Habilitado, ROL.idRol" +
                            " FROM ENER_LAND.Usuario U" +
                            " JOIN ENER_LAND.Rol_Usuario RU " +
                            "      ON RU.IdUsuario = U.IdUsuario " +
                            " JOIN ENER_LAND.Rol ROL " +
                            "      ON ROL.IdRol = RU.IdRol " +
                            " WHERE U.username = " + this.usuario.Text +
                            " AND U.Contraseña = " + encriptar(this.contraseña.Text);

                    DbResultSet rs = DbManager.GetDataTable(query);
                    /*tbCalle.Text = rs.dataTable.Rows[0].Field<String>(0);
                    tbAltura.Text = rs.dataTable.Rows[0].Field<Int32>(1).ToString();
                    tbMail.Text = rs.dataTable.Rows[0].Field<String>(2);
                    tbTelefono.Text = rs.dataTable.Rows[0].Field<Int32>(3).ToString();
                    dtpFechaCreacion.Value = rs.dataTable.Rows[0].Field<DateTime>(4);*/


                    if (rs.dataTable.Rows.Count == 0)
                    {
                        // No existe el nombre de usuario
                        errorLogin = true;
                    }
                    else
                    {
                        // El usuario existe
                        String idUsuario = rs.dataTable.Rows[0].Field<Int32>(0).ToString();
                        MessageBox.Show("idUsuario:" + idUsuario);
                        MessageBox.Show("Habilitado:" + rs.dataTable.Rows[0]["Habilitado"].ToString());
                        /*if (ds.Tables["Usuarios"].Rows[0]["estado"].ToString().Trim().Equals("False"))
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
                        }*/
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            MenuPrincipal.Hide();
        }
    }
    
    
}
