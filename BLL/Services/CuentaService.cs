using BLL.Interface;
using DAL.Factory;
using DAL.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace BLL.Services
{
    public  class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepo;

        public CuentaService()
        {
            // Devuelve una instancia de la clase CuentaRepository
            _cuentaRepo = RepositoryFactory.CuentaRepository();
        }

        public Cuenta BuscarPorCBU(string cbu)
        {
            return _cuentaRepo.GetByCBU(cbu);
        }

        public Cuenta BuscarPorTag(string tag) 
        {
            return _cuentaRepo.GetByTag(tag);
        }

        public void CrearCuenta(Cuenta cuenta, Cliente cliente)
        {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));

            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            // Asignar cliente como titular
            cuenta.Titular = cliente;

            // Validaciones según tipo de cuenta
            if (cuenta is CajaAhorro ca)
            {
                if (string.IsNullOrWhiteSpace(ca.CUIT) || string.IsNullOrWhiteSpace(ca.CBU) || string.IsNullOrWhiteSpace(ca.Alias))
                    throw new ArgumentException("CUIT, CBU y Alias son obligatorios para Caja de Ahorro.");

                if (ca.Saldo < 0)
                    throw new ArgumentException("El saldo no puede ser negativo.");
            }
            else if (cuenta is WalletBTC wbtc)
            {
                if (string.IsNullOrWhiteSpace(wbtc.Direccion))
                    throw new ArgumentException("El Address es obligatorio para la Wallet BTC.");

                if (wbtc.Saldo < 0)
                    throw new ArgumentException("El saldo en BTC no puede ser negativo.");
            }

            // Guardar cuenta
            _cuentaRepo.Add(cuenta);
            //Console.WriteLine($"[BLL] Cuenta creada con éxito para el cliente {cliente.Nombre}.");

        }
        public void Depositar(Cuenta cuenta, decimal monto)
        {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));
            if (monto <= 0)
                throw new ArgumentException("El monto a depositar debe ser mayor que cero.");
            
            // Validar si la cuenta es de tipo CajaAhorro o WalletBTC
            if (cuenta is CajaAhorro ca)
            {
                ca.Saldo += monto;
                _cuentaRepo.Update(ca);
            }
            else if (cuenta is WalletBTC wbtc)
            {
                wbtc.Saldo += monto;
                _cuentaRepo.Update(wbtc);
            }
            else
            {
                throw new InvalidOperationException("Tipo de cuenta no soportado.");
            }
            Console.WriteLine($"[BLL] Depósito realizado con éxito. Nuevo saldo: {cuenta.Saldo}.");

        }
    }
}
