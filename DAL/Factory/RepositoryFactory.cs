using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Factory
{
    public class RepositoryFactory
    {
        private static int backendType;

        static RepositoryFactory()
        {
            backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);
        }

        public static ICuentaRepository CuentaRepository()
        {
            if (backendType == (int)BackendType.Memory)
                return DAL.Implementation.Memory.CuentaRepository.Instance;
            else
                throw new Exception("PROBLEMAS");
        }



        public static IClienteRepository ClienteRepository()
        {
            if (backendType == (int)BackendType.Memory)
                return DAL.Implementation.Memory.ClienteRepository.Instance;
            else
                throw new Exception("PROBLEMAS");
        }


        public static IOperacionRepository OperacionRepository()
        {
            if (backendType == (int)BackendType.Memory)
                return DAL.Implementation.Memory.OperacionRepository.Instance;
           
            else
                return DAL.Implementation.SqlServer.OperacionesRepository.Instance;
            
            throw new Exception("PROBLEMAS");
        }

    }


    internal enum BackendType
    {
        Memory,
        SqlServer
    }

}
