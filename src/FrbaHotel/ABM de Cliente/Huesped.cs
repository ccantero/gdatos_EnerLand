using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.ABM_de_Cliente
{
    public class Huesped
    {
        // Variables de Instancia
        public int idHuesped;
        public string Tipo_Documento;
        public int Nro_Documento;
        public string Nombre;
        public string Apellido;
        public string Mail;
        public int Telefono;
        public string Calle;
        public int Numero;
        public int Piso;
        public char Departamento;
        public int idLocalidad;
        public DateTime Fecha_Nacimiento;
        public int idPais;
        public string Nacionalidad;
        public Boolean Habilitado;

        public Huesped()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            idHuesped = -1;
            Tipo_Documento = "";
            Nro_Documento = -1;
            Nombre = "";
            Apellido = "";
            Calle = "";
            Numero = -1;
            Piso = -1;
            Departamento = '\0';
            Telefono = 0;
            Mail = "";
            idLocalidad = -1;
            idPais = -1;
            Fecha_Nacimiento = DateTime.Today;
            Nacionalidad = "Argentina";
            Habilitado = false;
        }
    }
}
