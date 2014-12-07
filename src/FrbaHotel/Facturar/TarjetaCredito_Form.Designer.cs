namespace FrbaHotel.Facturar
{
    partial class TarjetaCredito_Form
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
            this.textBox_NroTarjeta = new System.Windows.Forms.TextBox();
            this.label_NroTarjeta = new System.Windows.Forms.Label();
            this.label_Vencimiento = new System.Windows.Forms.Label();
            this.comboBox_MesVencimiento = new System.Windows.Forms.ComboBox();
            this.comboBox_AnioVencimiento = new System.Windows.Forms.ComboBox();
            this.textBox_CodSeguridad = new System.Windows.Forms.TextBox();
            this.label_CodSeguridad = new System.Windows.Forms.Label();
            this.textBox_Titular = new System.Windows.Forms.TextBox();
            this.label_Titular = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.button_Cancel);
            this.groupBox1.Controls.Add(this.label_Titular);
            this.groupBox1.Controls.Add(this.textBox_Titular);
            this.groupBox1.Controls.Add(this.label_CodSeguridad);
            this.groupBox1.Controls.Add(this.textBox_CodSeguridad);
            this.groupBox1.Controls.Add(this.comboBox_AnioVencimiento);
            this.groupBox1.Controls.Add(this.comboBox_MesVencimiento);
            this.groupBox1.Controls.Add(this.label_Vencimiento);
            this.groupBox1.Controls.Add(this.label_NroTarjeta);
            this.groupBox1.Controls.Add(this.textBox_NroTarjeta);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a completar";
            // 
            // textBox_NroTarjeta
            // 
            this.textBox_NroTarjeta.Location = new System.Drawing.Point(6, 117);
            this.textBox_NroTarjeta.Name = "textBox_NroTarjeta";
            this.textBox_NroTarjeta.Size = new System.Drawing.Size(227, 20);
            this.textBox_NroTarjeta.TabIndex = 2;
            // 
            // label_NroTarjeta
            // 
            this.label_NroTarjeta.AutoSize = true;
            this.label_NroTarjeta.Location = new System.Drawing.Point(6, 101);
            this.label_NroTarjeta.Name = "label_NroTarjeta";
            this.label_NroTarjeta.Size = new System.Drawing.Size(91, 13);
            this.label_NroTarjeta.TabIndex = 2;
            this.label_NroTarjeta.Text = "Tarjeta de Credito";
            // 
            // label_Vencimiento
            // 
            this.label_Vencimiento.AutoSize = true;
            this.label_Vencimiento.Location = new System.Drawing.Point(7, 169);
            this.label_Vencimiento.Name = "label_Vencimiento";
            this.label_Vencimiento.Size = new System.Drawing.Size(65, 13);
            this.label_Vencimiento.TabIndex = 4;
            this.label_Vencimiento.Text = "Vencimiento";
            // 
            // comboBox_MesVencimiento
            // 
            this.comboBox_MesVencimiento.FormattingEnabled = true;
            this.comboBox_MesVencimiento.Location = new System.Drawing.Point(6, 187);
            this.comboBox_MesVencimiento.Name = "comboBox_MesVencimiento";
            this.comboBox_MesVencimiento.Size = new System.Drawing.Size(50, 21);
            this.comboBox_MesVencimiento.TabIndex = 3;
            // 
            // comboBox_AnioVencimiento
            // 
            this.comboBox_AnioVencimiento.FormattingEnabled = true;
            this.comboBox_AnioVencimiento.Location = new System.Drawing.Point(66, 187);
            this.comboBox_AnioVencimiento.Name = "comboBox_AnioVencimiento";
            this.comboBox_AnioVencimiento.Size = new System.Drawing.Size(50, 21);
            this.comboBox_AnioVencimiento.TabIndex = 4;
            // 
            // textBox_CodSeguridad
            // 
            this.textBox_CodSeguridad.Location = new System.Drawing.Point(156, 187);
            this.textBox_CodSeguridad.MaxLength = 3;
            this.textBox_CodSeguridad.Name = "textBox_CodSeguridad";
            this.textBox_CodSeguridad.PasswordChar = '#';
            this.textBox_CodSeguridad.Size = new System.Drawing.Size(75, 20);
            this.textBox_CodSeguridad.TabIndex = 5;
            // 
            // label_CodSeguridad
            // 
            this.label_CodSeguridad.AutoSize = true;
            this.label_CodSeguridad.Location = new System.Drawing.Point(153, 171);
            this.label_CodSeguridad.Name = "label_CodSeguridad";
            this.label_CodSeguridad.Size = new System.Drawing.Size(80, 13);
            this.label_CodSeguridad.TabIndex = 8;
            this.label_CodSeguridad.Text = "Cod. Seguridad";
            // 
            // textBox_Titular
            // 
            this.textBox_Titular.Location = new System.Drawing.Point(6, 49);
            this.textBox_Titular.Name = "textBox_Titular";
            this.textBox_Titular.Size = new System.Drawing.Size(227, 20);
            this.textBox_Titular.TabIndex = 1;
            // 
            // label_Titular
            // 
            this.label_Titular.AutoSize = true;
            this.label_Titular.Location = new System.Drawing.Point(7, 33);
            this.label_Titular.Name = "label_Titular";
            this.label_Titular.Size = new System.Drawing.Size(36, 13);
            this.label_Titular.TabIndex = 12;
            this.label_Titular.Text = "Titular";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(156, 244);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "Cancelar";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(22, 244);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Guardar";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // TarjetaCredito_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.groupBox1);
            this.Name = "TarjetaCredito_Form";
            this.Text = "TarjetaCredito_Form";
            this.Load += new System.EventHandler(this.TarjetaCredito_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_NroTarjeta;
        private System.Windows.Forms.TextBox textBox_NroTarjeta;
        private System.Windows.Forms.Label label_CodSeguridad;
        private System.Windows.Forms.TextBox textBox_CodSeguridad;
        private System.Windows.Forms.ComboBox comboBox_AnioVencimiento;
        private System.Windows.Forms.ComboBox comboBox_MesVencimiento;
        private System.Windows.Forms.Label label_Vencimiento;
        private System.Windows.Forms.Label label_Titular;
        private System.Windows.Forms.TextBox textBox_Titular;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;

    }
}