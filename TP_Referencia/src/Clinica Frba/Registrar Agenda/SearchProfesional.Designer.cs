namespace Clinica_Frba.RegistrarAgenda
{
    partial class SearchProfesionalForm
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
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.box_especialidad = new System.Windows.Forms.ComboBox();
            this.label_Especialidad = new System.Windows.Forms.Label();
            this.box_apellido = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.box_Matricula = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.box_nombre = new System.Windows.Forms.TextBox();
            this.label_matricula = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_buscar);
            this.groupBox1.Controls.Add(this.button_clean);
            this.groupBox1.Controls.Add(this.box_especialidad);
            this.groupBox1.Controls.Add(this.label_Especialidad);
            this.groupBox1.Controls.Add(this.box_apellido);
            this.groupBox1.Controls.Add(this.label_Apellido);
            this.groupBox1.Controls.Add(this.box_Matricula);
            this.groupBox1.Controls.Add(this.label_Nombre);
            this.groupBox1.Controls.Add(this.box_nombre);
            this.groupBox1.Controls.Add(this.label_matricula);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Búsqueda";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(366, 94);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 23);
            this.button_buscar.TabIndex = 9;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(50, 94);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 8;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // box_especialidad
            // 
            this.box_especialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.box_especialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.box_especialidad.Location = new System.Drawing.Point(278, 55);
            this.box_especialidad.Name = "box_especialidad";
            this.box_especialidad.Size = new System.Drawing.Size(225, 21);
            this.box_especialidad.TabIndex = 7;
            // 
            // label_Especialidad
            // 
            this.label_Especialidad.AutoSize = true;
            this.label_Especialidad.Location = new System.Drawing.Point(205, 58);
            this.label_Especialidad.Name = "label_Especialidad";
            this.label_Especialidad.Size = new System.Drawing.Size(67, 13);
            this.label_Especialidad.TabIndex = 6;
            this.label_Especialidad.Text = "Especialidad";
            // 
            // box_apellido
            // 
            this.box_apellido.Location = new System.Drawing.Point(278, 22);
            this.box_apellido.Name = "box_apellido";
            this.box_apellido.Size = new System.Drawing.Size(225, 20);
            this.box_apellido.TabIndex = 5;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Location = new System.Drawing.Point(205, 25);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(44, 13);
            this.label_Apellido.TabIndex = 4;
            this.label_Apellido.Text = "Apellido";
            // 
            // box_Matricula
            // 
            this.box_Matricula.Location = new System.Drawing.Point(64, 56);
            this.box_Matricula.Name = "box_Matricula";
            this.box_Matricula.Size = new System.Drawing.Size(135, 20);
            this.box_Matricula.TabIndex = 3;
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Location = new System.Drawing.Point(6, 25);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(44, 13);
            this.label_Nombre.TabIndex = 2;
            this.label_Nombre.Text = "Nombre";
            // 
            // box_nombre
            // 
            this.box_nombre.Location = new System.Drawing.Point(64, 22);
            this.box_nombre.Name = "box_nombre";
            this.box_nombre.Size = new System.Drawing.Size(135, 20);
            this.box_nombre.TabIndex = 1;
            // 
            // label_matricula
            // 
            this.label_matricula.AutoSize = true;
            this.label_matricula.Location = new System.Drawing.Point(6, 59);
            this.label_matricula.Name = "label_matricula";
            this.label_matricula.Size = new System.Drawing.Size(52, 13);
            this.label_matricula.TabIndex = 0;
            this.label_matricula.Text = "Matrícula";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = this.BackColor;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(509, 186);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SearchProfesionalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 351);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchProfesionalForm";
            this.Text = "SearchProfesional";
            this.Load += new System.EventHandler(this.SearchProfesionalForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(SearchProfesionalForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.TextBox box_nombre;
        private System.Windows.Forms.Label label_matricula;
        private System.Windows.Forms.TextBox box_apellido;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox box_Matricula;
        private System.Windows.Forms.Label label_Especialidad;
        private System.Windows.Forms.ComboBox box_especialidad;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}