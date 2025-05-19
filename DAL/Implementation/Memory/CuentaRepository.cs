using DAL.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Memory
{
    public class CuentaRepository : ICuentaRepository
    {
        #region singleton

        // Singleton instance
        private static CuentaRepository _instance;

        private static readonly object _lock = new object();

        // Lista persistente en memoria
        private readonly List<Cuenta> _cuentas = new List<Cuenta>();

        // Constructor privado para evitar instanciación externa
        private CuentaRepository() {}

        public static CuentaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new CuentaRepository();
                    }
                }
                return _instance;
            }
        }
        #endregion

        public void Add(Cuenta cuenta)
        {
            _cuentas.Add(cuenta);
        }

        public void Update(Cuenta cuenta)
        {
            if (cuenta == null)
                throw new ArgumentNullException(nameof(cuenta));

            // Buscar la cuenta existente por IdCuenta
            var existente = _cuentas.FirstOrDefault(c => c.IdCuenta == cuenta.IdCuenta);

            if (existente == null)
                throw new InvalidOperationException("La cuenta no existe en el repositorio.");

            // Actualizar propiedades principales
            existente.Saldo = cuenta.Saldo;
            //existente.Titular = cuenta.Titular;
            //existente.FechaCreacion = cuenta.FechaCreacion;
            //existente.TipoCuenta = cuenta.TipoCuenta;

            // Actualizar propiedades específicas según el tipo
            if (existente is CajaAhorro caExistente && cuenta is CajaAhorro caNueva)
            {
                caExistente.CBU = caNueva.CBU;
                caExistente.Alias = caNueva.Alias;
                caExistente.CUIT = caNueva.CUIT;
            }
            else if (existente is WalletBTC wbExistente && cuenta is WalletBTC wbNueva)
            {
                wbExistente.Direccion = wbNueva.Direccion;
                wbExistente.Tag = wbNueva.Tag;
            }
        }
        public Cuenta GetByCBU(string cbu)
        {
            return _cuentas.OfType<CajaAhorro>().FirstOrDefault(c => c.CBU == cbu);
        }

        public Cuenta GetByTag(string tag)
        {
            return _cuentas.OfType<WalletBTC>().FirstOrDefault(w => w.Tag == tag);
        }

        public Cuenta GetById(Guid idCuenta)
        {
            return _cuentas.FirstOrDefault(c => c.IdCuenta == idCuenta);
        }

        public IEnumerable<Cuenta> GetAll()
        {
            return _cuentas;
        }

        public IEnumerable<Cuenta> GetByClienteId(Guid idCliente)
        {
            return _cuentas.Where(c => c.Titular != null && c.Titular.IdCliente == idCliente);
        }
    }
}
