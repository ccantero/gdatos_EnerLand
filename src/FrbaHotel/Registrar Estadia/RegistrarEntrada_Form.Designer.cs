namespace FrbaHotel.Registrar_Estadia
{
    partial class RegistrarEntrada_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_CantHuespedes = new System.Windows.Forms.TextBox();
            this.label_CantidadHuespedes = new System.Windows.Forms.Label();
            this.label_CantidadDias = new System.Windows.Forms.Label();
            this.textBox_CantidadDias = new System.Windows.Forms.TextBox();
            this.textBox_Regimen = new System.Windows.Forms.TextBox();
            this.label_Regimen = new System.Windows.Forms.Label();
            this.box_FechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.textBox_idReserva = new System.Windows.Forms.TextBox();
            this.label_idReserva = new System.Windows.Forms.Label();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_FechaIngreso = new System.Windows.Forms.Label();
            this.dataGrid_ItemFactura = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_CantHuespedes);
            this.groupBox1.Controls.Add(this.label_CantidadHuespedes);
            this.groupBox1.Controls.Add(this.label_CantidadDias);
            this.groupBox1.Controls.Add(this.textBox_CantidadDias);
            this.groupBox1.Controls.Add(this.textBox_Regimen);
            this.groupBox1.Controls.Add(this.label_Regimen);
            this.groupBox1.Controls.Add(this.box_FechaIngreso);
            this.groupBox1.Controls.Add(this.textBox_idReserva);
            this.groupBox1.Controls.Add(this.label_idReserva);
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.label_FechaIngreso);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 240);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check-In";
            // 
            // textBox_CantHuespedes
            // 
            this.textBox_CantHuespedes.Location = new System.Drawing.Point(149, 100);
            this.textBox_CantHuespedes.Name = "textBox_CantHuespedes";
            this.textBox_CantHuespedes.Size = new System.Drawing.Size(103, 20);
            this.textBox_CantHuespedes.TabIndex = 25;
            // 
            // label_CantidadHuespedes
            // 
            this.label_CantidadHuespedes.AutoSize = true;
            this.label_CantidadHuespedes.Location = new System.Drawing.Point(147, 84);
            this.label_CantidadHuespedes.Name = "label_CantidadHuespedes";
            this.label_CantidadHuespedes.Size = new System.Drawing.Size(106, 13);
            this.label_CantidadHuespedes.TabIndex = 24;
            this.label_CantidadHuespedes.Text = "Cantidad Huespedes";
            // 
            // label_CantidadDias
            // 
            this.label_CantidadDias.AutoSize = true;
            this.label_CantidadDias.Location = new System.Drawing.Point(12, 84);
            this.label_CantidadDias.Name = "label_CantidadDias";
            this.label_CantidadDias.Size = new System.Drawing.Size(106, 13);
            this.label_CantidadDias.TabIndex = 23;
            this.label_CantidadDias.Text = "Cantidad Huespedes";
            // 
            // textBox_CantidadDias
            // 
            this.textBox_CantidadDias.Location = new System.Drawing.Point(15, 100);
            this.textBox_CantidadDias.Name = "textBox_CantidadDias";
            this.textBox_CantidadDias.Size = new System.Drawing.Size(103, 20);
            this.textBox_CantidadDias.TabIndex = 22;
            // 
            // textBox_Regimen
            // 
            this.textBox_Regimen.Enabled = false;
            this.textBox_Regimen.Location = new System.Drawing.Point(15, 155);
            this.textBox_Regimen.Name = "textBox_Regimen";
            this.textBox_Regimen.Size = new System.Drawing.Size(223, 20);
            this.textBox_Regimen.TabIndex = 20;
            // 
            // label_Regimen
            // 
            this.label_Regimen.AutoSize = true;
            this.label_Regimen.Location = new System.Drawing.Point(12, 139);
            this.label_Regimen.Name = "label_Regimen";
            this.label_Regimen.Size = new System.Drawing.Size(49, 13);
            this.label_Regimen.TabIndex = 18;
            this.label_Regimen.Text = "Regimen";
            // 
            // box_FechaIngreso
            // 
            this.box_FechaIngreso.Enabled = false;
            this.box_FechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.box_FechaIngreso.Location = new System.Drawing.Point(149, 45);
            this.box_FechaIngreso.Name = "box_FechaIngreso";
            this.box_FechaIngreso.Size = new System.Drawing.Size(89, 20);
            this.box_FechaIngreso.TabIndex = 17;
            // 
            // textBox_idReserva
            // 
            this.textBox_idReserva.Location = new System.Drawing.Point(15, 45);
            this.textBox_idReserva.Name = "textBox_idReserva";
            this.textBox_idReserva.Size = new System.Drawing.Size(103, 20);
            this.textBox_idReserva.TabIndex = 15;
            this.textBox_idReserva.TextChanged += new System.EventHandler(this.textBox_idReserva_TextChanged);
            // 
            // label_idReserva
            // 
            this.label_idReserva.AutoSize = true;
            this.label_idReserva.Location = new System.Drawing.Point(12, 29);
            this.label_idReserva.Name = "label_idReserva";
            this.label_idReserva.Size = new System.Drawing.Size(55, 13);
            this.label_idReserva.TabIndex = 14;
            this.label_idReserva.Text = "idReserva";
            // 
            // button_Clean
            // 
            this.button_Clean.Location = new System.Drawing.Point(163, 205);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 13;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(34, 205);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Submit";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_FechaIngreso
            // 
            this.label_FechaIngreso.AutoSize = true;
            this.label_FechaIngreso.Location = new System.Drawing.Point(148, 29);
            this.label_FechaIngreso.Name = "label_FechaIngreso";
            this.label_FechaIngreso.Size = new System.Drawing.Size(75, 13);
            this.label_FechaIngreso.TabIndex = 9;
            this.label_FechaIngreso.Text = "Fecha Ingreso";
            // 
            // dataGrid_ItemFactura
            // 
            this.dataGrid_ItemFactura.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_ItemFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ItemFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ItemFactura.Location = new System.Drawing.Point(12, 258);
            this.dataGrid_ItemFactura.Name = "dataGrid_ItemFactura";
            this.dataGrid_ItemFactura.RowHeadersVisible = false;
            this.dataGrid_ItemFactura.Size = new System.Drawing.Size(259, 100);
            this.dataGrid_ItemFactura.TabIndex = 21;
            // 
            // RegistrarEntrada_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 380);
            this.Controls.Add(this.dataGrid_ItemFactura);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarEntrada_Form";
            this.Text = "Registrar Estadia";
            this.Load += new System.EventHandler(this.RegistrarEntrada_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker box_FechaIngreso;
        private System.Windows.Forms.TextBox textBox_idReserva;
        private System.Windows.Forms.Label label_idReserva;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_FechaIngreso;
        private System.Windows.Forms.TextBox textBox_Regimen;
        private System.Windows.Forms.Label label_Regimen;
        private System.Windows.Forms.DataGridView dataGrid_ItemFactura;
        private System.Windows.Forms.TextBox textBox_CantHuespedes;
        private System.Windows.Forms.Label label_CantidadHuespedes;
        private System.Windows.Forms.Label label_CantidadDias;
        private System.Windows.Forms.TextBox textBox_CantidadDias;
    }
}