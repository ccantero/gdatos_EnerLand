﻿using System;
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
            getRegimenes(0);
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

        private void getRegimenes(int idHotel)
        {
            DbResultSet rs;
            clbRegimenes.Items.Clear();
            if (idHotel > 0)
            {
                 rs = DbManager.GetDataTable("SELECT idRegimen,Descripcion,CASE WHEN  (SELECT rh.idRegimen FROM ENER_LAND.Regimen_Hotel rh WHERE rh.idHotel=" + idHotel + " AND rh.idRegimen=r.idRegimen) >0 THEN 1 ELSE 0 END  CHECKED FROM ENER_LAND.Regimen r ORDER BY r.idRegimen");
            }
            else
            {
                 rs = DbManager.GetDataTable("SELECT idRegimen,Descripcion,0 CHECKED FROM ENER_LAND.Regimen r ORDER BY r.idRegimen");
            }
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
            if (Convert.ToInt32(cmbHoteles.SelectedValue) > 0)
            {
                getDatosHotel();
                getEstadoHotel();
                getRegimenes(Convert.ToInt32(cmbHoteles.SelectedValue));
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
            MessageBox.Show("SELECTED: " + cmbHoteles.SelectedValue);
            if (Convert.ToInt32(cmbHoteles.SelectedValue) > 0)
            {
                DbResultSet rs = DbManager.GetDataTable("SELECT  Calle,Numero as Altura,ISNULL(mail,'') Mail,ISNULL(telefono,'') Telefono,ISNULL(fecha_creacion,'') FechaCreacion FROM ENER_LAND.Hotel WHERE idHotel = " + cmbHoteles.SelectedValue);
                tbCalle.Text = rs.dataTable.Rows[0].Field<String>(0);
                tbAltura.Text = rs.dataTable.Rows[0].Field<Int32>(1).ToString();
                tbMail.Text = rs.dataTable.Rows[0].Field<String>(2);
                tbTelefono.Text = rs.dataTable.Rows[0].Field<Int32>(3).ToString();
                dtpFechaCreacion.Value = rs.dataTable.Rows[0].Field<DateTime>(4);
                tbHideDate.Visible = false;
                dtpFechaCreacion.Visible = true;
                getHabitacionesHotel(Convert.ToInt32(cmbHoteles.SelectedValue));
            }
            else
            {
                dgvHabitaciones.Visible = false;
                lblHabitaciones.Visible = false;
                btnNewRoom.Visible = false;
                btnEditRoom.Visible = false;
                btnDisableRoom.Visible = false;
            }
        }

        private void getHabitacionesHotel(int idHotel)
        {
            DbResultSet rs = DbManager.GetDataTable("SELECT hb.NUMERO ,thb.idTipo_Habitacion TIPO,thb.Descripcion TIPODESC,hb.PISO,CASE hb.UBICACION WHEN 'N' THEN 'Contrafrente' WHEN 'S' THEN 'Frente' END UBICACION, hb.DESCRIPCION,hb.HABILITADO FROM ENER_LAND.Habitacion hb, ENER_LAND.Tipo_Habitacion thb WHERE hb.idTipo_Habitacion=thb.idTipo_Habitacion AND hb.IdHotel=" + idHotel + " ORDER BY hb.NUMERO ASC");
            dgvHabitaciones.DataSource = rs.dataTable;
            dgvHabitaciones.Visible = true;
            lblHabitaciones.Visible = true;
            btnNewRoom.Visible = true;
            btnEditRoom.Visible = true;
            btnDisableRoom.Visible = true;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearFields();
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
            lblHabitaciones.Visible = false;
            dgvHabitaciones.Visible = false;
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
            Int32 idHotel = 0 ;

            if (Convert.ToInt32(cmbPaises.SelectedValue) > 0 && Convert.ToInt32(cmbLocalidades.SelectedValue) > 0 && (cmbHoteles.SelectedIndex > 0 || mode == 1) && cmbEstrellas.SelectedIndex > 0)
            {
                using (SqlConnection connection = DbManager.dbConnect())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        if (mode == 2)
                        {
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
                            idHotel = Convert.ToInt32(cmbHoteles.SelectedValue);

                        }

                        if (mode == 1)
                        {
                            command.CommandText = "ENER_LAND.Nuevo_Hotel  @idAdmin,@nombre,@mail, @telefono,@cantEstrellas,@calle,@numero,@idLocalidad,@idPais,@fechaCreacion,@habilitado";
                            //command.Parameters.AddWithValue("@idHotel", newId);

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

                            //var returnParameter = command.Parameters.Add("@idHotel", SqlDbType.Int);
                            //returnParameter.Direction = ParameterDirection.ReturnValue;
                            //MessageBox.Show(command.ExecuteScalar().ToString());
                             idHotel = Convert.ToInt32(command.ExecuteScalar());
                            MessageBox.Show(idHotel.ToString());
                             //= Convert.ToInt32(command.Parameters["@idHotel"].Value);
                        }



                        MessageBox.Show("LALA");
                        updateRegimenHotel(idHotel);
                        MessageBox.Show("LALA1");
                        connection.Close();

                    }
                }


                mode = 0;
                btnNew.Visible = true;
                btnEdit.Visible = true;
                btnStatusChange.Visible = true;
                btnAccept.Visible = false;
                btnCancel.Visible = false;
                lblHabitaciones.Visible = true;
                dgvHabitaciones.Visible = true;

                tbTelefono.ReadOnly = true;
                tbMail.ReadOnly = true;
                tbAltura.ReadOnly = true;
                tbCalle.ReadOnly = true;
                clbRegimenes.Enabled = false;
                cmbHoteles.DropDownStyle = ComboBoxStyle.DropDown;
                clearFields();

            }
            else
            {
                MessageBox.Show("Error al impactar cambios, faltan datos obligatorios.", "ABM Hoteles",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnStatusChange.Visible = true;
            btnAccept.Visible = false;
            btnCancel.Visible = false;
            lblHabitaciones.Visible = true;
            dgvHabitaciones.Visible = true;

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
            //cmbEstrellas.Enabled = false;
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
            clbRegimenes.Items.Clear();
            getRegimenes(0);
            refreshHoteles(null, null);
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

 

        private void updateRegimenHotel(int hotel){

            DbResultSet rs;
            rs = DbManager.dbSqlStatementExec("DELETE FROM ENER_LAND.Regimen_Hotel WHERE idHotel = " + hotel);
            int idRegimen;
       
            foreach (int idx in clbRegimenes.CheckedIndices)
            {
                idRegimen = idx + 1;
                MessageBox.Show("INSERT INTO ENER_LAND.Regimen_Hotel VALUES ( " + hotel + "," + idRegimen + ")");
                rs = DbManager.dbSqlStatementExec("INSERT INTO ENER_LAND.Regimen_Hotel VALUES ( " + hotel + "," + idRegimen + ")");
                    

                }
            }
        }

    }
