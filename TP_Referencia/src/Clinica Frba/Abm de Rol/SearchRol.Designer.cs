using System.Windows.Forms;
namespace Clinica_Frba.Abm_de_Rol
{
    partial class SearchRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rol_TextBox = new System.Windows.Forms.TextBox();
            this.RolLabel = new System.Windows.Forms.Label();
            this.CleanButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DataGrid_Roles = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Rol_TextBox);
            this.groupBox1.Controls.Add(this.RolLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // Rol_TextBox
            // 
            this.Rol_TextBox.Location = new System.Drawing.Point(48, 31);
            this.Rol_TextBox.Name = "Rol_TextBox";
            this.Rol_TextBox.Size = new System.Drawing.Size(205, 20);
            this.Rol_TextBox.TabIndex = 1;
            // 
            // RolLabel
            // 
            this.RolLabel.AutoSize = true;
            this.RolLabel.Location = new System.Drawing.Point(6, 34);
            this.RolLabel.Name = "RolLabel";
            this.RolLabel.Size = new System.Drawing.Size(23, 13);
            this.RolLabel.TabIndex = 0;
            this.RolLabel.Text = "Rol";
            // 
            // CleanButton
            // 
            this.CleanButton.Location = new System.Drawing.Point(22, 90);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(75, 23);
            this.CleanButton.TabIndex = 1;
            this.CleanButton.Text = "Limpiar";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(191, 90);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DataGrid_Roles
            // 
            this.DataGrid_Roles.AllowUserToAddRows = false;
            this.DataGrid_Roles.AllowUserToDeleteRows = false;
            #region Fit Data Grid
            this.DataGrid_Roles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGrid_Roles.BackgroundColor = this.BackColor;
            this.DataGrid_Roles.BorderStyle = BorderStyle.None;
            this.DataGrid_Roles.RowHeadersVisible = false;
            #endregion
            this.DataGrid_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Roles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_Roles_CellClick);
            this.DataGrid_Roles.Location = new System.Drawing.Point(13, 120);
            this.DataGrid_Roles.Name = "DataGrid_Roles";
            this.DataGrid_Roles.ReadOnly = true;          
            this.DataGrid_Roles.Size = new System.Drawing.Size(259, 150);
            this.DataGrid_Roles.TabIndex = 3;
            // 
            // SearchRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.DataGrid_Roles);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchRol";
            this.Text = "Buscar Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Roles)).EndInit();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchRol_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Rol_TextBox;
        private System.Windows.Forms.Label RolLabel;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView DataGrid_Roles;
    }
}