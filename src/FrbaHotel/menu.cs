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
    public partial class menu : UserControl
    {
        public menu()
        {
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
                    case 1: { gestionarUsuariosToolStripMenuItem.Visible = false; break; }
                    // ABM Huesped
                    case 2: { gestionarHuespedesToolStripMenuItem.Visible = false;  break; }
                    // ABM Hotel
                    case 3: { gestionarHotelesToolStripMenuItem.Visible = false; break; }
                    // ABM Habitacion
                    case 4: { gestionarHabitacionesToolStripMenuItem.Visible = false; break; }
                    // Generar Reserva
                    case 5: { generarReservaToolStripMenuItem.Visible = false; break; }
                    // Cancelar Reserva
                    case 6: { cancelarReservaToolStripMenuItem.Visible = false; break; }
                    // Registrar Estadia
                    case 7: { registrarIngresoToolStripMenuItem.Visible = false; break; }
                    //Registrar Consumible
                    case 8: { registrarConsumiblesToolStripMenuItem.Visible = false; break; }
                    //Facturar
                    case 9: { facturarEstadíasToolStripMenuItem.Visible = false; break; }
                    //Estadisticas
                    case 10: { estadísticasToolStripMenuItem.Visible = false; break; }
                }
                i++;
            }
        }

   }
}
