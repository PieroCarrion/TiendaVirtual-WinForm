using System;
using System.Windows.Forms;

namespace Presentacion {
    public partial class frmCompraFinalizada : Form {
        public frmCompraFinalizada() {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e) {
            Form1.clienteSesion = null;
            Form1.sesion = false;
            Close();
        }
        private void button1_Click(object sender, EventArgs e) {
            Form1.sesion = true;
            Close();
        }
    }
}
