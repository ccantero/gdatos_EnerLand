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
        const string single_quote = "\'";

        public LoginForm(Form parentForm)
        {
            InitializeComponent();
            MenuPrincipal = parentForm;
            MenuPrincipal.Visible = false;
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
        private void deshabilitarUsuario(string usuario)
        {
            string query_str =  "UPDATE ENER_LAND.Usuario " + 
                                "SET Habilitado = 0 " +
                                "WHERE username = " + single_quote + usuario + single_quote;
            DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
            if (unResultSet.operationState == 1)
                MessageBox.Show("No se pudo deshabilitar el Usuario. Falla en la BD");
        }

        // Metodo para registrar login invalido
        private void registrarLoginInvalido(string usuario)//
        {
            string query_str = "UPDATE ENER_LAND.Usuario " +
                                "SET intentosFallidos = intentosFallidos + 1 " +
                                "WHERE username = " + single_quote + usuario + single_quote;

            DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
            if (unResultSet.operationState == 1)
                MessageBox.Show("No se pudo registrar intento Fallido de Login. Falla en la BD");
        }

        // Metodo para registrar login correcto
        private void registrarLoginCorrecto(int idUsuario)//
        {
            string query_str = "UPDATE ENER_LAND.Usuario " +
                                "SET intentosFallidos = 0 " +
                                "WHERE idUsuario = " + idUsuario.ToString();

            DbResultSet unResultSet = DbManager.dbSqlStatementExec(query_str);
            if (unResultSet.operationState == 1)
                MessageBox.Show("No se pudo registrar intento correcto de Login. Falla en la BD");
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
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
                    query = " SELECT U.IdUsuario, U.Contraseña, U.Habilitado, ROL.idRol, U.intentosfallidos" +
                            " FROM ENER_LAND.Usuario U" +
                            " JOIN ENER_LAND.Rol_Usuario RU " +
                            "      ON RU.IdUsuario = U.IdUsuario " +
                            " JOIN ENER_LAND.Rol ROL " +
                            "      ON ROL.IdRol = RU.IdRol " +
                            " WHERE U.username = " + single_quote + this.usuario.Text + single_quote;

                    DbResultSet rs = DbManager.GetDataTable(query);

                    if (rs.dataTable.Rows.Count == 0)
                    {
                        // No existe el nombre de usuario
                        errorLogin = true;
                    }
                    else
                    {
                        // El usuario existe
                        int idUsuario = Convert.ToInt32(rs.dataTable.Rows[0]["idUsuario"].ToString().Trim());
                        String Password = rs.dataTable.Rows[0]["Contraseña"].ToString().Trim();
                        Boolean habilitado;
                        int intentos_fallidos = Convert.ToInt32(rs.dataTable.Rows[0]["intentosFallidos"].ToString().Trim());

                        if (rs.dataTable.Rows[0]["Habilitado"].ToString().Trim().Equals("1"))
                            habilitado = true;
                        else
                            habilitado = false;

                        if (habilitado)
                        {
                            if (Password.Equals(encriptar(this.contraseña.Text.Trim()).Trim()))
                            {
                                ((MainForm)MenuPrincipal).UserControl_MainMenu.actualUser = 1;
                                ((MainForm)MenuPrincipal).UserControl_MainMenu.CargarPermisos();
                                registrarLoginCorrecto(idUsuario);
                                MenuPrincipal.Visible = true;
                                this.Dispose();
                            }
                            else
                            {
                                if (intentos_fallidos == 3)
                                {
                                    MessageBox.Show("Ud. ha sido bloqueado, comuniquese con su administrador para que lo desbloquee.", "Usuario bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    deshabilitarUsuario(this.usuario.Text);
                                }

                                registrarLoginInvalido(this.usuario.Text);
                                errorLogin = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario con el que desea ingresar esta inhabilitado.", "Usuario Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }
    }
    
    
}
