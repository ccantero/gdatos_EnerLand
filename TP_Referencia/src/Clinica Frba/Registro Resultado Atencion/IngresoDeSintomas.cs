using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.RegResAtencion;

namespace Clinica_Frba.Ingreso_Sintomas
{
    public partial class IngresoDeSintomas : Form
    {
        // Menu anterior a ocultar
        RegResAtencionForm menuAnterior;
        MenuPrincipal menuPpal;

        // Variable para almacenar sintomas
        string[] sintomas = new string[5];

        public IngresoDeSintomas(MenuPrincipal menppal, RegResAtencionForm menAnt, ref string[] sint)
        {
            InitializeComponent();
            menuPpal = menppal;
            sintomas = sint;
            menuAnterior = menAnt;
            menuAnterior.Visible = false;
            this.Visible = true;
        }

        // Método para boton Limpiar
        private void button1_Click(object sender, EventArgs e)
        {
            sintoma1.Text = "";
            sintoma2.Text = "";
            sintoma3.Text = "";
            sintoma4.Text = "";
            sintoma5.Text = "";
        }

        // Método para boton Volver
        private void button4_Click(object sender, EventArgs e)
        {
            menuPpal.Visible = true;
            menuAnterior.Dispose();
            this.Dispose();
        }

        // Método para boton Guardar
        private void button2_Click(object sender, EventArgs e)
        {
            comprobarValoresIngresados();
            sintomas[5] = "no";
            if (sintomas[0] == "ninguno")
            {
                MessageBox.Show("Debe ingresar al menos 1 sintoma. Ingrese nuevamente los campos.");
                return;
            }
            else
            {
                MessageBox.Show("Los sintomas fueron ingresados correctamente.");
                menuAnterior.corroborarSintomas(ref sintomas);
                this.Dispose();
            }
        }

        // Método para comprobar sintomas ingresados
        private void comprobarValoresIngresados()
        {
            if (sintoma1.Text.Trim() == "")
            {
                sintomas[0] = "ninguno";
            }
            else
            {
                sintomas[0] = sintoma1.Text;
            }
            if (sintoma2.Text.Trim() == "")
            {
                sintomas[1] = "ninguno";
            }
            else
            {
                sintomas[1] = sintoma2.Text;
            }
            if (sintoma3.Text.Trim() == "")
            {
                sintomas[2] = "ninguno";
            }
            else
            {
                sintomas[2] = sintoma3.Text;
            }
            if (sintoma4.Text.Trim() == "")
            {
                sintomas[3] = "ninguno";
            }
            else
            {
                sintomas[3] = sintoma4.Text;
            }
            if (sintoma5.Text.Trim() == "")
            {
                sintomas[4] = "ninguno";
            }
            else
            {
                sintomas[4] = sintoma5.Text;
            }
        }

        // Método para boton guardar y agregar mas sintomas
        private void button3_Click(object sender, EventArgs e)
        {
            comprobarValoresIngresados();
            sintomas[5] = "si";
            if (sintomas[0] == "ninguno" || sintomas[1] == "ninguno" || sintomas[2] == "ninguno"
                || sintomas[3] == "ninguno" || sintomas[4] == "ninguno")
            {
                MessageBox.Show("Debe ingresar los 5 síntomas antes de agregar más. Ingrese nuevamente los campos.");
                return;
            }
            else
            {
                MessageBox.Show("Los sintomas fueron ingresados correctamente.");
                menuAnterior.corroborarSintomas(ref sintomas);
                this.Dispose();
            }
        }
    }
}
