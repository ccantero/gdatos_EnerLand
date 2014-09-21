using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Clinica_Frba.Login;
using Clinica_Frba.ListadosEstadisticos;
using Clinica_Frba.Afiliado;
using Clinica_Frba.EspMedicas;
using Clinica_Frba.Planes;
using Clinica_Frba.Profesional;
using Clinica_Frba.Abm_de_Rol;
using Clinica_Frba.CancAtencion;
using Clinica_Frba.Cancelar_Atencion_Afiliado;
using Clinica_Frba.Cancelar_Atencion_Profesional;
using Clinica_Frba.GenerarReceta;
using Clinica_Frba.PedirTurno;
using Clinica_Frba.RegistrarAgenda;
using Clinica_Frba.RegistroLlegada;
using Clinica_Frba.RegistroUsuario;
using Clinica_Frba.RegResAtencion;
using Clinica_Frba.buscarProfesionalForm;
using Clinica_Frba.buscarAfiliado;
using Clinica_Frba.bonoConsulta;
using Clinica_Frba.bonoFarmacia;

namespace Clinica_Frba
{
    public partial class MenuPrincipal : Form
    {
        public static int idRol;
        public static int Cod_Afiliado;
        public static string Afiliado_Nombre;
        public static int Cod_Plan_Medico;

        public static int Matricula;
        public static string Medico_Nombre;

        public static DataTable TablaFuncionalidades;
        public static DataTable TablaRolesFuncionalidades;
        public static System.Collections.Generic.List<int> Funcionalidades = new System.Collections.Generic.List<int>();
        
        public MenuPrincipal()
        {
            InitializeComponent();
            OcultarMenus();
            new LoginForm(this);
        }

        public void SetRol(int unRol, int numero_documento)
        {
            idRol = unRol;
            if (unRol == 1)
            {
                setAfiliado(numero_documento);
            }

            if (unRol == 3)
            {
                setProfesional(numero_documento);
            }
            CargarFuncionalidades();
        }

        private void setAfiliado(int numeroDocumento)
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Afiliados " +
                             "WHERE Numero_Documento = " + numeroDocumento.ToString() + "";

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                DataTable AuxTabla = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
                Cod_Afiliado = Convert.ToInt32(AuxTabla.Rows[0]["Cod_Afiliado"].ToString());
                Afiliado_Nombre = AuxTabla.Rows[0]["Apellido"].ToString() + " " + AuxTabla.Rows[0]["Nombre"].ToString();
                Cod_Plan_Medico = Convert.ToInt32(AuxTabla.Rows[0]["Cod_PlanMedico"].ToString());
            }
            else
            {
                MessageBox.Show("Se perdio la conexion con la Base de Datos");
            }
        }

        private void setProfesional(int numeroDocumento)
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Profesionales " +
                             "WHERE Numero_Documento = " + numeroDocumento.ToString() + "";

            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                DataTable AuxTabla = SQL_Methods.EjecutarProcedure(myConnection, myQuery);
                Matricula = Convert.ToInt32(AuxTabla.Rows[0]["Matricula"].ToString());
                Medico_Nombre = AuxTabla.Rows[0]["Apellido"].ToString() + " " + AuxTabla.Rows[0]["Nombre"].ToString();
            }
            else
            {
                MessageBox.Show("Se perdio la conexion con la Base de Datos");
            }
        }
        
        private void CargarFuncionalidades()
        {
            SqlConnection myConnection;
            myConnection = SQL_Methods.IniciarConnection();

            string myQuery = "SELECT F.id_funcionalidad " + 
                             "FROM ORACLE_FANS.Roles R, ORACLE_FANS.Roles_Funcionalidad RF, ORACLE_FANS.Funcionalidades F " +
                             "WHERE R.id_Rol = RF.id_Rol " +
                             "AND RF.id_Funcionalidad = F.id_funcionalidad " +
                             "AND R.id_Rol = " + idRol.ToString();


            if (SQL_Methods.DBConnectStatus)
            {
                DataTable Tabla = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in Tabla.Rows)
                {
                    Funcionalidades.Add(Convert.ToInt32(Row[0].ToString()));
                }
            }

            MostratMenus();
        }
        
        private void OcultarMenus()
        { 
            this.ABMsToolStripMenuItem.Visible = false;
            this.rolToolStripMenuItem.Visible = false;
            this.afiliadoToolStripMenuItem.Visible = false;
            this.profesionalToolStripMenuItem.Visible = false;
            this.especialidadMedicaToolStripMenuItem.Visible = false;
            this.planToolStripMenuItem.Visible = false;

            this.operacionesToolStripMenuItem.Visible = false;
            this.registrarAgendaToolStripMenuItem.Visible = false;
            this.compraDeBonoToolStripMenuItem.Visible = false;
            this.pedirTurnoToolStripMenuItem.Visible = false;
            this.llegadaToolStripMenuItem1.Visible = false;
            this.registrarResultadoToolStripMenuItem.Visible = false;
            this.cancelarAtencionAfiliadoToolStripMenuItem.Visible = false;
            this.cancelarAtencionToolStripMenuItem.Visible = false;
            this.generarRecetaToolStripMenuItem.Visible = false;
            this.comprarBonoConsultaAfiliadoToolStripMenuItem.Visible = false;
            this.comprarBonoFarmaciaAfiliadoToolStripMenuItem.Visible = false;

            this.registrosToolStripMenuItem.Visible = false;
            
        }

        public void MostratMenus()
        {
            foreach (int item in Funcionalidades)
            {
                switch (item)
                {
                    case 1:
                        this.ABMsToolStripMenuItem.Visible = true;
                        this.rolToolStripMenuItem.Visible = true;
                        break;
                    case 3:
                        this.ABMsToolStripMenuItem.Visible = true;
                        this.afiliadoToolStripMenuItem.Visible = true;
                        break;
                    case 4:
                        this.ABMsToolStripMenuItem.Visible = true;
                        this.profesionalToolStripMenuItem.Visible = true;
                        break;
                    case 5:
                        this.ABMsToolStripMenuItem.Visible = true;
                        this.especialidadMedicaToolStripMenuItem.Visible = true;
                        break;
                    case 6:
                        this.ABMsToolStripMenuItem.Visible = true;
                        this.planToolStripMenuItem.Visible = true;
                        break;
                    case 7:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.registrarAgendaToolStripMenuItem.Visible = true;
                        break;
                    case 8:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.compraDeBonoToolStripMenuItem.Visible = true;
                        break;
                    case 9:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.pedirTurnoToolStripMenuItem.Visible = true;
                        break;
                    case 10:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.llegadaToolStripMenuItem1.Visible = true;
                        break;
                    case 11:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.registrarResultadoToolStripMenuItem.Visible = true;
                        break;
                    case 12:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.cancelarAtencionAfiliadoToolStripMenuItem.Visible = true;
                        break;
                    case 13:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.cancelarAtencionToolStripMenuItem.Visible = true;
                        break;
                    case 14:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.generarRecetaToolStripMenuItem.Visible = true;
                        break;
                    case 15:
                        this.registrosToolStripMenuItem.Visible = true;
                        break;
                    case 16:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.comprarBonoConsultaAfiliadoToolStripMenuItem.Visible = true;
                        break;
                    case 17:
                        this.operacionesToolStripMenuItem.Visible = true;
                        this.comprarBonoFarmaciaAfiliadoToolStripMenuItem.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        
        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            // ID Funcionalidad 1
            Rol_Form abmRol = new Rol_Form(this);
        }

        private void afiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 3
            AfiliadoABM abmAfiliado = new AfiliadoABM(this);
        }

        private void profesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 4
            ProfesionalABM abmProfesional = new ProfesionalABM(this);
        }

        private void especialidadMedicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 5
            EspMedicasABM abmEspMed = new EspMedicasABM(this);
        }

        private void salirDeAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 6
            PlanesABM abmPlanes = new PlanesABM(this);
        }

        private void compraDeBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 8
            BuscarAfiliado buscAfiliadoForm = new BuscarAfiliado(this);
        }

        private void generarRecetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 14
            BuscarAfiliado buscAfiliado = new BuscarAfiliado(this, 1);
        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 9            
            if (idRol == 1)
            {
                PedirTurnoForm pedirTurno = new PedirTurnoForm(this, Cod_Afiliado, Afiliado_Nombre);
                return;
            }
            
            PedirTurnoForm PedirTurno = new PedirTurnoForm(this);
        }

        private void registrarAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 7            
            SearchProfesionalForm registrarAgenda = new SearchProfesionalForm(this);
        }

        private void cancelarAtencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 13
            CancelacionProfesionalForm cancelarAtencion = new CancelacionProfesionalForm(this);
        }

        private void registrarResultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 11
            BuscarAfiliado regAtencion = new BuscarAfiliado(this, true);
        }

        private void cancelarAtencionAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 12
            if (idRol == 1)
            {
                CancelacionAfiliadoForm cancelarAtencion = new CancelacionAfiliadoForm(this, Cod_Afiliado, Afiliado_Nombre);
                return;
            }
            
            CancelacionAfiliadoForm cancelarAtencionAfiliado = new CancelacionAfiliadoForm(this);
        }

        private void llegadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 10
            BuscarProfesional regLlegada = new BuscarProfesional(this, 0);
        }

        private void comprarBonoConsultaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 16
            CompraBonoConsulta ComprarBonoConsulta = new CompraBonoConsulta(this, Cod_Afiliado,Cod_Plan_Medico);
        }

        private void comprarBonoFarmaciaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ID Funcionalidad 17
            CompraBonoFarmacia ComprarBonoFarmacia = new CompraBonoFarmacia(this, Cod_Afiliado, Cod_Plan_Medico);
        }

        private void top5EspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadosEstadisticos.ListadosEstForm Listado = new ListadosEstForm(this);
        }

        private void top5BonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadosEstForm Listado = new ListadosEstForm(this, true);
        }

        private void top5EspecialidadesConMásBonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadosEstForm Listado = new ListadosEstForm(this, 1);
        }

        private void top10AfiliadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadosEstForm Listado = new ListadosEstForm(this, 0);
        }
    }
}
