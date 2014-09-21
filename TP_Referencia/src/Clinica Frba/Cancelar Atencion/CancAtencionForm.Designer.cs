namespace Clinica_Frba.CancAtencion
{
    partial class CancAtencionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rolCancelacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoCancelacion = new System.Windows.Forms.ComboBox();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancelación por parte de:";
            // 
            // rolCancelacion
            // 
            this.rolCancelacion.FormattingEnabled = true;
            this.rolCancelacion.Items.AddRange(new object[] {
            "Afiliado",
            "Profesional"});
            this.rolCancelacion.Location = new System.Drawing.Point(160, 13);
            this.rolCancelacion.Name = "rolCancelacion";
            this.rolCancelacion.Size = new System.Drawing.Size(152, 21);
            this.rolCancelacion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Cancelación:";
            // 
            // tipoCancelacion
            // 
            this.tipoCancelacion.FormattingEnabled = true;
            this.tipoCancelacion.Items.AddRange(new object[] {
            "Enfermedad",
            "Accidente",
            "Viaje",
            "Circunstancia Imprevista"});
            this.tipoCancelacion.Location = new System.Drawing.Point(160, 41);
            this.tipoCancelacion.Name = "tipoCancelacion";
            this.tipoCancelacion.Size = new System.Drawing.Size(152, 21);
            this.tipoCancelacion.TabIndex = 3;
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(160, 68);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(599, 20);
            this.descripcion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripción de cancelación:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Siguiente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(684, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CancAtencionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 150);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.tipoCancelacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rolCancelacion);
            this.Controls.Add(this.label1);
            this.Name = "CancAtencionForm";
            this.Text = "Cancelar Atención";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rolCancelacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoCancelacion;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}