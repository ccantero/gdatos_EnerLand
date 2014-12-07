using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.Facturar
{
    public class CreditCard
    {
        public string Titular;
        public string Numero_Tarjeta;
        public int MesVencimiento;
        public int AnioVencimiento;
        public int Cod_Seguridad;

        public CreditCard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Titular = String.Empty;
            Numero_Tarjeta = String.Empty;
            MesVencimiento = 0;
            AnioVencimiento = 0;
            Cod_Seguridad = -1;
        }

    }
}
