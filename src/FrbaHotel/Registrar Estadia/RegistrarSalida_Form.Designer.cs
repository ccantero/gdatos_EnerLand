namespace FrbaHotel.Registrar_Estadia
{
    partial class RegistrarSalida_Form
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
            this.box_FechaEgreso = new System.Windows.Forms.DateTimePicker();
            this.textBox_idReserva = new System.Windows.Forms.TextBox();
            this.label_idReserva = new System.Windows.Forms.Label();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_FechaIngreso = new System.Windows.Forms.Label();
            this.label_Huesped = new System.Windows.Forms.Label();
            this.textBox_Huesped = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.box_FechaEgreso);
            this.groupBox1.Controls.Add(this.textBox_idReserva);
            this.groupBox1.Controls.Add(this.label_idReserva);
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.label_FechaIngreso);
            this.groupBox1.Controls.Add(this.label_Huesped);
            this.groupBox1.Controls.Add(this.textBox_Huesped);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check-Out";
            // 
            // box_FechaEgreso
            // 
            this.box_FechaEgreso.Enabled = false;
            this.box_FechaEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.box_FechaEgreso.Location = new System.Drawing.Point(149, 45);
            this.box_FechaEgreso.Name = "box_FechaEgreso";
            this.box_FechaEgreso.Size = new System.Drawing.Size(89, 20);
            this.box_FechaEgreso.TabIndex = 17;
            // 
            // textBox_idReserva
            // 
            this.textBox_idReserva.Location = new System.Drawing.Point(15, 45);
            this.textBox_idReserva.Name = "textBox_idReserva";
            this.textBox_idReserva.Size = new System.Drawing.Size(89, 20);
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
            this.button_Clean.Location = new System.Drawing.Point(149, 138);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 13;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(29, 138);
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
            this.label_FechaIngreso.Size = new System.Drawing.Size(73, 13);
            this.label_FechaIngreso.TabIndex = 9;
            this.label_FechaIngreso.Text = "Fecha Egreso";
            // 
            // label_Huesped
            // 
            this.label_Huesped.AutoSize = true;
            this.label_Huesped.Location = new System.Drawing.Point(12, 84);
            this.label_Huesped.Name = "label_Huesped";
            this.label_Huesped.Size = new System.Drawing.Size(50, 13);
            this.label_Huesped.TabIndex = 5;
            this.label_Huesped.Text = "Huesped";
            // 
            // textBox_Huesped
            // 
            this.textBox_Huesped.Enabled = false;
            this.textBox_Huesped.Location = new System.Drawing.Point(15, 100);
            this.textBox_Huesped.Name = "textBox_Huesped";
            this.textBox_Huesped.Size = new System.Drawing.Size(223, 20);
            this.textBox_Huesped.TabIndex = 4;
            // 
            // RegistrarSalida_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 198);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarSalida_Form";
            this.Text = "Registrar Check-Out";
            this.Load += new System.EventHandler(this.RegistrarSalida_Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrarSalida_Form_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker box_FechaEgreso;
        private System.Windows.Forms.TextBox textBox_idReserva;
        private System.Windows.Forms.Label label_idReserva;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_FechaIngreso;
        private System.Windows.Forms.Label label_Huesped;
        private System.Windows.Forms.TextBox textBox_Huesped;
    }
}