namespace FrbaHotel.ABM_de_Rol
{
    partial class AgregarRol
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
            this.label_RolName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkedListBox_Funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label_Funcionalidades = new System.Windows.Forms.Label();
            this.label_ActiveRol = new System.Windows.Forms.Label();
            this.checkBox_ActiveRol = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_RolName
            // 
            this.label_RolName.AutoSize = true;
            this.label_RolName.Location = new System.Drawing.Point(4, 34);
            this.label_RolName.Name = "label_RolName";
            this.label_RolName.Size = new System.Drawing.Size(78, 13);
            this.label_RolName.TabIndex = 1;
            this.label_RolName.Text = "Nombre de Rol";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 2;
            // 
            // checkedListBox_Funcionalidades
            // 
            this.checkedListBox_Funcionalidades.FormattingEnabled = true;
            this.checkedListBox_Funcionalidades.Location = new System.Drawing.Point(119, 84);
            this.checkedListBox_Funcionalidades.Name = "checkedListBox_Funcionalidades";
            this.checkedListBox_Funcionalidades.Size = new System.Drawing.Size(169, 169);
            this.checkedListBox_Funcionalidades.TabIndex = 3;
            // 
            // label_Funcionalidades
            // 
            this.label_Funcionalidades.AutoSize = true;
            this.label_Funcionalidades.Location = new System.Drawing.Point(7, 84);
            this.label_Funcionalidades.Name = "label_Funcionalidades";
            this.label_Funcionalidades.Size = new System.Drawing.Size(84, 13);
            this.label_Funcionalidades.TabIndex = 4;
            this.label_Funcionalidades.Text = "Funcionalidades";
            // 
            // label_ActiveRol
            // 
            this.label_ActiveRol.AutoSize = true;
            this.label_ActiveRol.Location = new System.Drawing.Point(7, 268);
            this.label_ActiveRol.Name = "label_ActiveRol";
            this.label_ActiveRol.Size = new System.Drawing.Size(56, 13);
            this.label_ActiveRol.TabIndex = 5;
            this.label_ActiveRol.Text = "Rol Activo";
            // 
            // checkBox_ActiveRol
            // 
            this.checkBox_ActiveRol.AutoSize = true;
            this.checkBox_ActiveRol.Location = new System.Drawing.Point(119, 268);
            this.checkBox_ActiveRol.Name = "checkBox_ActiveRol";
            this.checkBox_ActiveRol.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ActiveRol.TabIndex = 6;
            this.checkBox_ActiveRol.UseVisualStyleBackColor = true;
            // 
            // AgregarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_ActiveRol);
            this.Controls.Add(this.label_ActiveRol);
            this.Controls.Add(this.label_Funcionalidades);
            this.Controls.Add(this.checkedListBox_Funcionalidades);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_RolName);
            this.Name = "AgregarRol";
            this.Size = new System.Drawing.Size(300, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_RolName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox_Funcionalidades;
        private System.Windows.Forms.Label label_Funcionalidades;
        private System.Windows.Forms.Label label_ActiveRol;
        private System.Windows.Forms.CheckBox checkBox_ActiveRol;

    }
}
