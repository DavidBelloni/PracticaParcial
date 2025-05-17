using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Domain;

namespace DAL.Implementation.SqlServer
{
    public class OperacionesRepository : IOperacionRepository
    {
        private List<OperacionesRepository> _list;

        #region singleton
        private readonly static OperacionesRepository _instance = new OperacionesRepository();

        public static OperacionesRepository Instance
        {
            get
            {
                return _instance;
            }
        }

        private OperacionesRepository()
        {
            _list = new List<OperacionesRepository>();
        }
        #endregion

        public void Add(Operacion operacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacion> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
