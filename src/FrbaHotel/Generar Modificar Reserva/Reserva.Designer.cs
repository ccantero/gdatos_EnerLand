namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Reserva
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbRegimenHotelRes = new System.Windows.Forms.ComboBox();
            this.udCantHuespedes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbTotalReserva = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCodReserva = new System.Windows.Forms.Label();
            this.tbCodReserva = new System.Windows.Forms.TextBox();
            this.btnReserva = new System.Windows.Forms.Button();
            this.lbHotelesDisponibles = new System.Windows.Forms.Label();
            this.cmbHotelesDisponibles = new System.Windows.Forms.ComboBox();
            this.lbHabDisponibles = new System.Windows.Forms.Label();
            this.cmbRegHotel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvHabitacionesReserva = new System.Windows.Forms.DataGridView();
            this.dgvHabDisponibles = new System.Windows.Forms.DataGridView();
            this.btnAgregarHabTipo = new System.Windows.Forms.Button();
            this.btnQuitarHabitacion = new System.Windows.Forms.Button();
            this.btnAgregarHabitacion = new System.Windows.Forms.Button();
            this.btnBuscarHotel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.udCantHuespedes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacionesReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(139, 35);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(153, 20);
            this.dtpFechaDesde.TabIndex = 0;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(360, 35);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(151, 20);
            this.dtpFechaHasta.TabIndex = 1;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // cmbRegimenHotelRes
            // 
            this.cmbRegimenHotelRes.FormattingEnabled = true;
            this.cmbRegimenHotelRes.Location = new System.Drawing.Point(139, 61);
            this.cmbRegimenHotelRes.Name = "cmbRegimenHotelRes";
            this.cmbRegimenHotelRes.Size = new System.Drawing.Size(153, 21);
            this.cmbRegimenHotelRes.TabIndex = 3;
            // 
            // udCantHuespedes
            // 
            this.udCantHuespedes.Location = new System.Drawing.Point(360, 62);
            this.udCantHuespedes.Name = "udCantHuespedes";
            this.udCantHuespedes.Size = new System.Drawing.Size(151, 20);
            this.udCantHuespedes.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Huespedes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Regimen";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(403, 445);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 57;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lbTotalReserva
            // 
            this.lbTotalReserva.AutoSize = true;
            this.lbTotalReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalReserva.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbTotalReserva.Location = new System.Drawing.Point(72, 409);
            this.lbTotalReserva.Name = "lbTotalReserva";
            this.lbTotalReserva.Size = new System.Drawing.Size(74, 20);
            this.lbTotalReserva.TabIndex = 56;
            this.lbTotalReserva.Text = "Total $0";
            this.lbTotalReserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalReserva.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblCodReserva
            // 
            this.lblCodReserva.AutoSize = true;
            this.lblCodReserva.Location = new System.Drawing.Point(73, 13);
            this.lblCodReserva.Name = "lblCodReserva";
            this.lblCodReserva.Size = new System.Drawing.Size(62, 13);
            this.lblCodReserva.TabIndex = 58;
            this.lblCodReserva.Text = "Nro reserva";
            // 
            // tbCodReserva
            // 
            this.tbCodReserva.Location = new System.Drawing.Point(139, 9);
            this.tbCodReserva.Name = "tbCodReserva";
            this.tbCodReserva.Size = new System.Drawing.Size(153, 20);
            this.tbCodReserva.TabIndex = 59;
            // 
            // btnReserva
            // 
            this.btnReserva.BackgroundImage = global::FrbaHotel.Properties.Resources._24x24search;
            this.btnReserva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserva.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReserva.Location = new System.Drawing.Point(298, 1);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(32, 36);
            this.btnReserva.TabIndex = 60;
            this.btnReserva.UseVisualStyleBackColor = true;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // lbHotelesDisponibles
            // 
            this.lbHotelesDisponibles.AutoSize = true;
            this.lbHotelesDisponibles.Location = new System.Drawing.Point(72, 93);
            this.lbHotelesDisponibles.Name = "lbHotelesDisponibles";
            this.lbHotelesDisponibles.Size = new System.Drawing.Size(32, 13);
            this.lbHotelesDisponibles.TabIndex = 64;
            this.lbHotelesDisponibles.Text = "Hotel";
            // 
            // cmbHotelesDisponibles
            // 
            this.cmbHotelesDisponibles.FormattingEnabled = true;
            this.cmbHotelesDisponibles.Location = new System.Drawing.Point(75, 109);
            this.cmbHotelesDisponibles.Name = "cmbHotelesDisponibles";
            this.cmbHotelesDisponibles.Size = new System.Drawing.Size(322, 21);
            this.cmbHotelesDisponibles.TabIndex = 65;
            this.cmbHotelesDisponibles.SelectionChangeCommitted += new System.EventHandler(this.cmbHotelesDisponibles_SelectionChangeCommitted);
            // 
            // lbHabDisponibles
            // 
            this.lbHabDisponibles.AutoSize = true;
            this.lbHabDisponibles.Location = new System.Drawing.Point(73, 133);
            this.lbHabDisponibles.Name = "lbHabDisponibles";
            this.lbHabDisponibles.Size = new System.Drawing.Size(112, 13);
            this.lbHabDisponibles.TabIndex = 67;
            this.lbHabDisponibles.Text = "Habitaciones del hotel";
            // 
            // cmbRegHotel
            // 
            this.cmbRegHotel.FormattingEnabled = true;
            this.cmbRegHotel.Location = new System.Drawing.Point(403, 109);
            this.cmbRegHotel.Name = "cmbRegHotel";
            this.cmbRegHotel.Size = new System.Drawing.Size(156, 21);
            this.cmbRegHotel.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Regimen de reserva";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Habitaciones de la reserva";
            // 
            // dgvHabitacionesReserva
            // 
            this.dgvHabitacionesReserva.AllowUserToAddRows = false;
            this.dgvHabitacionesReserva.AllowUserToDeleteRows = false;
            this.dgvHabitacionesReserva.AllowUserToResizeRows = false;
            this.dgvHabitacionesReserva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitacionesReserva.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabitacionesReserva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHabitacionesReserva.ColumnHeadersHeight = 20;
            this.dgvHabitacionesReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHabitacionesReserva.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHabitacionesReserva.EnableHeadersVisualStyles = false;
            this.dgvHabitacionesReserva.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvHabitacionesReserva.Location = new System.Drawing.Point(76, 273);
            this.dgvHabitacionesReserva.MultiSelect = false;
            this.dgvHabitacionesReserva.Name = "dgvHabitacionesReserva";
            this.dgvHabitacionesReserva.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHabitacionesReserva.RowHeadersVisible = false;
            this.dgvHabitacionesReserva.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitacionesReserva.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHabitacionesReserva.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvHabitacionesReserva.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabitacionesReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitacionesReserva.Size = new System.Drawing.Size(450, 116);
            this.dgvHabitacionesReserva.TabIndex = 74;
            // 
            // dgvHabDisponibles
            // 
            this.dgvHabDisponibles.AllowUserToAddRows = false;
            this.dgvHabDisponibles.AllowUserToDeleteRows = false;
            this.dgvHabDisponibles.AllowUserToResizeRows = false;
            this.dgvHabDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabDisponibles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHabDisponibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHabDisponibles.ColumnHeadersHeight = 20;
            this.dgvHabDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHabDisponibles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHabDisponibles.EnableHeadersVisualStyles = false;
            this.dgvHabDisponibles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvHabDisponibles.Location = new System.Drawing.Point(76, 151);
            this.dgvHabDisponibles.MultiSelect = false;
            this.dgvHabDisponibles.Name = "dgvHabDisponibles";
            this.dgvHabDisponibles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHabDisponibles.RowHeadersVisible = false;
            this.dgvHabDisponibles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabDisponibles.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHabDisponibles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvHabDisponibles.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHabDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabDisponibles.Size = new System.Drawing.Size(446, 92);
            this.dgvHabDisponibles.TabIndex = 77;
            // 
            // btnAgregarHabTipo
            // 
            this.btnAgregarHabTipo.BackgroundImage = global::FrbaHotel.Properties.Resources._24x24pedit;
            this.btnAgregarHabTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarHabTipo.Location = new System.Drawing.Point(528, 151);
            this.btnAgregarHabTipo.Name = "btnAgregarHabTipo";
            this.btnAgregarHabTipo.Size = new System.Drawing.Size(32, 34);
            this.btnAgregarHabTipo.TabIndex = 78;
            this.btnAgregarHabTipo.UseVisualStyleBackColor = true;
            this.btnAgregarHabTipo.Click += new System.EventHandler(this.btnAgregarTipoHabitacion_Click);
            // 
            // btnQuitarHabitacion
            // 
            this.btnQuitarHabitacion.BackgroundImage = global::FrbaHotel.Properties.Resources._24x24editcancel;
            this.btnQuitarHabitacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarHabitacion.Location = new System.Drawing.Point(528, 313);
            this.btnQuitarHabitacion.Name = "btnQuitarHabitacion";
            this.btnQuitarHabitacion.Size = new System.Drawing.Size(32, 33);
            this.btnQuitarHabitacion.TabIndex = 76;
            this.btnQuitarHabitacion.UseVisualStyleBackColor = true;
            this.btnQuitarHabitacion.Click += new System.EventHandler(this.btnQuitarHabitacion_Click);
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.BackgroundImage = global::FrbaHotel.Properties.Resources._24x24pedit;
            this.btnAgregarHabitacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(528, 273);
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(32, 34);
            this.btnAgregarHabitacion.TabIndex = 75;
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click);
            // 
            // btnBuscarHotel
            // 
            this.btnBuscarHotel.BackgroundImage = global::FrbaHotel.Properties.Resources._24x24search;
            this.btnBuscarHotel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscarHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHotel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarHotel.Location = new System.Drawing.Point(517, 28);
            this.btnBuscarHotel.Name = "btnBuscarHotel";
            this.btnBuscarHotel.Size = new System.Drawing.Size(30, 30);
            this.btnBuscarHotel.TabIndex = 15;
            this.btnBuscarHotel.UseVisualStyleBackColor = true;
            this.btnBuscarHotel.Click += new System.EventHandler(this.btnBuscarHotel_Click);
            // 
            // Reserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.btnAgregarHabTipo);
            this.Controls.Add(this.dgvHabDisponibles);
            this.Controls.Add(this.btnQuitarHabitacion);
            this.Controls.Add(this.btnAgregarHabitacion);
            this.Controls.Add(this.dgvHabitacionesReserva);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRegHotel);
            this.Controls.Add(this.lbHabDisponibles);
            this.Controls.Add(this.cmbHotelesDisponibles);
            this.Controls.Add(this.lbHotelesDisponibles);
            this.Controls.Add(this.btnReserva);
            this.Controls.Add(this.tbCodReserva);
            this.Controls.Add(this.lblCodReserva);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbTotalReserva);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBuscarHotel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.udCantHuespedes);
            this.Controls.Add(this.cmbRegimenHotelRes);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Name = "Reserva";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reserva_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.udCantHuespedes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacionesReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.ComboBox cmbRegimenHotelRes;
        private System.Windows.Forms.NumericUpDown udCantHuespedes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarHotel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lbTotalReserva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCodReserva;
        private System.Windows.Forms.TextBox tbCodReserva;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.Label lbHotelesDisponibles;
        private System.Windows.Forms.ComboBox cmbHotelesDisponibles;
        private System.Windows.Forms.Label lbHabDisponibles;
        private System.Windows.Forms.ComboBox cmbRegHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvHabitacionesReserva;
        private System.Windows.Forms.Button btnAgregarHabitacion;
        private System.Windows.Forms.Button btnQuitarHabitacion;
        private System.Windows.Forms.DataGridView dgvHabDisponibles;
        private System.Windows.Forms.Button btnAgregarHabTipo;
    }
}