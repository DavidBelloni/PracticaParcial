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
        public Guid IdCuenta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public TipoCuenta TipoCuenta { get; set; } 
        public Cliente Titular { get; set; }

        protected Cuenta() 
        {
            IdCuenta = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
        }

    }
}
