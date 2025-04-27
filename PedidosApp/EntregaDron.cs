using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public class EntregaDron : IMetodoEntrega
    {
        public double CalcularCosto(int km) => 20 * km;
        public string TipoEntrega() => "Dron";
    }
    public class EntregaMoto : IMetodoEntrega
    {
        public double CalcularCosto(int km) => 10 * km;
        public string TipoEntrega() => "Motocicleta";
    }
    public class EntregaCamion : IMetodoEntrega
    {
        public double CalcularCosto(int km) => 5 * km;
        public string TipoEntrega() => "Camión";
    }
}

