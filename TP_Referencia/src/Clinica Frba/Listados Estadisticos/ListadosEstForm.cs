using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba;

namespace Clinica_Frba.ListadosEstadisticos
{
    public partial class ListadosEstForm : Form
    {
        MenuPrincipal menuPcpal;
        bool Top5Cancelaciones;
        bool Top5Bonos;
        int Top5Especialidades;

        public ListadosEstForm(MenuPrincipal sender)
        {
            InitializeComponent();
            menuPcpal = sender;
            sender.Visible = false;
            this.Visible = true;
            Top5Cancelaciones = true;
            Top5Bonos = false;
            Top5Especialidades = 0; // 0 Falso
            CargarCombos();
        }

        public ListadosEstForm(MenuPrincipal sender, bool flag)
        {
            InitializeComponent();
            menuPcpal = sender;
            sender.Visible = false;
            this.Visible = true;
            CargarCombos();
            Top5Cancelaciones = false;
            Top5Bonos = flag;
            Top5Especialidades = 0; // 0 Falso

            this.label1.Visible = false;
            this.box_cancelador.Visible = false;
        }

        public ListadosEstForm(MenuPrincipal sender, int flag)
        {
            InitializeComponent();
            menuPcpal = sender;
            sender.Visible = false;
            this.Visible = true;
            CargarCombos();
            Top5Cancelaciones = false;
            Top5Bonos = false;
            Top5Especialidades = flag; // 0 Falso

            this.label1.Visible = false;
            this.box_cancelador.Visible = false;
        }
   
        private void CargarCombos()
        {
            box_anio.Items.Add("2013");
            box_anio.Items.Add("2014");

            box_from.Items.Add("Enero");
            box_from.Items.Add("Febrero");
            box_from.Items.Add("Marzo");
            box_from.Items.Add("Abril");
            box_from.Items.Add("Mayo");
            box_from.Items.Add("Junio");

            box_cancelador.Items.Add("Afiliado");
            box_cancelador.Items.Add("Profesional");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Top5Cancelaciones)
            {
                ListTop5Cancelaciones();
                return;
            }
            if (Top5Bonos)
            {
                ListTop5Bonos();
                return;
            }

            if (Top5Especialidades == 1)
            {
                ListTop5Especialidades();
                return;
            }

            ListTop10Afiliados();
   
        }

        private void box_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (box_from.Text)
            {
                case "Enero":
                    box_hasta.Text = "Julio";
                    break;
                case "Febrero":
                    box_hasta.Text = "Agosto";
                    break;
                case "Marzo":
                    box_hasta.Text = "Septiembre";
                    break;
                case "Abril":
                    box_hasta.Text = "Octubre";
                    break;
                case "Mayo":
                    box_hasta.Text = "Noviembre";
                    break;
                case "Junio":
                    box_hasta.Text = "Diciembre";
                    break;
            }
        }

        private void ListadosEstForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            menuPcpal.Visible = true;
            this.Dispose();
            return;
        }

        private void ListTop5Cancelaciones()
        {
            DataTable TablaCancelaciones;

            if (box_cancelador.SelectedIndex == 0)
            {
                TablaCancelaciones = SQL_Methods.Listado_Top5Cancelaciones(Convert.ToInt32(box_anio.Text),
                                                                                     box_from.SelectedIndex + 1,
                                                                                     1);

            }
            else
            {
                TablaCancelaciones = SQL_Methods.Listado_Top5Cancelaciones(Convert.ToInt32(box_anio.Text),
                                                                                         box_from.SelectedIndex + 1,
                                                                                         3);

            }

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaCancelaciones;
            this.dataGridView1.Visible = true;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void ListTop5Bonos()
        {
            DataTable TablaBonos;

            TablaBonos = SQL_Methods.Listado_Top5Bonos(Convert.ToInt32(box_anio.Text),
                                                       box_from.SelectedIndex + 1);


            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaBonos;
            this.dataGridView1.Visible = true;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void ListTop5Especialidades()
        {
            DataTable TablaBonos;

            TablaBonos = SQL_Methods.Listado_Top5Especialidades(Convert.ToInt32(box_anio.Text),
                                                                box_from.SelectedIndex + 1);


            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaBonos;
            this.dataGridView1.Visible = true;
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void ListTop10Afiliados()
        {
            DataTable TablaBonos;

            TablaBonos = SQL_Methods.Listado_Top10Afiliados(Convert.ToInt32(box_anio.Text),
                                                                box_from.SelectedIndex + 1);


            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = TablaBonos;
            this.dataGridView1.Visible = true;
            this.dataGridView1.RowHeadersVisible = false;
        }
    }
}
