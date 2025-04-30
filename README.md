Explicación Programa 

Gestión de Pedidos – TechExpress

Fabian Montoya

Enlace
https://github.com/Fabian199302/PedidosApp

## Funcionamiento del Sistema
Esta aplicación permite gestionar pedidos en una tienda virtual, asignando automáticamente un método de entrega según reglas de negocio. Utiliza:
- **Patrón Strategy**: Para definir diferentes métodos de entrega (`Dron`, `Motocicleta`, `Camión`).
- **Patrón Factory Method**: Para crear la estrategia de entrega según el tipo de producto, urgencia y peso.
- **Singleton**: Para mantener un registro único de todos los pedidos.
- **Principios SOLID**: Desacoplamiento, extensibilidad y responsabilidad única.

Flujo de la Aplicación:
1. **Ingreso de Datos**:
   - Cliente, tipo de producto, urgencia, peso y distancia.
2. **Cálculo de Entrega**:
   - La fábrica (`EntregaFactory`) selecciona el método de entrega según reglas:
     - Tecnología + Urgente → Dron ($20/km).
     - Accesorio → Motocicleta ($10/km).
     - Componente o peso >10kg → Camión ($5/km).
3. **Resultado**:
   - Muestra el método de entrega y costo total en la interfaz.
4. **Registro**:
   - Todos los pedidos se guardan en `RegistroPedidos` (Singleton).
________________________________________
Respuestas a las Preguntas de Comprensión:
1.	¿Qué ventaja ofrece usar una interfaz en lugar de una clase concreta?
o	Desacoplamiento: El código cliente (como Pedido) no depende de implementaciones específicas.
o	Extensibilidad: Permite añadir nuevas estrategias (ej: Bicicleta) sin modificar código existente.
2.	¿Por qué separamos la lógica de selección de entrega del objeto Pedido?
o	Para cumplir con el Principio de Responsabilidad Única (SOLID): El Pedido se encarga de datos del pedido, mientras EntregaFactory maneja la lógica de selección.
3.	¿Cuál de los principios SOLID consideras más importante en este ejercicio? ¿Por qué?
o	Open/Closed Principle (Principio Abierto/Cerrado): El sistema permite agregar nuevas estrategias (ej: Bicicleta) sin modificar clases existentes (como Pedido o EntregaFactory).
4.	Si se quiere añadir una entrega por "bicicleta" para pedidos ecológicos, ¿qué clases cambiarías?
o	Clases a modificar:
1.	Crear EntregaBicicleta (implementa IMetodoEntrega).
2.	Modificar EntregaFactory para incluir la condición (ej: si es ecológico → Bicicleta).
5.	¿Cómo favorece el uso de estos patrones el mantenimiento del sistema?
o	Strategy: Facilita cambiar algoritmos (cálculo de costo) sin afectar otros componentes.
o	Factory Method: Centraliza la creación de objetos, reduciendo acoplamiento.
o	Singleton: Garantiza un único punto de acceso al registro de pedidos.
6.	¿En qué casos reales usarías el patrón Singleton?
o	Ejemplos:
	Registro global de configuraciones.
	Conexión a bases de datos.
	Logging de eventos en una aplicación.

Pantallazos
 


 
 
 
Pantallazo evolución 2

 
 
 

 

