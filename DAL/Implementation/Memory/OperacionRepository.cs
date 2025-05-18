using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Domain;

namespace DAL.Implementation.Memory
{
    public class OperacionRepository : IOperacionRepository
    {
        #region singleton

        // Singleton Instance
        private static OperacionRepository _instance;

        private static readonly object _lock = new object();

        // Lista persistente en memoria
        private readonly List<Operacion> _operaciones = new List<Operacion>();

        // Constructor privado para evitar instanciación externa
        private OperacionRepository() {}

        // Método para obtener la instancia única
        public static OperacionRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new OperacionRepository();
                    }
                }
                return _instance;
            }
        }
        #endregion

        public void Add(Operacion operacion)
        {
            _operaciones.Add(operacion);
        }

        public IEnumerable<Operacion> GetAll()
        {
            return _operaciones;
        }
    }
}
