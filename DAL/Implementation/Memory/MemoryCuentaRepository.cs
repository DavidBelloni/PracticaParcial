using DAL.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Memory
{
    public class MemoryCuentaRepository : ICuentaRepository
    {
        #region singleton

        // Singleton instance
        private static MemoryCuentaRepository _instance;

        private static readonly object _lock = new object();

        // Lista persistente en memoria
        private readonly List<Cuenta> _cuentas = new List<Cuenta>();

        // Constructor privado para evitar instanciación externa
        private MemoryCuentaRepository() {}

        public static MemoryCuentaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new MemoryCuentaRepository();
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
            var existingCuenta = GetById(cuenta.IdCuenta);
            if (existingCuenta != null)
            {
                existingCuenta.Saldo = cuenta.Saldo;
                existingCuenta.FechaCreacion = cuenta.FechaCreacion;
                existingCuenta.TipoCuenta = cuenta.TipoCuenta;
                existingCuenta.Titular = cuenta.Titular;
            }
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
