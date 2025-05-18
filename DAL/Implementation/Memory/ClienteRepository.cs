using DAL.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Memory
{
    public class ClienteRepository : IClienteRepository
    {
        #region singleton

        // Singleton instance
        private static ClienteRepository _instance;

        private static readonly object _lock = new object();

        // Lista persistente en memoria
        private readonly List<Cliente> _clientes = new List<Cliente>();

        // Constructor privado para evitar instanciación externa
        private ClienteRepository() {}

        public static ClienteRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ClienteRepository();
                    }
                }
                return _instance;
            }
        }

        #endregion

        public void Add(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public Cliente GetById(Guid idCliente)
        {
            return _clientes.FirstOrDefault(c => c.IdCliente == idCliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clientes;
        }
    }
}
