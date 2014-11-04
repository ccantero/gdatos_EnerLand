using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class MainMenu : UserControl
    {
        public Form parentForm;
        public MainMenu(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            User testUser = new User(1);

            int[] permissions = testUser.getUserPermissions();
            int i = 0;
            while (i < permissions.Length)
            {
                switch (permissions[i])
                {   // ABM usuario
                    case 1: { gestionarUsuariosToolStripMenuItem.Visible = true; break; }
                    // ABM Huesped
                    case 2: { gestionarHuespedesToolStripMenuItem.Visible = true; break; }
                    // ABM Hotel
                    case 3: { gestionarHotelesToolStripMenuItem.Visible = true; break; }
                    // ABM Habitacion
                    case 4: {   break; }
                    // Generar Reserva
                    case 5: { generarReservaToolStripMenuItem.Visible = true; break; }
                    // Cancelar Reserva
                    case 6: { cancelarReservaToolStripMenuItem.Visible = true; break; }
                    // Registrar Estadia
                    case 7: { registrarIngresoToolStripMenuItem.Visible = true; break; }
                    //Registrar Consumible
                    case 8: { registrarConsumiblesToolStripMenuItem.Visible = true; break; }
                    //Facturar
                    case 9: { facturarEstadíasToolStripMenuItem.Visible = true; break; }
                    //Estadisticas
                    case 10: { estadísticasToolStripMenuItem.Visible = true; break; }
                }
                i++;
            }
        }

        private void gestionarHotelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Hotel.GestionHoteles formHoteles = new ABM_de_Hotel.GestionHoteles(parentForm);
            formHoteles.Show();
        }

        private void gestionarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Rol.GestionRoles formRol = new FrbaHotel.ABM_de_Rol.GestionRoles(parentForm);
            formRol.Show();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.LoginForm formLogin = new FrbaHotel.Login.LoginForm(parentForm);
            formLogin.Show();
        }

        private void generarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.GestionHuesped formHuesped = new FrbaHotel.ABM_de_Cliente.GestionHuesped(parentForm);
            formHuesped.Show();
        }


   }
}
