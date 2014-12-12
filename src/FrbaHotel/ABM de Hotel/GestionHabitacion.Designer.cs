namespace FrbaHotel.ABM_de_Hotel
{
    partial class GestionHabitacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionHabitacion));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumHabitacion = new System.Windows.Forms.TextBox();
            this.cbUbicacionHab = new System.Windows.Forms.ComboBox();
            this.tbDescHabitacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPisoHabitacion = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblHotel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Piso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número";
            // 
            // tbNumHabitacion
            // 
            this.tbNumHabitacion.Location = new System.Drawing.Point(106, 50);
            this.tbNumHabitacion.Name = "tbNumHabitacion";
            this.tbNumHabitacion.ShortcutsEnabled = false;
            this.tbNumHabitacion.Size = new System.Drawing.Size(100, 20);
            this.tbNumHabitacion.TabIndex = 2;
            this.tbNumHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbdigits_KeyPress);
            // 
            // cbUbicacionHab
            // 
            this.cbUbicacionHab.FormattingEnabled = true;
            this.cbUbicacionHab.Items.AddRange(new object[] {
            "Contrafrente",
            "Frente"});
            this.cbUbicacionHab.Location = new System.Drawing.Point(448, 50);
            this.cbUbicacionHab.Name = "cbUbicacionHab";
            this.cbUbicacionHab.Size = new System.Drawing.Size(100, 21);
            this.cbUbicacionHab.TabIndex = 7;
            // 
            // tbDescHabitacion
            // 
            this.tbDescHabitacion.Location = new System.Drawing.Point(281, 76);
            this.tbDescHabitacion.Name = "tbDescHabitacion";
            this.tbDescHabitacion.Size = new System.Drawing.Size(267, 20);
            this.tbDescHabitacion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ubicacion";
            // 
            // tbPisoHabitacion
            // 
            this.tbPisoHabitacion.Location = new System.Drawing.Point(281, 50);
            this.tbPisoHabitacion.Name = "tbPisoHabitacion";
            this.tbPisoHabitacion.Size = new System.Drawing.Size(100, 20);
            this.tbPisoHabitacion.TabIndex = 8;
            this.tbPisoHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbdigits_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(595, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 31);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Transparent;
            this.btnAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccept.BackgroundImage")));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAccept.Location = new System.Drawing.Point(561, 97);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(30, 31);
            this.btnAccept.TabIndex = 34;
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblHotel
            // 
            this.lblHotel.AutoSize = true;
            this.lblHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHotel.Location = new System.Drawing.Point(12, 9);
            this.lblHotel.Name = "lblHotel";
            this.lblHotel.Size = new System.Drawing.Size(183, 25);
            this.lblHotel.TabIndex = 36;
            this.lblHotel.Text = "Hotel - Habitacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tipo";
            // 
            // cbTipoHabitacion
            // 
            this.cbTipoHabitacion.FormattingEnabled = true;
            this.cbTipoHabitacion.Items.AddRange(new object[] {
            "Contrafrente",
            "Frente"});
            this.cbTipoHabitacion.Location = new System.Drawing.Point(106, 76);
            this.cbTipoHabitacion.Name = "cbTipoHabitacion";
            this.cbTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.cbTipoHabitacion.TabIndex = 38;
            // 
            // GestionHabitacion
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 137);
            this.Controls.Add(this.cbTipoHabitacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblHotel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tbPisoHabitacion);
            this.Controls.Add(this.cbUbicacionHab);
            this.Controls.Add(this.tbDescHabitacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNumHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestionHabitacion";
            this.Text = "Gestion de habitacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GestionHabitacion_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumHabitacion;
        private System.Windows.Forms.ComboBox cbUbicacionHab;
        private System.Windows.Forms.TextBox tbDescHabitacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPisoHabitacion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblHotel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipoHabitacion;
    }
}