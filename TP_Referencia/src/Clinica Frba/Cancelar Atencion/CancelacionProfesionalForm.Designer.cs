namespace Clinica_Frba.Cancelar_Atencion_Profesional
{
    partial class CancelacionProfesionalForm
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
            this.button_save = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.Box_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label_FechaHasta = new System.Windows.Forms.Label();
            this.box_fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label_fechaDesde = new System.Windows.Forms.Label();
            this.box_fecha = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.box_tipoCancelacion = new System.Windows.Forms.ComboBox();
            this.button_select = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.box_profesional = new System.Windows.Forms.TextBox();
            this.label_Profesional = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Controls.Add(this.button_clean);
            this.groupBox1.Controls.Add(this.Box_FechaHasta);
            this.groupBox1.Controls.Add(this.label_FechaHasta);
            this.groupBox1.Controls.Add(this.box_fechaDesde);
            this.groupBox1.Controls.Add(this.label_fechaDesde);
            this.groupBox1.Controls.Add(this.box_fecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.box_descripcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.box_tipoCancelacion);
            this.groupBox1.Controls.Add(this.button_select);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.box_profesional);
            this.groupBox1.Controls.Add(this.label_Profesional);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a completar";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(340, 362);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 15;
            this.button_save.Text = "Guardar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(66, 362);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 14;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // Box_FechaHasta
            // 
            this.Box_FechaHasta.Location = new System.Drawing.Point(151, 307);
            this.Box_FechaHasta.Name = "Box_FechaHasta";
            this.Box_FechaHasta.Size = new System.Drawing.Size(200, 20);
            this.Box_FechaHasta.TabIndex = 13;
            // 
            // label_FechaHasta
            // 
            this.label_FechaHasta.AutoSize = true;
            this.label_FechaHasta.Location = new System.Drawing.Point(6, 314);
            this.label_FechaHasta.Name = "label_FechaHasta";
            this.label_FechaHasta.Size = new System.Drawing.Size(68, 13);
            this.label_FechaHasta.TabIndex = 12;
            this.label_FechaHasta.Text = "Fecha Hasta";
            // 
            // box_fechaDesde
            // 
            this.box_fechaDesde.Location = new System.Drawing.Point(151, 252);
            this.box_fechaDesde.Name = "box_fechaDesde";
            this.box_fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.box_fechaDesde.TabIndex = 11;
            // 
            // label_fechaDesde
            // 
            this.label_fechaDesde.AutoSize = true;
            this.label_fechaDesde.Location = new System.Drawing.Point(6, 258);
            this.label_fechaDesde.Name = "label_fechaDesde";
            this.label_fechaDesde.Size = new System.Drawing.Size(71, 13);
            this.label_fechaDesde.TabIndex = 10;
            this.label_fechaDesde.Text = "Fecha Desde";
            // 
            // box_fecha
            // 
            this.box_fecha.FormattingEnabled = true;
            this.box_fecha.Location = new System.Drawing.Point(149, 196);
            this.box_fecha.Name = "box_fecha";
            this.box_fecha.Size = new System.Drawing.Size(200, 21);
            this.box_fecha.TabIndex = 9;
            this.box_fecha.SelectedIndexChanged += new System.EventHandler(this.box_fecha_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cancelar Turno";
            // 
            // box_descripcion
            // 
            this.box_descripcion.Location = new System.Drawing.Point(149, 141);
            this.box_descripcion.Name = "box_descripcion";
            this.box_descripcion.Size = new System.Drawing.Size(202, 20);
            this.box_descripcion.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripcion";
            // 
            // box_tipoCancelacion
            // 
            this.box_tipoCancelacion.FormattingEnabled = true;
            this.box_tipoCancelacion.Location = new System.Drawing.Point(149, 85);
            this.box_tipoCancelacion.Name = "box_tipoCancelacion";
            this.box_tipoCancelacion.Size = new System.Drawing.Size(202, 21);
            this.box_tipoCancelacion.TabIndex = 4;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(383, 28);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 3;
            this.button_select.Text = "Buscar";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 88);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(105, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Tipo de Cancelacion";
            // 
            // box_profesional
            // 
            this.box_profesional.Location = new System.Drawing.Point(149, 30);
            this.box_profesional.Name = "box_profesional";
            this.box_profesional.ReadOnly = true;
            this.box_profesional.Size = new System.Drawing.Size(202, 20);
            this.box_profesional.TabIndex = 1;
            // 
            // label_Profesional
            // 
            this.label_Profesional.AutoSize = true;
            this.label_Profesional.Location = new System.Drawing.Point(6, 33);
            this.label_Profesional.Name = "label_Profesional";
            this.label_Profesional.Size = new System.Drawing.Size(59, 13);
            this.label_Profesional.TabIndex = 0;
            this.label_Profesional.Text = "Profesional";
            // 
            // CancelacionProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 444);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelacionProfesionalForm";
            this.Text = "Cancelacion de Turnos";
            this.Load += new System.EventHandler(this.CancelacionProfesionalForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(CancelacionProfesionalForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox box_profesional;
        private System.Windows.Forms.Label label_Profesional;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.ComboBox box_tipoCancelacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box_descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox box_fecha;
        private System.Windows.Forms.DateTimePicker box_fechaDesde;
        private System.Windows.Forms.Label label_fechaDesde;
        private System.Windows.Forms.Label label_FechaHasta;
        private System.Windows.Forms.DateTimePicker Box_FechaHasta;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_clean;
    }
}