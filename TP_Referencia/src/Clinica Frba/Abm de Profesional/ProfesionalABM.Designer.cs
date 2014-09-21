namespace Clinica_Frba.Profesional
{
    partial class ProfesionalABM
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.acciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirAlMenuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDeAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // acciónToolStripMenuItem
            // 
            this.acciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProfesionalToolStripMenuItem,
            this.modificarProfesionalToolStripMenuItem,
            this.eliminarProfesionalToolStripMenuItem});
            this.acciónToolStripMenuItem.Name = "acciónToolStripMenuItem";
            this.acciónToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.acciónToolStripMenuItem.Text = "Acción";
            // 
            // agregarProfesionalToolStripMenuItem
            // 
            this.agregarProfesionalToolStripMenuItem.Name = "agregarProfesionalToolStripMenuItem";
            this.agregarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.agregarProfesionalToolStripMenuItem.Text = "Agregar Profesional";
            this.agregarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.agregarProfesionalToolStripMenuItem_Click);
            // 
            // modificarProfesionalToolStripMenuItem
            // 
            this.modificarProfesionalToolStripMenuItem.Name = "modificarProfesionalToolStripMenuItem";
            this.modificarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.modificarProfesionalToolStripMenuItem.Text = "Modificar Profesional";
            this.modificarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.modificarProfesionalToolStripMenuItem_Click);
            // 
            // eliminarProfesionalToolStripMenuItem
            // 
            this.eliminarProfesionalToolStripMenuItem.Name = "eliminarProfesionalToolStripMenuItem";
            this.eliminarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.eliminarProfesionalToolStripMenuItem.Text = "Eliminar Profesional";
            this.eliminarProfesionalToolStripMenuItem.Click += new System.EventHandler(this.eliminarProfesionalToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirAlMenuPrincipalToolStripMenuItem,
            this.salirDeAplicaciónToolStripMenuItem});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // salirAlMenuPrincipalToolStripMenuItem
            // 
            this.salirAlMenuPrincipalToolStripMenuItem.Name = "salirAlMenuPrincipalToolStripMenuItem";
            this.salirAlMenuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.salirAlMenuPrincipalToolStripMenuItem.Text = "Volver al Menú Principal";
            this.salirAlMenuPrincipalToolStripMenuItem.Click += new System.EventHandler(this.salirAlMenuPrincipalToolStripMenuItem_Click);
            // 
            // salirDeAplicaciónToolStripMenuItem
            // 
            this.salirDeAplicaciónToolStripMenuItem.Name = "salirDeAplicaciónToolStripMenuItem";
            this.salirDeAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.salirDeAplicaciónToolStripMenuItem.Text = "Salir de Aplicación";
            this.salirDeAplicaciónToolStripMenuItem.Click += new System.EventHandler(this.salirDeAplicaciónToolStripMenuItem_Click);
            // 
            // ProfesionalABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProfesionalABM";
            this.Text = "ABM Profesionales";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem acciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirAlMenuPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDeAplicaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProfesionalToolStripMenuItem;
    }
}