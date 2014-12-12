namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class Dialog_Form
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
            this.label_Prompt = new System.Windows.Forms.Label();
            this.Textbox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Prompt
            // 
            this.label_Prompt.AutoSize = true;
            this.label_Prompt.Location = new System.Drawing.Point(13, 11);
            this.label_Prompt.Name = "label_Prompt";
            this.label_Prompt.Size = new System.Drawing.Size(35, 13);
            this.label_Prompt.TabIndex = 3;
            this.label_Prompt.Text = "label1";
            // 
            // Textbox
            // 
            this.Textbox.Location = new System.Drawing.Point(12, 43);
            this.Textbox.MaxLength = 50;
            this.Textbox.Name = "Textbox";
            this.Textbox.Size = new System.Drawing.Size(259, 90);
            this.Textbox.TabIndex = 2;
            this.Textbox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dialog_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Prompt);
            this.Controls.Add(this.Textbox);
            this.Name = "Dialog_Form";
            this.Text = "Dialog_Form";
            this.Load += new System.EventHandler(this.Dialog_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Prompt;
        private System.Windows.Forms.RichTextBox Textbox;
        private System.Windows.Forms.Button button1;
    }
}