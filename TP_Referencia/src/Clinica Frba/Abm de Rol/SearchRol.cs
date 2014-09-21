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
    public partial class SearchRol : Form
    {
        public static Rol_Form FormularioRol; //Formulario Principal. Para poder ocultar el formulario anterior
        public static DataTable TablaRoles = new DataTable(); //DataTable para Alojar La consulta de Roles
        public static bool Flag_deletion = false;

        public SearchRol(Rol_Form sender)
        {
            InitializeComponent();
            FormularioRol = sender;
            FormularioRol.Visible = false;
            this.Visible = true;
            Flag_deletion = false;
        }

        public SearchRol(Rol_Form sender, bool FormDeletion)
        {
            InitializeComponent();
            FormularioRol = sender;
            FormularioRol.Visible = false;
            this.Visible = true;
            this.Text = "Eliminar Rol";
            Flag_deletion = true;
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            this.Rol_TextBox.Text = "";
            this.DataGrid_Roles.Columns.Clear();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            CargarRoles();

            if (TablaRoles.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado roles");
                return;
            }

            this.DataGrid_Roles.Columns.Clear();
            this.DataGrid_Roles.DataSource = TablaRoles;
            this.DataGrid_Roles.Visible = true;
            this.DataGrid_Roles.Columns["id_Rol"].Visible = false;
            this.DataGrid_Roles.Columns["isActive"].Visible = false;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.DataGrid_Roles.Columns.Add(btn);
            btn.HeaderText = "Action";

            if (Flag_deletion)
            {
                btn.Text = "Delete";
            }
            else
            {
                btn.Text = "Select";
            }
            
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
        }

        private void CargarRoles()
        {
            
            if (this.Rol_TextBox.Text.Trim().Equals(""))
            {
                if (Flag_deletion)
                {
                    MessageBox.Show("Debe ingresar el nombre del Rol a Eliminar");
                    return;
                }
                
                MessageBox.Show("Debe ingresar el nombre del Rol a Modificar");
                return;
            }

            string myQuery;
            if (Flag_deletion)
            {
                myQuery = "SELECT * FROM ORACLE_FANS.Roles " +
                          "WHERE Nombre LIKE '%" + this.Rol_TextBox.Text.Trim() + "%' " +
                          "AND isActive = 1";
            }
            else
            {
                myQuery = "SELECT * FROM ORACLE_FANS.Roles " +
                          "WHERE Nombre LIKE '%" + this.Rol_TextBox.Text.Trim() + "%'";
            }

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaRoles = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }        
        }

        private void DataGrid_Roles_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            if (e.ColumnIndex == 3)
            {
                if (Flag_deletion)
                {
                    int id_Rol = Convert.ToInt32(TablaRoles.Rows[e.RowIndex]["id_Rol"].ToString());

                    switch (id_Rol)
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

                    if (SQL_Methods.Rol_DarBaja(id_Rol))
                    {
                        MessageBox.Show(TablaRoles.Rows[e.RowIndex]["Nombre"].ToString() + " ha sido eliminado.");
                    }
                    
                    FormularioRol.Visible = true;
                    this.Dispose();
                }
                else
                {
                    int id_Rol = Convert.ToInt32(TablaRoles.Rows[e.RowIndex]["id_Rol"].ToString());
                    new AddModRol(FormularioRol, id_Rol);
                    this.Dispose();        
                }               
            }
        }

        private void SearchRol_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            FormularioRol.Visible = true;
            this.Dispose();
        } 
    
    }
}
