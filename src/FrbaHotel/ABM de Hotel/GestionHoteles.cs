using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class GestionHoteles : Form
    {
        private int mode;
        //0 consulta
        //1 Alta
        //2 Edicion
        public Form parentForm;
        public GestionHoteles(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        private void GestionHoteles_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            dtpFechaCreacion.Visible = false;

            mode = 0;
            
            parentForm.Hide();
            DbResultSet rs = DbManager.GetDataTable("SELECT IdPais, Nombre FROM ENER_LAND.Pais");
                        DataRow drow = rs.dataTable.NewRow();

            drow[0] = -1;
            drow[1] = "<Seleccionar>";
            rs.dataTable.Rows.InsertAt(drow, 0);

            cmbPaises.ValueMember = "idPais";
            cmbPaises.DisplayMember = "Nombre";
            cmbPaises.DataSource = rs.dataTable;

            cmbPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocalidades.DropDownStyle = ComboBoxStyle.DropDown;
            cmbEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            refreshHoteles(sender,e);
            getRegimenes();
        }

        private void cmbPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaises.SelectedIndex != 0 )
            {
                DbResultSet rs = DbManager.GetDataTable("SELECT idLocalidad, Nombre FROM ENER_LAND.Localidad ORDER BY Nombre ASC"/* WHERE + Join para obtener localidades en funcion de area padre, no necesario según alcance */);
                DataRow drow = rs.dataTable.NewRow();
                drow[0] = -1;
                drow[1] = "<Seleccionar>";
                rs.dataTable.Rows.InsertAt(drow, 0);
                cmbLocalidades.ValueMember = "idLocalidad";
                cmbLocalidades.DisplayMember = "Nombre";
                cmbLocalidades.DataSource = rs.dataTable;
                cmbLocalidades.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbLocalidades.Enabled = true;
            }
            if (mode == 0)
            {
                refreshHoteles(sender, e);
                clearDataFields();
            }
        }

        private void GestionHoteles_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentForm.Show();
        }

        private void cmbCiudades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                clearDataFields();
                refreshHoteles(sender, e);
            }
            

       }

        private void cmbEstrellas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (mode == 0) refreshHoteles(sender, e);

        }

        private void refreshHoteles(object sender, EventArgs e)
        {
            String query;

            query = "SELECT idHotel,RTRIM(Nombre) Nombre FROM ENER_LAND.Hotel WHERE 1=1 ";
            
            if (cmbPaises.SelectedIndex > 0)
                query += " AND idPais = " + cmbPaises.SelectedValue;
            if (cmbLocalidades.SelectedIndex > 0)
                query += " AND idLocalidad = " + cmbLocalidades.SelectedValue;
            if (cmbEstrellas.SelectedIndex > 0)
                query +=" AND Cantidad_Estrellas = " + cmbEstrellas.Text;

            query += " ORDER BY Nombre ASC";

            DbResultSet rs = DbManager.GetDataTable(query);
            DataRow drow = rs.dataTable.NewRow();
            drow[0] = -1;
            drow[1] = "";
            rs.dataTable.Rows.InsertAt(drow, 0);
            cmbHoteles.ValueMember = "idHotel";
            cmbHoteles.DisplayMember = "Nombre";
            cmbHoteles.DataSource = rs.dataTable;
            cmbHoteles.DropDownStyle = ComboBoxStyle.DropDown;
            cmbHoteles.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            if (mode == 0) refreshHoteles(sender, e);
        }

        private void getRegimenes()
        {
            clbRegimenes.Items.Clear();
            DbResultSet rs = DbManager.GetDataTable("SELECT idRegimen,Descripcion,CASE WHEN  (SELECT rh.idRegimen FROM ENER_LAND.Regimen_Hotel rh WHERE rh.idHotel=" + cmbHoteles.SelectedValue + " AND rh.idRegimen=r.idRegimen) >0 THEN 1 ELSE 0 END  CHECKED FROM ENER_LAND.Regimen r");
            foreach(DataRow row in rs.dataTable.Rows){
                CheckState status;
                
                if (row.Field<Int32>(2) > 0)
                    status = CheckState.Checked;
                else
                    status = CheckState.Unchecked;

               clbRegimenes.Items.Add(row[1].ToString(), status);
            }
                
        }

        private void cmbHoteles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getDatosHotel();
            getEstadoHotel();
            getRegimenes();
            if (cmbHoteles.SelectedIndex > 0)
            {
                btnEdit.Enabled = true;
                btnStatusChange.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnStatusChange.Enabled = false;
            }
            //MessageBox.Show(cmbHoteles.SelectedIndex.ToString() + " - " + cmbHoteles.Text + " - " + cmbHoteles.Name);
       }

        private void getDatosHotel()
        {
            if (cmbHoteles.SelectedIndex > 0)
            {
                DbResultSet rs = DbManager.GetDataTable("SELECT  Calle,Numero as Altura,ISNULL(mail,'') Mail,ISNULL(telefono,'') Telefono,ISNULL(fecha_creacion,'') FechaCreacion FROM ENER_LAND.Hotel WHERE idHotel = " + cmbHoteles.SelectedValue);
                tbCalle.Text =  rs.dataTable.Rows[0].Field<String>(0);
                tbAltura.Text = rs.dataTable.Rows[0].Field<Int32>(1).ToString();
                tbMail.Text = rs.dataTable.Rows[0].Field<String>(2);
                tbTelefono.Text = rs.dataTable.Rows[0].Field<Int32>(3).ToString();
                dtpFechaCreacion.Value = rs.dataTable.Rows[0].Field<DateTime>(4);
                tbHideDate.Visible = false;
                dtpFechaCreacion.Visible = true;

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mode = 1;
            cmbHoteles.DropDownStyle = ComboBoxStyle.Simple;
            cmbHoteles.SelectedIndex = 0;
            /*cmbHoteles.Enabled = false;*/
            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnStatusChange.Visible = false;
            btnAccept.Visible = true;
            btnCancel.Visible = true;
            tbTelefono.ReadOnly = false;
            tbMail.ReadOnly = false;
            tbAltura.ReadOnly = false;
            tbCalle.ReadOnly = false;
            clbRegimenes.Enabled = true;
            dtpFechaCreacion.Visible = true;
            tbHideDate.Visible = false;
            tbEstadoHotel.Text = "No";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            mode = 2;
            cmbHoteles.DropDownStyle = ComboBoxStyle.Simple;
            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnStatusChange.Visible = false;
            btnAccept.Visible = true;
            btnCancel.Visible = true;

            tbTelefono.ReadOnly = false;
            tbMail.ReadOnly = false;
            tbAltura.ReadOnly = false;
            tbCalle.ReadOnly = false;
            clbRegimenes.Enabled = true;
            dtpFechaCreacion.Visible = true;
            tbHideDate.Visible = false;

        }

        private void btnStatusChange_Click(object sender, EventArgs e)
        {
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cmbHoteles.SelectedIndex.ToString());

              using (SqlConnection connection = DbManager.dbConnect())
              {
                  using (SqlCommand command = new SqlCommand())
                  {
                      command.Connection = connection;
                      command.CommandType = CommandType.Text;
                      if (mode ==2 ){
                          command.CommandText = "UPDATE ENER_LAND.HOTEL SET " +
                                            "Nombre = @nombre, " +
                                            "Telefono = @telefono, " +
                                            "Mail = @mail, " +
                                            "Cantidad_estrellas = @cantEstrellas, " +
                                            "Numero = @numero, " +
                                            "IdLocalidad = @idLocalidad, " +
                                            "IdPais = @idPais, " +
                                            "Fecha_Creacion = @fechaCreacion," +
                                            "Habilitado = @habilitado " +
                                            "WHERE idHotel = @idHotel";
                          command.Parameters.AddWithValue("@idHotel", cmbHoteles.SelectedValue);
                      }
                  
                  if (mode == 1){
                      int newId = getNewIdHotel();
                    command.CommandText = "INSERT INTO  ENER_LAND.HOTEL VALUES" +
                                            "(@idAdmin,@nombre,@mail, @telefono,@cantEstrellas,@calle,@numero,@idLocalidad,@idPais,@fechaCreacion,@habilitado)";
                    //command.Parameters.AddWithValue("@idHotel", newId);
                  }


                      MessageBox.Show(command.CommandText);
                      command.Parameters.AddWithValue("@idAdmin", 1); //Todo tomar de usuario
                      command.Parameters.AddWithValue("@nombre", cmbHoteles.Text);
                      command.Parameters.AddWithValue("@telefono", tbTelefono.Text);
                      command.Parameters.AddWithValue("@mail", tbMail.Text);
                      command.Parameters.AddWithValue("@cantEstrellas", cmbEstrellas.Text);
                      command.Parameters.AddWithValue("@calle", tbCalle.Text); 
                      command.Parameters.AddWithValue("@numero", tbAltura.Text);
                      command.Parameters.AddWithValue("@idLocalidad", cmbLocalidades.SelectedValue);
                      command.Parameters.AddWithValue("@idPais", cmbPaises.SelectedValue);
                      command.Parameters.AddWithValue("@fechaCreacion", dtpFechaCreacion.Value);
                      command.Parameters.AddWithValue("@habilitado", getEstadoHotelCodificado());


                      int recordsAffected = command.ExecuteNonQuery();


                      connection.Close();

                  }
              }


            //TODO Save;
              mode = 0;
            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnStatusChange.Visible = true;
            btnAccept.Visible = false;
            btnCancel.Visible = false;

            tbTelefono.ReadOnly = true;
            tbMail.ReadOnly = true;
            tbAltura.ReadOnly = true;
            tbCalle.ReadOnly = true;
            clbRegimenes.Enabled = false;
            cmbHoteles.DropDownStyle = ComboBoxStyle.DropDown;
            clearFields();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnStatusChange.Visible = true;
            btnAccept.Visible = false;
            btnCancel.Visible = false;

            tbTelefono.ReadOnly = true;
            tbMail.ReadOnly = true;
            tbAltura.ReadOnly = true;
            tbCalle.ReadOnly = true;
            cmbHoteles.DropDownStyle = ComboBoxStyle.DropDown;

            
            clearFields();
            mode = 0;
        }

        /*TODO*/
        /*private void getHabilitacion()
        {
            if(cmbHoteles.SelectedIndex>0)
                DbResultSet rs = DbManager.GetDataTable("SELECT  Calle,Numero as Altura,ISNULL(mail,'') Mail,ISNULL(telefono,'') Telefono,ISNULL(fecha_creacion,'') FechaCreacion FROM ENER_LAND.Hotel WHERE idHotel = " + cmbHoteles.SelectedIndex);

        }*/

        private void getEstadoHotel()
        {
            if (cmbHoteles.SelectedIndex > 0)
            {
                DbResultSet rs = DbManager.dbGetString("SELECT  Habilitado  FROM ENER_LAND.Hotel WHERE idHotel = " + cmbHoteles.SelectedIndex);
                if (rs.strValue == "1")
                    tbEstadoHotel.Text = "Sí";
                if (rs.strValue == "0")
                    tbEstadoHotel.Text = "No";
            }


        }


        private void clearFields()
        {
            if (cmbLocalidades.Enabled)
                cmbLocalidades.SelectedIndex = -1;
            if (cmbEstrellas.Enabled)
                cmbEstrellas.SelectedIndex = -1;
            cmbPaises.SelectedIndex = 0;
            cmbEstrellas.Enabled = false;
            cmbLocalidades.Enabled = false;
            cmbHoteles.SelectedIndex = -1;
            clearDataFields();
        }

        private void clearDataFields()
        {
            tbAltura.Text = "";
            tbCalle.Text = "";
            tbMail.Text = "";
            tbTelefono.Text = "";
            tbEstadoHotel.Text = "";
            dtpFechaCreacion.Visible = false;
            tbHideDate.Visible = true;
            getRegimenes();
        }

        private void saveNuevoHotel()
        {
        }

        private void saveUpdateHotel()
        {
            DbManager.dbSqlStatementExec(
                     "UPDATE ENER_LAND.Hotel SET " + 
                     "Nombre = "+ cmbHoteles.SelectedText +
                     " , Mail = " + tbMail.Text  + 
                     ", Telefono = "+ tbTelefono.Text + 
                     ", Cantidad_Estrellas = " + cmbEstrellas.SelectedText +
                     " , Numero = " + tbAltura.Text +
                     " , idLocalidad = " + cmbLocalidades.SelectedValue + 
                     ", idPais = " + cmbPaises.SelectedValue + 
                     ", Fecha_Creacion = " + dtpFechaCreacion.Value +
                     " , Habilitado = "+ getEstadoHotelCodificado() +
                     "WHERE idHotel = " + cmbHoteles.SelectedValue
            );

         
        }

        private String getEstadoHotelCodificado()
        {
            if (tbEstadoHotel.Text == "Sí")
                return "1";
            if (tbEstadoHotel.Text == "No")
                return "0";

            else return "0";
        }

        private int getNewIdHotel(){


            DbResultSet rs = DbManager.GetDataTable("ENER_LAND.HotelSequence");
            return rs.intValue;
        }

    }
}
