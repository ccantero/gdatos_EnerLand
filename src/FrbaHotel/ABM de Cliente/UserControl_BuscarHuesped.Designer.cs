namespace FrbaHotel.ABM_de_Cliente
{
    partial class UserControl_BuscarHuesped
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_TipoDoc = new System.Windows.Forms.Label();
            this.label_Mail = new System.Windows.Forms.Label();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.box_dni = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.box_apellido = new System.Windows.Forms.TextBox();
            this.label_Nrodocumento = new System.Windows.Forms.Label();
            this.box_nombre = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label_TipoDoc
            // 
            this.label_TipoDoc.AutoSize = true;
            this.label_TipoDoc.Location = new System.Drawing.Point(6, 68);
            this.label_TipoDoc.Name = "label_TipoDoc";
            this.label_TipoDoc.Size = new System.Drawing.Size(84, 13);
            this.label_TipoDoc.TabIndex = 5;
            this.label_TipoDoc.Text = "Tipo documento";
            // 
            // label_Mail
            // 
            this.label_Mail.AutoSize = true;
            this.label_Mail.Location = new System.Drawing.Point(6, 108);
            this.label_Mail.Name = "label_Mail";
            this.label_Mail.Size = new System.Drawing.Size(26, 13);
            this.label_Mail.TabIndex = 9;
            this.label_Mail.Text = "Mail";
            // 
            // textBox_Mail
            // 
            this.textBox_Mail.Location = new System.Drawing.Point(103, 105);
            this.textBox_Mail.Name = "textBox_Mail";
            this.textBox_Mail.Size = new System.Drawing.Size(388, 20);
            this.textBox_Mail.TabIndex = 8;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(378, 160);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 14;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(60, 160);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 13;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 189);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(504, 219);
            this.dataGridView.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.box_dni);
            this.groupBox1.Controls.Add(this.label_Apellido);
            this.groupBox1.Controls.Add(this.box_apellido);
            this.groupBox1.Controls.Add(this.label_Nrodocumento);
            this.groupBox1.Controls.Add(this.label_Mail);
            this.groupBox1.Controls.Add(this.box_nombre);
            this.groupBox1.Controls.Add(this.textBox_Mail);
            this.groupBox1.Controls.Add(this.label_nombre);
            this.groupBox1.Controls.Add(this.label_TipoDoc);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 147);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // box_dni
            // 
            this.box_dni.Location = new System.Drawing.Point(356, 65);
            this.box_dni.Name = "box_dni";
            this.box_dni.Size = new System.Drawing.Size(135, 20);
            this.box_dni.TabIndex = 7;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Location = new System.Drawing.Point(261, 30);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(44, 13);
            this.label_Apellido.TabIndex = 6;
            this.label_Apellido.Text = "Apellido";
            // 
            // box_apellido
            // 
            this.box_apellido.Location = new System.Drawing.Point(356, 23);
            this.box_apellido.Name = "box_apellido";
            this.box_apellido.Size = new System.Drawing.Size(135, 20);
            this.box_apellido.TabIndex = 3;
            // 
            // label_Nrodocumento
            // 
            this.label_Nrodocumento.AutoSize = true;
            this.label_Nrodocumento.Location = new System.Drawing.Point(261, 68);
            this.label_Nrodocumento.Name = "label_Nrodocumento";
            this.label_Nrodocumento.Size = new System.Drawing.Size(85, 13);
            this.label_Nrodocumento.TabIndex = 4;
            this.label_Nrodocumento.Text = "Nro. Documento";
            // 
            // box_nombre
            // 
            this.box_nombre.Location = new System.Drawing.Point(103, 23);
            this.box_nombre.Name = "box_nombre";
            this.box_nombre.Size = new System.Drawing.Size(135, 20);
            this.box_nombre.TabIndex = 1;
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(6, 26);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(44, 13);
            this.label_nombre.TabIndex = 0;
            this.label_nombre.Text = "Nombre";
            // 
            // UserControl_BuscarHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_BuscarHuesped";
            this.Size = new System.Drawing.Size(525, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_TipoDoc;
        private System.Windows.Forms.Label label_Mail;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox box_dni;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox box_apellido;
        private System.Windows.Forms.Label label_Nrodocumento;
        private System.Windows.Forms.TextBox box_nombre;
        private System.Windows.Forms.Label label_nombre;
    }
}
