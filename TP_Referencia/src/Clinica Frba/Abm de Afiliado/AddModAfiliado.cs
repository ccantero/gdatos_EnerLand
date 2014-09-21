using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Clinica_Frba.Afiliado
{
    public partial class AddModAfiliado : Form
    {
        public static AfiliadoABM menu;
        public static DataTable TablaPlanesMedicos;
        public static bool Flag_Modification = false;
        public static bool Flag_Familiar = false;
        public static int Cod_Afiliado_Principal = -1;
        public static int PlanMedico_Familiar = -1; /* Variables para los Afiliados Secundarios */
        public static int NumeroFamiliar = 0;
        public static int FamiliaresACargo = 0;
        public static string MotivoCambioPlan = "";
        
        public AddModAfiliado(AfiliadoABM Parent)
        {
            InitializeComponent();
            menu = Parent;
            menu.Visible = false;
            this.Visible = true;
            Flag_Modification = false;
            Flag_Familiar = false;
        }

        // Redefinicion para el caso de Modificacion
        public AddModAfiliado(AfiliadoABM Parent, Afiliado Paciente) 
        {
            InitializeComponent();
            menu = Parent;
            menu.Visible = false;
            this.Visible = true;
            Flag_Modification = true;
            Flag_Familiar = false;
            this.Text = "ABM Afiiliados - Modificar Afiliado";
            CargarPacienteEnForm(Paciente);

            /* Campos que no pueden ser modificados */
            this.Box_Name.Enabled = false;
            this.Box_Apellido.Enabled = false;
            this.Box_DNI.Enabled = false;
            this.Box_PlanMed.Enabled = false;
            this.Box_CantFam.Enabled = false;

            if (!Paciente.Tipo_Documento.Equals(""))
            {
                this.Box_TipoDoc.Enabled = false;    
            }
            
            this.Box_FecNac.Enabled = false;

            if (Paciente.Cod_Afiliado % 10 == 1) /* Afiliado Principal */
            {
                this.Box_CantFam.Enabled = true;
                this.Box_PlanMed.Enabled = true;

                PlanMedico_Familiar = Paciente.Cod_PlanMedico;
                FamiliaresACargo = Paciente.CantFamiliaresACargo;
                this.Box_CantFam.Minimum = Paciente.CantFamiliaresACargo;
            }

            Cod_Afiliado_Principal = Paciente.Cod_Afiliado;
        }

        // Redefinicion para el caso de Agregar Familiares
        public AddModAfiliado(AfiliadoABM Parent, int Cod_Afiliado, int Cod_PlanMedico, int NumeroOrden)
        {
            InitializeComponent();
            menu = Parent;
            menu.Visible = false;
            this.Visible = true;
            Flag_Modification = false;
            Flag_Familiar = true;
            this.Text = "ABM Afiiliados - Agregar Familiar a Cargo";

            Cod_Afiliado_Principal = Cod_Afiliado;
            PlanMedico_Familiar = Cod_PlanMedico;
            NumeroFamiliar = NumeroOrden;

            this.Box_CantFam.ReadOnly = true;
            DataRow[] Rows = TablaPlanesMedicos.Select("Cod_PlanMedico = '" + Cod_PlanMedico.ToString().Trim() + "'");
            this.Box_PlanMed.Text = Rows[0][1].ToString().Trim();
            this.Box_PlanMed.Enabled = false;

            this.ControlBox = false;
        }

        private void AddModAfiliado_FormClosing(object sender, EventArgs e) // Método en caso de Boton Cerrar
        {
            if (!menu.IsDisposed)
            {
                menu.Visible = true;
                this.Dispose();    
            }
            this.Dispose();
        }

        private void AddModAfiliado_Load(object sender, EventArgs e)
        {           
            CargarPlanesMedicos();
            CargarGenero();
            CargarTipoDoc();
        }

        private void CargarPlanesMedicos() // Método para llenar Tabla de Planes Medicos
        {
            string myQuery = "SELECT * FROM ORACLE_FANS.Planes_Medicos";
            SqlConnection myConnection;

            myConnection = SQL_Methods.IniciarConnection();
            if (SQL_Methods.DBConnectStatus)
            {
                TablaPlanesMedicos = SQL_Methods.EjecutarProcedure(myConnection, myQuery);

                foreach (DataRow Row in TablaPlanesMedicos.Rows)
                {
                    this.Box_PlanMed.Items.Add(Row[1].ToString());
                }
            }
        }

        private void CargarGenero()
        {
            this.Box_TipoDoc.Items.Add("D.N.I.");
            this.Box_TipoDoc.Items.Add("L.E.");
            this.Box_TipoDoc.Items.Add("L.C.");
        }

        private void CargarTipoDoc()
        {
            this.Box_Genero.Items.Add("Hombre");
            this.Box_Genero.Items.Add("Mujer");
        }

        private void Box_Genero_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Box_EstadoCivil.Items.Clear(); //Limpieza
            this.Box_EstadoCivil.Text = "";

            if (Box_Genero.Text.Equals("Hombre"))
            {
                /* Cargo el estado civil en masculino */
                this.Box_EstadoCivil.Items.Add("Soltero");
                this.Box_EstadoCivil.Items.Add("Casado");
                this.Box_EstadoCivil.Items.Add("Viudo");
                this.Box_EstadoCivil.Items.Add("Concubinato");
                this.Box_EstadoCivil.Items.Add("Divorciado");
            }

            if (Box_Genero.Text.Equals("Mujer"))
            {
                /* Cargo el estado civil en femenino */
                this.Box_EstadoCivil.Items.Add("Soltera");
                this.Box_EstadoCivil.Items.Add("Casada");
                this.Box_EstadoCivil.Items.Add("Viuda");
                this.Box_EstadoCivil.Items.Add("Concubinato");
                this.Box_EstadoCivil.Items.Add("Divorciada");
            }

        }

        private void Clean_Button_Click(object sender, EventArgs e)
        {
            if (Flag_Modification)
            {
                return;
            }
            
            this.Box_Name.Text = "";
            this.Box_Apellido.Text = "";
            this.Box_mail.Text = "";
            this.Box_CantFam.Text = "";
            this.Box_Direccion.Text = "";
            this.Box_DNI.Text = "";
            this.Box_Genero.Text = "";
            this.Box_FecNac.Value = new System.DateTime(2013, 11, 5, 0, 0, 0, 0);
            this.Box_EstadoCivil.Items.Clear();
            this.Box_EstadoCivil.Text = "";
            this.Box_PlanMed.Text = "";
            this.Box_Telefono.Text = "";
            this.Box_TipoDoc.Text = "";
        }

        private void CargarPacienteEnForm(Afiliado Paciente) //Metodo exclusivo Para Modificar Afiliado
        {
            this.Box_Apellido.Text = Paciente.Apellido;
            this.Box_CantFam.Text = Paciente.CantFamiliaresACargo.ToString();
            this.Box_Direccion.Text = Paciente.Direccion;
            this.Box_DNI.Text = Paciente.Numero_Documento.ToString();
            this.Box_FecNac.Value = Paciente.Fecha_Nac;
            if (Paciente.Sexo.Equals('\0'))
            {
                this.Box_Genero.SelectedItem = -1;
            }
            else
            {
                if (Paciente.Sexo.Equals('M'))
                {
                    this.Box_Genero.Text = "Hombre";
                }
                else
                {
                    this.Box_Genero.Text = "Mujer";
                }
            }
            this.Box_EstadoCivil.Text = Paciente.Estado_Civil;
            this.Box_mail.Text = Paciente.Mail;
            this.Box_Name.Text = Paciente.Nombre;
            this.Box_Telefono.Text = Paciente.Telefono.ToString();
            this.Box_TipoDoc.Text = Paciente.Tipo_Documento;

            DataRow[] Rows = TablaPlanesMedicos.Select("Cod_PlanMedico = '" + Paciente.Cod_PlanMedico.ToString().Trim() + "'");
            this.Box_PlanMed.Text = Rows[0][1].ToString().Trim();

        }

        private Afiliado CargarFormEnPaciente(int Cod_PlanMedico)
        {
            Afiliado Paciente = new Afiliado();

            Paciente.Cod_PlanMedico = Cod_PlanMedico;
            Paciente.Nombre = this.Box_Name.Text.Trim();
            Paciente.Apellido = this.Box_Apellido.Text.Trim();
            Paciente.Tipo_Documento = this.Box_TipoDoc.Text.Trim();
            Paciente.Numero_Documento = Convert.ToInt32(this.Box_DNI.Text.Trim());
            Paciente.Direccion = this.Box_Direccion.Text.Trim();
            Paciente.Telefono = Convert.ToInt32(this.Box_Telefono.Text.Trim());
            Paciente.Mail = this.Box_mail.Text.Trim();
            Paciente.Fecha_Nac = this.Box_FecNac.Value;
            if (this.Box_Genero.Text.Trim().Equals("Hombre"))
            {
                Paciente.Sexo = 'M';
            }
            if (this.Box_Genero.Text.Trim().Equals("Mujer"))
            {
                Paciente.Sexo = 'F';
            }

            Paciente.Estado_Civil = this.Box_EstadoCivil.Text.Trim();
            Paciente.CantFamiliaresACargo = Convert.ToInt32(this.Box_CantFam.Value);

            return Paciente;
        }
        
        private void Save_Button_Click(object sender, EventArgs e)
        {
            int Cod_Afiliado;

            if (!CheckBoxes())
            {
                return;
            }

            DataRow[] Rows = TablaPlanesMedicos.Select("Descripcion = '" + this.Box_PlanMed.Text + "'");
            if (Rows.Length <= 0)
            {
                MessageBox.Show("Error en la Tabla Planes Medicos");
                return;
            }

            Afiliado Paciente = CargarFormEnPaciente(Convert.ToInt32(Rows[0][0].ToString().Trim()));

            if (Flag_Modification)
            {
                Paciente.Cod_Afiliado = Cod_Afiliado_Principal;
                if (Paciente.CantFamiliaresACargo < FamiliaresACargo)
                {
                    MessageBox.Show("No se puede disminuir la cantidad de Familiares a Cargo.");
                    return;
                }
                
                ModificarAfiliado(Paciente);
                
                return;
            }
            

            if (Flag_Familiar)
            {
                Paciente.Cod_Afiliado = Cod_Afiliado_Principal;
                Cod_Afiliado = SQL_Methods.Afiliado_DarAltaFamiliar(Paciente);
                Paciente.CantFamiliaresACargo = NumeroFamiliar - 1;
            }
            else
            {
                Cod_Afiliado = SQL_Methods.Afiliado_DarAlta(Paciente);
                Cod_Afiliado_Principal = Cod_Afiliado;
            }
                        
            if (Cod_Afiliado > 0)
            {
                if (!SQL_Methods.Usuario_Crear(1,Paciente.Numero_Documento.ToString()))
                {
                    MessageBox.Show("El usuario para el Afiliado no pudo ser creado");
                }
                MessageBox.Show("El Afiliado ha sido creado exitosamente bajo el Numero de Afiliado = " +
                                Cod_Afiliado.ToString());

                if (Paciente.CantFamiliaresACargo > 0)
                {
                    MessageBox.Show("A continuación deberá ingresar los datos de los " +
                                    Paciente.CantFamiliaresACargo.ToString() +
                                    " familiares que el Afiliado " + Cod_Afiliado_Principal.ToString() + 
                                    " tiene a su cargo");
                    this.Dispose();
                    menu.Visible = true;
                    menu.agregarFamiliares(Cod_Afiliado_Principal, Paciente.Cod_PlanMedico, Paciente.CantFamiliaresACargo);
                    return;
                }

                menu.Visible = true;
                this.Dispose();
                return;
            }
            else
            {
                menu.Visible = true;
                this.Dispose();
                return;
            }
        }

        private bool CheckString(string toCheck, string Type)
        {
            string expresion;

            if (Type.Equals("DNI"))
            {
                expresion = "^[1-9][0-9]{6,8}$";
                if (Regex.Match(toCheck, expresion).Success)
                    return true;
                else
                    return false;
            }

            if (Type.Equals("TEL"))
            {
                expresion = "^[1-9][0-9]{7,12}$";
                if (Regex.Match(toCheck, expresion).Success)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool CheckBoxes()
        {
            if (!CheckString(this.Box_Telefono.Text.Trim(),"TEL"))
            {
                MessageBox.Show("El formato del teléfono es incorrecto");
                return false;    
            }

            if (!CheckString(this.Box_DNI.Text.Trim(),"DNI"))
            {
                MessageBox.Show("El formato del Número de documento es incorrecto");
                return false;    
            }


            return true;
        }

        private void ModificarAfiliado(Afiliado Paciente)
        {
            if (!SQL_Methods.Afiliado_ModificarDatos(Paciente))
            {
                MessageBox.Show(Paciente.Cod_Afiliado.ToString() + " no pudo ser modificado.");
                return;
            }

            if (PlanMedico_Familiar != -1 && PlanMedico_Familiar != Paciente.Cod_PlanMedico)
            {
                DialogForm dialogForm = new DialogForm(this,
                                                       "Ingrese Motivo Cambio de Plan",
                                                       "Por favor ingrese el motivo del cambio de plan");

                
                return;
            }

            if (FamiliaresACargo < Paciente.CantFamiliaresACargo)
            {
                ModificarFamiliares(Paciente);
                this.Visible = false;
                return;
            }

            
            MessageBox.Show(Paciente.Cod_Afiliado.ToString() + " ha sido Modificado.");
            menu.Visible = true;
            this.Dispose();
            return;
        }

        public void ModificarPlanMedico(string unMotivo)
        {
            MotivoCambioPlan = unMotivo;
            
            
            
            
            DataRow[] Rows = TablaPlanesMedicos.Select("Descripcion = '" + this.Box_PlanMed.Text + "'");
            if (Rows.Length <= 0)
            {
                MessageBox.Show("Error en la Tabla Planes Medicos");
                return;
            }

            int Cod_PlanMedicoActual = Convert.ToInt32(Rows[0][0].ToString().Trim());

            if (!SQL_Methods.Afiliado_ModificarPlanMedico(Cod_Afiliado_Principal,
                                                          PlanMedico_Familiar,
                                                          Cod_PlanMedicoActual,
                                                           MotivoCambioPlan))
            {
                MessageBox.Show(Cod_Afiliado_Principal.ToString() + " no pudo ser modificado.");
                return;
            }

            Afiliado Paciente = CargarFormEnPaciente(Cod_PlanMedicoActual);
            if (FamiliaresACargo < Paciente.CantFamiliaresACargo)
            {
                ModificarFamiliares(Paciente);
                this.Visible = false;
                return;
            }
            
            MessageBox.Show(Cod_Afiliado_Principal.ToString() + " ha sido Modificado.");
            menu.Visible = true;
            this.Dispose();
            return;
        }

        private void ModificarFamiliares(Afiliado Paciente)
        {
            menu.agregarFamiliares(Cod_Afiliado_Principal, Paciente.Cod_PlanMedico, Paciente.CantFamiliaresACargo - FamiliaresACargo );
            return;
        }
    }
}
