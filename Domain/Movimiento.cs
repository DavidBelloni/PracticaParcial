using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class Movimiento
    {
        public Cuenta Origen { get; set; }

        public Cuenta Destino { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        public decimal SaldoPrevio { get; set; }

        public decimal SaldoFinal { get; set; }

    }
}
