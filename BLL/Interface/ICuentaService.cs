using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICuentaService
    {
        void Depositar(Cuenta cuenta, decimal monto);
        void Extraer(Cuenta cuenta, decimal monto);
        void Transferir(Cuenta origen, Cuenta destino, decimal monto);
        void ConvertirPesosABtc(CajaAhorro origenPesos, WalletBTC destinoBtc, decimal montoPesos);
    }
}
