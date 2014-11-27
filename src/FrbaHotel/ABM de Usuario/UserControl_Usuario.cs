﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class UserControl_Usuario : UserControl
    {
        public Boolean flag_Modificacion;
        public Boolean cambiar_contraseña;
        public Usuario Usuario_A_Modificar;
        public static DataTable TablaLocalidades;
        public static DataTable TablaPaises;
        public static DataTable TablaRoles;
        public static DataTable TablaRolUsuario;
        private Form FormPadre;
        
        public UserControl_Usuario(Form Parent)
        {
            InitializeComponent();
            flag_Modificacion = false;
            FormPadre = Parent;
            CargarTipoDoc();
            CargarLocalidades();
            CargarPaises();
            CargarRoles();

            this.checkBox_Habilitado.Enabled = false;
            cambiar_contraseña = true;
        }

        private void CargarTipoDoc()
        {
            this.ComboBox_TipoDoc.Items.Clear();
            this.ComboBox_TipoDoc.Items.Add("C.I.");
            this.ComboBox_TipoDoc.Items.Add("D.N.I");
            this.ComboBox_TipoDoc.Items.Add("Pasaporte");
        }

        private void CargarLocalidades()
        {
            DbResultSet rs;
            string myQuery = "SELECT * FROM ENER_LAND.Localidad";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaLocalidades = rs.dataTable;

            foreach (DataRow Row in TablaLocalidades.Rows)
            {
                this.ComboBox_Localidad.Items.Add(Row[1].ToString().Trim());
            }

            this.ComboBox_Localidad.Items.Add("Otro");

            return;
        }

        private void CargarPaises()
        {
            DbResultSet rs;
            string myQuery = "SELECT * FROM ENER_LAND.Pais";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaPaises = rs.dataTable;

            foreach (DataRow Row in TablaPaises.Rows)
            {
                this.ComboBox_PaisOrigen.Items.Add(Row[1].ToString().Trim());
            }

            this.ComboBox_PaisOrigen.Items.Add("Otro");

            return;
        }

        public void Cargar_Usuario(Usuario unUsuario)
        {
            flag_Modificacion = true;
            Usuario_A_Modificar = unUsuario;
            this.checkBox_Habilitado.Enabled = true;
            this.textBox_Usuario.Enabled = false;
            

            if (unUsuario.idLocalidad != -1)
            {
                DataRow[] Rows = TablaLocalidades.Select("idLocalidad = " + unUsuario.idLocalidad.ToString().Trim());
                this.ComboBox_Localidad.Text = Rows[0][1].ToString().Trim();
            }
            else
                this.ComboBox_Localidad.SelectedText = "Otro";

            if (unUsuario.idPais != -1)
            {
                DataRow[] Rows = TablaPaises.Select("idPais = " + unUsuario.idPais.ToString().Trim());
                this.ComboBox_PaisOrigen.Text = Rows[0][1].ToString().Trim();
            }
            else
                this.ComboBox_PaisOrigen.SelectedText = "Otro";

            this.textBox_Apellido.Text = unUsuario.Apellido;
            this.textBox_Calle.Text = unUsuario.Calle;
            if(unUsuario.Nro_Documento != -1)
                this.textBox_DNI.Text = unUsuario.Nro_Documento.ToString();
            
            this.textBox_mail.Text = unUsuario.Mail;
            this.textBox_Usuario.Text = unUsuario.username;
            this.textBox_Contraseña.Text = "******";
            this.textBox_Name.Text = unUsuario.Nombre;
            if(unUsuario.Numero != -1)
                this.textBox_Numero.Text = unUsuario.Numero.ToString();

            if (unUsuario.Piso != -1)
                this.textBox_Piso.Text = unUsuario.Piso.ToString();

            if (unUsuario.Telefono != -1)
                this.textBox_Telefono.Text = unUsuario.Telefono.ToString();

            this.textBox_Departamento.Text = unUsuario.Departamento.ToString();

            this.ComboBox_TipoDoc.Text = unUsuario.Tipo_Documento;

            if (unUsuario.Habilitado)
                this.checkBox_Habilitado.CheckState = CheckState.Checked;
            else
                this.checkBox_Habilitado.CheckState = CheckState.Unchecked;

            this.ComboBox_FecNac.Value = unUsuario.Fecha_Nacimiento;

            string query_str = "SELECT * FROM ENER_LAND.Rol_Usuario WHERE idUsuario = " + unUsuario.idUsuario.ToString();
            DbResultSet rs;

            rs = DbManager.GetDataTable(query_str);
            if (rs.operationState == 1)
            {
                MessageBox.Show("ERROR al cargar roles para este usuario");
                ((GestionUsuarios)FormPadre).Load_Menu();
                this.Dispose();
                return;
            }

            TablaRolUsuario = rs.dataTable;

            foreach (DataRow Row in TablaRolUsuario.Rows)
            {
                int idRol = Convert.ToInt32(Row["idRol"]);
                DataRow[] Rows = TablaRoles.Select("idRol = '" + idRol.ToString() + "'");
                String Rol_Description = Rows[0]["Descripcion"].ToString().Trim();
                int index = checkedListBox1.Items.IndexOf(Rol_Description);
                checkedListBox1.SetItemChecked(index, true);
            }

            cambiar_contraseña = false;
        }

        private void CargarRoles()
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT * FROM ENER_LAND.Rol WHERE Habilitado = 1 AND idRol <> 3");
            TablaRoles = rs.dataTable;

            foreach (DataRow Row in TablaRoles.Rows)
            {
                this.checkedListBox1.Items.Add(Row[1].ToString().Trim());
            }
        }
               
        private void Button_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Usuario unUsuario = new Usuario();
            
            unUsuario.Apellido = textBox_Apellido.Text.Trim();
            unUsuario.Calle = textBox_Calle.Text.Trim();
            
            if (!textBox_Departamento.Text.Trim().Equals(""))
                unUsuario.Departamento = Convert.ToChar(textBox_Departamento.Text.Trim());

            unUsuario.Fecha_Nacimiento = this.ComboBox_FecNac.Value;
            
            if (this.checkBox_Habilitado.CheckState == CheckState.Checked)
                unUsuario.Habilitado = true;
            else
                unUsuario.Habilitado = false;

            if (!this.ComboBox_Localidad.Text.Equals("Otro"))
            {
                DataRow[] Rows = TablaLocalidades.Select("Nombre = '" + this.ComboBox_Localidad.Text.ToString().Trim() + "'");
                unUsuario.idLocalidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
            }

            if (!this.ComboBox_PaisOrigen.Text.Equals("Otro"))
            {
                DataRow[] Rows = TablaPaises.Select("Nombre = '" + this.ComboBox_PaisOrigen.Text.ToString().Trim() + "'");
                unUsuario.idPais = Convert.ToInt32(Rows[0][0].ToString().Trim());
            }

            unUsuario.Mail = this.textBox_mail.Text.Trim();

            unUsuario.Nombre = textBox_Name.Text.Trim();
            unUsuario.Nro_Documento = Convert.ToInt32(textBox_DNI.Text.Trim());
            unUsuario.Numero = Convert.ToInt32(textBox_Numero.Text.Trim());
            if (cambiar_contraseña)
                unUsuario.password = Login.LoginForm.encriptar(textBox_Contraseña.Text.Trim());
            else
                unUsuario.password = Usuario_A_Modificar.password;
            
            if (!this.textBox_Piso.Text.Trim().Equals(""))
                unUsuario.Piso = Convert.ToInt32(this.textBox_Piso.Text.Trim());

            unUsuario.Telefono = Convert.ToInt32(this.textBox_Telefono.Text.Trim());
            unUsuario.Tipo_Documento = this.ComboBox_TipoDoc.Text.Trim();

            unUsuario.username = textBox_Usuario.Text.Trim();

            DbResultSet rs;
            string query_str;
            int idRol;

            if (!flag_Modificacion)
            {
                int idUsuario = DbManager.Agregar_Usuario(unUsuario);
                unUsuario.idUsuario = idUsuario;
            }
            else
            {
                unUsuario.idUsuario = Usuario_A_Modificar.idUsuario;
                DbManager.Modificar_Huesped(unUsuario);

                query_str = "DELETE FROM ENER_LAND.Rol_Usuario  " +
                            "WHERE idUsuario = " + unUsuario.idUsuario.ToString();

                rs = DbManager.dbSqlStatementExec(query_str);

                if (rs.operationState == 1)
                {
                    MessageBox.Show("No se pudo Modificar el Rol para este Usuario. Posible fallo en la Base de Datos");
                    return;
                }
            }

            foreach (var Rol in this.checkedListBox1.CheckedItems)
            {
                
                DataRow[] Rows = TablaRoles.Select("Descripcion = '" + Rol.ToString().Trim() + "'");
                
                if (Rows.Length > 0)
                {
                    idRol = Convert.ToInt32(Rows[0][0].ToString().Trim());
                    query_str = "INSERT INTO ENER_LAND.Rol_Usuario ([idUsuario],[idRol]) " +
                                "VALUES( " + unUsuario.idUsuario.ToString() + ", " + idRol.ToString() + ")";


                    rs = DbManager.dbSqlStatementExec(query_str);
                    if (rs.operationState == 1)
                    {
                        MessageBox.Show("No se pudo ingresar el Rol para este Usuario. Posible fallo en la Base de Datos");
                        query_str = "DELETE FROM ENER_LAND.Usuario WHERE idUsuario = " + unUsuario.idUsuario.ToString();
                        rs = DbManager.dbSqlStatementExec(query_str);
                        if (rs.operationState == 1)
                        {
                            MessageBox.Show("Falló en la Base de Datos");
                        }
                        return;
                    }
                }
            }

            ((GestionUsuarios)FormPadre).Load_Menu();

        }

        private void textBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            cambiar_contraseña = true;
        }
    
    }
}
