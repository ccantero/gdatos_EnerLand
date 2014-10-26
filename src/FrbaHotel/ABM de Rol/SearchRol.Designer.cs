namespace FrbaHotel.ABM_de_Rol
{
    partial class SearchRol
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
            this.label_RolName = new System.Windows.Forms.Label();
            this.groupBox_FiltroBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_FiltroBusqueda
            // 
            this.groupBox_FiltroBusqueda.Controls.Add(this.label_RolName);
            this.groupBox_FiltroBusqueda.Location = new System.Drawing.Point(8, 9);
            this.groupBox_FiltroBusqueda.Name = "groupBox_FiltroBusqueda";
            this.groupBox_FiltroBusqueda.Size = new System.Drawing.Size(347, 136);
            this.groupBox_FiltroBusqueda.TabIndex = 0;
            this.groupBox_FiltroBusqueda.TabStop = false;
            this.groupBox_FiltroBusqueda.Text = "Filtros de Búsqueda";
            // 
            // label_RolName
            // 
            this.label_RolName.AutoSize = true;
            this.label_RolName.Location = new System.Drawing.Point(7, 50);
            this.label_RolName.Name = "label_RolName";
            this.label_RolName.Size = new System.Drawing.Size(60, 13);
            this.label_RolName.TabIndex = 1;
            this.label_RolName.Text = "NombreRol";
            // 
            // SearchRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_FiltroBusqueda);
            this.Name = "SearchRol";
            this.Size = new System.Drawing.Size(368, 160);
            this.groupBox_FiltroBusqueda.ResumeLayout(false);
            this.groupBox_FiltroBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_FiltroBusqueda;
        private System.Windows.Forms.Label label_RolName;
    }
}
