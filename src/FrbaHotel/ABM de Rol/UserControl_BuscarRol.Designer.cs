namespace FrbaHotel.ABM_de_Rol
{
    partial class UserControl_BuscarRol
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
            this.groupBox_FiltroBusqueda = new System.Windows.Forms.GroupBox();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_RolName = new System.Windows.Forms.TextBox();
            this.label_RolName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGrid_Roles = new System.Windows.Forms.DataGridView();
            this.groupBox_FiltroBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_FiltroBusqueda
            // 
            this.groupBox_FiltroBusqueda.Controls.Add(this.button_search);
            this.groupBox_FiltroBusqueda.Controls.Add(this.textBox_RolName);
            this.groupBox_FiltroBusqueda.Controls.Add(this.label_RolName);
            this.groupBox_FiltroBusqueda.Location = new System.Drawing.Point(8, 9);
            this.groupBox_FiltroBusqueda.Name = "groupBox_FiltroBusqueda";
            this.groupBox_FiltroBusqueda.Size = new System.Drawing.Size(364, 103);
            this.groupBox_FiltroBusqueda.TabIndex = 0;
            this.groupBox_FiltroBusqueda.TabStop = false;
            this.groupBox_FiltroBusqueda.Text = "Filtros de Búsqueda";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(154, 74);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 3;
            this.button_search.Text = "Buscar";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_RolName
            // 
            this.textBox_RolName.Location = new System.Drawing.Point(82, 42);
            this.textBox_RolName.Name = "textBox_RolName";
            this.textBox_RolName.Size = new System.Drawing.Size(276, 20);
            this.textBox_RolName.TabIndex = 2;
            // 
            // label_RolName
            // 
            this.label_RolName.AutoSize = true;
            this.label_RolName.Location = new System.Drawing.Point(6, 45);
            this.label_RolName.Name = "label_RolName";
            this.label_RolName.Size = new System.Drawing.Size(60, 13);
            this.label_RolName.TabIndex = 1;
            this.label_RolName.Text = "NombreRol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGrid_Roles);
            this.groupBox1.Location = new System.Drawing.Point(4, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 205);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // dataGrid_Roles
            // 
            this.dataGrid_Roles.AllowUserToAddRows = false;
            this.dataGrid_Roles.AllowUserToDeleteRows = false;
            this.dataGrid_Roles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid_Roles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Roles.Location = new System.Drawing.Point(6, 19);
            this.dataGrid_Roles.Name = "dataGrid_Roles";
            this.dataGrid_Roles.ReadOnly = true;
            this.dataGrid_Roles.RowHeadersVisible = false;
            this.dataGrid_Roles.Size = new System.Drawing.Size(356, 179);
            this.dataGrid_Roles.TabIndex = 0;
            this.dataGrid_Roles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Roles_CellClick);
            // 
            // SearchRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_FiltroBusqueda);
            this.Name = "SearchRol";
            this.Size = new System.Drawing.Size(375, 330);
            this.Load += new System.EventHandler(this.SearchRol_Load);
            this.groupBox_FiltroBusqueda.ResumeLayout(false);
            this.groupBox_FiltroBusqueda.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Roles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_FiltroBusqueda;
        private System.Windows.Forms.Label label_RolName;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_RolName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGrid_Roles;
    }
}
