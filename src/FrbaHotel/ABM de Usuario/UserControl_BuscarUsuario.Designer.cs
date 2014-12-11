namespace FrbaHotel.ABM_de_Usuario
{
    partial class UserControl_BuscarUsuario
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_search = new System.Windows.Forms.Button();
            this.button_clean = new System.Windows.Forms.Button();
            this.dataGrid_Usuarios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.textbox_NroDocumento = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.label_Nrodocumento = new System.Windows.Forms.Label();
            this.label_Mail = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.label_TipoDoc = new System.Windows.Forms.Label();
            this.comboBox_TipoDocumento = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(592, 165);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 12;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(113, 165);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 13;
            this.button_clean.Text = "Limpiar";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // dataGrid_Usuarios
            // 
            this.dataGrid_Usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Usuarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_Usuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Usuarios.Location = new System.Drawing.Point(10, 194);
            this.dataGrid_Usuarios.Name = "dataGrid_Usuarios";
            this.dataGrid_Usuarios.RowHeadersVisible = false;
            this.dataGrid_Usuarios.Size = new System.Drawing.Size(805, 219);
            this.dataGrid_Usuarios.TabIndex = 19;
            this.dataGrid_Usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Usuarios_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_username);
            this.groupBox1.Controls.Add(this.label_Username);
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
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 147);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(103, 105);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(200, 20);
            this.textBox_username.TabIndex = 9;
            this.textBox_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_username_KeyPress);
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(6, 108);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(43, 13);
            this.label_Username.TabIndex = 8;
            this.label_Username.Text = "Usuario";
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
            this.label_Apellido.TabIndex = 2;
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
            this.label_Nrodocumento.TabIndex = 6;
            this.label_Nrodocumento.Text = "Nro. Documento";
            // 
            // label_Mail
            // 
            this.label_Mail.AutoSize = true;
            this.label_Mail.Location = new System.Drawing.Point(491, 108);
            this.label_Mail.Name = "label_Mail";
            this.label_Mail.Size = new System.Drawing.Size(26, 13);
            this.label_Mail.TabIndex = 10;
            this.label_Mail.Text = "Mail";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(103, 23);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(200, 20);
            this.textBox_nombre.TabIndex = 1;
            // 
            // textBox_Mail
            // 
            this.textBox_Mail.Location = new System.Drawing.Point(582, 105);
            this.textBox_Mail.Name = "textBox_Mail";
            this.textBox_Mail.Size = new System.Drawing.Size(200, 20);
            this.textBox_Mail.TabIndex = 11;
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
            // label_TipoDoc
            // 
            this.label_TipoDoc.AutoSize = true;
            this.label_TipoDoc.Location = new System.Drawing.Point(6, 68);
            this.label_TipoDoc.Name = "label_TipoDoc";
            this.label_TipoDoc.Size = new System.Drawing.Size(84, 13);
            this.label_TipoDoc.TabIndex = 4;
            this.label_TipoDoc.Text = "Tipo documento";
            // 
            // comboBox_TipoDocumento
            // 
            this.comboBox_TipoDocumento.FormattingEnabled = true;
            this.comboBox_TipoDocumento.Location = new System.Drawing.Point(103, 65);
            this.comboBox_TipoDocumento.Name = "comboBox_TipoDocumento";
            this.comboBox_TipoDocumento.Size = new System.Drawing.Size(200, 21);
            this.comboBox_TipoDocumento.TabIndex = 5;
            // 
            // UserControl_BuscarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.dataGrid_Usuarios);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_BuscarUsuario";
            this.Size = new System.Drawing.Size(825, 425);
            this.Load += new System.EventHandler(this.UserControl_BuscarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Usuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.DataGridView dataGrid_Usuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_NroDocumento;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.Label label_Nrodocumento;
        private System.Windows.Forms.Label label_Mail;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label_TipoDoc;
        private System.Windows.Forms.ComboBox comboBox_TipoDocumento;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label_Username;
    }
}
