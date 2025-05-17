using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.Factory;
using DAL.Interface;
using Domain;
using static Domain.Enum;

namespace BLL.Services
{
    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRepository _operacionRepo;

        public OperacionService()
        {
            _operacionRepo = RepositoryFactory.OperacionRepository();
        }


        public void RegistrarOperacion(Guid origenId, Guid destinoId, decimal monto, TipoOperacion tipo)
        {
            var operacion = new Operacion
            {
                Origen = origenId,
                Destino = destinoId,
                Monto = monto,
                TipoOperacion = tipo,
                Fecha = DateTime.Now
            };
            _operacionRepo.Add(operacion);
        }

        public IEnumerable<Operacion> ListarOperacionesPorCuenta(Guid idCuenta)
        {
            return _operacionRepo.GetAll().Where(o =>
                (o.OrigenId.HasValue && o.OrigenId.Value == idCuenta) ||
                (o.DestinoId.HasValue && o.DestinoId.Value == idCuenta));
        }

        public IEnumerable<Operacion> ListarOperacionesPorCliente(Guid idCliente)
        {
            // Esta lógica depende de que puedas obtener las cuentas del cliente desde otro repository
            // Aquí se asume que el repositorio de operaciones solo conoce los idCuenta
            throw new NotImplementedException("Requiere acceso a las cuentas del cliente");
        }
    }
}
