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
        private readonly IOperacionService _operacionService;

        public CuentaService()
        {
            // Devuelve una instancia de la clase CuentaRepository
            _cuentaRepo = RepositoryFactory.CuentaRepository();
        }


        public void Depositar(Cuenta cuenta, decimal monto)
        {
            if (cuenta == null) throw new ArgumentNullException(nameof(cuenta));
            if (monto <= 0) throw new ArgumentException("El monto debe ser positivo");

            cuenta.Saldo += monto;
            _cuentaRepo.Update(cuenta);
            _operacionService.RegistrarOperacion(cuenta.IdCuenta, monto, TipoOperacion.Deposito);
        }

        public void Extraer(Cuenta cuenta, decimal monto)
        {
            if (cuenta == null) throw new ArgumentNullException(nameof(cuenta));
            if (monto <= 0) throw new ArgumentException("El monto debe ser positivo");
            if (cuenta.saldo < monto) throw new InvalidOperationException("Saldo insuficiente");

            cuenta.saldo -= monto;
            _cuentaRepo.Update(cuenta);
            _operacionService.RegistrarOperacion(cuenta.idCuenta, null, monto, TipoOperacion.Extraccion);
        }

        public void Transferir(Cuenta origen, Cuenta destino, decimal monto)
        {
            if (origen == null || destino == null)
                throw new ArgumentNullException("Las cuentas no pueden ser nulas");
            if (monto <= 0) throw new ArgumentException("El monto debe ser positivo");
            if (origen.Saldo < monto) throw new InvalidOperationException("Saldo insuficiente en la cuenta origen.");

            origen.Saldo -= monto;
            destino.Ssaldo += monto;
            _cuentaRepo.Update(origen);
            _cuentaRepo.Update(destino);
            _operacionService.RegistrarOperacion(origen.idCuenta, destino.idCuenta, monto, TipoOperacion.Transferencia);
        }

        public void ConvertirPesosABtc(CajaAhorro origenPesos, WalletBTC destinoBtc, decimal montoPesos)
        {
            if (origenPesos == null || destinoBtc == null)
                throw new ArgumentNullException("Las cuentas no pueden ser nulas");
            if (montoPesos <= 0) throw new ArgumentException("El monto debe ser positivo");
            if (origenPesos.Saldo < montoPesos) throw new InvalidOperationException("Saldo insuficiente en la caja de ahorro.");

            // Por simplicidad: 1 BTC = 1000 $
            decimal montoBtc = montoPesos / 1000m;
            origenPesos.Saldo -= montoPesos;
            destinoBtc.Saldo += montoBtc;
            _cuentaRepo.Update(origenPesos);
            _cuentaRepo.Update(destinoBtc);
            _operacionService.RegistrarOperacion(origenPesos.idCuenta, destinoBtc.idCuenta, montoPesos, TipoOperacion.Conversion);
        }
    }
}
