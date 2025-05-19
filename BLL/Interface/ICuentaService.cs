using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum;

namespace BLL.Interface
{
    public interface ICuentaService
    {
        // Crear Cuenta
        void CrearCuenta(Cuenta cuenta, Cliente cliente);
        void Depositar(Cuenta cuenta, decimal monto);

        //void Extraer(Cuenta cuenta, decimal monto);
        //void Transferir(Cuenta origen, Cuenta destino, decimal monto);
        //void ConvertirPesosABtc(CajaAhorro origenPesos, WalletBTC destinoBtc, decimal montoPesos);
    }
}
