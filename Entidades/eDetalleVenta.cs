namespace Entidades {
    public class eDetalleVenta {
        //public int idDetalleVenta { get; set; }
        public int idVenta{ get; set; }
        public string codigoProducto { get; set; }
        public int cantidad { get; set; }
        public decimal PUnitario { get; set; }
        public decimal total { get; set; }
        public eDetalleVenta() { }
        public eDetalleVenta(int idVenta, string codigoProducto, int cantidad, decimal pUnitario, decimal total) {
            this.idVenta = idVenta;
            this.codigoProducto = codigoProducto;
            this.cantidad = cantidad;
            this.PUnitario = pUnitario;
            this.total = total;
        }
    }
}
