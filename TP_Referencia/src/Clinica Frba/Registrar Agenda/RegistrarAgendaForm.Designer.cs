using System.Windows.Forms;
namespace Clinica_Frba.RegistrarAgenda
{
    partial class RegistrarAgendaForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_clean = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_fecIni = new System.Windows.Forms.Label();
            this.box_fecini = new System.Windows.Forms.DateTimePicker();
            this.label_fecFin = new System.Windows.Forms.Label();
            this.box_fecfin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 600);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_clean
            // 
            this.button_clean.Location = new System.Drawing.Point(75, 679);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(75, 23);
            this.button_clean.TabIndex = 1;
            this.button_clean.Text = "Clean";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(428, 679);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Guardar";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_fecIni
            // 
            this.label_fecIni.AutoSize = true;
            this.label_fecIni.Location = new System.Drawing.Point(12, 28);
            this.label_fecIni.Name = "label_fecIni";
            this.label_fecIni.Size = new System.Drawing.Size(65, 13);
            this.label_fecIni.TabIndex = 3;
            this.label_fecIni.Text = "Fecha Inicio";
            // 
            // box_fecini
            // 
            this.box_fecini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.box_fecini.Location = new System.Drawing.Point(94, 22);
            this.box_fecini.Name = "box_fecini";
            this.box_fecini.Size = new System.Drawing.Size(95, 20);
            this.box_fecini.TabIndex = 4;
            // 
            // label_fecFin
            // 
            this.label_fecFin.AutoSize = true;
            this.label_fecFin.Location = new System.Drawing.Point(312, 28);
            this.label_fecFin.Name = "label_fecFin";
            this.label_fecFin.Size = new System.Drawing.Size(54, 13);
            this.label_fecFin.TabIndex = 5;
            this.label_fecFin.Text = "Fecha Fin";
            // 
            // box_fecfin
            // 
            this.box_fecfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.box_fecfin.Location = new System.Drawing.Point(392, 21);
            this.box_fecfin.Name = "box_fecfin";
            this.box_fecfin.Size = new System.Drawing.Size(150, 20);
            this.box_fecfin.TabIndex = 6;
            // 
            // RegistrarAgendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 713);
            this.Controls.Add(this.box_fecfin);
            this.Controls.Add(this.label_fecFin);
            this.Controls.Add(this.box_fecini);
            this.Controls.Add(this.label_fecIni);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.dataGridView1);
            this.FormClosing +=new FormClosingEventHandler(RegistrarAgendaForm_FormClosing);
            
            this.Name = "RegistrarAgendaForm";
            this.Text = "Registrar Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button_clean;
        private Button button_save;
        private Label label_fecIni;
        private DateTimePicker box_fecini;
        private Label label_fecFin;
        private DateTimePicker box_fecfin;

    }
}