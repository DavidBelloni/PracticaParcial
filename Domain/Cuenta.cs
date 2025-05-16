using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public abstract class Cuenta

    {
        public Guid idCuenta { get; set; }
        public decimal saldo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public TipoCuenta tipoCuenta { get; set; } 

    }
}
