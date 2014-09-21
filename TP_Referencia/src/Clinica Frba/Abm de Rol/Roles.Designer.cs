namespace Clinica_Frba.Abm_de_Rol
{
    partial class Rol_Form
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
            this.agregarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverAlMenúPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarRolToolStripMenuItem,
            this.modificarRolToolStripMenuItem,
            this.eliminarRolToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // agregarRolToolStripMenuItem
            // 
            this.agregarRolToolStripMenuItem.Name = "agregarRolToolStripMenuItem";
            this.agregarRolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarRolToolStripMenuItem.Text = "Agregar Rol";
            this.agregarRolToolStripMenuItem.Click += new System.EventHandler(this.agregarRolToolStripMenuItem_Click);
            // 
            // modificarRolToolStripMenuItem
            // 
            this.modificarRolToolStripMenuItem.Name = "modificarRolToolStripMenuItem";
            this.modificarRolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarRolToolStripMenuItem.Text = "Modificar Rol";
            this.modificarRolToolStripMenuItem.Click += new System.EventHandler(this.modificarRolToolStripMenuItem_Click);
            // 
            // eliminarRolToolStripMenuItem
            // 
            this.eliminarRolToolStripMenuItem.Name = "eliminarRolToolStripMenuItem";
            this.eliminarRolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarRolToolStripMenuItem.Text = "Eliminar Rol";
            this.eliminarRolToolStripMenuItem.Click += new System.EventHandler(this.eliminarRolToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverAlMenúPrincipalToolStripMenuItem,
            this.salirToolStripMenuItem1});
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
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.salirToolStripMenuItem1.Text = "Salir del Programa";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // Rol_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rol_Form_FormClosing);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Rol_Form";
            this.Text = "ABM Roles";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverAlMenúPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;

    }
}