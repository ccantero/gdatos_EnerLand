namespace FrbaHotel.ABM_de_Hotel
{
    partial class BajaHabitacion
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
            this.dtpFechaInicioDeshabilitado = new System.Windows.Forms.DateTimePicker();
            this.udDiasDeshabilitados = new System.Windows.Forms.NumericUpDown();
            this.tbMotivo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.lbDiasDeshabilitado = new System.Windows.Forms.Label();
            this.lbMotivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udDiasDeshabilitados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaInicioDeshabilitado
            // 
            this.dtpFechaInicioDeshabilitado.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaInicioDeshabilitado.Location = new System.Drawing.Point(125, 32);
            this.dtpFechaInicioDeshabilitado.Name = "dtpFechaInicioDeshabilitado";
            this.dtpFechaInicioDeshabilitado.Size = new System.Drawing.Size(152, 20);
            this.dtpFechaInicioDeshabilitado.TabIndex = 0;
            this.dtpFechaInicioDeshabilitado.Value = new System.DateTime(2014, 12, 11, 22, 20, 53, 0);
            // 
            // udDiasDeshabilitados
            // 
            this.udDiasDeshabilitados.Location = new System.Drawing.Point(125, 59);
            this.udDiasDeshabilitados.Name = "udDiasDeshabilitados";
            this.udDiasDeshabilitados.Size = new System.Drawing.Size(152, 20);
            this.udDiasDeshabilitados.TabIndex = 1;
            // 
            // tbMotivo
            // 
            this.tbMotivo.Location = new System.Drawing.Point(125, 85);
            this.tbMotivo.MaxLength = 50;
            this.tbMotivo.Name = "tbMotivo";
            this.tbMotivo.Size = new System.Drawing.Size(152, 20);
            this.tbMotivo.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(201, 120);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Location = new System.Drawing.Point(13, 32);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(64, 13);
            this.lbFechaInicio.TabIndex = 4;
            this.lbFechaInicio.Text = "Fecha inicio";
            // 
            // lbDiasDeshabilitado
            // 
            this.lbDiasDeshabilitado.AutoSize = true;
            this.lbDiasDeshabilitado.Location = new System.Drawing.Point(13, 59);
            this.lbDiasDeshabilitado.Name = "lbDiasDeshabilitado";
            this.lbDiasDeshabilitado.Size = new System.Drawing.Size(88, 13);
            this.lbDiasDeshabilitado.TabIndex = 5;
            this.lbDiasDeshabilitado.Text = "Cantidad de días";
            // 
            // lbMotivo
            // 
            this.lbMotivo.AutoSize = true;
            this.lbMotivo.Location = new System.Drawing.Point(13, 85);
            this.lbMotivo.Name = "lbMotivo";
            this.lbMotivo.Size = new System.Drawing.Size(39, 13);
            this.lbMotivo.TabIndex = 6;
            this.lbMotivo.Text = "Motivo";
            // 
            // BajaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 155);
            this.Controls.Add(this.lbMotivo);
            this.Controls.Add(this.lbDiasDeshabilitado);
            this.Controls.Add(this.lbFechaInicio);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbMotivo);
            this.Controls.Add(this.udDiasDeshabilitados);
            this.Controls.Add(this.dtpFechaInicioDeshabilitado);
            this.Name = "BajaHabitacion";
            this.Text = "BajaHabitacion";
            this.Load += new System.EventHandler(this.BajaHotel_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BajaHotel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.udDiasDeshabilitados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicioDeshabilitado;
        private System.Windows.Forms.NumericUpDown udDiasDeshabilitados;
        private System.Windows.Forms.TextBox tbMotivo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lbFechaInicio;
        private System.Windows.Forms.Label lbDiasDeshabilitado;
        private System.Windows.Forms.Label lbMotivo;
    }
}