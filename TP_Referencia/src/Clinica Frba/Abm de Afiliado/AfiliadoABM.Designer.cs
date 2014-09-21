namespace Clinica_Frba.Afiliado
{
    partial class AfiliadoABM
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
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverAlMenuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDeLaAplicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarAfiliadoToolStripMenuItem,
            this.modificarAfiliadoToolStripMenuItem,
            this.eliminarAfiliadoToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // agregarAfiliadoToolStripMenuItem
            // 
            this.agregarAfiliadoToolStripMenuItem.Name = "agregarAfiliadoToolStripMenuItem";
            this.agregarAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarAfiliadoToolStripMenuItem.Text = "Agregar Afiliado";
            this.agregarAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.agregarAfiliadoToolStripMenuItem_Click);
            // 
            // modificarAfiliadoToolStripMenuItem
            // 
            this.modificarAfiliadoToolStripMenuItem.Name = "modificarAfiliadoToolStripMenuItem";
            this.modificarAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modificarAfiliadoToolStripMenuItem.Text = "Modificar Afiliado";
            this.modificarAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.modificarAfiliadoToolStripMenuItem_Click);
            // 
            // eliminarAfiliadoToolStripMenuItem
            // 
            this.eliminarAfiliadoToolStripMenuItem.Name = "eliminarAfiliadoToolStripMenuItem";
            this.eliminarAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.eliminarAfiliadoToolStripMenuItem.Text = "Eliminar Afiliado";
            this.eliminarAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.eliminarAfiliadoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverAlMenuPrincipalToolStripMenuItem,
            this.salirDeLaAplicacionToolStripMenuItem});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // volverAlMenuPrincipalToolStripMenuItem
            // 
            this.volverAlMenuPrincipalToolStripMenuItem.Name = "volverAlMenuPrincipalToolStripMenuItem";
            this.volverAlMenuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.volverAlMenuPrincipalToolStripMenuItem.Text = "Volver al Menu Principal";
            this.volverAlMenuPrincipalToolStripMenuItem.Click += new System.EventHandler(this.volverAlMenuPrincipalToolStripMenuItem_Click);
            // 
            // salirDeLaAplicacionToolStripMenuItem
            // 
            this.salirDeLaAplicacionToolStripMenuItem.Name = "salirDeLaAplicacionToolStripMenuItem";
            this.salirDeLaAplicacionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.salirDeLaAplicacionToolStripMenuItem.Text = "Salir de la Aplicacion";
            this.salirDeLaAplicacionToolStripMenuItem.Click += new System.EventHandler(this.salirDeLaAplicacionToolStripMenuItem_Click);
            // 
            // AfiliadoABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.FormClosing +=new System.Windows.Forms.FormClosingEventHandler(AfiliadoABM_FormClosing);
            this.Name = "AfiliadoABM";
            this.Text = "ABM Afiliados";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverAlMenuPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDeLaAplicacionToolStripMenuItem;

    }
}