using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.RegistrarAgenda
{
    public partial class RegistrarAgendaForm : Form
    {
        MenuPrincipal menu;
        PedirTurno.PedirTurnoForm menuPedirTurno;
        int cantidadTurnos;
        int Matricula = -2;
        int Cod_CartillaMedica = -1;
        DateTime FechaTurno = @Clinica_Frba.Properties.Settings.Default.Fecha;
        
        public RegistrarAgendaForm(MenuPrincipal FormularioPadre, int Cod_Medico)
        {
            InitializeComponent();
            menu = FormularioPadre;
            CargarTabla();
            this.Visible = true;
            cantidadTurnos = 0;
            Matricula = Cod_Medico;
            
        }

        public void CargarTabla()
        {
            // Format DataGridView
            
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = this.BackColor;

            this.dataGridView1.RowHeadersWidth = 75;
            
            String [] Semana = {"Lunes", 
                                "Martes", 
                                "Miercoles", 
                                "Jueves", 
                                "Viernes", 
                                "Sabado"
                               };

            // Add columns to DataGridView

            foreach (String item in Semana)
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Columna_" + item;
                checkColumn.HeaderText = item;
                checkColumn.Width = 75;
                checkColumn.ReadOnly = true;
                checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
                dataGridView1.Columns.Add(checkColumn);
            }

            // Add rows to DataGridView
            for (int i = 7; i <= 32; i++)
            {
                TimeSpan t = TimeSpan.FromSeconds(25200 + ((i - 7)* 1800));
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 7].HeaderCell.Value = t.ToString().Substring(0, 5) ;
            }

            // Sabados no se trabaja hasta las 10
            for (int i = 0; i < 6; i++)
            {
                DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
                dataGridView1[5, i] = TextBoxCell;
                dataGridView1[5, i].Value = "";
                dataGridView1[5, i].Style.BackColor = Color.Black;
                dataGridView1[5, i].ReadOnly = true;
            }

            // Sabados no se trabaja desde las 5
            for (int i = 16; i <= 25; i++)
            {
                DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
                dataGridView1[5, i] = TextBoxCell;
                dataGridView1[5, i].Value = "";
                dataGridView1[5, i].Style.BackColor = Color.Black;
                dataGridView1[5, i].ReadOnly = true;
                
            }
            
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
            {
                return;
            }
            DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (chkCell.Value == chkCell.TrueValue) //It was Not Checked
            {
                if (cantidadTurnos > (96 - 1))
                {
                    MessageBox.Show("La cantidad maxima de horas por médico por semana es 48hs");
                    return;
                }
                chkCell.Value = true;
                cantidadTurnos = cantidadTurnos + 1;
            }
            else //It was Checked
            {
                chkCell.Value = false;
                chkCell.Value = chkCell.TrueValue;
                cantidadTurnos = cantidadTurnos - 1;
            }
        }

        private void RegistrarAgendaForm_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            if (menu == null)
            {
                menuPedirTurno.Visible = true;
                this.Dispose();
                return;
            }
            menu.Visible = true;
            this.Dispose();
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 5; j++)
                {                   
                    DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[j];
                    chkCell.Value = false;
                    chkCell.Value = chkCell.TrueValue;
                }
            }

            for (int i = 6; i < 16; i++)
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[5];
                chkCell.Value = false;
                chkCell.Value = chkCell.TrueValue;
                cantidadTurnos = 0;
            }

            cantidadTurnos = 0;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            TimeSpan diffResult = box_fecfin.Value.Subtract(box_fecini.Value);

            if (diffResult.Days < 7)
            {
                MessageBox.Show("No se puede generar una Agenda para un intervalo de tiempo tan corto." +
                                System.Environment.NewLine +
                                "Por favor ingrese un intervalo de fechas de mínimo una semana");

                return;
            }

            if (diffResult.Days > 120)
            {
                MessageBox.Show("No se puede generar una Agenda para un intervalo de tiempo tan largo." +
                                System.Environment.NewLine +
                                "Por favor ingrese un intervalo de fechas de máximo 120 días");

                return;
            }
            
            Cod_CartillaMedica = SQL_Methods.Profesional_AgregarCartilla(Matricula,this.box_fecini.Value, this.box_fecfin.Value);
            if (Cod_CartillaMedica == -1)
            {
                MessageBox.Show(Matricula.ToString() + " no pudo ser agregada a la cartilla.");
                return;
            }
            
            foreach (DataGridViewRow Row in this.dataGridView1.Rows) /* Recorro filas */
            {
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++) /* Recorro Columnas */
                {
                    DataGridViewCheckBoxCell cell;
                    try
                    {
                         cell = (DataGridViewCheckBoxCell)Row.Cells[i];
                    }
                    catch (Exception)
                    {
                        continue;
                        throw;
                    }
                    
                    if (cell.Value != null)
                    {
                        bool Valor =  (bool)cell.Value;
                        if ( Valor == true)
                        {
                            DateTime Hora = Convert.ToDateTime(Row.HeaderCell.Value.ToString());
                            if (!SQL_Methods.Profesional_AgregarAgenda(Matricula, Hora, i + 1))
                            {
                                MessageBox.Show(Matricula.ToString() + " no pudo ser agregada a la cartilla.");
                                return;
                            }
                        }
                    }
                }
            }

            menu.Visible = true;
            this.Dispose();
            return;
        }


    
    }
}
