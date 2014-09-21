namespace Clinica_Frba.ListadosEstadisticos
{
    partial class ListadosEstForm
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
            this.box_hasta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_hasta = new System.Windows.Forms.Label();
            this.box_from = new System.Windows.Forms.ComboBox();
            this.label_desde = new System.Windows.Forms.Label();
            this.box_anio = new System.Windows.Forms.ComboBox();
            this.label_anio = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.box_cancelador = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.box_cancelador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.box_hasta);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label_hasta);
            this.groupBox1.Controls.Add(this.box_from);
            this.groupBox1.Controls.Add(this.label_desde);
            this.groupBox1.Controls.Add(this.box_anio);
            this.groupBox1.Controls.Add(this.label_anio);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a completar";
            // 
            // box_hasta
            // 
            this.box_hasta.Location = new System.Drawing.Point(322, 88);
            this.box_hasta.Name = "box_hasta";
            this.box_hasta.ReadOnly = true;
            this.box_hasta.Size = new System.Drawing.Size(121, 20);
            this.box_hasta.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_hasta
            // 
            this.label_hasta.AutoSize = true;
            this.label_hasta.Location = new System.Drawing.Point(255, 91);
            this.label_hasta.Name = "label_hasta";
            this.label_hasta.Size = new System.Drawing.Size(35, 13);
            this.label_hasta.TabIndex = 5;
            this.label_hasta.Text = "Hasta";
            // 
            // box_from
            // 
            this.box_from.FormattingEnabled = true;
            this.box_from.Location = new System.Drawing.Point(73, 88);
            this.box_from.Name = "box_from";
            this.box_from.Size = new System.Drawing.Size(121, 21);
            this.box_from.TabIndex = 4;
            this.box_from.SelectedIndexChanged += new System.EventHandler(this.box_from_SelectedIndexChanged);
            // 
            // label_desde
            // 
            this.label_desde.AutoSize = true;
            this.label_desde.Location = new System.Drawing.Point(6, 91);
            this.label_desde.Name = "label_desde";
            this.label_desde.Size = new System.Drawing.Size(38, 13);
            this.label_desde.TabIndex = 3;
            this.label_desde.Text = "Desde";
            // 
            // box_anio
            // 
            this.box_anio.FormattingEnabled = true;
            this.box_anio.Location = new System.Drawing.Point(73, 32);
            this.box_anio.Name = "box_anio";
            this.box_anio.Size = new System.Drawing.Size(121, 21);
            this.box_anio.TabIndex = 1;
            // 
            // label_anio
            // 
            this.label_anio.AutoSize = true;
            this.label_anio.Location = new System.Drawing.Point(6, 35);
            this.label_anio.Name = "label_anio";
            this.label_anio.Size = new System.Drawing.Size(26, 13);
            this.label_anio.TabIndex = 0;
            this.label_anio.Text = "Año";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(461, 199);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cancelador";
            // 
            // box_cancelador
            // 
            this.box_cancelador.FormattingEnabled = true;
            this.box_cancelador.Location = new System.Drawing.Point(322, 32);
            this.box_cancelador.Name = "box_cancelador";
            this.box_cancelador.Size = new System.Drawing.Size(121, 21);
            this.box_cancelador.TabIndex = 9;
            // 
            // ListadosEstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ListadosEstForm_FormClosing);
            this.Name = "ListadosEstForm";
            this.Text = "Listados Estadisticos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox box_anio;
        private System.Windows.Forms.Label label_anio;
        private System.Windows.Forms.TextBox box_hasta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_hasta;
        private System.Windows.Forms.ComboBox box_from;
        private System.Windows.Forms.Label label_desde;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox box_cancelador;
        private System.Windows.Forms.Label label1;
    }
}