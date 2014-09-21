using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Afiliado;

namespace Clinica_Frba.Afiliado
{
    public partial class AfiliadoABM : Form
    {
        public static MenuPrincipal menu; //Formulario Principal. Para poder ocultar el formulario anterior
        public static AddModAfiliado AltaAfiliado;
        public static SearchAfiliado BuscarAfiliado;
        
        public AfiliadoABM(MenuPrincipal sender)
        {
            InitializeComponent();
            menu = sender;
            menu.Visible = false;
            this.Visible = true;
        }

        private void agregarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaAfiliado = new AddModAfiliado(this);
        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void salirDeLaAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            menu.Dispose();
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                this.Close();
                return;
                throw;
            }
            
        }

        private void AfiliadoABM_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            menu.Visible = true;
            this.Dispose();
        }

        private void modificarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarAfiliado = new SearchAfiliado(this);
        }

        private void eliminarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarAfiliado = new SearchAfiliado(this, true);
        }

        public void agregarFamiliares(int Cod_Afiliado, int Cod_PlanMedico, int numero)
        {
            if (numero == 0)
            {
                return;
            }
            AltaAfiliado = new AddModAfiliado(this, Cod_Afiliado, Cod_PlanMedico, numero);    
        }
    
    }

}
