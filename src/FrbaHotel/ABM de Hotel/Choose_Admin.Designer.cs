namespace FrbaHotel.ABM_de_Hotel
{
    partial class Choose_Admin
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
            this.button_Accept = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_Prompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Accept
            // 
            this.button_Accept.Location = new System.Drawing.Point(95, 67);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(75, 23);
            this.button_Accept.TabIndex = 5;
            this.button_Accept.Text = "Aceptar";
            this.button_Accept.UseVisualStyleBackColor = true;
            this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label_Prompt
            // 
            this.label_Prompt.AutoSize = true;
            this.label_Prompt.Location = new System.Drawing.Point(11, 7);
            this.label_Prompt.Name = "label_Prompt";
            this.label_Prompt.Size = new System.Drawing.Size(0, 13);
            this.label_Prompt.TabIndex = 3;
            this.label_Prompt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choose_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 97);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_Prompt);
            this.Name = "Choose_Admin";
            this.Text = "Choose_Admin";
            this.Load += new System.EventHandler(this.Choose_Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Prompt;
    }
}