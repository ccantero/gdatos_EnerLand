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
            this.label_Estadia = new System.Windows.Forms.Label();
            this.textBox_idEstadia = new System.Windows.Forms.TextBox();
            this.textBox_Huesped = new System.Windows.Forms.TextBox();
            this.label_Huesped = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.box_FechaFactura = new System.Windows.Forms.DateTimePicker();
            this.label_Fecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_FormaDePago = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clean = new System.Windows.Forms.Button();
            this.dataGrid_ItemFactura = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label_FacturaNro = new System.Windows.Forms.Label();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label_Total = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.comboBox_FormaDePago);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_Fecha);
            this.groupBox1.Controls.Add(this.box_FechaFactura);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Controls.Add(this.label_Huesped);
            this.groupBox1.Controls.Add(this.textBox_Huesped);
            this.groupBox1.Controls.Add(this.textBox_idEstadia);
            this.groupBox1.Controls.Add(this.label_Estadia);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturacion";
            // 
            // label_Estadia
            // 
            this.label_Estadia.AutoSize = true;
            this.label_Estadia.Location = new System.Drawing.Point(7, 33);
            this.label_Estadia.Name = "label_Estadia";
            this.label_Estadia.Size = new System.Drawing.Size(50, 13);
            this.label_Estadia.TabIndex = 1;
            this.label_Estadia.Text = "idEstadia";
            // 
            // textBox_idEstadia
            // 
            this.textBox_idEstadia.Location = new System.Drawing.Point(92, 30);
            this.textBox_idEstadia.Name = "textBox_idEstadia";
            this.textBox_idEstadia.Size = new System.Drawing.Size(215, 20);
            this.textBox_idEstadia.TabIndex = 2;
            // 
            // textBox_Huesped
            // 
            this.textBox_Huesped.Location = new System.Drawing.Point(92, 73);
            this.textBox_Huesped.Name = "textBox_Huesped";
            this.textBox_Huesped.Size = new System.Drawing.Size(215, 20);
            this.textBox_Huesped.TabIndex = 4;
            // 
            // label_Huesped
            // 
            this.label_Huesped.AutoSize = true;
            this.label_Huesped.Location = new System.Drawing.Point(7, 76);
            this.label_Huesped.Name = "label_Huesped";
            this.label_Huesped.Size = new System.Drawing.Size(50, 13);
            this.label_Huesped.TabIndex = 5;
            this.label_Huesped.Text = "Huesped";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(328, 70);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 6;
            this.button_Search.Text = "Buscar";
            this.button_Search.UseVisualStyleBackColor = true;
            // 
            // box_FechaFactura
            // 
            this.box_FechaFactura.Location = new System.Drawing.Point(92, 112);
            this.box_FechaFactura.Name = "box_FechaFactura";
            this.box_FechaFactura.Size = new System.Drawing.Size(215, 20);
            this.box_FechaFactura.TabIndex = 8;
            // 
            // label_Fecha
            // 
            this.label_Fecha.AutoSize = true;
            this.label_Fecha.Location = new System.Drawing.Point(7, 118);
            this.label_Fecha.Name = "label_Fecha";
            this.label_Fecha.Size = new System.Drawing.Size(37, 13);
            this.label_Fecha.TabIndex = 9;
            this.label_Fecha.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Forma de Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox_FormaDePago
            // 
            this.comboBox_FormaDePago.FormattingEnabled = true;
            this.comboBox_FormaDePago.Location = new System.Drawing.Point(92, 151);
            this.comboBox_FormaDePago.Name = "comboBox_FormaDePago";
            this.comboBox_FormaDePago.Size = new System.Drawing.Size(215, 21);
            this.comboBox_FormaDePago.TabIndex = 11;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(43, 198);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Facturar";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Clean
            // 
            this.button_Clean.Location = new System.Drawing.Point(232, 198);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 13;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            // 
            // dataGrid_ItemFactura
            // 
            //this.dataGrid_ItemFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_ItemFactura.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_ItemFactura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_ItemFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ItemFactura.Location = new System.Drawing.Point(12, 285);
            this.dataGrid_ItemFactura.Name = "dataGrid_ItemFactura";
            this.dataGrid_ItemFactura.RowHeadersVisible = false;
            this.dataGrid_ItemFactura.Size = new System.Drawing.Size(410, 265);
            this.dataGrid_ItemFactura.TabIndex = 20;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 256);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(89, 20);
            this.textBox3.TabIndex = 22;
            // 
            // label_FacturaNro
            // 
            this.label_FacturaNro.AutoSize = true;
            this.label_FacturaNro.Location = new System.Drawing.Point(20, 259);
            this.label_FacturaNro.Name = "label_FacturaNro";
            this.label_FacturaNro.Size = new System.Drawing.Size(43, 13);
            this.label_FacturaNro.TabIndex = 21;
            this.label_FacturaNro.Text = "Factura";
            // 
            // textBox_Total
            // 
            this.textBox_Total.Location = new System.Drawing.Point(327, 259);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.Size = new System.Drawing.Size(89, 20);
            this.textBox_Total.TabIndex = 24;
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Location = new System.Drawing.Point(242, 262);
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
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label_FacturaNro);
            this.Controls.Add(this.dataGrid_ItemFactura);
            this.Controls.Add(this.groupBox1);
            this.Name = "Factura_Form";
            this.Text = "Facturacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ItemFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Estadia;
        private System.Windows.Forms.ComboBox comboBox_FormaDePago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Fecha;
        private System.Windows.Forms.DateTimePicker box_FechaFactura;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label_Huesped;
        private System.Windows.Forms.TextBox textBox_Huesped;
        private System.Windows.Forms.TextBox textBox_idEstadia;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGrid_ItemFactura;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label_FacturaNro;
        private System.Windows.Forms.TextBox textBox_Total;
        private System.Windows.Forms.Label label_Total;
    }
}