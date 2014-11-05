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
            this.textBox_PaisOrigen = new System.Windows.Forms.TextBox();
            this.Box_FecNac = new System.Windows.Forms.DateTimePicker();
            this.label_PaisOrigen = new System.Windows.Forms.Label();
            this.label_FecNac = new System.Windows.Forms.Label();
            this.label_Nacionalidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Nacionalidad = new System.Windows.Forms.TextBox();
            this.label_Localidad = new System.Windows.Forms.Label();
            this.textBox_Localidad = new System.Windows.Forms.TextBox();
            this.label_Departamento = new System.Windows.Forms.Label();
            this.label_Piso = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_Piso = new System.Windows.Forms.TextBox();
            this.textBox_Numero = new System.Windows.Forms.TextBox();
            this.label_Altura = new System.Windows.Forms.Label();
            this.ComboBox_TipoDoc = new System.Windows.Forms.ComboBox();
            this.label_TipoDoc = new System.Windows.Forms.Label();
            this.textBox_Telefono = new System.Windows.Forms.TextBox();
            this.label_Telefono = new System.Windows.Forms.Label();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.label_mail = new System.Windows.Forms.Label();
            this.textBox_Calle = new System.Windows.Forms.TextBox();
            this.label_Calle = new System.Windows.Forms.Label();
            this.textBox_DNI = new System.Windows.Forms.TextBox();
            this.label_NroDocumento = new System.Windows.Forms.Label();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label_Apellido = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_PaisOrigen);
            this.groupBox2.Controls.Add(this.Box_FecNac);
            this.groupBox2.Controls.Add(this.label_PaisOrigen);
            this.groupBox2.Controls.Add(this.label_FecNac);
            this.groupBox2.Location = new System.Drawing.Point(4, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 98);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos  Generales";
            // 
            // textBox_PaisOrigen
            // 
            this.textBox_PaisOrigen.Location = new System.Drawing.Point(131, 22);
            this.textBox_PaisOrigen.Name = "textBox_PaisOrigen";
            this.textBox_PaisOrigen.Size = new System.Drawing.Size(171, 20);
            this.textBox_PaisOrigen.TabIndex = 25;
            // 
            // Box_FecNac
            // 
            this.Box_FecNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Box_FecNac.Location = new System.Drawing.Point(131, 61);
            this.Box_FecNac.Name = "Box_FecNac";
            this.Box_FecNac.Size = new System.Drawing.Size(120, 20);
            this.Box_FecNac.TabIndex = 13;
            this.Box_FecNac.Value = new System.DateTime(2013, 11, 5, 0, 0, 0, 0);
            // 
            // label_PaisOrigen
            // 
            this.label_PaisOrigen.AutoSize = true;
            this.label_PaisOrigen.Location = new System.Drawing.Point(8, 22);
            this.label_PaisOrigen.Name = "label_PaisOrigen";
            this.label_PaisOrigen.Size = new System.Drawing.Size(76, 13);
            this.label_PaisOrigen.TabIndex = 10;
            this.label_PaisOrigen.Text = "Pais de Origen";
            // 
            // label_FecNac
            // 
            this.label_FecNac.AutoSize = true;
            this.label_FecNac.Location = new System.Drawing.Point(8, 67);
            this.label_FecNac.Name = "label_FecNac";
            this.label_FecNac.Size = new System.Drawing.Size(108, 13);
            this.label_FecNac.TabIndex = 7;
            this.label_FecNac.Text = "Fecha de Nacimiento";
            // 
            // label_Nacionalidad
            // 
            this.label_Nacionalidad.AutoSize = true;
            this.label_Nacionalidad.Location = new System.Drawing.Point(7, 186);
            this.label_Nacionalidad.Name = "label_Nacionalidad";
            this.label_Nacionalidad.Size = new System.Drawing.Size(69, 13);
            this.label_Nacionalidad.TabIndex = 6;
            this.label_Nacionalidad.Text = "Nacionalidad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Nacionalidad);
            this.groupBox1.Controls.Add(this.label_Localidad);
            this.groupBox1.Controls.Add(this.textBox_Localidad);
            this.groupBox1.Controls.Add(this.label_Departamento);
            this.groupBox1.Controls.Add(this.label_Piso);
            this.groupBox1.Controls.Add(this.label_Nacionalidad);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox_Piso);
            this.groupBox1.Controls.Add(this.textBox_Numero);
            this.groupBox1.Controls.Add(this.label_Altura);
            this.groupBox1.Controls.Add(this.ComboBox_TipoDoc);
            this.groupBox1.Controls.Add(this.label_TipoDoc);
            this.groupBox1.Controls.Add(this.textBox_Telefono);
            this.groupBox1.Controls.Add(this.label_Telefono);
            this.groupBox1.Controls.Add(this.textBox_mail);
            this.groupBox1.Controls.Add(this.label_mail);
            this.groupBox1.Controls.Add(this.textBox_Calle);
            this.groupBox1.Controls.Add(this.label_Calle);
            this.groupBox1.Controls.Add(this.textBox_DNI);
            this.groupBox1.Controls.Add(this.label_NroDocumento);
            this.groupBox1.Controls.Add(this.textBox_Apellido);
            this.groupBox1.Controls.Add(this.label_Apellido);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label_Nombre);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 459);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Contacto";
            // 
            // textBox_Nacionalidad
            // 
            this.textBox_Nacionalidad.Location = new System.Drawing.Point(103, 183);
            this.textBox_Nacionalidad.Name = "textBox_Nacionalidad";
            this.textBox_Nacionalidad.Size = new System.Drawing.Size(200, 20);
            this.textBox_Nacionalidad.TabIndex = 26;
            // 
            // label_Localidad
            // 
            this.label_Localidad.AutoSize = true;
            this.label_Localidad.Location = new System.Drawing.Point(6, 342);
            this.label_Localidad.Name = "label_Localidad";
            this.label_Localidad.Size = new System.Drawing.Size(53, 13);
            this.label_Localidad.TabIndex = 24;
            this.label_Localidad.Text = "Localidad";
            // 
            // textBox_Localidad
            // 
            this.textBox_Localidad.Location = new System.Drawing.Point(102, 339);
            this.textBox_Localidad.Name = "textBox_Localidad";
            this.textBox_Localidad.Size = new System.Drawing.Size(199, 20);
            this.textBox_Localidad.TabIndex = 23;
            // 
            // label_Departamento
            // 
            this.label_Departamento.AutoSize = true;
            this.label_Departamento.Location = new System.Drawing.Point(172, 303);
            this.label_Departamento.Name = "label_Departamento";
            this.label_Departamento.Size = new System.Drawing.Size(74, 13);
            this.label_Departamento.TabIndex = 22;
            this.label_Departamento.Text = "Departamento";
            // 
            // label_Piso
            // 
            this.label_Piso.AutoSize = true;
            this.label_Piso.Location = new System.Drawing.Point(6, 303);
            this.label_Piso.Name = "label_Piso";
            this.label_Piso.Size = new System.Drawing.Size(27, 13);
            this.label_Piso.TabIndex = 21;
            this.label_Piso.Text = "Piso";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(252, 300);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 20;
            // 
            // textBox_Piso
            // 
            this.textBox_Piso.Location = new System.Drawing.Point(102, 300);
            this.textBox_Piso.Name = "textBox_Piso";
            this.textBox_Piso.Size = new System.Drawing.Size(50, 20);
            this.textBox_Piso.TabIndex = 19;
            // 
            // textBox_Numero
            // 
            this.textBox_Numero.Location = new System.Drawing.Point(102, 261);
            this.textBox_Numero.Name = "textBox_Numero";
            this.textBox_Numero.Size = new System.Drawing.Size(200, 20);
            this.textBox_Numero.TabIndex = 17;
            // 
            // label_Altura
            // 
            this.label_Altura.AutoSize = true;
            this.label_Altura.Location = new System.Drawing.Point(7, 264);
            this.label_Altura.Name = "label_Altura";
            this.label_Altura.Size = new System.Drawing.Size(34, 13);
            this.label_Altura.TabIndex = 16;
            this.label_Altura.Text = "Altura";
            // 
            // ComboBox_TipoDoc
            // 
            this.ComboBox_TipoDoc.FormattingEnabled = true;
            this.ComboBox_TipoDoc.Location = new System.Drawing.Point(103, 104);
            this.ComboBox_TipoDoc.Name = "ComboBox_TipoDoc";
            this.ComboBox_TipoDoc.Size = new System.Drawing.Size(200, 21);
            this.ComboBox_TipoDoc.TabIndex = 4;
            // 
            // label_TipoDoc
            // 
            this.label_TipoDoc.AutoSize = true;
            this.label_TipoDoc.Location = new System.Drawing.Point(7, 107);
            this.label_TipoDoc.Name = "label_TipoDoc";
            this.label_TipoDoc.Size = new System.Drawing.Size(69, 13);
            this.label_TipoDoc.TabIndex = 14;
            this.label_TipoDoc.Text = "Tipo de Doc.";
            // 
            // textBox_Telefono
            // 
            this.textBox_Telefono.Location = new System.Drawing.Point(102, 417);
            this.textBox_Telefono.Name = "textBox_Telefono";
            this.textBox_Telefono.Size = new System.Drawing.Size(201, 20);
            this.textBox_Telefono.TabIndex = 15;
            // 
            // label_Telefono
            // 
            this.label_Telefono.AutoSize = true;
            this.label_Telefono.Location = new System.Drawing.Point(6, 420);
            this.label_Telefono.Name = "label_Telefono";
            this.label_Telefono.Size = new System.Drawing.Size(49, 13);
            this.label_Telefono.TabIndex = 12;
            this.label_Telefono.Text = "Telefono";
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(103, 378);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(200, 20);
            this.textBox_mail.TabIndex = 13;
            // 
            // label_mail
            // 
            this.label_mail.AutoSize = true;
            this.label_mail.Location = new System.Drawing.Point(7, 381);
            this.label_mail.Name = "label_mail";
            this.label_mail.Size = new System.Drawing.Size(26, 13);
            this.label_mail.TabIndex = 10;
            this.label_mail.Text = "Mail";
            // 
            // textBox_Calle
            // 
            this.textBox_Calle.Location = new System.Drawing.Point(102, 222);
            this.textBox_Calle.Name = "textBox_Calle";
            this.textBox_Calle.Size = new System.Drawing.Size(200, 20);
            this.textBox_Calle.TabIndex = 9;
            // 
            // label_Calle
            // 
            this.label_Calle.AutoSize = true;
            this.label_Calle.Location = new System.Drawing.Point(7, 225);
            this.label_Calle.Name = "label_Calle";
            this.label_Calle.Size = new System.Drawing.Size(30, 13);
            this.label_Calle.TabIndex = 11;
            this.label_Calle.Text = "Calle";
            // 
            // textBox_DNI
            // 
            this.textBox_DNI.Location = new System.Drawing.Point(103, 144);
            this.textBox_DNI.Name = "textBox_DNI";
            this.textBox_DNI.Size = new System.Drawing.Size(200, 20);
            this.textBox_DNI.TabIndex = 8;
            // 
            // label_NroDocumento
            // 
            this.label_NroDocumento.AutoSize = true;
            this.label_NroDocumento.Location = new System.Drawing.Point(7, 147);
            this.label_NroDocumento.Name = "label_NroDocumento";
            this.label_NroDocumento.Size = new System.Drawing.Size(90, 13);
            this.label_NroDocumento.TabIndex = 4;
            this.label_NroDocumento.Text = "Núm. Documento";
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Location = new System.Drawing.Point(103, 65);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(200, 20);
            this.textBox_Apellido.TabIndex = 3;
            // 
            // label_Apellido
            // 
            this.label_Apellido.AutoSize = true;
            this.label_Apellido.Location = new System.Drawing.Point(7, 68);
            this.label_Apellido.Name = "label_Apellido";
            this.label_Apellido.Size = new System.Drawing.Size(44, 13);
            this.label_Apellido.TabIndex = 2;
            this.label_Apellido.Text = "Apellido";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(103, 26);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(200, 20);
            this.textBox_Name.TabIndex = 1;
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
            this.Size = new System.Drawing.Size(330, 571);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker Box_FecNac;
        private System.Windows.Forms.Label label_PaisOrigen;
        private System.Windows.Forms.Label label_Nacionalidad;
        private System.Windows.Forms.Label label_FecNac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboBox_TipoDoc;
        private System.Windows.Forms.Label label_TipoDoc;
        private System.Windows.Forms.TextBox textBox_Telefono;
        private System.Windows.Forms.Label label_Telefono;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label_mail;
        private System.Windows.Forms.TextBox textBox_Calle;
        private System.Windows.Forms.Label label_Calle;
        private System.Windows.Forms.TextBox textBox_DNI;
        private System.Windows.Forms.Label label_NroDocumento;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label_Apellido;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.TextBox textBox_Numero;
        private System.Windows.Forms.Label label_Altura;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_Piso;
        private System.Windows.Forms.Label label_Departamento;
        private System.Windows.Forms.Label label_Piso;
        private System.Windows.Forms.TextBox textBox_PaisOrigen;
        private System.Windows.Forms.TextBox textBox_Nacionalidad;
        private System.Windows.Forms.Label label_Localidad;
        private System.Windows.Forms.TextBox textBox_Localidad;
    }
}
