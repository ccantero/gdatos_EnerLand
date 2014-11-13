﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class UserControl_BuscarHuesped : UserControl
    {
        private Form FormPadre;
        public static DataTable TablaHuespedes = new DataTable();

        public UserControl_BuscarHuesped(Form parentForm)
        {
            InitializeComponent();
            FormPadre = parentForm;
        }

        private void button_search_Click(object sender, EventArgs e)
        {   
            DbResultSet rs;

            if (this.textBox_nombre.Text.Trim().Equals("") &&
               this.textBox_apellido.Text.Trim().Equals("") &&
               this.comboBox_TipoDocumento.Text.Trim().Equals("") &&
               this.textbox_NroDocumento.Text.Trim().Equals("")  &&
               this.textBox_Mail.Text.Trim().Equals("")
               )
            {
                MessageBox.Show("Debe introducir al menos un criterio de búsqueda");
                return;
            }

            string myQuery =    "SELECT	x1.idHuesped, " +
                                "x1.Apellido, " +
		                        "x1.Nombre, " +
		                        "x1.Tipo_Documento, " +
		                        "x1.Nro_Documento, " +
		                        "x1.Fecha_Nacimiento, " +
		                        "x1.Nacionalidad, " +
		                        "Mail = CASE WHEN x1.Mail IS NULL THEN x1.Mail_Alternativo ELSE x1.Mail END, " +
		                        "x1.Calle, " +
		                        "x1.Numero, " +
		                        "x1.Piso, " +
		                        "x1.Departamento, " +
		                        "x1.idLocalidad, " +
		                        "x1.Telefono, " +
		                        "x1.Habilitado, " +
		                        "MailIncorrecto = CASE WHEN x1.Mail IS NULL THEN 1 ELSE 0 END " +
                                "FROM ENER_LAND.Huesped x1 " +
                                "WHERE Nombre LIKE '%" + this.textBox_nombre.Text.Trim() + "%' " +
                                "AND Apellido LIKE '%" + this.textBox_apellido.Text.Trim() + "%' " +
                                "AND Tipo_Documento LIKE '%" + this.comboBox_TipoDocumento.Text.Trim() + "%' " +
                                "AND Nro_Documento LIKE '%" + this.textbox_NroDocumento.Text.Trim() + "%' " +
                                "AND ( Mail LIKE '%" + this.textBox_Mail.Text.Trim() + "%' " +
                                      "OR Mail_Alternativo LIKE '%" + this.textBox_Mail.Text.Trim() + "%' " +
                                ")";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaHuespedes = rs.dataTable;

            if (TablaHuespedes.Rows.Count == 0)
            {
                MessageBox.Show("No se han encontrado Huespedes");
                // TODO: Habilitar Boton Crear Huesped.
                return;
            }

            this.dataGrid_Huespedes.Columns.Clear();
            this.dataGrid_Huespedes.AllowUserToAddRows = false;
            this.dataGrid_Huespedes.AllowUserToOrderColumns = false;
            
            this.dataGrid_Huespedes.DataSource = TablaHuespedes;
            this.dataGrid_Huespedes.Visible = true;
            
            this.dataGrid_Huespedes.Columns["idLocalidad"].Visible = false;
            this.dataGrid_Huespedes.Columns["idHuesped"].Visible = false;
            this.dataGrid_Huespedes.Columns["MailIncorrecto"].Visible = false;
            this.dataGrid_Huespedes.Columns["Habilitado"].Visible = false;
            this.dataGrid_Huespedes.Columns["Telefono"].Visible = false;
            this.dataGrid_Huespedes.Columns["Calle"].Visible = false;
            this.dataGrid_Huespedes.Columns["Numero"].Visible = false;
            this.dataGrid_Huespedes.Columns["Piso"].Visible = false;
            this.dataGrid_Huespedes.Columns["Departamento"].Visible = false;
            this.dataGrid_Huespedes.Columns["Fecha_Nacimiento"].Visible = false;

            foreach (DataGridViewColumn column in dataGrid_Huespedes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            this.dataGrid_Huespedes.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Select";
            btn.Name = "row_button";
            btn.UseColumnTextForButtonValue = true;
        }

        private void dataGrid_Huespedes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16 && e.RowIndex > -1)
            {
                MessageBox.Show(e.RowIndex.ToString());
                CargarDatosAfiliado(e.RowIndex);
            }
        }

        private Huesped CargarDatosAfiliado(int fila)
        {
            Huesped cliente = new Huesped();
            cliente.Apellido = TablaHuespedes.Rows[fila]["Apellido"].ToString();
            cliente.Calle = TablaHuespedes.Rows[fila]["Calle"].ToString();
            cliente.Departamento = Convert.ToChar(TablaHuespedes.Rows[fila]["Departamento"].ToString());
            cliente.Fecha_Nacimiento = Convert.ToDateTime(TablaHuespedes.Rows[fila]["Fecha_Nacimiento"].ToString());
            if (TablaHuespedes.Rows[fila]["Habilitado"].ToString().Trim().Equals("1"))
            {
                cliente.Habilitado = true;
            }
            else
            {
                cliente.Habilitado = false;
            }

            cliente.idHuesped = Convert.ToInt32(TablaHuespedes.Rows[fila]["idHuesped"].ToString());
            cliente.idLocalidad = Convert.ToInt32(TablaHuespedes.Rows[fila]["idLocalidad"].ToString());
            cliente.Mail = TablaHuespedes.Rows[fila]["Mail"].ToString();
            cliente.Nacionalidad = TablaHuespedes.Rows[fila]["Nacionalidad"].ToString();
            cliente.Nombre = TablaHuespedes.Rows[fila]["Nombre"].ToString();
            cliente.Nro_Documento = Convert.ToInt32(TablaHuespedes.Rows[fila]["Nro_Documento"].ToString());
            cliente.Numero = Convert.ToInt32(TablaHuespedes.Rows[fila]["Numero"].ToString());
            cliente.Piso = Convert.ToChar(TablaHuespedes.Rows[fila]["Piso"].ToString());
            cliente.Telefono = Convert.ToInt32(TablaHuespedes.Rows[fila]["Telefono"].ToString());
            cliente.Tipo_Documento = TablaHuespedes.Rows[fila]["Tipo_Documento"].ToString();

            return cliente;
        }
    }
}
