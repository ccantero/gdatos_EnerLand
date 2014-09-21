using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Afiliado
{

    public class Afiliado
    {
        public int Cod_Afiliado; // Update
        public int Cod_PlanMedico; // Alta + Update
        public string Nombre; //Alta
        public string Apellido; //Alta 
        public string Tipo_Documento; //Alta + Update
        public int Numero_Documento; //Alta + Update
        public string Direccion; //Alta + Update
        public int Telefono; //Alta + Update
        public string Mail; //Alta + Update
        public DateTime Fecha_Nac; //Alta
        public char Sexo; //Alta + Update
        public string Estado_Civil; //Alta + Update
        public int CantFamiliaresACargo; //Alta + Update
        public bool Active;
        public DateTime Fecha_Baja;
    
        public Afiliado()
        {
            InitializeComponent();        
        }

        private void InitializeComponent()
        {
            Cod_Afiliado = -1;
            Nombre = "";
            Apellido = "";
            Cod_PlanMedico = -1;
            Tipo_Documento = "";
            Numero_Documento = -1;
            Direccion = "";
            Telefono = 0;
            Sexo = '\0';
            Estado_Civil = "";
            Mail = "";
            Fecha_Baja = DateTime.Today;
            CantFamiliaresACargo = 0;
            Active = false;
        }


    }
}
