using BLL.Interface;
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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepo;

        public ClienteService()
        {
            // Devuelve una instancia de la clase ClienteRepository
            _clienteRepo = RepositoryFactory.ClienteRepository();
        }

        public Cliente CrearCliente(string nombre)
        {
            var cliente = new Cliente
            {
                Nombre = nombre
            };

            // Agregar el cliente a la base de datos
            _clienteRepo.Add(cliente);
            return cliente;
        }

    }
}
