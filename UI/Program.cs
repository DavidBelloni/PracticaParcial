using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BLL.Services;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia desde la BLL
            var cuenta1 = new OperacionesServices();
            var cuenta2 = new OperacionesServices();    

            cuenta1.Add(new CajaAhorro { Alias = "Caja de Ahorro", saldo = 1000, CBU= 1001.ToString(), CUIT= 20002.ToString() });
            cuenta2.Add(new CajaAhorro { Alias = "Caja de Ahorro2", saldo = 2000, CBU = 2002.ToString(), CUIT = 30003.ToString() });
            
          
        }
    }
}
