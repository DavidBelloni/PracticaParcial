using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CajaAhorro : Cuenta
    {
       public string CUIT { get; set; } 

       public string CBU { get; set; }

       public string Alias { get; set; }

        public CajaAhorro()
        {
            idCuenta = Guid.NewGuid();
            fechaCreacion = DateTime.Now;
        }
    }
}
