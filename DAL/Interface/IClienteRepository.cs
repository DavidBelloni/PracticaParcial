using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        Cliente GetById(Guid idCliente);
        IEnumerable<Cliente> GetAll();
    }
}
