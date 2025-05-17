using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Enum
    {
        public enum TipoOperacion
        {
            Transferencia,
            Deposito,
            Conversion
        }
        public enum TipoCuenta
        {
            CA,
            BTC

        }
    }
}
