namespace Clinica_Frba.bonoFarmacia
{
    partial class CompraBonoFarmacia
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
            this.codigoAfiliado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.planMedico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cantBonos = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cantBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // codigoAfiliado
            // 
            this.codigoAfiliado.Location = new System.Drawing.Point(124, 12);
            this.codigoAfiliado.Name = "codigoAfiliado";
            this.codigoAfiliado.ReadOnly = true;
            this.codigoAfiliado.Size = new System.Drawing.Size(125, 20);
            this.codigoAfiliado.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Código Afiliado:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Realizar Compra";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Plan Médico:";
            // 
            // planMedico
            // 
            this.planMedico.Location = new System.Drawing.Point(124, 50);
            this.planMedico.Name = "planMedico";
            this.planMedico.ReadOnly = true;
            this.planMedico.Size = new System.Drawing.Size(125, 20);
            this.planMedico.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cantidad de Bonos:";
            // 
            // cantBonos
            // 
            this.cantBonos.Location = new System.Drawing.Point(124, 95);
            this.cantBonos.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.cantBonos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantBonos.Name = "cantBonos";
            this.cantBonos.Size = new System.Drawing.Size(125, 20);
            this.cantBonos.TabIndex = 15;
            this.cantBonos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CompraBonoFarmacia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 185);
            this.Controls.Add(this.cantBonos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.planMedico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codigoAfiliado);
            this.Name = "CompraBonoFarmacia";
            this.Text = "Compra Bono Farmacia";
            ((System.ComponentModel.ISupportInitialize)(this.cantBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigoAfiliado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox planMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cantBonos;
    }
}