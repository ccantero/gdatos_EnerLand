namespace FrbaHotel.ABM_de_Cliente
{
    partial class UserControl_Huesped
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Box_EstadoCivil = new System.Windows.Forms.ComboBox();
            this.Box_Genero = new System.Windows.Forms.ComboBox();
            this.Box_FecNac = new System.Windows.Forms.DateTimePicker();
            this.label_sexo = new System.Windows.Forms.Label();
            this.label_EstadoCivil = new System.Windows.Forms.Label();
            this.label_FecNac = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Box_TipoDoc = new System.Windows.Forms.ComboBox();
            this.label_TipoDoc = new System.Windows.Forms.Label();
            this.Box_Telefono = new System.Windows.Forms.TextBox();
            this.label_Telefono = new System.Windows.Forms.Label();
            this.Box_mail = new System.Windows.Forms.TextBox();
            this.label_mail = new System.Windows.Forms.Label();
            this.Box_Direccion = new System.Windows.Forms.TextBox();
            this.label_Direccion = new System.Windows.Forms.Label();
            this.Box_DNI = new System.Windows.Forms.TextBox();
            this.label_DNI = new System.Windows.Forms.Label();
            this.Box_Apellido = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.Box_Name = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Box_EstadoCivil);
            this.groupBox2.Controls.Add(this.Box_Genero);
            this.groupBox2.Controls.Add(this.Box_FecNac);
            this.groupBox2.Controls.Add(this.label_sexo);
            this.groupBox2.Controls.Add(this.label_EstadoCivil);
            this.groupBox2.Controls.Add(this.label_FecNac);
            this.groupBox2.Location = new System.Drawing.Point(3, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 136);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos  Generales";
            // 
            // Box_EstadoCivil
            // 
            this.Box_EstadoCivil.FormattingEnabled = true;
            this.Box_EstadoCivil.Location = new System.Drawing.Point(131, 58);
            this.Box_EstadoCivil.Name = "Box_EstadoCivil";
            this.Box_EstadoCivil.Size = new System.Drawing.Size(121, 21);
            this.Box_EstadoCivil.TabIndex = 12;
            // 
            // Box_Genero
            // 
            this.Box_Genero.FormattingEnabled = true;
            this.Box_Genero.Location = new System.Drawing.Point(131, 19);
            this.Box_Genero.Name = "Box_Genero";
            this.Box_Genero.Size = new System.Drawing.Size(121, 21);
            this.Box_Genero.TabIndex = 11;
            // 
            // Box_FecNac
            // 
            this.Box_FecNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Box_FecNac.Location = new System.Drawing.Point(131, 98);
            this.Box_FecNac.Name = "Box_FecNac";
            this.Box_FecNac.Size = new System.Drawing.Size(120, 20);
            this.Box_FecNac.TabIndex = 13;
            this.Box_FecNac.Value = new System.DateTime(2013, 11, 5, 0, 0, 0, 0);
            // 
            // label_sexo
            // 
            this.label_sexo.AutoSize = true;
            this.label_sexo.Location = new System.Drawing.Point(8, 22);
            this.label_sexo.Name = "label_sexo";
            this.label_sexo.Size = new System.Drawing.Size(31, 13);
            this.label_sexo.TabIndex = 10;
            this.label_sexo.Text = "Sexo";
            // 
            // label_EstadoCivil
            // 
            this.label_EstadoCivil.AutoSize = true;
            this.label_EstadoCivil.Location = new System.Drawing.Point(8, 61);
            this.label_EstadoCivil.Name = "label_EstadoCivil";
            this.label_EstadoCivil.Size = new System.Drawing.Size(62, 13);
            this.label_EstadoCivil.TabIndex = 6;
            this.label_EstadoCivil.Text = "Estado Civil";
            // 
            // label_FecNac
            // 
            this.label_FecNac.AutoSize = true;
            this.label_FecNac.Location = new System.Drawing.Point(7, 102);
            this.label_FecNac.Name = "label_FecNac";
            this.label_FecNac.Size = new System.Drawing.Size(108, 13);
            this.label_FecNac.TabIndex = 7;
            this.label_FecNac.Text = "Fecha de Nacimiento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Box_TipoDoc);
            this.groupBox1.Controls.Add(this.label_TipoDoc);
            this.groupBox1.Controls.Add(this.Box_Telefono);
            this.groupBox1.Controls.Add(this.label_Telefono);
            this.groupBox1.Controls.Add(this.Box_mail);
            this.groupBox1.Controls.Add(this.label_mail);
            this.groupBox1.Controls.Add(this.Box_Direccion);
            this.groupBox1.Controls.Add(this.label_Direccion);
            this.groupBox1.Controls.Add(this.Box_DNI);
            this.groupBox1.Controls.Add(this.label_DNI);
            this.groupBox1.Controls.Add(this.Box_Apellido);
            this.groupBox1.Controls.Add(this.label_Apellido);
            this.groupBox1.Controls.Add(this.Box_Name);
            this.groupBox1.Controls.Add(this.label_Nombre);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 251);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Contacto";
            // 
            // Box_TipoDoc
            // 
            this.Box_TipoDoc.FormattingEnabled = true;
            this.Box_TipoDoc.Location = new System.Drawing.Point(98, 91);
            this.Box_TipoDoc.Name = "Box_TipoDoc";
            this.Box_TipoDoc.Size = new System.Drawing.Size(150, 21);
            this.Box_TipoDoc.TabIndex = 4;
            // 
            // label_TipoDoc
            // 
            this.label_TipoDoc.AutoSize = true;
            this.label_TipoDoc.Location = new System.Drawing.Point(7, 94);
            this.label_TipoDoc.Name = "label_TipoDoc";
            this.label_TipoDoc.Size = new System.Drawing.Size(69, 13);
            this.label_TipoDoc.TabIndex = 14;
            this.label_TipoDoc.Text = "Tipo de Doc.";
            // 
            // Box_Telefono
            // 
            this.Box_Telefono.Location = new System.Drawing.Point(98, 218);
            this.Box_Telefono.Name = "Box_Telefono";
            this.Box_Telefono.Size = new System.Drawing.Size(150, 20);
            this.Box_Telefono.TabIndex = 15;
            // 
            // label_Telefono
            // 
            this.label_Telefono.AutoSize = true;
            this.label_Telefono.Location = new System.Drawing.Point(7, 221);
            this.label_Telefono.Name = "label_Telefono";
            this.label_Telefono.Size = new System.Drawing.Size(49, 13);
            this.label_Telefono.TabIndex = 12;
            this.label_Telefono.Text = "Telefono";
            // 
            // Box_mail
            // 
            this.Box_mail.Location = new System.Drawing.Point(98, 186);
            this.Box_mail.Name = "Box_mail";
            this.Box_mail.Size = new System.Drawing.Size(150, 20);
            this.Box_mail.TabIndex = 13;
            // 
            // label_mail
            // 
            this.label_mail.AutoSize = true;
            this.label_mail.Location = new System.Drawing.Point(7, 189);
            this.label_mail.Name = "label_mail";
            this.label_mail.Size = new System.Drawing.Size(26, 13);
            this.label_mail.TabIndex = 10;
            this.label_mail.Text = "Mail";
            // 
            // Box_Direccion
            // 
            this.Box_Direccion.Location = new System.Drawing.Point(98, 153);
            this.Box_Direccion.Name = "Box_Direccion";
            this.Box_Direccion.Size = new System.Drawing.Size(150, 20);
            this.Box_Direccion.TabIndex = 9;
            // 
            // label_Direccion
            // 
            this.label_Direccion.AutoSize = true;
            this.label_Direccion.Location = new System.Drawing.Point(7, 156);
            this.label_Direccion.Name = "label_Direccion";
            this.label_Direccion.Size = new System.Drawing.Size(52, 13);
            this.label_Direccion.TabIndex = 11;
            this.label_Direccion.Text = "Direccion";
            // 
            // Box_DNI
            // 
            this.Box_DNI.Location = new System.Drawing.Point(98, 120);
            this.Box_DNI.Name = "Box_DNI";
            this.Box_DNI.Size = new System.Drawing.Size(150, 20);
            this.Box_DNI.TabIndex = 8;
            // 
            // label_DNI
            // 
            this.label_DNI.AutoSize = true;
            this.label_DNI.Location = new System.Drawing.Point(7, 123);
            this.label_DNI.Name = "label_DNI";
            this.label_DNI.Size = new System.Drawing.Size(26, 13);
            this.label_DNI.TabIndex = 4;
            this.label_DNI.Text = "DNI";
            // 
            // Box_Apellido
            // 
            this.Box_Apellido.Location = new System.Drawing.Point(98, 56);
            this.Box_Apellido.Name = "Box_Apellido";
            this.Box_Apellido.Size = new System.Drawing.Size(150, 20);
            this.Box_Apellido.TabIndex = 3;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Location = new System.Drawing.Point(7, 59);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(44, 13);
            this.label_Apellido.TabIndex = 2;
            this.label_Apellido.Text = "Apellido";
            // 
            // Box_Name
            // 
            this.Box_Name.Location = new System.Drawing.Point(98, 26);
            this.Box_Name.Name = "Box_Name";
            this.Box_Name.Size = new System.Drawing.Size(150, 20);
            this.Box_Name.TabIndex = 1;
            // 
            // label_Nombre
            // 
            this.label_Nombre.Location = new System.Drawing.Point(7, 26);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(44, 13);
            this.label_Nombre.TabIndex = 0;
            this.label_Nombre.Text = "Nombre";
            // 
            // UserControl_Huesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_Huesped";
            this.Size = new System.Drawing.Size(377, 398);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox Box_EstadoCivil;
        private System.Windows.Forms.ComboBox Box_Genero;
        private System.Windows.Forms.DateTimePicker Box_FecNac;
        private System.Windows.Forms.Label label_sexo;
        private System.Windows.Forms.Label label_EstadoCivil;
        private System.Windows.Forms.Label label_FecNac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Box_TipoDoc;
        private System.Windows.Forms.Label label_TipoDoc;
        private System.Windows.Forms.TextBox Box_Telefono;
        private System.Windows.Forms.Label label_Telefono;
        private System.Windows.Forms.TextBox Box_mail;
        private System.Windows.Forms.Label label_mail;
        private System.Windows.Forms.TextBox Box_Direccion;
        private System.Windows.Forms.Label label_Direccion;
        private System.Windows.Forms.TextBox Box_DNI;
        private System.Windows.Forms.Label label_DNI;
        private System.Windows.Forms.TextBox Box_Apellido;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox Box_Name;
        private System.Windows.Forms.Label label_Nombre;
    }
}
