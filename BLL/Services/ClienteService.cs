using DAL.Factory;
using DAL.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly ICuentaRepository _cuentaRepo;

        public ClienteService()
        {
            // Devuelve una instancia de la clase ClienteRepository
            _clienteRepo = RepositoryFactory.ClienteRepository();
            _cuentaRepo = RepositoryFactory.CuentaRepository();
        }

        public Cliente CrearCliente(string nombre)
        {
            var cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nombre = nombre
            };
            _clienteRepo.Add(cliente);
            return cliente;
        }


        public IEnumerable<Cliente> ObtenerTodos()
        {
            return _clienteRepo.GetAll();
        }

    }
}
