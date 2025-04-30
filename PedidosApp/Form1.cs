using System;
using System.Linq;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Configuración inicial
            cmbProducto.Items.AddRange(new object[] { "tecnología", "accesorio", "componente" });
            cmbProducto.SelectedIndex = 0;

            cmbtipoentrega.Items.AddRange(new object[] { "Todos", "Bicicleta", "Dron", "Motocicleta", "Camión" });
            cmbtipoentrega.SelectedIndex = 0;

            nudPeso.DecimalPlaces = 2;
            nudPeso.Increment = 0.1m;
            nudDistancia.Minimum = 1;

            ConfigurarDataGrid();
            ActualizarDataGrid();
        }

        private void ConfigurarDataGrid()
        {
            dataGridViewpedido.AutoGenerateColumns = false;
            dataGridViewpedido.Columns.Clear();

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Producto",
                DataPropertyName = "Producto",
                Width = 100
            });

            dataGridViewpedido.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Urgente",
                DataPropertyName = "Urgente",
                Width = 70
            });

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Peso (kg)",
                DataPropertyName = "Peso",
                Width = 80
            });

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Distancia (km)",
                DataPropertyName = "Distancia",
                Width = 100
            });

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Método Entrega",
                DataPropertyName = "MetodoEntrega",
                Width = 120
            });

            dataGridViewpedido.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Costo",
                DataPropertyName = "Costo",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
        }

        private void ActualizarDataGrid(string filtro = "Todos")
        {
            var pedidos = RegistroPedidos.Instancia.Pedidos;

            var pedidosFiltrados = (filtro == "Todos")
                ? pedidos
                : pedidos.Where(p => p.MetodoEntrega.TipoEntrega() == filtro).ToList();

            dataGridViewpedido.DataSource = pedidosFiltrados.Select(p => new
            {
                p.Cliente,
                p.Producto,
                p.Urgente,
                Peso = $"{p.Peso:0.00} kg",
                Distancia = $"{p.Distancia} km",
                MetodoEntrega = p.MetodoEntrega.TipoEntrega(),
                Costo = p.ObtenerCosto()
            }).ToList();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCliente.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el nombre del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pedido = new Pedido(
                    txtCliente.Text.Trim(),
                    cmbProducto.SelectedItem.ToString(),
                    chkUrgente.Checked,
                    Convert.ToDouble(nudPeso.Value),
                    Convert.ToInt32(nudDistancia.Value)
                );

                RegistroPedidos.Instancia.AgregarPedido(pedido);
                lblResultado.Text = $"Entrega: {pedido.MetodoEntrega.TipoEntrega()}\nCosto: {pedido.ObtenerCosto():C2}";
                lblResultado.ForeColor = System.Drawing.Color.DarkGreen;

                ActualizarDataGrid(); // Mostrar todos los pedidos
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al procesar el pedido";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón Historial (¡IMPORTANTE! Verificar que esté vinculado)
        private void buttonHistorial_Click(object sender, EventArgs e)
        {
            if (cmbtipoentrega.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un método de entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarDataGrid(cmbtipoentrega.SelectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código adicional si es necesario
        }
    }
}