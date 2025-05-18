using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BLL.Services;
using BLL.Interface;
using static Domain.Enum;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IClienteService clienteService = new ClienteService();
            ICuentaService cuentaService = new CuentaService();

            // Registrar Cliente 
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombre = Console.ReadLine();
            // Crear cliente
            Cliente cliente = clienteService.CrearCliente(nombre);
            // Mostrar mensaje de éxito
            Console.WriteLine($"Cliente creado con éxito. ID: {cliente.IdCliente}, Nombre: {cliente.Nombre}");
            // Crear Cuenta
            Console.WriteLine("Ingrese el tipo de cuenta a crear (0=CA, 1=BTC): "); //TipoCuenta es un Enum
            int tipoCuenta = int.Parse(Console.ReadLine());
            // Si cuenta es 0 pedir datos CUIT, CBU, Alias
            if (tipoCuenta == 0)
            {
                var cuenta = new CajaAhorro();
                {
                    Console.WriteLine("Ingrese el CUIT:");
                    cuenta.CUIT = Console.ReadLine();
                    Console.WriteLine("Ingrese el CBU:");
                    cuenta.CBU = Console.ReadLine();
                    Console.WriteLine("Ingrese el Alias:");
                    cuenta.Alias = Console.ReadLine();
                    Console.WriteLine("Ingrese el Saldo Inicial: ");
                    cuenta.Saldo = decimal.Parse(Console.ReadLine());
                }
                // Crear cuenta
                cuentaService.CrearCuenta(cuenta, cliente);
            }
            else
            {
                var cuenta = new WalletBTC();
                Console.WriteLine("Ingrese el Tag:");
                string idBilletera = Console.ReadLine();
                cuentaService.CrearCuenta(cuenta, cliente);
            }






        }
    }
}
