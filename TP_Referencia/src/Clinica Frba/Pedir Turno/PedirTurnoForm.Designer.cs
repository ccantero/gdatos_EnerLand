namespace Clinica_Frba.PedirTurno
{
    partial class PedirTurnoForm
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
            this.comboBox_hora = new System.Windows.Forms.ComboBox();
            this.label_horario = new System.Windows.Forms.Label();
            this.button_select_medico = new System.Windows.Forms.Button();
            this.box_medico = new System.Windows.Forms.TextBox();
            this.label_fecha = new System.Windows.Forms.Label();
            this.Combo_fecha = new System.Windows.Forms.DateTimePicker();
            this.button_save = new System.Windows.Forms.Button();
            this.button_Clean = new System.Windows.Forms.Button();
            this.label_medico = new System.Windows.Forms.Label();
            this.button_Select_Afiliado = new System.Windows.Forms.Button();
            this.box_Afiliado = new System.Windows.Forms.TextBox();
            this.label_afiliado = new System.Windows.Forms.Label();
            this.button_select_prof = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_hora);
            this.groupBox1.Controls.Add(this.label_horario);
            this.groupBox1.Controls.Add(this.button_select_medico);
            this.groupBox1.Controls.Add(this.box_medico);
            this.groupBox1.Controls.Add(this.label_fecha);
            this.groupBox1.Controls.Add(this.Combo_fecha);
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Controls.Add(this.button_Clean);
            this.groupBox1.Controls.Add(this.label_medico);
            this.groupBox1.Controls.Add(this.button_Select_Afiliado);
            this.groupBox1.Controls.Add(this.box_Afiliado);
            this.groupBox1.Controls.Add(this.label_afiliado);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a Completar";
            // 
            // comboBox_hora
            // 
            this.comboBox_hora.FormattingEnabled = true;
            this.comboBox_hora.Location = new System.Drawing.Point(98, 192);
            this.comboBox_hora.Name = "comboBox_hora";
            this.comboBox_hora.Size = new System.Drawing.Size(121, 21);
            this.comboBox_hora.TabIndex = 17;
            // 
            // label_horario
            // 
            this.label_horario.AutoSize = true;
            this.label_horario.Location = new System.Drawing.Point(11, 200);
            this.label_horario.Name = "label_horario";
            this.label_horario.Size = new System.Drawing.Size(41, 13);
            this.label_horario.TabIndex = 16;
            this.label_horario.Text = "Horario";
            // 
            // button_select_medico
            // 
            this.button_select_medico.Location = new System.Drawing.Point(318, 140);
            this.button_select_medico.Name = "button_select_medico";
            this.button_select_medico.Size = new System.Drawing.Size(75, 23);
            this.button_select_medico.TabIndex = 15;
            this.button_select_medico.Text = "Seleccionar";
            this.button_select_medico.UseVisualStyleBackColor = true;
            this.button_select_medico.Click += new System.EventHandler(this.button_select_medico_Click);
            // 
            // box_medico
            // 
            this.box_medico.BackColor = System.Drawing.SystemColors.Control;
            this.box_medico.Location = new System.Drawing.Point(98, 142);
            this.box_medico.Name = "box_medico";
            this.box_medico.ReadOnly = true;
            this.box_medico.Size = new System.Drawing.Size(200, 20);
            this.box_medico.TabIndex = 14;
            // 
            // label_fecha
            // 
            this.label_fecha.AutoSize = true;
            this.label_fecha.Location = new System.Drawing.Point(11, 93);
            this.label_fecha.Name = "label_fecha";
            this.label_fecha.Size = new System.Drawing.Size(37, 13);
            this.label_fecha.TabIndex = 10;
            this.label_fecha.Text = "Fecha";
            // 
            // Combo_fecha
            // 
            this.Combo_fecha.Location = new System.Drawing.Point(98, 87);
            this.Combo_fecha.Name = "Combo_fecha";
            this.Combo_fecha.Size = new System.Drawing.Size(200, 20);
            this.Combo_fecha.TabIndex = 9;
            this.Combo_fecha.ValueChanged += new System.EventHandler(this.Combo_fecha_ValueChanged);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(261, 252);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "Guardar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_Clean
            // 
            this.button_Clean.Location = new System.Drawing.Point(55, 252);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 7;
            this.button_Clean.Text = "Limpiar";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // label_medico
            // 
            this.label_medico.AutoSize = true;
            this.label_medico.Location = new System.Drawing.Point(11, 145);
            this.label_medico.Name = "label_medico";
            this.label_medico.Size = new System.Drawing.Size(42, 13);
            this.label_medico.TabIndex = 5;
            this.label_medico.Text = "Medico";
            // 
            // button_Select_Afiliado
            // 
            this.button_Select_Afiliado.Location = new System.Drawing.Point(318, 30);
            this.button_Select_Afiliado.Name = "button_Select_Afiliado";
            this.button_Select_Afiliado.Size = new System.Drawing.Size(75, 23);
            this.button_Select_Afiliado.TabIndex = 2;
            this.button_Select_Afiliado.Text = "Seleccionar";
            this.button_Select_Afiliado.UseVisualStyleBackColor = true;
            this.button_Select_Afiliado.Click += new System.EventHandler(this.button_Select_Afiliado_Click);
            // 
            // box_Afiliado
            // 
            this.box_Afiliado.BackColor = System.Drawing.SystemColors.Control;
            this.box_Afiliado.Location = new System.Drawing.Point(98, 32);
            this.box_Afiliado.Name = "box_Afiliado";
            this.box_Afiliado.ReadOnly = true;
            this.box_Afiliado.Size = new System.Drawing.Size(200, 20);
            this.box_Afiliado.TabIndex = 1;
            // 
            // label_afiliado
            // 
            this.label_afiliado.AutoSize = true;
            this.label_afiliado.Location = new System.Drawing.Point(11, 37);
            this.label_afiliado.Name = "label_afiliado";
            this.label_afiliado.Size = new System.Drawing.Size(41, 13);
            this.label_afiliado.TabIndex = 0;
            this.label_afiliado.Text = "Afiliado";
            // 
            // button_select_prof
            // 
            this.button_select_prof.Location = new System.Drawing.Point(0, 0);
            this.button_select_prof.Name = "button_select_prof";
            this.button_select_prof.Size = new System.Drawing.Size(75, 23);
            this.button_select_prof.TabIndex = 0;
            // 
            // PedirTurnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 309);
            this.Controls.Add(this.groupBox1);
            this.Name = "PedirTurnoForm";
            this.Text = "Pedir Turno";
            this.Load += new System.EventHandler(this.PedirTurnoForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(PedirTurnoForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_afiliado;
        private System.Windows.Forms.TextBox box_Afiliado;
        private System.Windows.Forms.Button button_Select_Afiliado;
        private System.Windows.Forms.Label label_medico;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Label label_fecha;
        private System.Windows.Forms.DateTimePicker Combo_fecha;
        private System.Windows.Forms.Button button_select_prof;
        private System.Windows.Forms.TextBox box_medico;
        private System.Windows.Forms.Button button_select_medico;
        private System.Windows.Forms.Label label_horario;
        private System.Windows.Forms.ComboBox comboBox_hora;
    }

}