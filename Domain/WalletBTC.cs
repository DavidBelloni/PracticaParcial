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

        public WalletBTC() { }
        public WalletBTC(Cliente titular, string direccion, decimal saldoInicial = 0)
            : base(titular, TipoCuenta.BTC, saldoInicial)
        {
            Direccion = direccion;
        }
    }
}
