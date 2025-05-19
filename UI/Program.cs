using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BLL.Services;
using BLL.Interface;
using static Domain.Enum;
using System.ComponentModel.Design;

namespace UI
{
    class Program
    {

        static void Main(string[] args)
        {
            IClienteService clienteService = new ClienteService();
            ICuentaService cuentaService = new CuentaService();
            Cliente cliente = null;
            //Cuenta cuentaDestino = null;

            bool salir = false;
            while (!salir)
            {
                // Menú
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Crear Cuenta");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Convertir Pesos a BTC");
                Console.WriteLine("6. Convertir BTC a Pesos");
                Console.WriteLine("7. Salir");

                // Leer opción
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        // Registrar Cliente
                        Console.WriteLine("Ingrese el nombre del cliente:");
                        string nombre = Console.ReadLine();
                        cliente = clienteService.CrearCliente(nombre);
                        Console.WriteLine($"Cliente creado con éxito. ID: {cliente.IdCliente}, Nombre: {cliente.Nombre}");
                        break;
                    case 2:
                        // Crear Cuenta
                        Console.WriteLine("Ingrese el tipo de cuenta a crear (0=CA, 1=BTC): ");
                        int tipoCuenta = int.Parse(Console.ReadLine());
                        if (tipoCuenta == 0)
                        {
                            var cuenta = new CajaAhorro();
                            Console.WriteLine("Ingrese el CUIT:");
                            cuenta.CUIT = Console.ReadLine();
                            Console.WriteLine("Ingrese el Alias:");
                            cuenta.Alias = Console.ReadLine();
                            cuentaService.CrearCuenta(cuenta, cliente);
                            Console.WriteLine($"Cuenta de Caja de Ahorro creada con éxito para el cliente {cliente.Nombre}. CBU: {cuenta.CBU}, Alias: {cuenta.Alias}");
                        }
                        else
                        {
                            var cuenta = new WalletBTC();
                            Console.WriteLine("Ingrese el Tag de la Wallet BTC:");
                            cuenta.Tag = Console.ReadLine();
                            cuentaService.CrearCuenta(cuenta, cliente);
                            Console.WriteLine($"Wallet BTC creada con éxito para el cliente {cliente.Nombre}. Dirección: {cuenta.Direccion}, Tag: {cuenta.Tag}");
                        }
                        break;
                    case 3:
                        // Depositar
                        Console.WriteLine("Seleccione el tipo de cuenta Destino (0=CA, 1=BTC): ");
                        int tipoCuentaDestino = int.Parse(Console.ReadLine());
                        // Solicitar CBU o Dirección
                        if (tipoCuentaDestino == 0)
                        {
                            var cuentaDestino = new CajaAhorro();
                            Console.WriteLine("Ingrese el CBU de la cuenta de destino:");
                            cuentaDestino.CBU = Console.ReadLine();
                            Console.WriteLine("Ingrese el monto a depositar: ");
                            decimal montoDeposito;
                            if (!decimal.TryParse(Console.ReadLine(), out montoDeposito) || montoDeposito <= 0)
                            {
                                Console.WriteLine("Monto no válido.");
                                continue;
                            }
                            cuentaService.Depositar(cuentaDestino, montoDeposito);
                            // Mensaje de exito
                            Console.WriteLine($"Se han depositado {montoDeposito} en la cuenta de Caja de Ahorro con CBU: {cuentaDestino.CBU}");
                        }
                        else
                        {
                            var cuentaDestino = new WalletBTC();
                            Console.WriteLine("Ingrese el Tag de la Wallet BTC de destino:");
                            cuentaDestino.Tag = Console.ReadLine();
                            Console.WriteLine("Ingrese el monto a depositar: ");
                            decimal montoDeposito;
                            if (!decimal.TryParse(Console.ReadLine(), out montoDeposito) || montoDeposito <= 0)
                            {
                                Console.WriteLine("Monto no válido.");
                                continue;
                            }
                            cuentaService.Depositar(cuentaDestino, montoDeposito);
                            // Mensaje de exito
                            Console.WriteLine($"Se han depositado {montoDeposito} en la Wallet BTC con dirección: {cuentaDestino.Direccion}");
                        }
                        break;
                    case 4:
                        // Transferir
                        break;
                    case 5:
                        // Convertir Pesos a BTC
                        break;
                    case 6:
                        // Convertir BTC a Pesos
                        break;
                    case 7:
                        // Salir
                        salir = true;
                        // Despedida
                        Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.WriteLine(); // Línea en blanco para separar iteraciones
            }
        }
    }
}
