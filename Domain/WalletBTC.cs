using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WalletBTC : Cuenta
    {
        public string Direccion { get; set; }
        public string Tag { get; set; }

        public WalletBTC()
        {
            this.idCuenta = Guid.NewGuid();
            this.fechaCreacion = DateTime.Now;
        }   
    }
}
