using System.Windows.Forms;
using System;
namespace Clinica_Frba.Abm_de_Rol
{
    partial class AddModRol
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.FuncionalidadesCheckList = new System.Windows.Forms.CheckedListBox();
            this.CleanButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FuncionalidadesLabel = new System.Windows.Forms.Label();
            this.label_activo = new System.Windows.Forms.Label();
            this.box_checkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(15, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(80, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Nombre del Rol";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(105, 12);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(195, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // FuncionalidadesCheckList
            // 
            this.FuncionalidadesCheckList.FormattingEnabled = true;
            this.FuncionalidadesCheckList.Location = new System.Drawing.Point(105, 55);
            this.FuncionalidadesCheckList.Name = "FuncionalidadesCheckList";
            this.FuncionalidadesCheckList.Size = new System.Drawing.Size(195, 154);
            this.FuncionalidadesCheckList.TabIndex = 1;
            // 
            // CleanButton
            // 
            this.CleanButton.Location = new System.Drawing.Point(12, 262);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(75, 23);
            this.CleanButton.TabIndex = 2;
            this.CleanButton.Text = "Limpiar";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(232, 262);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FuncionalidadesLabel
            // 
            this.FuncionalidadesLabel.AutoSize = true;
            this.FuncionalidadesLabel.Location = new System.Drawing.Point(15, 55);
            this.FuncionalidadesLabel.Name = "FuncionalidadesLabel";
            this.FuncionalidadesLabel.Size = new System.Drawing.Size(84, 13);
            this.FuncionalidadesLabel.TabIndex = 4;
            this.FuncionalidadesLabel.Text = "Funcionalidades";
            // 
            // label_activo
            // 
            this.label_activo.AutoSize = true;
            this.label_activo.Location = new System.Drawing.Point(15, 229);
            this.label_activo.Name = "label_activo";
            this.label_activo.Size = new System.Drawing.Size(56, 13);
            this.label_activo.TabIndex = 6;
            this.label_activo.Text = "Rol Activo";
            // 
            // box_checkActive
            // 
            this.box_checkActive.AutoSize = true;
            this.box_checkActive.Location = new System.Drawing.Point(105, 228);
            this.box_checkActive.Name = "box_checkActive";
            this.box_checkActive.Size = new System.Drawing.Size(15, 14);
            this.box_checkActive.TabIndex = 7;
            this.box_checkActive.UseVisualStyleBackColor = true;
            // 
            // AddModRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormClosing += new FormClosingEventHandler(AddModRol_FormClosing);
            this.ClientSize = new System.Drawing.Size(319, 300);
            this.Controls.Add(this.box_checkActive);
            this.Controls.Add(this.label_activo);
            this.Controls.Add(this.FuncionalidadesLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.FuncionalidadesCheckList);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.SaveButton);
            this.Name = "AddModRol";
            this.Text = "ABM Roles - Agregar un Rol";
            this.Load += new System.EventHandler(this.AddModRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.CheckedListBox FuncionalidadesCheckList;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label FuncionalidadesLabel;
        private Label label_activo;
        private CheckBox box_checkActive;

    
    
    }

    
}