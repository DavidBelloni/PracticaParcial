using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class CajaAhorro : Cuenta
    {
       public string CUIT { get; set; } 

       public string CBU { get; set; }

       public string Alias { get; set; }

        public CajaAhorro() { }
        public CajaAhorro(Cliente titular, string cbu, string cuit, decimal saldoInicial = 0)
            : base(titular, TipoCuenta.CA, saldoInicial)
        {
            CBU = cbu;
            CUIT = cuit;
        }
    }
}
