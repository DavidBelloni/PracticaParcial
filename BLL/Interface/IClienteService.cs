using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace BLL.Interface
{
    public interface IClienteService
    {
        // Crear un nuevo Cliente
        Cliente CrearCliente(string nombre);
    }
}
