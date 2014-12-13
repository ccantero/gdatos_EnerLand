using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Security.Cryptography;

namespace FrbaHotel.Login
{
    public partial class LoginForm : Form
    {
        public Form MenuPrincipal;
        const string single_quote = "\'";
        public int currentUser;  /* Usuario Guest */
        public int currentRol;  /* Rol Guest */
        public int currentHotel;  /* Hotel No Definido */
        public Boolean Flag_Error = false;

        public LoginForm(Form parentForm)
        {
            InitializeComponent();
            MenuPrincipal = parentForm;
            MenuPrincipal.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            currentUser = -1;
            currentRol = -1;
            currentHotel = -1;
        }
        
        // Metodo para encriptacion de contraseña
        public static string encriptar(string contraseña)
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
            Check_Login_Attempt();
        }

        private void Check_Login_Attempt()
        {
            // Variable para determinar si el login fue correcto o no
            bool errorLogin = false;
            String query;

            if (this.usuario.Text.Length == 0) errorLogin = true;
            if (this.contraseña.Text.Length == 0) errorLogin = true;

            if (errorLogin == false)
            {
                query = " SELECT U.IdUsuario, U.Contraseña, U.Habilitado, U.intentosfallidos" +
                        " FROM ENER_LAND.Usuario U" +
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
                    currentUser = Convert.ToInt32(rs.dataTable.Rows[0]["idUsuario"].ToString().Trim());
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
                            Flag_Error = false;
                            registrarLoginCorrecto(currentUser);
                            if (!Flag_Error)
                            {
                                usuario_ChooseRol(currentUser);    
                            }

                            if (!Flag_Error)
                            {
                                usuario_ChooseHotel(currentUser);
                            }
                            
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.Show();
            this.Dispose();
        }

        public void CargarMenu()
        {
            if (currentUser == -1 || currentRol == -1 || currentHotel == -1)
                return;

            ((MainForm)MenuPrincipal).UserControl_MainMenu.actualUser = currentUser;
            ((MainForm)MenuPrincipal).UserControl_MainMenu.actualRol = currentRol;
            ((MainForm)MenuPrincipal).UserControl_MainMenu.actualHotel = currentHotel;
            ((MainForm)MenuPrincipal).UserControl_MainMenu.CargarPermisos();
            MenuPrincipal.Visible = true;
            this.Dispose();
        }

        private void usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Check_Login_Attempt();
            }
        }

        private void contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Check_Login_Attempt();
            }
        }

        private void usuario_ChooseRol(int idUsuario)
        {
            string query;
            DbResultSet rs;
            
            query = "SELECT x1.IdRol, x2.Habilitado, x2.Descripcion " +
                    "FROM ENER_LAND.Rol_Usuario x1, ENER_LAND.Rol x2 " +
                    "WHERE x1.idRol = x2.idRol " +
                    "AND x2.Habilitado = 1 " +
                    "AND x1.idUsuario = " + idUsuario.ToString();

            rs = DbManager.GetDataTable(query);

            if (rs.dataTable.Rows.Count == 0)
            {
                MessageBox.Show("El Usuario no dispone de Roles Habilitados para Ingresar al Sistema",
                                "Rol Inhabilitado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                Flag_Error = true;
            }
            else
            {
                if (rs.dataTable.Rows.Count == 1)
                {
                    currentRol = Convert.ToInt32(rs.dataTable.Rows[0]["idRol"].ToString());
                }
                else
                {
                    string[,] roles = new string[rs.dataTable.Rows.Count, 3];
                    int i = 0;

                    foreach (DataRow Row in rs.dataTable.Rows)
                    {
                        roles[i, 0] = Row["idRol"].ToString();
                        roles[i, 1] = Row["Descripcion"].ToString();
                        roles[i, 2] = "Rol";
                        i++;
                    }

                    RolSelectionForm selectRolForm = new RolSelectionForm("Seleccion de Rol",
                                                                          "Por favor seleccione el Rol para Acceder al Sistema",
                                                                          roles,
                                                                          this);
                    selectRolForm.Visible = true;
                }
            }
        }

        public void usuario_ChooseHotel(int idUsuario)
        {
            string query;
            DbResultSet rs;

            if (idUsuario == 1)
            {
                query = "SELECT idHotel, Nombre FROM ENER_LAND.Hotel";
            }
            else
                query = "SELECT x1.idHotel, x2.Nombre " +
                        "FROM ENER_LAND.Usuario_Hoteles x1, ENER_LAND.Hotel x2 " +
                        "WHERE x1.idHotel = x2.idHotel " +
                        "AND x2.Habilitado = 1 " +
                        "AND x1.idUsuario = " + idUsuario.ToString() + " " +
                        "UNION " +
                        "SELECT idHotel, Nombre " +
                        "FROM ENER_LAND.Hotel " +
                        "WHERE Habilitado = 1 " +
                        "AND Administrador = " + idUsuario.ToString();

            rs = DbManager.GetDataTable(query);

            if (rs.dataTable.Rows.Count == 0)
            {
                MessageBox.Show("El Usuario no dispone de Hoteles Habilitados para Ingresar al Sistema",
                                "Hotel Inhabilitado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                MenuPrincipal.Show();
                this.Dispose();
            }
            else
            {
                if (rs.dataTable.Rows.Count == 1)
                {
                    currentHotel = Convert.ToInt32(rs.dataTable.Rows[0]["idHotel"].ToString());
                }
                else
                {
                    string[,] hoteles = new string[rs.dataTable.Rows.Count, 3];
                    int i = 0;

                    foreach (DataRow Row in rs.dataTable.Rows)
                    {
                        hoteles[i, 0] = Row["idHotel"].ToString();
                        hoteles[i, 1] = Row["Nombre"].ToString().Trim();
                        hoteles[i, 2] = "Hotel";
                        i++;
                    }

                    RolSelectionForm selectRolForm = new RolSelectionForm("Seleccion de Hotel",
                                                                          "Por favor seleccione el Hotel para Acceder al Sistema",
                                                                          hoteles,
                                                                          this);
                    selectRolForm.Visible = true;
                }
            }
        }
    }
    
    
}
