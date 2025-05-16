using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Enum
    {
        public enum TipoMovimiento
        {
            Transferencia,
            Deposito,
            Retiro
        }
        public enum TipoCuenta
        {
            BTC,
            ETH,
            USDT
        }
    }
}
