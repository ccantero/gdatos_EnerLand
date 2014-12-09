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
            this.comboBox_TipoDocumento = new System.Windows.Forms.ComboBox();
            this.label_TipoDoc = new System.Windows.Forms.Label();
            this.label_Mail = new System.Windows.Forms.Label();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.dataGrid_Huespedes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_NroDocumento = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.label_Nrodocumento = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.button_AddHuesped = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Huespedes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_TipoDocumento
            // 
            this.comboBox_TipoDocumento.FormattingEnabled = true;
            this.comboBox_TipoDocumento.Location = new System.Drawing.Point(103, 65);
            this.comboBox_TipoDocumento.Name = "comboBox_TipoDocumento";
            this.comboBox_TipoDocumento.Size = new System.Drawing.Size(200, 21);
            this.comboBox_TipoDocumento.TabIndex = 4;
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
            this.textBox_Mail.Size = new System.Drawing.Size(679, 20);
            this.textBox_Mail.TabIndex = 8;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(588, 160);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 14;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(109, 160);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 13;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // dataGrid_Huespedes
            // 
            this.dataGrid_Huespedes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Huespedes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_Huespedes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_Huespedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Huespedes.Location = new System.Drawing.Point(6, 189);
            this.dataGrid_Huespedes.Name = "dataGrid_Huespedes";
            this.dataGrid_Huespedes.RowHeadersVisible = false;
            this.dataGrid_Huespedes.Size = new System.Drawing.Size(805, 219);
            this.dataGrid_Huespedes.TabIndex = 15;
            this.dataGrid_Huespedes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Huespedes_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_NroDocumento);
            this.groupBox1.Controls.Add(this.label_Apellido);
            this.groupBox1.Controls.Add(this.textBox_apellido);
            this.groupBox1.Controls.Add(this.label_Nrodocumento);
            this.groupBox1.Controls.Add(this.label_Mail);
            this.groupBox1.Controls.Add(this.textBox_nombre);
            this.groupBox1.Controls.Add(this.textBox_Mail);
            this.groupBox1.Controls.Add(this.label_nombre);
            this.groupBox1.Controls.Add(this.label_TipoDoc);
            this.groupBox1.Controls.Add(this.comboBox_TipoDocumento);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 147);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // textbox_NroDocumento
            // 
            this.textbox_NroDocumento.Location = new System.Drawing.Point(582, 66);
            this.textbox_NroDocumento.Name = "textbox_NroDocumento";
            this.textbox_NroDocumento.Size = new System.Drawing.Size(200, 20);
            this.textbox_NroDocumento.TabIndex = 7;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Location = new System.Drawing.Point(491, 26);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(44, 13);
            this.label_Apellido.TabIndex = 6;
            this.label_Apellido.Text = "Apellido";
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Location = new System.Drawing.Point(582, 23);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.Size = new System.Drawing.Size(200, 20);
            this.textBox_apellido.TabIndex = 3;
            // 
            // label_Nrodocumento
            // 
            this.label_Nrodocumento.AutoSize = true;
            this.label_Nrodocumento.Location = new System.Drawing.Point(491, 68);
            this.label_Nrodocumento.Name = "label_Nrodocumento";
            this.label_Nrodocumento.Size = new System.Drawing.Size(85, 13);
            this.label_Nrodocumento.TabIndex = 4;
            this.label_Nrodocumento.Text = "Nro. Documento";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(103, 23);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(200, 20);
            this.textBox_nombre.TabIndex = 1;
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
            // button_AddHuesped
            // 
            this.button_AddHuesped.Location = new System.Drawing.Point(342, 160);
            this.button_AddHuesped.Name = "button_AddHuesped";
            this.button_AddHuesped.Size = new System.Drawing.Size(106, 23);
            this.button_AddHuesped.TabIndex = 16;
            this.button_AddHuesped.Text = "Agregar Huesped";
            this.button_AddHuesped.UseVisualStyleBackColor = true;
            this.button_AddHuesped.Visible = false;
            this.button_AddHuesped.Click += new System.EventHandler(this.button_AddHuesped_Click);
            // 
            // UserControl_BuscarHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_AddHuesped);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.dataGrid_Huespedes);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_BuscarHuesped";
            this.Size = new System.Drawing.Size(825, 425);
            this.Load += new System.EventHandler(this.UserControl_BuscarHuesped_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Huespedes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_TipoDocumento;
        private System.Windows.Forms.Label label_TipoDoc;
        private System.Windows.Forms.Label label_Mail;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.DataGridView dataGrid_Huespedes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_NroDocumento;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.Label label_Nrodocumento;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Button button_AddHuesped;
    }
}
