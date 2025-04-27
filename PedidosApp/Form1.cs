using System;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Configurar controles al iniciar
            cmbProducto.Items.AddRange(new object[] { "tecnología", "accesorio", "componente" });
            cmbProducto.SelectedIndex = 0; // Selecciona "tecnología" por defecto

            // Configurar NumericUpDowns
            nudPeso.DecimalPlaces = 2;
            nudPeso.Increment = 0.1m;
            nudDistancia.Minimum = 1;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrEmpty(txtCliente.Text))
                {
                    MessageBox.Show("Ingrese el nombre del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProducto.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener valores del formulario
                string cliente = txtCliente.Text;
                string producto = cmbProducto.SelectedItem.ToString();
                bool urgente = chkUrgente.Checked;
                double peso = Convert.ToDouble(nudPeso.Value);
                int distancia = Convert.ToInt32(nudDistancia.Value);

                // Crear pedido
                Pedido pedido = new Pedido(cliente, producto, urgente, peso, distancia);

                // Registrar pedido
                RegistroPedidos.Instancia.AgregarPedido(pedido);

                // Mostrar resultado
                lblResultado.Text = $"Entrega: {pedido.MetodoEntrega.TipoEntrega()}\n" +
                                    $"Costo: ${pedido.ObtenerCosto():0.00}";
                lblResultado.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al calcular el pedido.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}