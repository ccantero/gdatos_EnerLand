namespace FrbaHotel.ABM_de_Hotel
{
    partial class GestionHoteles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionHoteles));
            this.cmbPaises = new System.Windows.Forms.ComboBox();
            this.cmbLocalidades = new System.Windows.Forms.ComboBox();
            this.lvlPais = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.cmbEstrellas = new System.Windows.Forms.ComboBox();
            this.cmbHoteles = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.tbAltura = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.clbRegimenes = new System.Windows.Forms.CheckedListBox();
            this.lblHabitaciones = new System.Windows.Forms.Label();
            this.lblHabilitado = new System.Windows.Forms.Label();
            this.tbEstadoHotel = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnStatusChange = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.tbHideDate = new System.Windows.Forms.TextBox();
            this.btnEditRoom = new System.Windows.Forms.Button();
            this.btnNewRoom = new System.Windows.Forms.Button();
            this.btnDisableRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPaises
            // 
            this.cmbPaises.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPaises.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaises.FormattingEnabled = true;
            this.cmbPaises.Location = new System.Drawing.Point(44, 36);
            this.cmbPaises.Name = "cmbPaises";
            this.cmbPaises.Size = new System.Drawing.Size(187, 21);
            this.cmbPaises.TabIndex = 0;
            this.cmbPaises.SelectionChangeCommitted += new System.EventHandler(this.cmbPaises_SelectedIndexChanged);
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLocalidades.Enabled = false;
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(237, 36);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(203, 21);
            this.cmbLocalidades.TabIndex = 1;
            this.cmbLocalidades.SelectionChangeCommitted += new System.EventHandler(this.cmbCiudades_SelectionChangeCommitted);
            // 
            // lvlPais
            // 
            this.lvlPais.AutoSize = true;
            this.lvlPais.Location = new System.Drawing.Point(44, 20);
            this.lvlPais.Name = "lvlPais";
            this.lvlPais.Size = new System.Drawing.Size(29, 13);
            this.lvlPais.TabIndex = 2;
            this.lvlPais.Text = "País";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(234, 20);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 3;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Location = new System.Drawing.Point(443, 20);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(105, 13);
            this.lblEstrellas.TabIndex = 4;
            this.lblEstrellas.Text = "Cantidad de estrellas";
            // 
            // cmbEstrellas
            // 
            this.cmbEstrellas.FormattingEnabled = true;
            this.cmbEstrellas.Items.AddRange(new object[] {
            "<Seleccionar>",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbEstrellas.Location = new System.Drawing.Point(446, 36);
            this.cmbEstrellas.Name = "cmbEstrellas";
            this.cmbEstrellas.Size = new System.Drawing.Size(110, 21);
            this.cmbEstrellas.TabIndex = 6;
            this.cmbEstrellas.SelectionChangeCommitted += new System.EventHandler(this.cmbEstrellas_SelectionChangeCommitted);
            // 
            // cmbHoteles
            // 
            this.cmbHoteles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHoteles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHoteles.FormattingEnabled = true;
            this.cmbHoteles.Location = new System.Drawing.Point(76, 63);
            this.cmbHoteles.Name = "cmbHoteles";
            this.cmbHoteles.Size = new System.Drawing.Size(516, 21);
            this.cmbHoteles.TabIndex = 6;
            this.cmbHoteles.SelectedIndexChanged += new System.EventHandler(this.cmbHoteles_SelectionChangeCommitted);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Location = new System.Drawing.Point(41, 66);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(32, 13);
            this.lblHotel.TabIndex = 7;
            this.lblHotel.Text = "Hotel";
            // 
            // tbCalle
            // 
            this.tbCalle.Location = new System.Drawing.Point(76, 90);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.ReadOnly = true;
            this.tbCalle.Size = new System.Drawing.Size(164, 20);
            this.tbCalle.TabIndex = 9;
            // 
            // tbAltura
            // 
            this.tbAltura.Location = new System.Drawing.Point(292, 90);
            this.tbAltura.Name = "tbAltura";
            this.tbAltura.ReadOnly = true;
            this.tbAltura.Size = new System.Drawing.Size(90, 20);
            this.tbAltura.TabIndex = 10;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(40, 93);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(30, 13);
            this.lblCalle.TabIndex = 11;
            this.lblCalle.Text = "Calle";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(246, 93);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(34, 13);
            this.lblAltura.TabIndex = 12;
            this.lblAltura.Text = "Altura";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(420, 90);
            this.tbMail.Name = "tbMail";
            this.tbMail.ReadOnly = true;
            this.tbMail.Size = new System.Drawing.Size(172, 20);
            this.tbMail.TabIndex = 13;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(388, 93);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(26, 13);
            this.lblMail.TabIndex = 14;
            this.lblMail.Text = "Mail";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(76, 117);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.ReadOnly = true;
            this.tbTelefono.Size = new System.Drawing.Size(164, 20);
            this.tbTelefono.TabIndex = 15;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(41, 120);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(25, 13);
            this.lblTelefono.TabIndex = 16;
            this.lblTelefono.Text = "Tel.";
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(246, 120);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(96, 13);
            this.lblFechaCreacion.TabIndex = 18;
            this.lblFechaCreacion.Text = "Fecha de creación";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(41, 151);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(115, 13);
            this.lblRegimen.TabIndex = 19;
            this.lblRegimen.Text = "Regimenes disponibles";
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.AllowUserToResizeRows = false;
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvHabitaciones.ColumnHeadersHeight = 20;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHabitaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHabitaciones.EnableHeadersVisualStyles = false;
            this.dgvHabitaciones.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvHabitaciones.Location = new System.Drawing.Point(43, 280);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHabitaciones.RowHeadersVisible = false;
            this.dgvHabitaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitaciones.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvHabitaciones.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvHabitaciones.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitaciones.Size = new System.Drawing.Size(549, 188);
            this.dgvHabitaciones.TabIndex = 24;
            this.dgvHabitaciones.Visible = false;
            // 
            // clbRegimenes
            // 
            this.clbRegimenes.CheckOnClick = true;
            this.clbRegimenes.Enabled = false;
            this.clbRegimenes.FormattingEnabled = true;
            this.clbRegimenes.Location = new System.Drawing.Point(43, 167);
            this.clbRegimenes.Name = "clbRegimenes";
            this.clbRegimenes.Size = new System.Drawing.Size(549, 94);
            this.clbRegimenes.TabIndex = 27;
            // 
            // lblHabitaciones
            // 
            this.lblHabitaciones.AutoSize = true;
            this.lblHabitaciones.Location = new System.Drawing.Point(44, 264);
            this.lblHabitaciones.Name = "lblHabitaciones";
            this.lblHabitaciones.Size = new System.Drawing.Size(69, 13);
            this.lblHabitaciones.TabIndex = 28;
            this.lblHabitaciones.Text = "Habitaciones";
            this.lblHabitaciones.Visible = false;
            // 
            // lblHabilitado
            // 
            this.lblHabilitado.AutoSize = true;
            this.lblHabilitado.Location = new System.Drawing.Point(495, 120);
            this.lblHabilitado.Name = "lblHabilitado";
            this.lblHabilitado.Size = new System.Drawing.Size(54, 13);
            this.lblHabilitado.TabIndex = 29;
            this.lblHabilitado.Text = "Habilitado";
            // 
            // tbEstadoHotel
            // 
            this.tbEstadoHotel.Enabled = false;
            this.tbEstadoHotel.Location = new System.Drawing.Point(555, 117);
            this.tbEstadoHotel.Name = "tbEstadoHotel";
            this.tbEstadoHotel.ReadOnly = true;
            this.tbEstadoHotel.Size = new System.Drawing.Size(37, 20);
            this.tbEstadoHotel.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(598, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 31);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Transparent;
            this.btnAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccept.BackgroundImage")));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAccept.Location = new System.Drawing.Point(598, 34);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(30, 31);
            this.btnAccept.TabIndex = 32;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnStatusChange
            // 
            this.btnStatusChange.BackColor = System.Drawing.Color.Transparent;
            this.btnStatusChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStatusChange.BackgroundImage")));
            this.btnStatusChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStatusChange.Enabled = false;
            this.btnStatusChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusChange.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStatusChange.Location = new System.Drawing.Point(598, 108);
            this.btnStatusChange.Name = "btnStatusChange";
            this.btnStatusChange.Size = new System.Drawing.Size(30, 31);
            this.btnStatusChange.TabIndex = 31;
            this.btnStatusChange.UseVisualStyleBackColor = false;
            this.btnStatusChange.Click += new System.EventHandler(this.btnStatusChange_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Location = new System.Drawing.Point(598, 71);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 31);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(598, 34);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(30, 31);
            this.btnNew.TabIndex = 25;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Location = new System.Drawing.Point(562, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Checked = false;
            this.dtpFechaCreacion.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFechaCreacion.Enabled = false;
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(348, 117);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(141, 20);
            this.dtpFechaCreacion.TabIndex = 34;
            // 
            // tbHideDate
            // 
            this.tbHideDate.Location = new System.Drawing.Point(348, 117);
            this.tbHideDate.Name = "tbHideDate";
            this.tbHideDate.ReadOnly = true;
            this.tbHideDate.Size = new System.Drawing.Size(141, 20);
            this.tbHideDate.TabIndex = 35;
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.BackColor = System.Drawing.Color.Transparent;
            this.btnEditRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditRoom.BackgroundImage")));
            this.btnEditRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRoom.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditRoom.Location = new System.Drawing.Point(598, 317);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(30, 31);
            this.btnEditRoom.TabIndex = 38;
            this.btnEditRoom.UseVisualStyleBackColor = false;
            this.btnEditRoom.Visible = false;
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.BackColor = System.Drawing.Color.Transparent;
            this.btnNewRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewRoom.BackgroundImage")));
            this.btnNewRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRoom.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNewRoom.Location = new System.Drawing.Point(598, 280);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(30, 31);
            this.btnNewRoom.TabIndex = 37;
            this.btnNewRoom.UseVisualStyleBackColor = false;
            this.btnNewRoom.Visible = false;
            // 
            // btnDisableRoom
            // 
            this.btnDisableRoom.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisableRoom.BackgroundImage")));
            this.btnDisableRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDisableRoom.Enabled = false;
            this.btnDisableRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableRoom.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDisableRoom.Location = new System.Drawing.Point(598, 354);
            this.btnDisableRoom.Name = "btnDisableRoom";
            this.btnDisableRoom.Size = new System.Drawing.Size(30, 31);
            this.btnDisableRoom.TabIndex = 36;
            this.btnDisableRoom.UseVisualStyleBackColor = false;
            this.btnDisableRoom.Visible = false;
            // 
            // GestionHoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.btnNewRoom);
            this.Controls.Add(this.btnDisableRoom);
            this.Controls.Add(this.tbHideDate);
            this.Controls.Add(this.dtpFechaCreacion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnStatusChange);
            this.Controls.Add(this.tbEstadoHotel);
            this.Controls.Add(this.lblHabilitado);
            this.Controls.Add(this.lblHabitaciones);
            this.Controls.Add(this.clbRegimenes);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.lblRegimen);
            this.Controls.Add(this.lblFechaCreacion);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.tbAltura);
            this.Controls.Add(this.tbCalle);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.cmbHoteles);
            this.Controls.Add(this.cmbEstrellas);
            this.Controls.Add(this.lblEstrellas);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lvlPais);
            this.Controls.Add(this.cmbLocalidades);
            this.Controls.Add(this.cmbPaises);
            this.Name = "GestionHoteles";
            this.Text = "GestionHoteles";
            this.Load += new System.EventHandler(this.GestionHoteles_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GestionHoteles_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPaises;
        private System.Windows.Forms.ComboBox cmbLocalidades;
        private System.Windows.Forms.Label lvlPais;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblEstrellas;
        private System.Windows.Forms.ComboBox cmbEstrellas;
        private System.Windows.Forms.ComboBox cmbHoteles;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbCalle;
        private System.Windows.Forms.TextBox tbAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckedListBox clbRegimenes;
        private System.Windows.Forms.Label lblHabitaciones;
        private System.Windows.Forms.Label lblHabilitado;
        private System.Windows.Forms.TextBox tbEstadoHotel;
        private System.Windows.Forms.Button btnStatusChange;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.TextBox tbHideDate;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.Button btnNewRoom;
        private System.Windows.Forms.Button btnDisableRoom;

    }
}