namespace FrbaHotel.Facturar
{
    partial class Factura_Form
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
            this.button_CheckReserva = new System.Windows.Forms.Button();
            this.Box_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.box_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label_FechaHasta = new System.Windows.Forms.Label();
            this.textBox_idReserva = new System.Windows.Forms.TextBox();
            this.label_idReserva = new System.Windows.Forms.Label();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.comboBox_FormaDePago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_FechaDesde = new System.Windows.Forms.Label();
            this.label_Huesped = new System.Windows.Forms.Label();
            this.textBox_Huesped = new System.Windows.Forms.TextBox();
            this.textBox_idEstadia = new System.Windows.Forms.TextBox();
            this.label_idEstadia = new System.Windows.Forms.Label();
            this.dataGrid_ItemFactura = new System.Windows.Forms.DataGridView();
            this.textBox_FacturaNro = new System.Windows.Forms.TextBox();
            this.label_FacturaNro = new System.Windows.Forms.Label();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label_Total = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_CheckReserva);
            this.groupBox1.Controls.Add(this.Box_FechaHasta);
            this.groupBox1.Controls.Add(this.box_FechaDesde);
            this.groupBox1.Controls.Add(this.label_FechaHasta);
            this.groupBox1.Controls.Add(this.textBox_idReserva);
            this.groupBox1.Controls.Add(this.label_idReserva);
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.comboBox_FormaDePago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_FechaDesde);
            this.groupBox1.Controls.Add(this.label_Huesped);
            this.groupBox1.Controls.Add(this.textBox_Huesped);
            this.groupBox1.Controls.Add(this.textBox_idEstadia);
            this.groupBox1.Controls.Add(this.label_idEstadia);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturacion";
            // 
            // button_CheckReserva
            // 
            this.button_CheckReserva.Location = new System.Drawing.Point(187, 26);
            this.button_CheckReserva.Name = "button_CheckReserva";
            this.button_CheckReserva.Size = new System.Drawing.Size(50, 23);
            this.button_CheckReserva.TabIndex = 19;
            this.button_CheckReserva.Text = "Check";
            this.button_CheckReserva.UseVisualStyleBackColor = true;
            this.button_CheckReserva.Click += new System.EventHandler(this.button_CheckReserva_Click);
            // 
            // Box_FechaHasta
            // 
            this.Box_FechaHasta.Enabled = false;
            this.Box_FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Box_FechaHasta.Location = new System.Drawing.Point(299, 80);
            this.Box_FechaHasta.Name = "Box_FechaHasta";
            this.Box_FechaHasta.Size = new System.Drawing.Size(89, 20);
            this.Box_FechaHasta.TabIndex = 18;
            // 
            // box_FechaDesde
            // 
            this.box_FechaDesde.Enabled = false;
            this.box_FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.box_FechaDesde.Location = new System.Drawing.Point(92, 81);
            this.box_FechaDesde.Name = "box_FechaDesde";
            this.box_FechaDesde.Size = new System.Drawing.Size(89, 20);
            this.box_FechaDesde.TabIndex = 17;
            // 
            // label_FechaHasta
            // 
            this.label_FechaHasta.AutoSize = true;
            this.label_FechaHasta.Location = new System.Drawing.Point(225, 86);
            this.label_FechaHasta.Name = "label_FechaHasta";
            this.label_FechaHasta.Size = new System.Drawing.Size(68, 13);
            this.label_FechaHasta.TabIndex = 16;
            this.label_FechaHasta.Text = "Fecha Hasta";
            // 
            // textBox_idReserva
            // 
            this.textBox_idReserva.Location = new System.Drawing.Point(92, 26);
            this.textBox_idReserva.Name = "textBox_idReserva";
            this.textBox_idReserva.Size = new System.Drawing.Size(89, 20);
            this.textBox_idReserva.TabIndex = 1;
            // 
            // label_idReserva
            // 
            this.label_idReserva.AutoSize = true;
            this.label_idReserva.Location = new System.Drawing.Point(7, 29);
            this.label_idReserva.Name = "label_idReserva";
            this.label_idReserva.Size = new System.Drawing.Size(55, 13);
            this.label_idReserva.TabIndex = 14;
            this.label_idReserva.Text = "idReserva";
            // 
            // button_Clean
            // 
            this.button_Clean.Location = new System.Drawing.Point(299, 194);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 4;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(299, 129);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "Facturar";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox_FormaDePago
            // 
            this.comboBox_FormaDePago.FormattingEnabled = true;
            this.comboBox_FormaDePago.Location = new System.Drawing.Point(92, 191);
            this.comboBox_FormaDePago.Name = "comboBox_FormaDePago";
            this.comboBox_FormaDePago.Size = new System.Drawing.Size(145, 21);
            this.comboBox_FormaDePago.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Forma de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_FechaDesde
            // 
            this.label_FechaDesde.AutoSize = true;
            this.label_FechaDesde.Location = new System.Drawing.Point(7, 87);
            this.label_FechaDesde.Name = "label_FechaDesde";
            this.label_FechaDesde.Size = new System.Drawing.Size(71, 13);
            this.label_FechaDesde.TabIndex = 9;
            this.label_FechaDesde.Text = "Fecha Desde";
            // 
            // label_Huesped
            // 
            this.label_Huesped.AutoSize = true;
            this.label_Huesped.Location = new System.Drawing.Point(7, 139);
            this.label_Huesped.Name = "label_Huesped";
            this.label_Huesped.Size = new System.Drawing.Size(50, 13);
            this.label_Huesped.TabIndex = 5;
            this.label_Huesped.Text = "Huesped";
            // 
            // textBox_Huesped
            // 
            this.textBox_Huesped.Enabled = false;
            this.textBox_Huesped.Location = new System.Drawing.Point(92, 136);
            this.textBox_Huesped.Name = "textBox_Huesped";
            this.textBox_Huesped.Size = new System.Drawing.Size(145, 20);
            this.textBox_Huesped.TabIndex = 4;
            // 
            // textBox_idEstadia
            // 
            this.textBox_idEstadia.Enabled = false;
            this.textBox_idEstadia.Location = new System.Drawing.Point(299, 26);
            this.textBox_idEstadia.Name = "textBox_idEstadia";
            this.textBox_idEstadia.Size = new System.Drawing.Size(89, 20);
            this.textBox_idEstadia.TabIndex = 2;
            // 
            // label_idEstadia
            // 
            this.label_idEstadia.AutoSize = true;
            this.label_idEstadia.Location = new System.Drawing.Point(243, 29);
            this.label_idEstadia.Name = "label_idEstadia";
            this.label_idEstadia.Size = new System.Drawing.Size(50, 13);
            this.label_idEstadia.TabIndex = 1;
            this.label_idEstadia.Text = "idEstadia";
            // 
            // dataGrid_ItemFactura
            // 
            this.dataGrid_ItemFactura.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_ItemFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ItemFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ItemFactura.Location = new System.Drawing.Point(12, 297);
            this.dataGrid_ItemFactura.Name = "dataGrid_ItemFactura";
            this.dataGrid_ItemFactura.RowHeadersVisible = false;
            this.dataGrid_ItemFactura.Size = new System.Drawing.Size(410, 253);
            this.dataGrid_ItemFactura.TabIndex = 20;
            // 
            // textBox_FacturaNro
            // 
            this.textBox_FacturaNro.Enabled = false;
            this.textBox_FacturaNro.Location = new System.Drawing.Point(105, 271);
            this.textBox_FacturaNro.Name = "textBox_FacturaNro";
            this.textBox_FacturaNro.Size = new System.Drawing.Size(89, 20);
            this.textBox_FacturaNro.TabIndex = 22;
            // 
            // label_FacturaNro
            // 
            this.label_FacturaNro.AutoSize = true;
            this.label_FacturaNro.Location = new System.Drawing.Point(20, 274);
            this.label_FacturaNro.Name = "label_FacturaNro";
            this.label_FacturaNro.Size = new System.Drawing.Size(43, 13);
            this.label_FacturaNro.TabIndex = 21;
            this.label_FacturaNro.Text = "Factura";
            // 
            // textBox_Total
            // 
            this.textBox_Total.Enabled = false;
            this.textBox_Total.Location = new System.Drawing.Point(312, 271);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.Size = new System.Drawing.Size(89, 20);
            this.textBox_Total.TabIndex = 24;
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Location = new System.Drawing.Point(256, 274);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(31, 13);
            this.label_Total.TabIndex = 23;
            this.label_Total.Text = "Total";
            // 
            // Factura_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 562);
            this.Controls.Add(this.textBox_Total);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.textBox_FacturaNro);
            this.Controls.Add(this.label_FacturaNro);
            this.Controls.Add(this.dataGrid_ItemFactura);
            this.Controls.Add(this.groupBox1);
            this.Name = "Factura_Form";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.Factura_Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Factura_Form_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_idEstadia;
        private System.Windows.Forms.ComboBox comboBox_FormaDePago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_FechaDesde;
        private System.Windows.Forms.Label label_Huesped;
        private System.Windows.Forms.TextBox textBox_Huesped;
        private System.Windows.Forms.TextBox textBox_idEstadia;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGrid_ItemFactura;
        private System.Windows.Forms.TextBox textBox_FacturaNro;
        private System.Windows.Forms.Label label_FacturaNro;
        private System.Windows.Forms.TextBox textBox_Total;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.DateTimePicker Box_FechaHasta;
        private System.Windows.Forms.DateTimePicker box_FechaDesde;
        private System.Windows.Forms.Label label_FechaHasta;
        private System.Windows.Forms.TextBox textBox_idReserva;
        private System.Windows.Forms.Label label_idReserva;
        private System.Windows.Forms.Button button_CheckReserva;
    }
}