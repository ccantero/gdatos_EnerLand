using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.bonoConsulta;
using Clinica_Frba.bonoFarmacia;
using System.Data.SqlClient;
using Clinica_Frba.Cancelar_Atencion_Afiliado;
using Clinica_Frba.RegResAtencion;
using Clinica_Frba.GenerarReceta;

namespace Clinica_Frba.buscarAfiliado
{
    public partial class BuscarAfiliado : Form
    {
        // Formulario anterior a ocultar
        public static MenuPrincipal menu;

        // Tabla para alojar usuarios
        public static DataTable TablaAfiliados = new DataTable();

        // Variables para cancelar atención
        public static int Flag_CancelarAtencion = 0;
        public static string tipoCancelacion;
        public static string descripcionCancelacion;

        // Variables para registro de atencion
        public static bool flag_reg = false;

        // Variables para receta
        public static int flag_receta = 0;

        // Constructor para compra de bonos
        public BuscarAfiliado(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            flag_reg = false;
            flag_receta = 0;
            Flag_CancelarAtencion = 0;
        }

        // Constructor para cancelar Atencion
        public BuscarAfiliado(MenuPrincipal sender, string tipoCanc, string descCanc ,int flagCancelarAtencion)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            this.Text = "Buscar Afiliado";
            Flag_CancelarAtencion = flagCancelarAtencion;
            tipoCancelacion = tipoCanc;
            descripcionCancelacion = descCanc;
            flag_reg = false;
            flag_receta = 0;
        }

        // Constructor para registro de atencion
        public BuscarAfiliado(MenuPrincipal sender, bool flag)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            flag_reg = flag;
            Flag_CancelarAtencion = 0;
            flag_receta = 0;
        }

        // Constructor para crear receta
        public BuscarAfiliado(MenuPrincipal sender, int flag)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            flag_reg = false;
            Flag_CancelarAtencion = 0;
            flag_receta = flag;
        }

        // Metodo para boton de cruz
        private void SearchAfiliado_FormClosing(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        // Metodo para boton limpiar
        private void button_clean_Click(object sender, EventArgs e)
        {
            this.box_apellido.Text = "";
            this.box_codigo.Text = "";
            this.box_nombre.Text = "";
            this.box_documento.Text = "";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Columns.Clear();
        }

        // Metodo para cargar afiliados en la tabla
        private void CargarAfiliados()
        {
            TablaAfiliados.Rows.Clear();

            string myQuery = "SELECT * FROM ORACLE_FANS.Afiliados " +
                             "WHERE Nombre LIKE '%" + this.box_nombre.Text.Trim() + "%' " +
                             "AND Apellido LIKE '%" + this.box_apellido.Text.Trim() + "%' " +
                             "AND Cod_Afiliado LIKE '%" + this.box_codigo.Text.Trim() + "%' " +
                             "AND Numero_Documento LIKE '%" + this.box_documento.Text.Trim() + "%' ";

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaAfiliados = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
            }
        }

        // Metodo para boton buscar
        private void button_search_Click(object sender, EventArgs e)
        {
            CargarAfiliados();

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = TablaAfiliados;

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Visible = true;
            if (Flag_CancelarAtencion == 0 && flag_reg == false && flag_receta == 0)
            {
                DataGridViewButtonColumn botonFarmacia = new DataGridViewButtonColumn();
                DataGridViewButtonColumn botonConsulta = new DataGridViewButtonColumn();
                this.dataGridView1.Columns.Add(botonFarmacia);
                this.dataGridView1.Columns.Add(botonConsulta);
                botonFarmacia.HeaderText = "Accion";
                botonConsulta.HeaderText = "Accion";
                botonFarmacia.Text = "Compra Bono Farmacia";
                botonConsulta.Text = "Compra Bono Consulta";
                botonFarmacia.Name = "row_button";
                botonConsulta.Name = "row_button";
                botonFarmacia.UseColumnTextForButtonValue = true;
                botonConsulta.UseColumnTextForButtonValue = true;
            }
            else
            {
                DataGridViewButtonColumn botonCancelarAtencion = new DataGridViewButtonColumn();
                this.dataGridView1.Columns.Add(botonCancelarAtencion);
                botonCancelarAtencion.HeaderText = "Accion";
                botonCancelarAtencion.Text = "Select";
                botonCancelarAtencion.Name = "row_button";
                botonCancelarAtencion.UseColumnTextForButtonValue = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigoAfiliado = Convert.ToInt32(TablaAfiliados.Rows[e.RowIndex][0].ToString());
            int planMedico = Convert.ToInt32(TablaAfiliados.Rows[e.RowIndex][1].ToString());
            string nombreAfiliado = TablaAfiliados.Rows[e.RowIndex][2].ToString();
            string apellidoAfiliado = TablaAfiliados.Rows[e.RowIndex][3].ToString();

            if (flag_reg == false && Flag_CancelarAtencion == 0 && flag_receta == 0)
            {
                if (e.ColumnIndex == 15)
                {
                    new CompraBonoFarmacia(menu, codigoAfiliado, planMedico);
                    this.Dispose();
                }
                if (e.ColumnIndex == 16)
                {
                    new CompraBonoConsulta(menu, codigoAfiliado, planMedico);
                    this.Dispose();
                }
            }
            else
            {
                if (flag_reg == false && flag_receta == 0)
                {
                    if (e.ColumnIndex == 15)
                    {
                        //new CancelacionAfiliadoForm(menu, tipoCancelacion, descripcionCancelacion, codigoAfiliado.ToString(), nombreAfiliado, apellidoAfiliado);
                        this.Dispose();
                    }
                }
                else
                {
                    if (flag_receta == 1)
                    {
                        new GenerarRecetaForm(menu, codigoAfiliado.ToString());
                        this.Dispose();
                        return;
                    }
                    if (e.ColumnIndex == 15)
                    {
                        new RegResAtencionForm(menu, codigoAfiliado.ToString());
                        this.Dispose();
                    }
                }
            }  
        }

        private void volver_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }
    }
}