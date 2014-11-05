namespace FrbaHotel.ABM_de_Cliente
{
    partial class GestionHuesped
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
            this.agregarHuéspedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarHuéspedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarHuéspedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // acciónToolStripMenuItem
            // 
            this.acciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarHuéspedToolStripMenuItem,
            this.modificarHuéspedToolStripMenuItem,
            this.eliminarHuéspedToolStripMenuItem});
            this.acciónToolStripMenuItem.Name = "acciónToolStripMenuItem";
            this.acciónToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.acciónToolStripMenuItem.Text = "Acción";
            // 
            // agregarHuéspedToolStripMenuItem
            // 
            this.agregarHuéspedToolStripMenuItem.Name = "agregarHuéspedToolStripMenuItem";
            this.agregarHuéspedToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.agregarHuéspedToolStripMenuItem.Text = "Agregar Huésped";
            // 
            // modificarHuéspedToolStripMenuItem
            // 
            this.modificarHuéspedToolStripMenuItem.Name = "modificarHuéspedToolStripMenuItem";
            this.modificarHuéspedToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.modificarHuéspedToolStripMenuItem.Text = "Modificar Huésped";
            // 
            // eliminarHuéspedToolStripMenuItem
            // 
            this.eliminarHuéspedToolStripMenuItem.Name = "eliminarHuéspedToolStripMenuItem";
            this.eliminarHuéspedToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.eliminarHuéspedToolStripMenuItem.Text = "Eliminar Huésped";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // GestionHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 437);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GestionHuesped";
            this.Text = "Gestion Huéspedes";
            this.Load += new System.EventHandler(this.GestionHuesped_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GestionHuesped_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem acciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarHuéspedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarHuéspedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarHuéspedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}