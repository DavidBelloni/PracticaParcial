using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Implementation.Memory
{
    public class OperacionesRepository : IOperacionesRepository
    {
        private List<OperacionesRepository> _list;

        #region singleton
        private readonly static OperacionesRepository _instance = new OperacionesRepository();

        public static OperacionesRepository Current
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
    }
}
