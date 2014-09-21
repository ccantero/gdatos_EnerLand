namespace Clinica_Frba.RegResAtencion
{
    partial class RegResAtencionForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaTurno = new System.Windows.Forms.DateTimePicker();
            this.horaTurno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.minutosTurno = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numBono = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.afiliado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número Afiliado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Turno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hora:";
            // 
            // fechaTurno
            // 
            this.fechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaTurno.Location = new System.Drawing.Point(102, 59);
            this.fechaTurno.Name = "fechaTurno";
            this.fechaTurno.Size = new System.Drawing.Size(113, 20);
            this.fechaTurno.TabIndex = 28;
            this.fechaTurno.Value = global::Clinica_Frba.Properties.Settings.Default.Fecha;
            // 
            // horaTurno
            // 
            this.horaTurno.FormattingEnabled = true;
            this.horaTurno.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.horaTurno.Location = new System.Drawing.Point(51, 90);
            this.horaTurno.Name = "horaTurno";
            this.horaTurno.Size = new System.Drawing.Size(42, 21);
            this.horaTurno.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Minutos:";
            // 
            // minutosTurno
            // 
            this.minutosTurno.FormattingEnabled = true;
            this.minutosTurno.Items.AddRange(new object[] {
            "00",
            "30"});
            this.minutosTurno.Location = new System.Drawing.Point(173, 90);
            this.minutosTurno.Name = "minutosTurno";
            this.minutosTurno.Size = new System.Drawing.Size(42, 21);
            this.minutosTurno.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Bono Consulta Utilizado:";
            // 
            // numBono
            // 
            this.numBono.Location = new System.Drawing.Point(136, 127);
            this.numBono.Name = "numBono";
            this.numBono.Size = new System.Drawing.Size(79, 20);
            this.numBono.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Ingresar Síntomas y Diagnóstico";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // afiliado
            // 
            this.afiliado.Location = new System.Drawing.Point(102, 12);
            this.afiliado.Name = "afiliado";
            this.afiliado.ReadOnly = true;
            this.afiliado.Size = new System.Drawing.Size(113, 20);
            this.afiliado.TabIndex = 36;
            // 
            // RegResAtencionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 208);
            this.Controls.Add(this.afiliado);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numBono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minutosTurno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.horaTurno);
            this.Controls.Add(this.fechaTurno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegResAtencionForm";
            this.Text = "Registro de Resultado de Atención";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaTurno;
        private System.Windows.Forms.ComboBox horaTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox minutosTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numBono;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox afiliado;
    }
}