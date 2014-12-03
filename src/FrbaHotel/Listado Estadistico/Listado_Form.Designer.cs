namespace FrbaHotel.Listado_Estadistico
{
    partial class Form_ListadoEstadistico
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
            this.dataGridView_Listado = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBox_Listados = new System.Windows.Forms.ComboBox();
            this.label_Listados = new System.Windows.Forms.Label();
            this.ComboBox_To = new System.Windows.Forms.TextBox();
            this.button_Accept = new System.Windows.Forms.Button();
            this.label_hasta = new System.Windows.Forms.Label();
            this.ComboBox_DateFrom = new System.Windows.Forms.ComboBox();
            this.label_desde = new System.Windows.Forms.Label();
            this.comboBox_Anio = new System.Windows.Forms.ComboBox();
            this.label_anio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Listado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Listado
            // 
            this.dataGridView_Listado.AllowUserToAddRows = false;
            this.dataGridView_Listado.AllowUserToDeleteRows = false;
            this.dataGridView_Listado.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Listado.Location = new System.Drawing.Point(11, 169);
            this.dataGridView_Listado.Name = "dataGridView_Listado";
            this.dataGridView_Listado.Size = new System.Drawing.Size(461, 281);
            this.dataGridView_Listado.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboBox_Listados);
            this.groupBox1.Controls.Add(this.label_Listados);
            this.groupBox1.Controls.Add(this.ComboBox_To);
            this.groupBox1.Controls.Add(this.button_Accept);
            this.groupBox1.Controls.Add(this.label_hasta);
            this.groupBox1.Controls.Add(this.ComboBox_DateFrom);
            this.groupBox1.Controls.Add(this.label_desde);
            this.groupBox1.Controls.Add(this.comboBox_Anio);
            this.groupBox1.Controls.Add(this.label_anio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos a completar";
            // 
            // ComboBox_Listados
            // 
            this.ComboBox_Listados.FormattingEnabled = true;
            this.ComboBox_Listados.Location = new System.Drawing.Point(58, 29);
            this.ComboBox_Listados.Name = "ComboBox_Listados";
            this.ComboBox_Listados.Size = new System.Drawing.Size(377, 21);
            this.ComboBox_Listados.TabIndex = 9;
            // 
            // label_Listados
            // 
            this.label_Listados.AutoSize = true;
            this.label_Listados.Location = new System.Drawing.Point(6, 32);
            this.label_Listados.Name = "label_Listados";
            this.label_Listados.Size = new System.Drawing.Size(46, 13);
            this.label_Listados.TabIndex = 8;
            this.label_Listados.Text = "Listados";
            // 
            // ComboBox_To
            // 
            this.ComboBox_To.Location = new System.Drawing.Point(335, 89);
            this.ComboBox_To.Name = "ComboBox_To";
            this.ComboBox_To.ReadOnly = true;
            this.ComboBox_To.Size = new System.Drawing.Size(100, 20);
            this.ComboBox_To.TabIndex = 7;
            // 
            // button_Accept
            // 
            this.button_Accept.Location = new System.Drawing.Point(201, 122);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(75, 23);
            this.button_Accept.TabIndex = 6;
            this.button_Accept.Text = "Calcular";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // label_hasta
            // 
            this.label_hasta.AutoSize = true;
            this.label_hasta.Location = new System.Drawing.Point(294, 92);
            this.label_hasta.Name = "label_hasta";
            this.label_hasta.Size = new System.Drawing.Size(35, 13);
            this.label_hasta.TabIndex = 5;
            this.label_hasta.Text = "Hasta";
            // 
            // ComboBox_DateFrom
            // 
            this.ComboBox_DateFrom.FormattingEnabled = true;
            this.ComboBox_DateFrom.Location = new System.Drawing.Point(188, 88);
            this.ComboBox_DateFrom.Name = "ComboBox_DateFrom";
            this.ComboBox_DateFrom.Size = new System.Drawing.Size(100, 21);
            this.ComboBox_DateFrom.TabIndex = 4;
            this.ComboBox_DateFrom.SelectedIndexChanged += new System.EventHandler(this.ComboBox_DateFrom_SelectedIndexChanged);
            // 
            // label_desde
            // 
            this.label_desde.AutoSize = true;
            this.label_desde.Location = new System.Drawing.Point(144, 92);
            this.label_desde.Name = "label_desde";
            this.label_desde.Size = new System.Drawing.Size(38, 13);
            this.label_desde.TabIndex = 3;
            this.label_desde.Text = "Desde";
            // 
            // comboBox_Anio
            // 
            this.comboBox_Anio.FormattingEnabled = true;
            this.comboBox_Anio.Location = new System.Drawing.Point(38, 88);
            this.comboBox_Anio.Name = "comboBox_Anio";
            this.comboBox_Anio.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Anio.TabIndex = 1;
            // 
            // label_anio
            // 
            this.label_anio.AutoSize = true;
            this.label_anio.Location = new System.Drawing.Point(6, 92);
            this.label_anio.Name = "label_anio";
            this.label_anio.Size = new System.Drawing.Size(26, 13);
            this.label_anio.TabIndex = 0;
            this.label_anio.Text = "Año";
            // 
            // Form_ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.dataGridView_Listado);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_ListadoEstadistico";
            this.Text = "Listados Estadisticos";
            this.Load += new System.EventHandler(this.Form_ListadoEstadistico_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ListadoEstadistico_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Listado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Listado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ComboBox_To;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.Label label_hasta;
        private System.Windows.Forms.ComboBox ComboBox_DateFrom;
        private System.Windows.Forms.Label label_desde;
        private System.Windows.Forms.ComboBox comboBox_Anio;
        private System.Windows.Forms.Label label_anio;
        private System.Windows.Forms.ComboBox ComboBox_Listados;
        private System.Windows.Forms.Label label_Listados;

    }
}