using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();

    }
}
