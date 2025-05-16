using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.Factory;
using DAL.Interface;

namespace BLL.Services
{
    public class OperacionesServices : IOperacionesServices
    {

        private readonly IOperacionesRepository _repository;

        public OperacionesServices()
        {
            _repository = FactoryDao.OperacionesRepository();
        }

        public void Add(object CajaAhorro)
        {
            return 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
