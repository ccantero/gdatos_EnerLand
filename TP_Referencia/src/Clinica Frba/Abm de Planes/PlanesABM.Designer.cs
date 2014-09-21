namespace Clinica_Frba.Planes
{
    partial class PlanesABM
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.abmPlanes_FormClosing);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.acciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarPlanesMédicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverAlMenúPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mostrarPlanesMédicosToolStripMenuItem});
            this.acciónToolStripMenuItem.Name = "acciónToolStripMenuItem";
            this.acciónToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.acciónToolStripMenuItem.Text = "Acción";
            // 
            // mostrarPlanesMédicosToolStripMenuItem
            // 
            this.mostrarPlanesMédicosToolStripMenuItem.Name = "mostrarPlanesMédicosToolStripMenuItem";
            this.mostrarPlanesMédicosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.mostrarPlanesMédicosToolStripMenuItem.Text = "Mostrar Planes Médicos";
            this.mostrarPlanesMédicosToolStripMenuItem.Click += new System.EventHandler(this.mostrarPlanesMédicosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverAlMenúPrincipalToolStripMenuItem,
            this.salirDeAplicaciónToolStripMenuItem});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // volverAlMenúPrincipalToolStripMenuItem
            // 
            this.volverAlMenúPrincipalToolStripMenuItem.Name = "volverAlMenúPrincipalToolStripMenuItem";
            this.volverAlMenúPrincipalToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.volverAlMenúPrincipalToolStripMenuItem.Text = "Volver al Menú Principal";
            this.volverAlMenúPrincipalToolStripMenuItem.Click += new System.EventHandler(this.volverAlMenúPrincipalToolStripMenuItem_Click);
            // 
            // salirDeAplicaciónToolStripMenuItem
            // 
            this.salirDeAplicaciónToolStripMenuItem.Name = "salirDeAplicaciónToolStripMenuItem";
            this.salirDeAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.salirDeAplicaciónToolStripMenuItem.Text = "Salir de Aplicación";
            this.salirDeAplicaciónToolStripMenuItem.Click += new System.EventHandler(this.salirDeAplicaciónToolStripMenuItem_Click);
            // 
            // PlanesABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlanesABM";
            this.Text = "ABM Planes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem acciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarPlanesMédicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverAlMenúPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDeAplicaciónToolStripMenuItem;
    }
}