namespace FrbaHotel.Registrar_Consumible
{
    partial class RegistroConsumible_Form
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
            this.dataGrid_Consumibles = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Box_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.label_Cantidad = new System.Windows.Forms.Label();
            this.textBox_Regimen = new System.Windows.Forms.TextBox();
            this.label_Regimen = new System.Windows.Forms.Label();
            this.button_CheckReserva = new System.Windows.Forms.Button();
            this.textBox_idReserva = new System.Windows.Forms.TextBox();
            this.label_idReserva = new System.Windows.Forms.Label();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.comboBox_Consumible = new System.Windows.Forms.ComboBox();
            this.label_Consumible = new System.Windows.Forms.Label();
            this.label_Huesped = new System.Windows.Forms.Label();
            this.textBox_Huesped = new System.Windows.Forms.TextBox();
            this.textBox_idEstadia = new System.Windows.Forms.TextBox();
            this.label_idEstadia = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Consumibles)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_Consumibles
            // 
            this.dataGrid_Consumibles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_Consumibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_Consumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Consumibles.Location = new System.Drawing.Point(12, 291);
            this.dataGrid_Consumibles.Name = "dataGrid_Consumibles";
            this.dataGrid_Consumibles.RowHeadersVisible = false;
            this.dataGrid_Consumibles.Size = new System.Drawing.Size(410, 259);
            this.dataGrid_Consumibles.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_Total);
            this.groupBox1.Controls.Add(this.textBox_Total);
            this.groupBox1.Controls.Add(this.Box_Cantidad);
            this.groupBox1.Controls.Add(this.label_Cantidad);
            this.groupBox1.Controls.Add(this.textBox_Regimen);
            this.groupBox1.Controls.Add(this.label_Regimen);
            this.groupBox1.Controls.Add(this.button_CheckReserva);
            this.groupBox1.Controls.Add(this.textBox_idReserva);
            this.groupBox1.Controls.Add(this.label_idReserva);
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.comboBox_Consumible);
            this.groupBox1.Controls.Add(this.label_Consumible);
            this.groupBox1.Controls.Add(this.label_Huesped);
            this.groupBox1.Controls.Add(this.textBox_Huesped);
            this.groupBox1.Controls.Add(this.textBox_idEstadia);
            this.groupBox1.Controls.Add(this.label_idEstadia);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 272);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // Box_Cantidad
            // 
            this.Box_Cantidad.Location = new System.Drawing.Point(299, 139);
            this.Box_Cantidad.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Box_Cantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Box_Cantidad.Name = "Box_Cantidad";
            this.Box_Cantidad.Size = new System.Drawing.Size(89, 20);
            this.Box_Cantidad.TabIndex = 4;
            this.Box_Cantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Box_Cantidad.ValueChanged += new System.EventHandler(this.Box_Cantidad_ValueChanged);
            // 
            // label_Cantidad
            // 
            this.label_Cantidad.AutoSize = true;
            this.label_Cantidad.Location = new System.Drawing.Point(243, 139);
            this.label_Cantidad.Name = "label_Cantidad";
            this.label_Cantidad.Size = new System.Drawing.Size(49, 13);
            this.label_Cantidad.TabIndex = 22;
            this.label_Cantidad.Text = "Cantidad";
            // 
            // textBox_Regimen
            // 
            this.textBox_Regimen.Enabled = false;
            this.textBox_Regimen.Location = new System.Drawing.Point(299, 81);
            this.textBox_Regimen.Name = "textBox_Regimen";
            this.textBox_Regimen.Size = new System.Drawing.Size(89, 20);
            this.textBox_Regimen.TabIndex = 21;
            // 
            // label_Regimen
            // 
            this.label_Regimen.AutoSize = true;
            this.label_Regimen.Location = new System.Drawing.Point(243, 84);
            this.label_Regimen.Name = "label_Regimen";
            this.label_Regimen.Size = new System.Drawing.Size(49, 13);
            this.label_Regimen.TabIndex = 20;
            this.label_Regimen.Text = "Regimen";
            // 
            // button_CheckReserva
            // 
            this.button_CheckReserva.Location = new System.Drawing.Point(173, 26);
            this.button_CheckReserva.Name = "button_CheckReserva";
            this.button_CheckReserva.Size = new System.Drawing.Size(50, 23);
            this.button_CheckReserva.TabIndex = 2;
            this.button_CheckReserva.Text = "Check";
            this.button_CheckReserva.UseVisualStyleBackColor = true;
            this.button_CheckReserva.Click += new System.EventHandler(this.button_CheckReserva_Click);
            // 
            // textBox_idReserva
            // 
            this.textBox_idReserva.Location = new System.Drawing.Point(74, 26);
            this.textBox_idReserva.Name = "textBox_idReserva";
            this.textBox_idReserva.Size = new System.Drawing.Size(93, 20);
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
            this.button_Clean.Location = new System.Drawing.Point(246, 233);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 6;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(92, 233);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Registrar";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox_Consumible
            // 
            this.comboBox_Consumible.FormattingEnabled = true;
            this.comboBox_Consumible.Location = new System.Drawing.Point(74, 136);
            this.comboBox_Consumible.Name = "comboBox_Consumible";
            this.comboBox_Consumible.Size = new System.Drawing.Size(145, 21);
            this.comboBox_Consumible.TabIndex = 3;
            this.comboBox_Consumible.SelectedIndexChanged += new System.EventHandler(this.comboBox_Consumible_SelectedIndexChanged);
            // 
            // label_Consumible
            // 
            this.label_Consumible.AutoSize = true;
            this.label_Consumible.Location = new System.Drawing.Point(7, 139);
            this.label_Consumible.Name = "label_Consumible";
            this.label_Consumible.Size = new System.Drawing.Size(61, 13);
            this.label_Consumible.TabIndex = 10;
            this.label_Consumible.Text = "Consumible";
            this.label_Consumible.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Huesped
            // 
            this.label_Huesped.AutoSize = true;
            this.label_Huesped.Location = new System.Drawing.Point(7, 84);
            this.label_Huesped.Name = "label_Huesped";
            this.label_Huesped.Size = new System.Drawing.Size(50, 13);
            this.label_Huesped.TabIndex = 5;
            this.label_Huesped.Text = "Huesped";
            // 
            // textBox_Huesped
            // 
            this.textBox_Huesped.Enabled = false;
            this.textBox_Huesped.Location = new System.Drawing.Point(74, 81);
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
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Location = new System.Drawing.Point(7, 195);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(31, 13);
            this.label_Total.TabIndex = 26;
            this.label_Total.Text = "Total";
            // 
            // textBox_Total
            // 
            this.textBox_Total.Enabled = false;
            this.textBox_Total.Location = new System.Drawing.Point(74, 192);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.Size = new System.Drawing.Size(145, 20);
            this.textBox_Total.TabIndex = 25;
            // 
            // RegistroConsumible_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 562);
            this.Controls.Add(this.dataGrid_Consumibles);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistroConsumible_Form";
            this.Text = "Registro de Consumibles";
            this.Load += new System.EventHandler(this.RegistroConsumible_Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistroConsumible_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Consumibles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Cantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_Consumibles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_CheckReserva;
        private System.Windows.Forms.TextBox textBox_idReserva;
        private System.Windows.Forms.Label label_idReserva;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ComboBox comboBox_Consumible;
        private System.Windows.Forms.Label label_Consumible;
        private System.Windows.Forms.Label label_Huesped;
        private System.Windows.Forms.TextBox textBox_Huesped;
        private System.Windows.Forms.TextBox textBox_idEstadia;
        private System.Windows.Forms.Label label_idEstadia;
        private System.Windows.Forms.NumericUpDown Box_Cantidad;
        private System.Windows.Forms.Label label_Cantidad;
        private System.Windows.Forms.TextBox textBox_Regimen;
        private System.Windows.Forms.Label label_Regimen;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.TextBox textBox_Total;
    }
}