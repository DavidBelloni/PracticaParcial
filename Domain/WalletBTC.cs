using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class WalletBTC : Cuenta
    {
        public string Direccion { get; set; }
        public string Tag { get; set; }

        public WalletBTC() 
        {
            Saldo = 0;
            // Direccion Generada Aleatoriamente
            Direccion = Guid.NewGuid().ToString().Substring(0, 20);
        }
    }
}
