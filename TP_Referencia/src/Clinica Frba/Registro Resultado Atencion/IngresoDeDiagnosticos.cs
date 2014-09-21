using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.RegResAtencion;

namespace Clinica_Frba.Ingreso_Diagnosticos
{
    public partial class IngresoDeDiagnosticos : Form
    {
        // Menu anterior a ocultar
        RegResAtencionForm menAnt;
        MenuPrincipal menuPpal;

        // Variable para almacenar diagnosticos
        string[] diagnosticos = new string[6];

        public IngresoDeDiagnosticos(MenuPrincipal menu, RegResAtencionForm sender, ref string[] diag)
        {
            InitializeComponent();
            menuPpal = menu;
            menAnt = sender;
            menAnt.Visible = false;
            this.Visible = true;
            diagnosticos = diag;
        }

        // Método para boton Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            diagnostico1.Text = "";
            diagnostico2.Text = "";
            diagnostico3.Text = "";
            diagnostico4.Text = "";
            diagnostico5.Text = "";
        }

        // Método para boton Volver
        private void button3_Click(object sender, EventArgs e)
        {
            menAnt.Visible = true;
            this.Dispose();
        }

        // Método para boton Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            corroborarDiagnosticos();
            diagnosticos[5] = "no";
            if (diagnosticos[0] == "ninguno")
            {
                MessageBox.Show("Debe ingresar al menos 1 diagnóstico. Ingrese nuevamente los campos.");
                return;
            }
            else
            {
                MessageBox.Show("Los diagnósticos fueron ingresados correctamente.");
                menAnt.corroborarDiagnosticos(diagnosticos);
                this.Dispose();
            }
        }

        // Método para boton Guardar y agregar mas diagnosticos
        private void button4_Click(object sender, EventArgs e)
        {
            corroborarDiagnosticos();
            diagnosticos[5] = "si";
            if (diagnosticos[0] == "ninguno" || diagnosticos[1] == "ninguno" || diagnosticos[2] == "ninguno"
                || diagnosticos[3] == "niguno" || diagnosticos[4] == "ninguno")
            {
                MessageBox.Show("Debe ingresar los 5 síntomas antes de agregar más. Ingrese nuevamente los campos.");
                return;
            }
            else
            {
                MessageBox.Show("Los diagnósticos fueron ingresados correctamente.");
                menAnt.corroborarDiagnosticos(diagnosticos);
                this.Dispose();
            }
        }

        // Método para corroborar diagnosticos ingresados
        private void corroborarDiagnosticos()
        {
            if (diagnostico1.Text.Trim() == "")
            {
                diagnosticos[0] = "ninguno";
            }
            else
            {
                diagnosticos[0] = diagnostico1.Text;
            }
            if (diagnostico2.Text.Trim() == "")
            {
                diagnosticos[1] = "ninguno";
            }
            else
            {
                diagnosticos[1] = diagnostico2.Text;
            }
            if (diagnostico3.Text.Trim() == "")
            {
                diagnosticos[2] = "ninguno";
            }
            else
            {
                diagnosticos[2] = diagnostico3.Text;
            }
            if (diagnostico4.Text.Trim() == "")
            {
                diagnosticos[3] = "ninguno";
            }
            else
            {
                diagnosticos[3] = diagnostico4.Text;
            }
            if (diagnostico5.Text.Trim() == "")
            {
                diagnosticos[4] = "ninguno";
            }
            else
            {
                diagnosticos[4] = diagnostico5.Text;
            }
        }
    }
}
