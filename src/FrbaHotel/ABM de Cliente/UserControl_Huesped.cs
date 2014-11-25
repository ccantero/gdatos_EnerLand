using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class UserControl_Huesped : UserControl
    {
        public Boolean flag_Modificacion;
        public Huesped huesped_A_Modificar;
        public static DataTable TablaLocalidades;
        public static DataTable TablaPaises;
        private Form FormPadre;

        public UserControl_Huesped(Form Parent)
        {
            InitializeComponent();
            flag_Modificacion = false;
            FormPadre = Parent;
            CargarTipoDoc();
            CargarLocalidades();
            CargarPaises();

            this.checkBox_Habilitado.Enabled = false;
        }

        public void Cargar_Huesped(Huesped unHuesped)
        {
            flag_Modificacion = true;            
            huesped_A_Modificar = unHuesped;
            this.checkBox_Habilitado.Enabled = true;

            if (unHuesped.idLocalidad != -1)
            {
                DataRow[] Rows = TablaLocalidades.Select("idLocalidad = " + unHuesped.idLocalidad.ToString().Trim());
                this.ComboBox_Localidad.Text = Rows[0][1].ToString().Trim();
            }
            else
                this.ComboBox_Localidad.SelectedText = "Otro";

            if (unHuesped.idPais != -1)
            {
                DataRow[] Rows = TablaPaises.Select("idPais = " + unHuesped.idPais.ToString().Trim());
                this.ComboBox_PaisOrigen.Text = Rows[0][1].ToString().Trim();
            }
            else
                this.ComboBox_PaisOrigen.SelectedText = "Otro";
         
            this.textBox_Apellido.Text = unHuesped.Apellido;
            this.textBox_Calle.Text = unHuesped.Calle;
            this.textBox_DNI.Text = unHuesped.Nro_Documento.ToString();
            this.textBox_mail.Text = unHuesped.Mail;
            this.textBox_Nacionalidad.Text = unHuesped.Nacionalidad;
            this.textBox_Name.Text = unHuesped.Nombre;
            this.textBox_Numero.Text = unHuesped.Numero.ToString();

            if(unHuesped.Piso != -1)
                this.textBox_Piso.Text = unHuesped.Piso.ToString();
            
            if (unHuesped.Telefono != -1)
                this.textBox_Telefono.Text = unHuesped.Telefono.ToString();

            this.textBox_Departamento.Text = unHuesped.Departamento.ToString();

            this.ComboBox_TipoDoc.Text = unHuesped.Tipo_Documento;

            if (unHuesped.Habilitado)
                this.checkBox_Habilitado.CheckState = CheckState.Checked;
            else
                this.checkBox_Habilitado.CheckState = CheckState.Unchecked;

            this.Box_FecNac.Value = unHuesped.Fecha_Nacimiento;


        }

        private void CargarLocalidades()
        {
            DbResultSet rs;
            string myQuery = "SELECT * FROM ENER_LAND.Localidad";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaLocalidades = rs.dataTable;

            foreach (DataRow Row in TablaLocalidades.Rows)
            {
                this.ComboBox_Localidad.Items.Add(Row[1].ToString().Trim());
            }

            this.ComboBox_Localidad.Items.Add("Otro");

            return;
        }

        private void CargarTipoDoc()
        {
            this.ComboBox_TipoDoc.Items.Clear();
            this.ComboBox_TipoDoc.Items.Add("C.I.");
            this.ComboBox_TipoDoc.Items.Add("D.N.I");
            this.ComboBox_TipoDoc.Items.Add("Pasaporte");
        }

        private void CargarPaises()
        {
            DbResultSet rs;
            string myQuery = "SELECT * FROM ENER_LAND.Pais";

            rs = DbManager.GetDataTable(myQuery);
            if (rs.operationState == 1)
                MessageBox.Show("Falló la busqueda");

            TablaPaises = rs.dataTable;

            foreach (DataRow Row in TablaPaises.Rows)
            {
                this.ComboBox_PaisOrigen.Items.Add(Row[1].ToString().Trim());
            }

            this.ComboBox_PaisOrigen.Items.Add("Otro");

            return;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Huesped nuevoHuesped = new Huesped();
            // TODO: Check Mail Regular Expression
            // TODO: Check Phone Number Regular Expression
            // TODO: Check Street Number Regular Expression
            // TODO: Check Floor Regular Expression
            // TODO: Check Department Regular Expression
            // TODO: Check Document Number Regular Expression
            nuevoHuesped.Apellido = this.textBox_Apellido.Text.Trim();
            nuevoHuesped.Calle = this.textBox_Calle.Text.Trim();
            
            if(!textBox_Departamento.Text.Trim().Equals(""))
                nuevoHuesped.Departamento = Convert.ToChar(textBox_Departamento.Text.Trim());
            
            nuevoHuesped.Fecha_Nacimiento = this.Box_FecNac.Value;

            if (this.checkBox_Habilitado.CheckState == CheckState.Checked)
                nuevoHuesped.Habilitado = true;
            else
                nuevoHuesped.Habilitado = false;

            if (!this.ComboBox_Localidad.Text.Equals("Otro"))
            {
                DataRow[] Rows = TablaLocalidades.Select("Nombre = '" + this.ComboBox_Localidad.Text.ToString().Trim() + "'");
                nuevoHuesped.idLocalidad = Convert.ToInt32(Rows[0][0].ToString().Trim());
            }

            if (!this.ComboBox_PaisOrigen.Text.Equals("Otro"))
            {
                DataRow[] Rows = TablaPaises.Select("Nombre = '" + this.ComboBox_PaisOrigen.Text.ToString().Trim() + "'");
                nuevoHuesped.idPais = Convert.ToInt32(Rows[0][0].ToString().Trim());
            }

            nuevoHuesped.Mail = this.textBox_mail.Text.Trim();

            nuevoHuesped.Nacionalidad = this.textBox_Nacionalidad.Text.Trim();

            nuevoHuesped.Nombre = this.textBox_Name.Text.Trim();
            nuevoHuesped.Nro_Documento = Convert.ToInt32(this.textBox_DNI.Text.Trim());
            nuevoHuesped.Numero = Convert.ToInt32(this.textBox_Numero.Text.Trim());
            if(!this.textBox_Piso.Text.Trim().Equals(""))
                nuevoHuesped.Piso = Convert.ToInt32(this.textBox_Piso.Text.Trim());

            nuevoHuesped.Telefono = Convert.ToInt32(this.textBox_Telefono.Text.Trim());

            nuevoHuesped.Tipo_Documento = this.ComboBox_TipoDoc.Text.Trim();

            if (!Check_Unique_Mail())
            {
                MessageBox.Show("Mail no es unico. Existe otro huesped con el mismo Mail. Verifique e intente nuevamente");
                return;
            }

            if (!flag_Modificacion)
                DbManager.Agregar_Huesped(nuevoHuesped);
            else
            {
                nuevoHuesped.idHuesped = huesped_A_Modificar.idHuesped;
                DbManager.Modificar_Huesped(nuevoHuesped);
            }
                

            ((GestionHuesped)FormPadre).Load_Menu();
        }

        private void Button_Clean_Click(object sender, EventArgs e)
        {
            foreach (Control X in this.groupBox1.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = string.Empty;
                }
            }

            this.Box_FecNac.Text = string.Empty;
            this.ComboBox_TipoDoc.Text = string.Empty;
            this.ComboBox_Localidad.Text = string.Empty;
            this.ComboBox_PaisOrigen.Text = string.Empty;

        }

        private Boolean Check_Unique_Mail()
        {
            DbResultSet rs;

            if (flag_Modificacion)
            {
                rs = DbManager.GetDataTable("SELECT idHuesped FROM ENER_LAND.Huesped WHERE Mail = '" +
                                            this.textBox_mail.Text.Trim() + "'" +
                                            " AND idHuesped <> " + huesped_A_Modificar.idHuesped
                                            );

                if (rs.dataTable.Rows.Count == 0)
                    return true;
            };

            rs = DbManager.GetDataTable("SELECT idHuesped FROM ENER_LAND.Huesped WHERE Mail = '" + 
                                                    this.textBox_mail.Text.Trim() + "'"
                                                    );

            if (rs.dataTable.Rows.Count == 0)
                return true;


            return false;
        }   
    
    }
}
