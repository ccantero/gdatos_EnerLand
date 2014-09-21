namespace Clinica_Frba.buscarAfiliado
{
    partial class BuscarAfiliado
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
            this.box_documento = new System.Windows.Forms.TextBox();
            this.label_telefono = new System.Windows.Forms.Label();
            this.box_codigo = new System.Windows.Forms.TextBox();
            this.label_documento = new System.Windows.Forms.Label();
            this.box_apellido = new System.Windows.Forms.TextBox();
            this.label_afiliado = new System.Windows.Forms.Label();
            this.box_nombre = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.box_documento);
            this.groupBox1.Controls.Add(this.label_telefono);
            this.groupBox1.Controls.Add(this.box_codigo);
            this.groupBox1.Controls.Add(this.label_documento);
            this.groupBox1.Controls.Add(this.box_apellido);
            this.groupBox1.Controls.Add(this.label_afiliado);
            this.groupBox1.Controls.Add(this.box_nombre);
            this.groupBox1.Controls.Add(this.label_nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // box_documento
            // 
            this.box_documento.Location = new System.Drawing.Point(352, 65);
            this.box_documento.Name = "box_documento";
            this.box_documento.Size = new System.Drawing.Size(133, 20);
            this.box_documento.TabIndex = 7;
            // 
            // label_telefono
            // 
            this.label_telefono.AutoSize = true;
            this.label_telefono.Location = new System.Drawing.Point(261, 68);
            this.label_telefono.Name = "label_telefono";
            this.label_telefono.Size = new System.Drawing.Size(65, 13);
            this.label_telefono.TabIndex = 6;
            this.label_telefono.Text = "Documento:";
            // 
            // box_codigo
            // 
            this.box_codigo.Location = new System.Drawing.Point(352, 23);
            this.box_codigo.Name = "box_codigo";
            this.box_codigo.Size = new System.Drawing.Size(133, 20);
            this.box_codigo.TabIndex = 3;
            // 
            // label_documento
            // 
            this.label_documento.AutoSize = true;
            this.label_documento.Location = new System.Drawing.Point(261, 26);
            this.label_documento.Name = "label_documento";
            this.label_documento.Size = new System.Drawing.Size(80, 13);
            this.label_documento.TabIndex = 4;
            this.label_documento.Text = "Código Afiliado:";
            // 
            // box_apellido
            // 
            this.box_apellido.Location = new System.Drawing.Point(103, 65);
            this.box_apellido.Name = "box_apellido";
            this.box_apellido.Size = new System.Drawing.Size(133, 20);
            this.box_apellido.TabIndex = 5;
            // 
            // label_afiliado
            // 
            this.label_afiliado.AutoSize = true;
            this.label_afiliado.Location = new System.Drawing.Point(6, 68);
            this.label_afiliado.Name = "label_afiliado";
            this.label_afiliado.Size = new System.Drawing.Size(47, 13);
            this.label_afiliado.TabIndex = 2;
            this.label_afiliado.Text = "Apellido:";
            // 
            // box_nombre
            // 
            this.box_nombre.Location = new System.Drawing.Point(103, 23);
            this.box_nombre.Name = "box_nombre";
            this.box_nombre.Size = new System.Drawing.Size(133, 20);
            this.box_nombre.TabIndex = 1;
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(6, 26);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_nombre.TabIndex = 0;
            this.label_nombre.Text = "Nombre:";
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(89, 118);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 3;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(329, 118);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 4;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(501, 191);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(439, 369);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 6;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // BuscarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 404);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.groupBox1);
            this.Name = "BuscarAfiliado";
            this.Text = "Buscar Afiliado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox box_documento;
        private System.Windows.Forms.Label label_telefono;
        private System.Windows.Forms.TextBox box_codigo;
        private System.Windows.Forms.Label label_documento;
        private System.Windows.Forms.TextBox box_apellido;
        private System.Windows.Forms.Label label_afiliado;
        private System.Windows.Forms.TextBox box_nombre;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button volver;

    }
}