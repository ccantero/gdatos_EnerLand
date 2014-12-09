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
        public int actualUser = 2;  /* Usuario Guest */
        public int actualRol = 3;  /* Rol Guest */
        public int actualHotel = -1;  /* Hotel No Definido */
        
        public MainMenu(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
            actualUser = 2;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            CargarPermisos();            
        }

        public void CargarPermisos()
        {
            User testUser = new User(actualUser, actualRol);
            
            // Se ocultan todos los Menu.
            foreach (ToolStripItem X in this.menuStrip1.Items)
            {
                X.Visible = false;
                if (X.Name == "ingresarToolStripMenuItem")
                    X.Visible = true;
            }
            
            int[] permissions = testUser.getUserPermissions();
            int i = 0;
            while (i < permissions.Length)
            {
                switch (permissions[i])
                {   // ABM usuario
                    case 1:
                        {
                            if (actualUser == 1) // Usuario Administrador
                            {
                                usuariosToolStripMenuItem.Visible = true;
                                gestionarUsuariosToolStripMenuItem.Visible = true;
                            }
                            break;
                        }
                    // ABM Huesped
                    case 2:
                        {
                            huespedesToolStripMenuItem.Visible = true;
                            gestionarHuespedesToolStripMenuItem.Visible = true;
                            break;
                        }
                    // ABM Hotel y ABM Habitacion
                    case 3:
                        {
                            hotelesToolStripMenuItem.Visible = true;
                            gestionarHotelesToolStripMenuItem.Visible = true;
                            break;
                        }
                    // Generar Reserva
                    case 4:
                        {
                            reservasToolStripMenuItem.Visible = true;
                            generarReservaToolStripMenuItem.Visible = true;
                            break;
                        }
                    // Modificar Reserva
                    case 5:
                        {
                            reservasToolStripMenuItem.Visible = true;
                            modificarReservaToolStripMenuItem.Visible = true;
                            break;
                        }
                    // Cancelar Reserva
                    case 6:
                        {
                            reservasToolStripMenuItem.Visible = true;
                            cancelarReservaToolStripMenuItem.Visible = true;
                            break;
                        }
                    // Registrar Estadia
                    case 7:
                        {
                            estadiasToolStripMenuItem.Visible = true;
                            registrarIngresoToolStripMenuItem.Visible = true;
                            registrarCheckoutToolStripMenuItem.Visible = true;
                            break;
                        }
                    //Registrar Consumible
                    case 8:
                        {
                            estadiasToolStripMenuItem.Visible = true;
                            registrarConsumiblesToolStripMenuItem.Visible = true;
                            break;
                        }
                    //Facturar
                    case 9:
                        {
                            estadiasToolStripMenuItem.Visible = true;
                            facturarEstadíasToolStripMenuItem.Visible = true;
                            break;
                        }
                    //Estadisticas
                    case 10: { estadísticasToolStripMenuItem.Visible = true; break; }
                }
                i++;
            }

            if (actualUser != 2)
                this.ingresarToolStripMenuItem.Text = "Logout";
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

        private void generarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.Reserva formReserva = new FrbaHotel.Generar_Modificar_Reserva.Reserva(parentForm, 1);
            formReserva.Show();
        }

        private void cancelarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.Reserva formReserva = new FrbaHotel.Generar_Modificar_Reserva.Reserva(parentForm, 0);
            formReserva.Show();
        }

        private void modificarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.Reserva formReserva = new FrbaHotel.Generar_Modificar_Reserva.Reserva(parentForm, 2);
            formReserva.Show();
        }

        private void gestionarHuespedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.GestionHuesped formHuesped = new FrbaHotel.ABM_de_Cliente.GestionHuesped(parentForm);
            formHuesped.Show();
        }

        private void ingresarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (actualUser != 2)
            {
                actualUser = 2;
                actualRol = 3;
                actualHotel = -1;
                CargarPermisos();
                this.ingresarToolStripMenuItem.Text = "Ingresar";
                return;
            }
            Login.LoginForm formLogin = new FrbaHotel.Login.LoginForm(parentForm);
            formLogin.Visible = true;
        }

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.GestionUsuarios formUsuario = new FrbaHotel.ABM_de_Usuario.GestionUsuarios(parentForm);
            formUsuario.Visible = true;
        }

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.Form_ListadoEstadistico formListado = new FrbaHotel.Listado_Estadistico.Form_ListadoEstadistico(parentForm);
            formListado.Show();
        }

        private void facturarEstadíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturar.Factura_Form facturaForm = new FrbaHotel.Facturar.Factura_Form(parentForm);
            facturaForm.currentHotel = actualHotel;
            facturaForm.Show();
        }

        private void registrarConsumiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Consumible.RegistroConsumible_Form registroConsumibleForm = new FrbaHotel.Registrar_Consumible.RegistroConsumible_Form(parentForm);
            registroConsumibleForm.currentHotel = actualHotel;
            registroConsumibleForm.Show();
        }

        private void registrarCheckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Estadia.RegistrarSalida_Form registrarSalidaForm = new FrbaHotel.Registrar_Estadia.RegistrarSalida_Form(parentForm);
            registrarSalidaForm.currentHotel = actualHotel;
            registrarSalidaForm.Show();
        }

        private void registrarIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Estadia.RegistrarEntrada_Form registrarEntradaForm = new FrbaHotel.Registrar_Estadia.RegistrarEntrada_Form(parentForm);
            registrarEntradaForm.currentHotel = actualHotel;
            registrarEntradaForm.Show();
        }
   }
}
