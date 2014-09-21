using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class AddModRol : Form
    {
        public static Rol_Form FormularioRol; //Formulario Principal. Para poder ocultar el formulario anterior
        public static DataTable TablaFuncionalidades = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        public static DataTable TablaRoles = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        public static DataTable TablaRolesFuncionalidades = new DataTable(); //DataTable para Alojar La consulta de Funcionalidades
        public static bool Flag_Modification;

        public AddModRol(Rol_Form sender)
        {
            InitializeComponent();
            FormularioRol = sender;
            FormularioRol.Visible = false;
            this.Visible = true;
            Flag_Modification = false;

            this.label_activo.Visible = false;
            this.box_checkActive.Visible = false;

            this.CleanButton.Location = new System.Drawing.Point(12, 230);
            this.SaveButton.Location = new System.Drawing.Point(232, 230);
            this.ClientSize = new System.Drawing.Size(319, 265);
        }

        public AddModRol(Rol_Form sender, int id_Rol) // Redefinicion para el caso de Modificacion
        {
            InitializeComponent();
            this.Visible = true;
            FormularioRol = sender;
            FormularioRol.Visible = false;
            Flag_Modification = true;
            this.Text = "ABM Roles - Modificar un Rol";
            CargarRol(id_Rol);

            this.label_activo.Visible = true;
            this.box_checkActive.Visible = true;
        }

        private void CargarRol(int id_Rol) // Metodo Exclusivo para Modificacion de Roles
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Roles " +
                             "WHERE id_Rol = " + id_Rol.ToString() + "";
            
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaRoles = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }

            this.NameTextBox.Text = TablaRoles.Rows[0][1].ToString();
            
            myQuery = "SELECT * FROM ORACLE_FANS.Roles_Funcionalidad " +
                      "WHERE id_Rol = " + id_Rol.ToString();

            if (SQL_Methods.DBConnectStatus)
            {
                TablaRolesFuncionalidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in TablaRolesFuncionalidades.Rows)
                {
                    int id_Funcionalidad = Convert.ToInt32(Row[0]);
                    DataRow[] Rows = TablaFuncionalidades.Select("id_funcionalidad = '" + id_Funcionalidad.ToString().Trim() + "'");
                    String Descripcion = Rows[0][1].ToString().Trim();
                    int index = FuncionalidadesCheckList.Items.IndexOf(Descripcion);
                    FuncionalidadesCheckList.SetItemChecked(index, true);
                    
                }
            }

            if (Convert.ToBoolean(TablaRoles.Rows[0][2].ToString())) // Rol Activo
            {
                this.box_checkActive.CheckState = CheckState.Checked;
                this.box_checkActive.Enabled = false;
            }

        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            this.NameTextBox.Text = "";
            int i = 0;

            foreach (DataRow item in TablaFuncionalidades.Rows) // Destildar Funcionalidades
            {
                //MessageBox.Show(item[1].ToString());
                //int index = this.FuncionalidadesCheckList.Items.IndexOf(item[1].ToString());
                this.FuncionalidadesCheckList.SetItemChecked(i, false);
                i++;
            }
            this.NameTextBox.Select();
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int idRol; 

            if (this.NameTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("El nombre del Rol no puede ser vacio");
                return;
            }
            
            if (Flag_Modification)
            {
                idRol = Convert.ToInt32(TablaRoles.Rows[0][0].ToString());
                switch (idRol)
                {
                    case 1:
                        MessageBox.Show("El Rol Afiliado no debe ser modificado");
                        return;
                    case 2:
                        MessageBox.Show("El Rol Administrativo no debe ser modificado");
                        return;
                    case 3:
                        MessageBox.Show("El Rol Profesional no debe ser modificado");
                        return;
                }
                
                if (!this.NameTextBox.Text.Trim().Equals(TablaRoles.Rows[0][1].ToString()))
                {
                    if (!SQL_Methods.Rol_Renombrar(idRol,this.NameTextBox.Text.Trim()))
	                {
		                MessageBox.Show("Error al renombrar el Rol");
	                }
                }

                if (!SQL_Methods.Rol_EliminarFuncionalidades(idRol))
                {
                    MessageBox.Show("Error al eliminar funcionalidades el Rol");
                }

                if (!AgregarFuncionalidades(idRol))
                {
                    MessageBox.Show("[ERROR] - No se pudo agregar alguna de las funcionalidades.");
                    FormularioRol.Visible = true;
                    this.Dispose();
                    return;
                }


                if (box_checkActive.Checked && box_checkActive.Enabled)
                {
                    if (!SQL_Methods.Rol_Habilitar(idRol))
                    {
                        MessageBox.Show("[ERROR] - No se pudo habilitar el rol");
                        FormularioRol.Visible = true;
                        this.Dispose();
                        return;
                    }
                }

                FormularioRol.Visible = true;
                this.Dispose();
                return;
            }
            

            idRol = SQL_Methods.Rol_DarAlta(this.NameTextBox.Text.Trim());

            if ( idRol > 0)
            {                
                if (!AgregarFuncionalidades(idRol))
                {
                    MessageBox.Show("[ERROR] - No se pudo agregar alguna de las funcionalidades.");
                    FormularioRol.Visible = true;
                    this.Dispose();
                    return;
                }
                MessageBox.Show(this.NameTextBox.Text.Trim() + " ha sido agregado.");
                FormularioRol.Visible = true;
                this.Dispose();
                return;
            }
            else
            {
                MessageBox.Show(this.NameTextBox.Text.Trim() + " no pudo ser agregado.");
                return;
            }

        }

        private void AddModRol_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            FormularioRol.Visible = true;
            this.Dispose();
        } 

        public void CargarFuncionalidades() // Método para llenar Tabla de Funcionalidades
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Funcionalidades";
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaFuncionalidades = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in TablaFuncionalidades.Rows)
                {
                    this.FuncionalidadesCheckList.Items.Add(Row[1].ToString().Trim());
                }
            }
        }

        private void AddModRol_Load(object sender, EventArgs e)
        {
            CargarFuncionalidades();
        }

        private bool AgregarFuncionalidades(int idRol)
        {
            foreach (var item in this.FuncionalidadesCheckList.CheckedItems)
            {
                DataRow[] Rows = TablaFuncionalidades.Select("Descripcion = '" + item.ToString().Trim() + "'");
                if (Rows.Length > 0)
                {
                    int IdFuncionalidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
                    if (!SQL_Methods.Rol_AgregarFuncionalidad(idRol, IdFuncionalidad))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    
    }
}
