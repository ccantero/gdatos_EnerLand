using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.buscarAfiliado;
using Clinica_Frba.buscarProfesionalForm;

namespace Clinica_Frba.CancAtencion
{
    public partial class CancAtencionForm : Form
    {
        // Menu anterior a ocultar
        MenuPrincipal menu;

        public CancAtencionForm(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
            rolCancelacion.Select();
        }

        // Método para botón Volver
        private void button3_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
            rolCancelacion.Select();
        }

        // Método para boton Limpiar
        private void button1_Click(object sender, EventArgs e)
        {
            rolCancelacion.Text = "";
            tipoCancelacion.Text = "";
            descripcion.Text = "";
            rolCancelacion.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rolCancelacion.Text.Trim() == "" || tipoCancelacion.Text.Trim() == "" || descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Se requiere que todos los campos estén completos para continuar.");
                rolCancelacion.Select();
                return;
            }
            if (!rolCancelacion.Items.Contains(rolCancelacion.Text))
            {
                MessageBox.Show("Ingresó de forma incorrecta por parte de quien es la cancelación. Ingrese nuevamente ese campo para continuar.");
                rolCancelacion.Select();
                return;
            }
            if (!tipoCancelacion.Items.Contains(tipoCancelacion.Text))
            {
                MessageBox.Show("Ingresó de forma incorrecta el tipo de cancelación. Ingrese nuevamente ese campo para continuar.");
                tipoCancelacion.Select();
                return;            
            }
            if (rolCancelacion.Text == "Afiliado")
            {
                new BuscarAfiliado(menu, tipoCancelacion.Text, descripcion.Text, 1);
                this.Dispose();
            }
            else
            {
                new BuscarProfesional(menu, 1);
                this.Dispose();
            }
        }
    }
}
