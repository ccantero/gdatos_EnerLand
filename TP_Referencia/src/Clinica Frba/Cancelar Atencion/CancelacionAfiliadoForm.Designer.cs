namespace Clinica_Frba.Cancelar_Atencion_Afiliado
{
    partial class CancelacionAfiliadoForm
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
            this.label_Afiliado = new System.Windows.Forms.Label();
            this.box_Afiliado = new System.Windows.Forms.TextBox();
            this.button_SearchTurno = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_volver = new System.Windows.Forms.Button();
            this.box_descripcion = new System.Windows.Forms.TextBox();
            this.button_clean = new System.Windows.Forms.Button();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.box_tipoCancelacion = new System.Windows.Forms.ComboBox();
            this.label_TipoCancelacion = new System.Windows.Forms.Label();
            this.button_select_Afiliado = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Afiliado
            // 
            this.label_Afiliado.AutoSize = true;
            this.label_Afiliado.Location = new System.Drawing.Point(6, 24);
            this.label_Afiliado.Name = "label_Afiliado";
            this.label_Afiliado.Size = new System.Drawing.Size(41, 13);
            this.label_Afiliado.TabIndex = 2;
            this.label_Afiliado.Text = "Afiliado";
            // 
            // box_Afiliado
            // 
            this.box_Afiliado.Location = new System.Drawing.Point(159, 22);
            this.box_Afiliado.Name = "box_Afiliado";
            this.box_Afiliado.ReadOnly = true;
            this.box_Afiliado.Size = new System.Drawing.Size(244, 20);
            this.box_Afiliado.TabIndex = 5;
            // 
            // button_SearchTurno
            // 
            this.button_SearchTurno.Location = new System.Drawing.Point(201, 188);
            this.button_SearchTurno.Name = "button_SearchTurno";
            this.button_SearchTurno.Size = new System.Drawing.Size(107, 23);
            this.button_SearchTurno.TabIndex = 7;
            this.button_SearchTurno.Text = "Guardar";
            this.button_SearchTurno.UseVisualStyleBackColor = true;
            this.button_SearchTurno.Click += new System.EventHandler(this.button_SearchTurno_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_volver);
            this.groupBox1.Controls.Add(this.box_descripcion);
            this.groupBox1.Controls.Add(this.button_clean);
            this.groupBox1.Controls.Add(this.button_SearchTurno);
            this.groupBox1.Controls.Add(this.label_descripcion);
            this.groupBox1.Controls.Add(this.box_tipoCancelacion);
            this.groupBox1.Controls.Add(this.label_TipoCancelacion);
            this.groupBox1.Controls.Add(this.button_select_Afiliado);
            this.groupBox1.Controls.Add(this.label_Afiliado);
            this.groupBox1.Controls.Add(this.box_Afiliado);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 238);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a Completar";
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(388, 188);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(107, 23);
            this.button_volver.TabIndex = 16;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // box_descripcion
            // 
            this.box_descripcion.Location = new System.Drawing.Point(159, 133);
            this.box_descripcion.Name = "box_descripcion";
            this.box_descripcion.Size = new System.Drawing.Size(244, 20);
            this.box_descripcion.TabIndex = 11;
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(23, 188);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(107, 23);
            this.button_clean.TabIndex = 15;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Location = new System.Drawing.Point(6, 136);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(63, 13);
            this.label_descripcion.TabIndex = 10;
            this.label_descripcion.Text = "Descripcion";
            // 
            // box_tipoCancelacion
            // 
            this.box_tipoCancelacion.FormattingEnabled = true;
            this.box_tipoCancelacion.Location = new System.Drawing.Point(159, 77);
            this.box_tipoCancelacion.Name = "box_tipoCancelacion";
            this.box_tipoCancelacion.Size = new System.Drawing.Size(244, 21);
            this.box_tipoCancelacion.TabIndex = 9;
            // 
            // label_TipoCancelacion
            // 
            this.label_TipoCancelacion.AutoSize = true;
            this.label_TipoCancelacion.Location = new System.Drawing.Point(6, 80);
            this.label_TipoCancelacion.Name = "label_TipoCancelacion";
            this.label_TipoCancelacion.Size = new System.Drawing.Size(105, 13);
            this.label_TipoCancelacion.TabIndex = 8;
            this.label_TipoCancelacion.Text = "Tipo de Cancelacion";
            // 
            // button_select_Afiliado
            // 
            this.button_select_Afiliado.Location = new System.Drawing.Point(420, 19);
            this.button_select_Afiliado.Name = "button_select_Afiliado";
            this.button_select_Afiliado.Size = new System.Drawing.Size(75, 23);
            this.button_select_Afiliado.TabIndex = 6;
            this.button_select_Afiliado.Text = "Seleccionar";
            this.button_select_Afiliado.UseVisualStyleBackColor = true;
            this.button_select_Afiliado.Click += new System.EventHandler(this.button_select_Afiliado_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = this.BackColor;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 267);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(512, 188);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CancelacionAfiliadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 467);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelacionAfiliadoForm";
            this.Text = "Cancelación por parte de Afiliado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Afiliado;
        private System.Windows.Forms.TextBox box_Afiliado;
        private System.Windows.Forms.Button button_SearchTurno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_select_Afiliado;
        private System.Windows.Forms.TextBox box_descripcion;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.ComboBox box_tipoCancelacion;
        private System.Windows.Forms.Label label_TipoCancelacion;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}