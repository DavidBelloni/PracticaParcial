using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Factory
{
    public class FactoryDao
    {
        private static int backendType;

        static FactoryDao()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        public static IOperacionesRepository OperacionesRepository()
        {
            if (backendType == (int)BackendType.Memory)
                return DAL.Implementation.Memory.OperacionesRepository.Current;
           
            else
                return DAL.Implementation.SqlServer.OperacionesRepository.Current;
            
            throw new Exception("PROBLEMAS");
        }

        public static IOperacionesRepository operacionesRepository()
        {
            if (backendType == (int)BackendType.SqlServer)
                return DAL.Implementation.Memory.OperacionesRepository.Current;

            else
                return DAL.Implementation.SqlServer.OperacionesRepository.Current;

            throw new Exception("PROBLEMAS");
        }

    }


    internal enum BackendType
    {
        Memory,
        SqlServer
    }

}
