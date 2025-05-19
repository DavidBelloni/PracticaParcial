using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICuentaRepository
    {
        void Add(Cuenta cuenta);
        void Update(Cuenta cuenta);
        Cuenta GetByCBU(string cbu);
        Cuenta GetByTag(string tag);
        Cuenta GetById(Guid idCuenta);
        IEnumerable<Cuenta> GetAll();
        IEnumerable<Cuenta> GetByClienteId(Guid idCliente);
    }
}
