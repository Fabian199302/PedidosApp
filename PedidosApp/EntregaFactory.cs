using System;

namespace PedidosApp
{
    public static class EntregaFactory
    {
        public static IMetodoEntrega CrearEntrega(string tipoProducto, bool urgente, double peso)
        {
            // Primero verificar la nueva regla de bicicleta
            if (tipoProducto == "accesorio" && peso < 2 && !urgente)
                return new EntregaBicicleta();

            // Luego las reglas originales
            if (tipoProducto == "tecnología" && urgente)
                return new EntregaDron();

            if (tipoProducto == "accesorio")
                return new EntregaMoto();

            if (tipoProducto == "componente" || peso > 10)
                return new EntregaCamion();

            // Valor por defecto
            return new EntregaMoto();
        }
    }
}

