using System;
using System.Windows.Forms;
using Entidades;
using Negocio;
namespace Presentacion {
    public partial class frmCatalogo : Form {
        private nProducto nProducto = null;
        public frmCatalogo() {
            InitializeComponent();
            nProducto = new nProducto();
        }
        private void frmCatalogo_Load(object sender, EventArgs e) {
            ListViewItem item;
            if (nProducto.listarProductos() != null) {
                foreach (eProducto producto in nProducto.listarProductos()) {
                    item = new ListViewItem();
                    item = listView1.Items.Add(producto.nombreProducto);
                    item.SubItems.Add(producto.precioProducto.ToString());
                    item.SubItems.Add(producto.stockProducto.ToString());
                }
            } else {
                MessageBox.Show("No hay productos");
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
