using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Domain.Enum;

namespace Domain
{
    public class Operacion
    {
        public Cuenta Origen { get; set; }

        public Cuenta Destino { get; set; }

        public TipoOperacion TipoOperacion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Operacion() { }

        public Operacion(Guid origen, Guid destino, decimal montoOperacion, TipoOperacion tipo)
        {
            Origen = origen;
            Destino = destino;
            Monto = montoOperacion;
            TipoOperacion = tipo;
            Fecha = DateTime.Now;
        }
    }
}
