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
        void RegistrarOperacion(Guid origenId, Guid destinoId, decimal monto, TipoOperacion tipo);
        IEnumerable<Operacion> ListarOperacionesPorCuenta(Guid idCuenta);
        IEnumerable<Operacion> ListarOperacionesPorCliente(Guid idCliente);
    }
}
