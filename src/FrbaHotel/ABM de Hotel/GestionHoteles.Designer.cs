﻿namespace FrbaHotel.ABM_de_Hotel
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
            this.cmbPaises = new System.Windows.Forms.ComboBox();
            this.cmbLocalidades = new System.Windows.Forms.ComboBox();
            this.lvlPais = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblEstrellas = new System.Windows.Forms.Label();
            this.cmbEstrellas = new System.Windows.Forms.ComboBox();
            this.cmbHoteles = new System.Windows.Forms.ComboBox();
            this.lblHotel = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.tbAltura = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.tbFechaCreacion = new System.Windows.Forms.TextBox();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cbRegimen1 = new System.Windows.Forms.CheckBox();
            this.cbRegimen2 = new System.Windows.Forms.CheckBox();
            this.cbRegimen3 = new System.Windows.Forms.CheckBox();
            this.cbRegimen4 = new System.Windows.Forms.CheckBox();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPaises
            // 
            this.cmbPaises.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPaises.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaises.FormattingEnabled = true;
            this.cmbPaises.Location = new System.Drawing.Point(76, 36);
            this.cmbPaises.Name = "cmbPaises";
            this.cmbPaises.Size = new System.Drawing.Size(164, 21);
            this.cmbPaises.TabIndex = 0;
            this.cmbPaises.SelectionChangeCommitted += new System.EventHandler(this.cmbPaises_SelectedIndexChanged);
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbLocalidades.Enabled = false;
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(292, 36);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(145, 21);
            this.cmbLocalidades.TabIndex = 1;
            this.cmbLocalidades.SelectionChangeCommitted += new System.EventHandler(this.cmbCiudades_SelectionChangeCommitted);
            // 
            // lvlPais
            // 
            this.lvlPais.AutoSize = true;
            this.lvlPais.Location = new System.Drawing.Point(41, 39);
            this.lvlPais.Name = "lvlPais";
            this.lvlPais.Size = new System.Drawing.Size(29, 13);
            this.lvlPais.TabIndex = 2;
            this.lvlPais.Text = "País";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(246, 39);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 3;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblEstrellas
            // 
            this.lblEstrellas.AutoSize = true;
            this.lblEstrellas.Location = new System.Drawing.Point(443, 39);
            this.lblEstrellas.Name = "lblEstrellas";
            this.lblEstrellas.Size = new System.Drawing.Size(105, 13);
            this.lblEstrellas.TabIndex = 4;
            this.lblEstrellas.Text = "Cantidad de estrellas";
            // 
            // cmbEstrellas
            // 
            this.cmbEstrellas.Enabled = false;
            this.cmbEstrellas.FormattingEnabled = true;
            this.cmbEstrellas.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbEstrellas.Location = new System.Drawing.Point(554, 36);
            this.cmbEstrellas.Name = "cmbEstrellas";
            this.cmbEstrellas.Size = new System.Drawing.Size(38, 21);
            this.cmbEstrellas.TabIndex = 3;
            this.cmbEstrellas.SelectionChangeCommitted += new System.EventHandler(this.cmbEstrellas_SelectionChangeCommitted);
            // 
            // cmbHoteles
            // 
            this.cmbHoteles.FormattingEnabled = true;
            this.cmbHoteles.Location = new System.Drawing.Point(76, 63);
            this.cmbHoteles.Name = "cmbHoteles";
            this.cmbHoteles.Size = new System.Drawing.Size(485, 21);
            this.cmbHoteles.TabIndex = 6;
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
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(567, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(25, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbCalle
            // 
            this.tbCalle.Location = new System.Drawing.Point(76, 90);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(164, 20);
            this.tbCalle.TabIndex = 9;
            // 
            // tbAltura
            // 
            this.tbAltura.Location = new System.Drawing.Point(292, 90);
            this.tbAltura.Name = "tbAltura";
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
            // tbFechaCreacion
            // 
            this.tbFechaCreacion.Location = new System.Drawing.Point(348, 117);
            this.tbFechaCreacion.Name = "tbFechaCreacion";
            this.tbFechaCreacion.Size = new System.Drawing.Size(244, 20);
            this.tbFechaCreacion.TabIndex = 17;
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
            this.lblRegimen.Location = new System.Drawing.Point(41, 143);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(115, 13);
            this.lblRegimen.TabIndex = 19;
            this.lblRegimen.Text = "Regimenes disponibles";
            // 
            // cbRegimen1
            // 
            this.cbRegimen1.AutoSize = true;
            this.cbRegimen1.Location = new System.Drawing.Point(76, 159);
            this.cbRegimen1.Name = "cbRegimen1";
            this.cbRegimen1.Size = new System.Drawing.Size(111, 17);
            this.cbRegimen1.TabIndex = 20;
            this.cbRegimen1.Text = "Pension Completa";
            this.cbRegimen1.UseVisualStyleBackColor = true;
            // 
            // cbRegimen2
            // 
            this.cbRegimen2.AutoSize = true;
            this.cbRegimen2.Location = new System.Drawing.Point(190, 159);
            this.cbRegimen2.Name = "cbRegimen2";
            this.cbRegimen2.Size = new System.Drawing.Size(96, 17);
            this.cbRegimen2.TabIndex = 21;
            this.cbRegimen2.Text = "Media Pensión";
            this.cbRegimen2.UseVisualStyleBackColor = true;
            // 
            // cbRegimen3
            // 
            this.cbRegimen3.AutoSize = true;
            this.cbRegimen3.Location = new System.Drawing.Point(292, 159);
            this.cbRegimen3.Name = "cbRegimen3";
            this.cbRegimen3.Size = new System.Drawing.Size(132, 17);
            this.cbRegimen3.TabIndex = 22;
            this.cbRegimen3.Text = "All Inclusive moderado";
            this.cbRegimen3.UseVisualStyleBackColor = true;
            // 
            // cbRegimen4
            // 
            this.cbRegimen4.AutoSize = true;
            this.cbRegimen4.Location = new System.Drawing.Point(430, 159);
            this.cbRegimen4.Name = "cbRegimen4";
            this.cbRegimen4.Size = new System.Drawing.Size(81, 17);
            this.cbRegimen4.TabIndex = 23;
            this.cbRegimen4.Text = "All inclusive";
            this.cbRegimen4.UseVisualStyleBackColor = true;
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Location = new System.Drawing.Point(29, 218);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.Size = new System.Drawing.Size(581, 250);
            this.dgvHabitaciones.TabIndex = 24;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(456, 182);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(65, 23);
            this.btSave.TabIndex = 25;
            this.btSave.Text = "btSave";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(527, 182);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(65, 23);
            this.btCancel.TabIndex = 26;
            this.btCancel.Text = "btCancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // GestionHoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.dgvHabitaciones);
            this.Controls.Add(this.cbRegimen4);
            this.Controls.Add(this.cbRegimen3);
            this.Controls.Add(this.cbRegimen2);
            this.Controls.Add(this.cbRegimen1);
            this.Controls.Add(this.lblRegimen);
            this.Controls.Add(this.lblFechaCreacion);
            this.Controls.Add(this.tbFechaCreacion);
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
        private System.Windows.Forms.TextBox tbFechaCreacion;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.CheckBox cbRegimen1;
        private System.Windows.Forms.CheckBox cbRegimen2;
        private System.Windows.Forms.CheckBox cbRegimen3;
        private System.Windows.Forms.CheckBox cbRegimen4;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;

    }
}